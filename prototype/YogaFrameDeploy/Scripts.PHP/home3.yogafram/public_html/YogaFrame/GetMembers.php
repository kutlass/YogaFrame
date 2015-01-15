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
        //$queryResult = array();
        $fResult = Util::ExecuteStoredFunction($strQuery, /*ref*/ $queryResult);
        if (true == $fResult)
        {
            //var_dump($queryResult);
            if (true == $queryResult[0])
            {
                $fResult = true;
            }
            else
            {
                $fResult = false;
            }
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
