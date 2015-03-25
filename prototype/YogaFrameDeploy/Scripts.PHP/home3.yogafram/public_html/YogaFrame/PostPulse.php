<?php

require_once ('./Util.php');
require_once ('./Pulses.php');

class PostPulseHelper
{
    public static function PostPulse(
        $valColDescription,
        $valIdtblDapplers
        )
    {
        //
        // No param validation performed at this layer, which
        // facilitates RAW_PASSTHROUGH requests
        //
        $strQuery =
            "CALL PostPulse("        .
            "'"                      . $valColDescription  . "'," .
            "'"                      . $valIdtblDapplers   . "'"  .
            ")";
        $fResult = false;
        $mysqli = Util::YogaConnect();
        if (null != $mysqli)
        {
            $fResult = false;
            $fResult = Util::ExecuteQuery($mysqli, $strQuery);
            if (true != $fResult)
            {
                $jSession = JSession::Initialize();
                $jSession->Dispatch->Message = "PostPulse.php: Failed to call the stored procedure.";
                Trace::RespondToClientWithFailure($jSession);
            }
            
            $mysqli->close();
        }
        
        return $fResult;
    }
}

?>
