<?php

require_once ('./Util.php');

//
// - Create one master array for the records
// - Pass array by reference to be filled by the GetMoves() stored proc helper
// - Pass newly-filled resultset array to the JSON encoder
//
$tbl_Moves = array();
$strStoredProcedureName = "GetMoves()";
$fResult = false;
$fResult = GetMovesHelper::FetchDataViaStoredProcedure($strStoredProcedureName, $tbl_Moves);
if (true == $fResult)
{
    $fResult = GetMovesHelper::EncodeJson($tbl_Moves);
}

class GetMovesHelper
{
    public static function FetchDataViaStoredProcedure($strStoredProcedureName)
    {
        $fResult = false;
        if (null == $strStoredProcedureName)
        {
            $fResult = false;
            Trace::WriteLineFailure("GetMovesHelper::FetchDataViaStoredProcedure: null parameter detected. Fail and bail...");
            return $fResult;
        }
        
        $fResult = Util::ExecuteQueryReadOnly($strStoredProcedureName);
        
        return $fResult;
    }
    
    public static function EncodeJson($tbl_Moves)
    {
        $fResult = false;
        if (null == $tbl_Moves)
        {
            Trace::WriteLineFailure("")
            $fResult = false;
            return $fResult;
        }
        
        //
        // Format the master array into JSON encoding
        //
        Trace::WriteLine("GetMovesHelper::EncodeJson: ");
        $json_encode = json_encode( array('tbl_Moves'=>$tbl_Moves));
        if (FALSE != $json_encode)
        {
            Trace::WriteLine("GetMovesHelper::EncodeJson: echoing json_encode() value...");
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
