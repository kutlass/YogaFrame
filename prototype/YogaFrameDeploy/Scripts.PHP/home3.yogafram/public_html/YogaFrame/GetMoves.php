<?php

require_once ('./Util.php');

//
// Create one master array of the records
//
$tbl_Moves = array();
$strStoredProcedureName = "GetMoves()";
GetMovesHelper::FetchDataViaStoredProcedure($strStoredProcedureName);

class GetMovesHelper
{
    public static function FetchDataViaStoredProcedure($strStoredProcedureName)
    {
        $fResult = false;
        $fResult = Util::ExecuteQueryReadOnly($strStoredProcedureName);
        
        return $fResult;
    }
    
    public static function EncodeJson()
    {
        //
        // Format the master array into JSON encoding
        //
        Trace::WriteLine("Util::ExecuteQueryReadOnly: echoing json_encode() value...");
        $json_encode = json_encode( array('tbl_Moves'=>$tbl_Moves));
        Trace::EchoJson($json_encode);
    }
}
        /*
        CREATE TABLE `tbl_Moves` (
          `idtbl_Moves` int(11) NOT NULL AUTO_INCREMENT,
          `colName` varchar(45) DEFAULT NULL,
          `idtblDapplers` int(11) DEFAULT NULL,
          PRIMARY KEY (`idtbl_Moves`)
        ) ENGINE=InnoDB AUTO_INCREMENT=0 DEFAULT CHARSET=latin1;
        
        */
?>
