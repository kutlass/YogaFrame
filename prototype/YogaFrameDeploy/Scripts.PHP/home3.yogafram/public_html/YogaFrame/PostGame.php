<?php

require_once ('./Util.php');
require_once ('./Games.php');

class PostGameHelper
{
    public static function PostGame(
        $valColName,
        $valColDeveloper,
        $valColDeveloperURL,
        $valColPublisher,
        $valColPublisherURL,
        $valColDescription
        )
    {
        //
        // No param validation performed at this layer, which
        // facilitates RAW_PASSTHROUGH requests
        //        
        $strQuery =
            "CALL PostGame("         .
            "'"                      . $valColName         . "'," .
            "'"                      . $valColDeveloper    . "'," .
            "'"                      . $valColDeveloperURL . "'," .
            "'"                      . $valColPublisher    . "'," .
            "'"                      . $valColPublisherURL . "'," .
            "'"                      . $valColDescription  . "'"  .
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
                $dispatchFailure->Message = "PostGame.php: Failed to call the stored procedure.";
                Trace::WriteDispatchFailure($dispatchFailure);
            }
            
            $mysqli->close();
        }
        
        return $fResult;
    }
}


/*
$valColName         = $games->TblGame[0]->ColName;
$valColDeveloper    = $games->TblGame[0]->ColDeveloper;
$valColDeveloperURL = $games->TblGame[0]->ColDeveloperURL;
$valColPublisher    = $games->TblGame[0]->ColPublisher;
$valColPublisherURL = $games->TblGame[0]->ColPublisherURL;
$valColDescription  = $games->TblGame[0]->ColDescription;
*/
?>
