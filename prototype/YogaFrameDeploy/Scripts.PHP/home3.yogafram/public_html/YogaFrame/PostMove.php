<?php

require_once ('./Util.php');
require_once ('./Moves.php');

class PostMoveHelper
{
    public static function PostMove(
        $valColName,
        $valIdtblCharacters,
        $valIdtblDapplers
        )
    {
        //
        // No param validation performed at this layer, which
        // facilitates RAW_PASSTHROUGH requests
        //
        $strQuery =
            "CALL PostMove("    .
            "'"                 . $valColName         . "'," .
            "'"                 . $valIdtblCharacters . "'," .
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
                $jSession = JSession::Initialize();
                $jSession->Dispatch->Message = "PostMoveHelper::PostMove: Failed to call the stored procedure.";
                Trace::RespondToClientWithFailure($jSession);
            }
            
            $mysqli->close();
        }
        
        return $fResult;
    }
}

?>
