<?php

require_once ('./Util.php');
require_once ('./JSession.php');
require_once ('./Dispatch.php');
require_once ('./Sessions.php');
require_once ('./PostSession.php');
require_once ('./Members.php');
require_once ('./PostMember.php');
require_once ('./GetMembers.php');
require_once ('./GetSessions.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom JSession object
// - Call ProcessRequest, passing JSession instance as input
//
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
if (null != $deserializedPhpObjectFromJson)
{
    //
    // See what the Client wanted
    //
    $jSessionRequest = JSession::CreateInstanceFromJson($deserializedPhpObjectFromJson);
    if (null != $jSessionRequest)
    {
        //
        // Initialize a server response utilizing a JSession.
        // Some of these allocations may be premature but we'll
        // investigate once more UX functionality is flowing
        //
        $jSessionResponse = new JSession();
        $jSessionResponse->Dispatch = new Dispatch();
        $jSessionResponse->Sessions = new Sessions();
        $jSessionResponse->Sessions->TblSessions = array( new TblSession() );
        $jSessionResponse->Members = new Members();
        $jSessionResponse->Members->TblMembers = array( new TblMember() );
        
        $fResult = Session::ProcessRequest($jSessionRequest, $jSessionResponse);
        if (true == $fResult)
        {
            $jSessionResponse->Dispatch->Message = "S_OK";
            Trace::RespondToClientWithSuccess($jSessionResponse);
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
    public static function ProcessRequest(&$jSessionRequest, &$jSessionResponse)
    {
        $fResult = false;
        
        //
        // Flatten out the hierarchy for readability during processing
        //
        $dispatch = $jSessionRequest->Dispatch;
        $members  = $jSessionRequest->Members;
        $sessions = $jSessionRequest->Sessions;
        
        $valColNameAlias        = $members->TblMembers[0]->ColNameAlias;
        $valColNameFirst        = $members->TblMembers[0]->ColNameFirst;
        $valColNameLast         = $members->TblMembers[0]->ColNameLast;
        $valColEmailAddress     = $members->TblMembers[0]->ColEmailAddress;
        $valColIsEmailVerified  = $members->TblMembers[0]->ColIsEmailVerified;        
        $valColPasswordSaltHash = $members->TblMembers[0]->ColPasswordSaltHash;
        $valColBio              = $members->TblMembers[0]->ColBio;
        $valColDtMemberSince    = $members->TblMembers[0]->ColDtMemberSince;
        
        $valGuidSession     = $sessions->TblSessions[0]->GuidSession;
        $valIdtblMembers    = $sessions->TblSessions[0]->IdtblMembers;
        $valDtLastHeartBeat = $sessions->TblSessions[0]->DtLastHeartBeat;
        
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
                    $jSessionResponse,
                    $valColNameAlias,
                    $valColNameFirst,
                    $valColNameLast,
                    $valColEmailAddress,
                    $valColPasswordSaltHash,
                    $valColBio
                    );
                break;
            case "POSTREQUEST_SESSION_POSTSESSION_RAW_PASSTHROUGH":
                $fResult = PostSessionHelper::PostSession(
                    $valGuidSession,
                    $valIdtblMembers,
                    $valDtLastHeartBeat
                    );
                break;
            case "POSTREQUEST_MEMBER_POSTMEMBER_RAW_PASSTHROUGH":
                $fResult = PostMemberHelper::PostMember(
                    $valColNameAlias,
                    $valColNameFirst,
                    $valColNameLast,
                    $valColEmailAddress,
                    $valColIsEmailVerified,
                    $valColPasswordSaltHash,
                    $valColBio,
                    $valColDtMemberSince
                    );
                break;
            case "GETREQUEST_MEMBER_GETMEMBERS":
                $fResult = GetMembersHelper::GetMembers(
                    $jSessionResponse->Members /*ref*/
                    );
                break;
            case "GETREQUEST_SESSION_GETSESSIONS":
                $fResult = GetSessionsHelper::GetSessions(
                    $jSessionResponse->Sessions /*ref*/
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
        &$jSessionOut,
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
            $strDtMemberSince = date('Y-m-d H:i:s');
            $fResult = PostMemberHelper::PostMember(
                $strUserNameAlias,
                $strUserNameFirst,
                $strUserNameLast,
                $strEmailAddress,
                "false",
                $strPassword,
                "No bio provided.",
                $strDtMemberSince
                );
            if (true == $fResult)
            {
                //
                // Successfully added a new user account! Now that we have that
                // under our belts, let's give him/her a new YogaFrame Session
                // token to facilitate their trods along our amusement park.
                //
                $sessionToken = new Sessions();
                $sessionToken->TblSessions = array( new TblSession() );
                $sessionToken->TblSessions[0]->GuidSession = Util::GenerateGuid();
                $sessionToken->TblSessions[0]->IdtblMembers = "17";
                $sessionToken->TblSessions[0]->DtLastHeartBeat = date('Y-m-d H:i:s');
                $fResult = PostSessionHelper::PostSession(
                    $sessionToken->TblSessions[0]->GuidSession,
                    $sessionToken->TblSessions[0]->IdtblMembers,
                    $sessionToken->TblSessions[0]->DtLastHeartBeat
                    );
                if (true == $fResult)
                {
                    //
                    // Temporary: Filling in the response payload so we can check
                    //            how it's looking on the client.
                    //
                    $jSessionOut->Members->TblMembers[0]->ColNameAlias = $strUserNameAlias;
                    $jSessionOut->Members->TblMembers[0]->ColNameFirst = $strUserNameFirst;
                    $jSessionOut->Members->TblMembers[0]->ColNameLast = $strUserNameLast;
                    $jSessionOut->Members->TblMembers[0]->ColEmailAddress = $strEmailAddress;
                    $jSessionOut->Sessions->TblSessions[0]->GuidSession = $sessionToken->TblSessions[0]->GuidSession;
                    $jSessionOut->Sessions->TblSessions[0]->IdtblMembers = $sessionToken->TblSessions[0]->IdtblMembers;
                    $jSessionOut->Sessions->TblSessions[0]->DtLastHeartBeat = $sessionToken->TblSessions[0]->DtLastHeartBeat;                  
                }
            }
            else
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
