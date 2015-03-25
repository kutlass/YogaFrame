<?php

require_once ('./Util.php');
require_once ('./Characters.php');

class PostCharacterHelper
{
    public static function PostCharacter(
        $valColName,
        $valColDescription,
        $valIdtblGames,
        $valIdtblDapplers
    )
    {
        //
        // No param validation performed at this layer, which
        // facilitates RAW_PASSTHROUGH requests
        //
        $strQuery =
            "CALL PostCharacter("    .
            "'"                      . $valColName        . "'," .
            "'"                      . $valColDescription . "'," .
            "'"                      . $valIdtblGames     . "'," .
            "'"                      . $valIdtblDapplers  . "'"  .
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
                $jSession->Dispatch->Message = "PostCharacterHelper::PostCharacter: Failed to call the stored procedure.";
                Trace::RespondToClientWithFailure($jSession /*ref*/);
            }
            
            $mysqli->close();
        }
        
        return $fResult;
    }
}

?>
