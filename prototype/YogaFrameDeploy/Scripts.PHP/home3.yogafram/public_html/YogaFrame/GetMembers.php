<?php

require_once ('./Util.php');
require_once ('./Members.php');

class GetMembersHelper
{
    public static function GetMembers(/*ref*/ &$members)
    {
        $fResult = false;
        $tbl_Members = array();
        $strStoredProcedureName = "GetMembers()";
        $fResult = GetMembersHelper::FetchDataViaStoredProcedure($strStoredProcedureName, $tbl_Members);
        if (true == $fResult)
        {
            $strTblMembers = var_export($tbl_Members, true);
            $members->TblMembers[0]->ColNameAlias = "GetMembersHelper::GetMembers: var_export: " . $strTblMembers;
        }
    
        return $fResult;
    }
    
    public static function FetchDataViaStoredProcedure($strStoredProcedureName, /*ref*/ &$tbl_Members)
    {
        $fResult = false;
        $fResult = Util::ExecuteQueryReadOnly($strStoredProcedureName, $tbl_Members);
        
        return $fResult;
    }
}

?>
