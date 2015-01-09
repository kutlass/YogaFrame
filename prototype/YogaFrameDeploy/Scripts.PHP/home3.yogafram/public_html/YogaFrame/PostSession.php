<?php

require_once ('./Util.php');
require_once ('./Sessions.php');

class PostSessionHelper
{
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
