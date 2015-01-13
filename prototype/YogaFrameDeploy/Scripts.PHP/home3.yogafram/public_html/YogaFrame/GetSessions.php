<?php

require_once ('./Util.php');
require_once ('./Sessions.php');

class GetSessionsHelper
{
    public static function GetSessions(/*ref*/ &$sessions)
    {
        $fResult = false;
        $tbl_Sessions = array();
        $strStoredProcedureName = "GetSessions()";
        $fResult = GetSessionsHelper::FetchDataViaStoredProcedure($strStoredProcedureName, $tbl_Sessions);
        if (true == $fResult)
        {
            $sessions->TblSessions = $tbl_Sessions;
        }
    
        return $fResult;
    }
    
    public static function GetSessionByMemberId(/*ref*/ &$sessions, $valIdtblMembers)
    {
        $fResult = false;
        $tbl_Sessions = array();
        $strStoredProcedureName = "GetSessionByMemberId(" . "'" . $valIdtblMembers . "'" . ")";
        $fResult = GetSessionsHelper::FetchDataViaStoredProcedure($strStoredProcedureName, $tbl_Sessions);
        if (true == $fResult)
        {
            $sessions->TblSessions = $tbl_Sessions;
        }
    
        return $fResult;
    }    
    
    public static function FetchDataViaStoredProcedure($strStoredProcedureName, /*ref*/ &$tbl_Sessions)
    {
        $fResult = false;
        $fResult = Util::ExecuteQueryReadOnly($strStoredProcedureName, $tbl_Sessions);
        
        return $fResult;
    }
}

?>
