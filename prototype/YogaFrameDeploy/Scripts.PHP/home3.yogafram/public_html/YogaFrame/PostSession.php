<?php

require_once ('./Util.php');

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

//
// Object representation of client-submitted payload
//
class TblSession
{
    public $GuidSession;
    public $IdtblMembers;
    public $DtLastHeartBeat;
}

class Sessions
{
    public $TblSession;
    
    public static function CreateInstanceFromJson($deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Sessions
        //
        $arraySource = $deserializedPhpObjectFromJson->tbl_Sessions;
        $sessions = new Sessions();
        $sessions->TblSession = array( new TblSession() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $sessions->TblSession[$i]->GuidSession     = $arraySource[$i]->guidSession;
            $sessions->TblSession[$i]->IdtblMembers    = $arraySource[$i]->idtblMembers;
            $sessions->TblSession[$i]->DtLastHeartBeat = $arraySource[$i]->dtLastHeartBeat;
        }
        
        return $sessions;
    }
}

?>
