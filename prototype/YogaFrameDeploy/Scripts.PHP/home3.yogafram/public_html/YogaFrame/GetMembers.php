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
        $fResult = GetMembersHelper::FetchDataViaStoredProcedure($strStoredProcedureName, /*ref*/ $tbl_Members);
        if (true == $fResult)
        {
            $members->TblMembers = $tbl_Members;
        }
    
        return $fResult;
    }
    
    public static function GetMemberByAlias(/*ref*/ &$members, $valColNameAlias)
    {
        $fResult = false;
        $tbl_Members = array();
        $strStoredProcedureName = "GetMemberByAlias(" . "'" . $valColNameAlias . "'" . ")";
        $fResult = GetMembersHelper::FetchDataViaStoredProcedure($strStoredProcedureName, /*ref*/ $tbl_Members);
        if (true == $fResult)
        {
            $members->TblMembers = $tbl_Members;
        }
        
        return $fResult;
    }
    
    public static function MemberValidateCredentials($strUserName, $strPassword)
    {
        $fResult = false;
        $strQuery =
            "SELECT MemberValidateCredentials(" .
            "'"                                 . $strUserName  . "'," .
            "'"                                 . $strPassword  . "'"  .
            ")";
        $mysqli = Util::YogaConnect();
        if (null != $mysqli)
        {
            $fResult = Util::ExecuteQuery($mysqli, $strQuery);
            
            $mysqli->close();
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
