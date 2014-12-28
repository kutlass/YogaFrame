﻿<?php

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
