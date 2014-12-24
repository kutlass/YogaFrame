<?php

require_once ('./Util.php');

//
// - Create one master array for the records
// - Pass array by reference to be filled by the GetInputSequences() stored proc helper
// - Pass newly-filled resultset array to the JSON encoder
//
$tbl_InputSequences = array();
$strStoredProcedureName = "GetInputSequences()";
$fResult = false;
$fResult = GetInputSequencesHelper::FetchDataViaStoredProcedure($strStoredProcedureName, $tbl_InputSequences);
if (true == $fResult)
{
    $fResult = GetInputSequencesHelper::EncodeJson($tbl_InputSequences);
}

class GetInputSequencesHelper
{
    public static function FetchDataViaStoredProcedure($strStoredProcedureName, /*ref*/ &$tbl_InputSequences)
    {
        $fResult = false;
        $fResult = Util::ExecuteQueryReadOnly($strStoredProcedureName, $tbl_InputSequences);
        
        return $fResult;
    }
    
    public static function EncodeJson($tbl_InputSequences)
    {
        $fResult = false;

        //
        // Format the master array into JSON encoding
        //
        Trace::WriteLine("GetInputSequencesHelper::EncodeJson: ");
        $json_encode = json_encode( array('tbl_InputSequences'=>$tbl_InputSequences));
        if (FALSE != $json_encode)
        {
            Trace::WriteLine("GetInputSequencesHelper::EncodeJson: echoing json_encode() value...");
            Trace::EchoJson($json_encode);
            
            //
            // If we got this far, the entire function succeeded:
            //
            $fResult = true;
        }
        else
        {
            $fResult = false;
            Trace::WriteLineFailure("Util::EncodeJson: json_encode() returned FALSE.");
        }
        
        return $fResult;
    }
}

?>
