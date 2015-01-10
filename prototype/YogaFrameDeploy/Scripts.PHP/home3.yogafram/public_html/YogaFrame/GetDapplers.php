<?php

require_once ('./Util.php');
require_once ('./Dapplers.php');

class GetDapplersHelper
{
    public static function GetDapplers(/*ref*/ &$characters)
    {
        $fResult = false;
        $tbl_Dapplers = array();
        $strStoredProcedureName = "GetDapplers()";
        $fResult = GetDapplersHelper::FetchDataViaStoredProcedure($strStoredProcedureName, $tbl_Dapplers);
        if (true == $fResult)
        {
            $characters->TblDapplers = $tbl_Dapplers;
        }
    
        return $fResult;
    }
    
    public static function FetchDataViaStoredProcedure($strStoredProcedureName, /*ref*/ &$tbl_Dapplers)
    {
        $fResult = false;
        $fResult = Util::ExecuteQueryReadOnly($strStoredProcedureName, $tbl_Dapplers);
        
        return $fResult;
    }
}

?>
