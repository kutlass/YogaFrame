<?php

require_once ('./Util.php');
require_once ('./Characters.php');

class PostCharacterHelper
{
    public static function PostCharacter(
        $valColName,
        $valColDescription,
        $valIdtblGames
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
            "'"                      . $valIdtblGames     . "'"  .
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
                $dispatchFailure->Message = "PostCharacterHelper::PostCharacter: Failed to call the stored procedure.";
                Trace::WriteDispatchFailure($dispatchFailure);
            }
            
            $mysqli->close();
        }
        
        return $fResult;            
    }
}

?>
