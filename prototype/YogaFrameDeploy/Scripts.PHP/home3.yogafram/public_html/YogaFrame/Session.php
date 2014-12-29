<?php

require_once ('./Util.php');
require_once ('./Sessions.php');
require_once ('./Members.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom Sessions object
// - Call stored procedure, passing Sessions instance fields as input
//
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
if (null != $deserializedPhpObjectFromJson)
{
    $sessions = Sessions::CreateInstanceFromJson($deserializedPhpObjectFromJson);
}
else
{
    Trace::WriteLineFailure("Session.php: Failure: null object returned from json_decode.");
}

class Session
{
    public static function ProcessRequest($sessions)
    {
        $fResult = false;
        
        $valColNameAlias        = $members->TblMember[0]->ColNameAlias;
        $valColNameFirst        = $members->TblMember[0]->ColNameFirst;
        $valColNameLast         = $members->TblMember[0]->ColNameLast;
        $valColEmailAddress     = $members->TblMember[0]->ColEmailAddress;
        $valColPasswordSaltHash = $members->TblMember[0]->ColPasswordSaltHash;
        $valColBio              = $members->TblMember[0]->ColBio;
        
        $dispatch = $members->Dispatch;
        
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
                $dispatchFailure = new Dispatch();
                $dispatchFailure->Message = "PostMemberHelper::ProcessRequest: Invalid request: " . $dispatch->Message;
                Trace::WriteDispatchFailure($dispatchFailure);
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
                $dispatch = new Dispatch();
                $dispatch->Message = "Session::MemberSignUp: Call to PostMemberHelper::PostMember() failed.";
                Trace::WriteDispatchFailure($dispatch);
            }
        }
        else
        {
            $fResult = false;
            $dispatch = new Dispatch();
            $dispatch->Message = "Your password is weak.";
            Trace::WriteDispatchFailure($dispatch);
        }

        return $fResult;
    }
}

?>
