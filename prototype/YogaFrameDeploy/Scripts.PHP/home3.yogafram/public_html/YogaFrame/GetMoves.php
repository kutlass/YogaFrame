<?php

require_once ('./Util.php');
require_once ('./Moves.php');

class GetMovesHelper
{
    public static function GetMoves(/*ref*/ &$moves)
    {
        $fResult = false;
        $tbl_Moves = array();
        $strStoredProcedureName = "GetMoves()";
        $fResult = GetMovesHelper::FetchDataViaStoredProcedure($strStoredProcedureName, $tbl_Moves);
        if (true == $fResult)
        {
            $moves->TblMoves = $tbl_Moves;
        }
    
        return $fResult;
    }
    
    public static function FetchDataViaStoredProcedure($strStoredProcedureName, /*ref*/ &$tbl_Moves)
    {
        $fResult = false;
        $fResult = Util::ExecuteQueryReadOnly($strStoredProcedureName, $tbl_Moves);
        
        return $fResult;
    }
}

?>
