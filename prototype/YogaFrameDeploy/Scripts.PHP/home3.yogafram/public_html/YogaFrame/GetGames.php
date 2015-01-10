<?php

require_once ('./Util.php');
require_once ('./Games.php');

class GetGamesHelper
{
    public static function GetGames(/*ref*/ &$games)
    {
        $fResult = false;
        $tbl_Games = array();
        $strStoredProcedureName = "GetGames()";
        $fResult = GetGamesHelper::FetchDataViaStoredProcedure($strStoredProcedureName, $tbl_Games);
        if (true == $fResult)
        {
            $games->TblGames = $tbl_Games;
        }
    
        return $fResult;
    }
    
    public static function FetchDataViaStoredProcedure($strStoredProcedureName, /*ref*/ &$tbl_Games)
    {
        $fResult = false;
        $fResult = Util::ExecuteQueryReadOnly($strStoredProcedureName, $tbl_Games);
        
        return $fResult;
    }
}

?>
