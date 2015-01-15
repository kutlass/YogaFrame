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
        $strStoredFunctionName =
            "MemberValidateCredentials(" .
            "'"                          . $strUserName  . "'," .
            "'"                          . $strPassword  . "'"  .
            ")";
        $fResult = Util::ExecuteStoredFunction($strStoredFunctionName, /*ref*/ $scalarResult);
        if (true == $fResult)
        {
            if (true == $scalarResult)
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
    
    public static function MemberExistsAlias($strColNameAlias)
    {
        $fResult = false;
        $strStoredFunctionName =
            "MemberExistsAlias(" .
            "'"                  . $strColNameAlias  . "'"  .
            ")";
        $fResult = Util::ExecuteStoredFunction($strStoredFunctionName, /*ref*/ $scalarResult);
        if (true == $fResult)
        {
            if (true == $scalarResult)
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
    
    public static function MemberExistsEmailAddress($strColEmailAddress)
    {
        $fResult = false;
        $strStoredFunctionName =
            "MemberExistsEmailAddress(" .
            "'"                         . $strColEmailAddress  . "'"  .
            ")";
        $fResult = Util::ExecuteStoredFunction($strStoredFunctionName, /*ref*/ $scalarResult);
        if (true == $fResult)
        {
            if (true == $scalarResult)
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
