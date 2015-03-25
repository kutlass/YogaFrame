<?php

require_once ('./Util.php');
require_once ('./Pulses.php');

class GetPulsesHelper
{
    public static function GetPulses(/*ref*/ &$pulses)
    {
        $fResult = false;
        $tbl_Pulses = array();
        $strStoredProcedureName = "GetPulses()";
        $fResult = GetPulsesHelper::FetchDataViaStoredProcedure($strStoredProcedureName, $tbl_Pulses);
        if (true == $fResult)
        {
            $pulses->TblPulses = $tbl_Pulses;
        }
    
        return $fResult;
    }
    
    public static function FetchDataViaStoredProcedure($strStoredProcedureName, /*ref*/ &$tbl_Pulses)
    {
        $fResult = false;
        $fResult = Util::ExecuteQueryReadOnly($strStoredProcedureName, $tbl_Pulses);
        
        return $fResult;
    }
}

?>
