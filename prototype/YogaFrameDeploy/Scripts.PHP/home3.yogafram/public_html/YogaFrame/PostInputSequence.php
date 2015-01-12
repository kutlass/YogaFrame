<?php

require_once ('./Util.php');
require_once ('./InputSequences.php');

class PostInputSequenceHelper
{
    public static function PostInputSequence(
        $valIdtblMoves,
        $valIdtblDapplers
        )
    {
        //
        // No param validation performed at this layer, which
        // facilitates RAW_PASSTHROUGH requests
        //    
        $strQuery =
            "CALL PostInputSequence("    .
            "'"                 . $valIdtblMoves      . "'," .
            "'"                 . $valIdtblDapplers   . "'"  .
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
                $dispatchFailure->Message = "PostInputSequenceHelper::PostInputSequence: Failed to call the stored procedure.";
                Trace::WriteDispatchFailure($dispatchFailure);
            }
            
            $mysqli->close();
        }
        
        return $fResult;
    }    
}


?>
