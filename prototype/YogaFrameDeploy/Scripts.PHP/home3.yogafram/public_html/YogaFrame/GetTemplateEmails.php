<?php

require_once ('./Util.php');
require_once ('./TemplateEmails.php');

class GetTemplateEmailsHelper
{
    public static function GetTemplateEmails(/*ref*/ &$templateEmails)
    {
        $fResult = false;
        $tbl_TemplateEmails = array();
        $strStoredProcedureName = "GetTemplateEmails()";
        $fResult = GetTemplateEmailsHelper::FetchDataViaStoredProcedure($strStoredProcedureName, $tbl_TemplateEmails);
        if (true == $fResult)
        {
            $templateEmails->TblTemplateEmails = $tbl_TemplateEmails;
        }
    
        return $fResult;
    }
    
    public static function FetchDataViaStoredProcedure($strStoredProcedureName, /*ref*/ &$tbl_TemplateEmails)
    {
        $fResult = false;
        $fResult = Util::ExecuteQueryReadOnly($strStoredProcedureName, $tbl_TemplateEmails);
        
        return $fResult;
    }
}

?>
