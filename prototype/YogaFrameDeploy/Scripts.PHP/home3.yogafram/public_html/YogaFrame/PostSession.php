<?php

require_once ('./Util.php');
require_once ('./Sessions.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom Sessions object
// - Call stored procedure, passing Sessions instance fields as input
//
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
if (null != $deserializedPhpObjectFromJson)
{
    $sessions = Sessions::CreateInstanceFromJson($deserializedPhpObjectFromJson);
    
    $valGuidSession      = $sessions->TblSession[0]->GuidSession;
    $valIdtblMembers     = $sessions->TblSession[0]->IdtblMembers;
    $valDtLastHeartBeat  = $sessions->TblSession[0]->DtLastHeartBeat;

    $strQuery =
        "CALL PostSession(" .
        "'"                 . $valGuidSession      . "'," .
        "'"                 . $valIdtblMembers     . "'," .
        "'"                 . $valDtLastHeartBeat  . "'"  .
        ")";
    
    $mysqli = Util::YogaConnect();
    if (null != $mysqli)
    {
        $fResult = false;
        $fResult = Util::ExecuteQuery($mysqli, $strQuery);
        if (true != $fResult)
        {
            Trace::WriteLineFailure("PostSession.php: Failed to call the stored procedure.");
        }
        
        $mysqli->close();
    }
}
else
{
    Trace::WriteLineFailure("PostSession.php: Failure: null object returned from json_decode.");
}

?>
