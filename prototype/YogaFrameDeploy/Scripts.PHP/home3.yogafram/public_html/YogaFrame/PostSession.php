<?php

require_once ('./Util.php');
require_once ('./Sessions.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom Sessions object
// - Call stored procedure, passing Sessions instance fields as input
//
/*
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
if (null != $deserializedPhpObjectFromJson)
{
    $sessions = Sessions::CreateInstanceFromJson($deserializedPhpObjectFromJson);
    if (null != $sessions)
    {
        $fResult = false;
        $fResult = PostSessionHelper::ProcessRequest($sessions);
        if (false != $fResult)
        {
            $dispatch = new Dispatch();
            $dispatch->Message = "S_OK";
            Trace::WriteDispatchSuccess($dispatch);
        }
    }
}
else
{
    Trace::WriteLineFailure("PostSession.php: Failure: null object returned from json_decode.");
}
*/
class PostSessionHelper
{
    public static function ProcessRequest($sessions)
    {
        $fResult = false;
        //
        // No param validation performed at this layer, which
        // facilitates RAW_PASSTHROUGH requests
        //        
        $valGuidSession      = $sessions->TblSession[0]->GuidSession;
        $valIdtblMembers     = $sessions->TblSession[0]->IdtblMembers;
        $valDtLastHeartBeat  = $sessions->TblSession[0]->DtLastHeartBeat;
        
        $dispatch = $sessions->Dispatch;
        
        switch ($dispatch->Message)
        {
            case "POSTREQUEST_SESSION_POSTSESSION_RAW_PASSTHROUGH":
                $fResult = PostSessionHelper::PostSession(
                    $valGuidSession,
                    $valIdtblMembers,
                    $valDtLastHeartBeat
                    );
                break;            
            default:
                $fResult = false;
                $dispatchFailure = new Dispatch();
                $dispatchFailure->Message = "PostSessionHelper::ProcessRequest: Invalid request: " . $dispatch->Message;
                Trace::WriteDispatchFailure($dispatchFailure);
        }
        
        return $fResult;
    }
    public static function PostSession(
        $valGuidSession,
        $valIdtblMembers,
        $valDtLastHeartBeat
    )
    {
        //
        // No param validation performed at this layer, which
        // facilitates RAW_PASSTHROUGH requests
        //
        $strQuery =
            "CALL PostSession(" .
            "'"                 . $valGuidSession      . "'," .
            "'"                 . $valIdtblMembers     . "'," .
            "'"                 . $valDtLastHeartBeat  . "'"  .
            ")";
        $fResult = false;
        $mysqli = Util::YogaConnect();
        if (null != $mysqli)
        {
            $fResult = false;
            $fResult = Util::ExecuteQuery($mysqli, $strQuery);
            if (true != $fResult)
            {
                $dispatchFailure = new Dispatch();
                $dispatchFailure->Message = "PostSession.php: Failed to call the stored procedure.";
                Trace::WriteDispatchFailure($dispatchFailure);
            }
            
            $mysqli->close();
        }
        
        return $fResult;
    }
}
?>
