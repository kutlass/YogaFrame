<?php

require_once ('./Util.php');

//
// - Create one master array for the records
// - Pass array by reference to be filled by the GetSessions() stored proc helper
// - Pass newly-filled resultset array to the JSON encoder
//
$tbl_Sessions = array();
$strStoredProcedureName = "GetSessions()";
$fResult = false;
$fResult = GetSessionsHelper::FetchDataViaStoredProcedure($strStoredProcedureName, $tbl_Sessions);
if (true == $fResult)
{
    $fResult = GetSessionsHelper::EncodeJson($tbl_Sessions);
}

class GetSessionsHelper
{
    public static function FetchDataViaStoredProcedure($strStoredProcedureName, /*ref*/ &$tbl_Sessions)
    {
        $fResult = false;
        $fResult = Util::ExecuteQueryReadOnly($strStoredProcedureName, $tbl_Sessions);
        
        return $fResult;
    }
    
    public static function EncodeJson($tbl_Sessions)
    {
        $fResult = false;

        //
        // Format the master array into JSON encoding
        //
        Trace::WriteLine("GetSessionsHelper::EncodeJson: Calling json_encode()...");
        $json_encode = json_encode( array('tbl_Sessions'=>$tbl_Sessions));
        if (FALSE != $json_encode)
        {
            Trace::WriteLine("GetSessionsHelper::EncodeJson: echoing json_encode() value...");
            Trace::EchoJson($json_encode);
            
            //
            // If we got this far, the entire function succeeded:
            //
            $fResult = true;
        }
        else
        {
            $fResult = false;
            Trace::WriteLineFailure("GetSessionsHelper::EncodeJson: json_encode() returned FALSE.");
        }
        
        return $fResult;
    }
}

?>
