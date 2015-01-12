<?php

require_once ('./Util.php');
require_once ('./InputSequences.php');

class GetInputSequencesHelper
{
    public static function GetInputSequences(/*ref*/ &$inputSequences)
    {
        $fResult = false;
        $tbl_InputSequences = array();
        $strStoredProcedureName = "GetInputSequences()";
        $fResult = GetInputSequencesHelper::FetchDataViaStoredProcedure($strStoredProcedureName, $tbl_InputSequences);
        if (true == $fResult)
        {
            $inputSequences->TblInputSequences = $tbl_InputSequences;
        }
    
        return $fResult;
    }
    
    public static function FetchDataViaStoredProcedure($strStoredProcedureName, /*ref*/ &$tbl_InputSequences)
    {
        $fResult = false;
        $fResult = Util::ExecuteQueryReadOnly($strStoredProcedureName, $tbl_InputSequences);
        
        return $fResult;
    }
}

?>
