<?php

require_once ('./Util.php');
require_once ('./Characters.php');

class GetCharactersHelper
{
    public static function GetCharacters(/*ref*/ &$characters)
    {
        $fResult = false;
        $tbl_Characters = array();
        $strStoredProcedureName = "GetCharacters()";
        $fResult = GetCharactersHelper::FetchDataViaStoredProcedure($strStoredProcedureName, $tbl_Characters);
        if (true == $fResult)
        {
            $characters->TblCharacters = $tbl_Characters;
        }
    
        return $fResult;
    }
    
    public static function FetchDataViaStoredProcedure($strStoredProcedureName, /*ref*/ &$tbl_Characters)
    {
        $fResult = false;
        $fResult = Util::ExecuteQueryReadOnly($strStoredProcedureName, $tbl_Characters);
        
        return $fResult;
    }
}

?>
