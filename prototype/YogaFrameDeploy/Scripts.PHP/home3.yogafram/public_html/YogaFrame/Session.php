<?php

require_once ('./Util.php');
require_once ('./JSession.php');
require_once ('./Dispatch.php');
require_once ('./Sessions.php');
require_once ('./PostSession.php');
require_once ('./Members.php');
require_once ('./PostMember.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom JSession object
// - Call ProcessRequest, passing JSession instance as input
//
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
if (null != $deserializedPhpObjectFromJson)
{
    $jSession = JSession::CreateInstanceFromJson($deserializedPhpObjectFromJson);
    if (null != $jSession)
    {
        $fResult = Session::ProcessRequest($jSession);
        if (true == $fResult)
        {
            $jSession = new JSession();
            $jSession->Dispatch = new Dispatch();
            $jSession->Dispatch->Message = "S_OK";
            Trace::RespondToClientWithSuccess($jSession);
        }
    }
}
else
{
    $dispatch = new Dispatch();
    $dispatch->Message = "Session.php: Failure: null object returned from json_decode.";
    Trace::WriteDispatchFailure($dispatch);
}

class Session
{
    public static function ProcessRequest($jSession)
    {
        $fResult = false;
        
        $dispatch = $jSession->Dispatch;
        $members  = $jSession->Members;
        $sessions = $jSession->Sessions;
        
        $valColNameAlias        = $members->TblMember[0]->ColNameAlias;
        $valColNameFirst        = $members->TblMember[0]->ColNameFirst;
        $valColNameLast         = $members->TblMember[0]->ColNameLast;
        $valColEmailAddress     = $members->TblMember[0]->ColEmailAddress;
        $valColPasswordSaltHash = $members->TblMember[0]->ColPasswordSaltHash;
        $valColBio              = $members->TblMember[0]->ColBio;
        
        $valGuidSession     = $sessions->GuidSession;
        $valIdTblMembers    = $sessions->IdtblMembers;
        $valDtLastHeartBeat = $sessions->DtLastHeartBeat;
        
        switch ($dispatch->Message)
        {
            case "POSTREQUEST_MEMBER_SIGN_IN":
                $fResult = Session::MemberSignIn(
                    $valColNameAlias,
                    $valColPasswordSaltHash
                    );
                break;
            case "POSTREQUEST_MEMBER_SIGN_UP":
                $fResult = Session::MemberSignUp(
                    $valColNameAlias,
                    $valColNameFirst,
                    $valColNameLast,
                    $valColEmailAddress,
                    $valColPasswordSaltHash,
                    $valColBio
                    );
                if (true == $fResult)
                {
                    $fResult = PostSessionHelper::PostSession(
                        $valGuidSession,
                        $valIdTblMembers,
                        $valDtLastHeartBeat
                        );
                }
                break;
            case "POSTREQUEST_SESSION_POSTMSESSION_RAW_PASSTHROUGH":
                $fResult = PostMemberHelper::PostMember(
                    $valColNameAlias,
                    $valColNameFirst,
                    $valColNameLast,
                    $valColEmailAddress,
                    $valColPasswordSaltHash,
                    $valColBio
                    );
                break;            
            default:
                $fResult = false;
                $jSession = new JSession();
                $jSession->Dispatch = new Dispatch();
                $jSession->Dispatch->Message = "Session::ProcessRequest: Invalid request: " . $dispatch->Message;
                Trace::RespondToClientWithFailure($jSession);
        }
        
        return $fResult;        
    }
    public static function MemberSignIn(
        $strUserName,
        $strPassword
    )
    {
        
    }
    public static function MemberSignUp(
        $strUserNameAlias,
        $strUserNameFirst,
        $strUserNameLast,
        $strEmailAddress,
        $strPassword
        )
    {
        $fResult = false;
        
        //
        // TODO: Here, prior to the call to PostMember, is where
        // we'll likely do a series of regular expression checks against
        // all the params submitted by the client.
        //
        if ( preg_match("/^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$/", $strPassword) )
        {
            $fResult = true;
            
            //
            // If we got here, the  password met Strong criteria:
            //  - password must be at least 8 characters AND
            //  - must contain at least one lower case letter AND
            //  - one upper case letter AND
            //  - one digit
            //
            $fResult = PostMemberHelper::PostMember(
                $strUserNameAlias,
                $strUserNameFirst,
                $strUserNameLast,
                $strEmailAddress,
                $strPassword,
                "No bio provided."
                );
            if (false == $fResult)
            {
                $jSession = new JSession();
                $jSession->Dispatch = new Dispatch();
                $jsession->Dispatch->Message = "Session::MemberSignUp: Call to PostMemberHelper::PostMember() failed.";
                Trace::RespondToClientWithFailure($jSession);
            }
        }
        else
        {
            $fResult = false;
            $jSession = new JSession();
            $jSession->Dispatch = new Dispatch();
            $jSession->Dispatch->Message = "Session::MemberSignUp: Your password is weak.";
            Trace::RespondToClientWithFailure($jSession);
        }

        return $fResult;
    }
}

?>
