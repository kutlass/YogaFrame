<?php

require_once ('./Util.php');
require_once ('./PostSession.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom Sessions object
// - Call stored procedure, passing Sessions instance fields as input
//
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
if (null != $deserializedPhpObjectFromJson)
{
    var_dump($deserializedPhpObjectFromJson);
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
        
    }
}

?>
