<?php

require_once ('../../ConnectData.php');
require_once ('./Trace.php');

class Util
{
    //
    // YogaConnect - Opens MySQL connection to the YogaFrame service
    //             - On success, returns valid mysqli object
    //             - On failure, returns null
    //
    public static function YogaConnect()
    {
        Trace::WriteLine("Util::YogaConnect: Calling mysqli()...");
        $mysqli = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_NAME);
        if (true != $mysqli->connect_errno)
        {
            Trace::WriteLine("Util::YogaConnect: mysqli() connection succeeded.");
            Trace::WriteLine("Util::YogaConnect: " . $mysqli->host_info);
        }
        else
        {
            $mysqli = null;
            Trace::WriteLineFailure("Util::YogaConnect: mysqli() connection failed: (" . $mysqli->connect_errno . ") " . $mysqli->connect_error);
        }
        
        return $mysqli;
    }
    
    public static function ExecuteQuery($mysqli, $strQuery)
    {
        if (null == $mysqli || null == $strQuery)
        {
            Trace.WriteLineFailure("Util::ExecuteQuery: null parameter detected. Fail and bail...");
            return false;
        }
        
        $fResult = false;
        Trace::WriteLine("Util::ExecuteQuery: strQuery = " . $strQuery);
        Trace::WriteLine("Util::ExecuteQuery: Calling mysqli->query(strQuery)...");
        if ( $mysqli->multi_query($strQuery) )
        {
            $fResult = true;
            Trace::WriteLine("Util::ExecuteQuery: mysqli->query() succeeded.");         
        }
        else
        {
            $fResult = false;
            Trace::WriteLineFailure("Util::ExecuteQuery: mysqli->query() failed: (" . $mysqli->errno . ") " . $mysqli->error);
        }
        
        return $fResult;
    }
    
    public static function ExecuteQueryReadOnly($strStoredProcedureName)
    {
        header('Content-type: application/json');
        
        require_once ('Connect.php');
        $mysqli = YogaConnect();
        
        $strQuery = "CALL GetMoves()";
        Trace::WriteLine("Util::ExecuteQueryReadOnly: strQuery = " . $strQuery);
        Trace::WriteLine("Util::ExecuteQueryReadOnly: Calling mysqli->multi_query(strQuery)...");
        if ( $mysqli->multi_query($strQuery) )
        {
            Trace::WriteLine("Util::ExecuteQueryReadOnly: mysqli->multi_query() succeeded.");    
            do
            {
                Trace::WriteLine("Util::ExecuteQueryReadOnly: (INSIDE DO WHILE LOOP) Calling mysqli->store_result()...");
                if ( $mysqli_result = $mysqli->store_result() )
                {
                    Trace::WriteLine("Util::ExecuteQueryReadOnly: mysqli->store_result() succeeded.");
                    
                    //
                    // Create one master array of the records
                    //
                    $tbl_Moves = array();
                    
                    // Associative array.
                    while ( $fetch_array = $mysqli_result->fetch_array(MYSQLI_ASSOC) )
                    {
                        //Trace::WriteLine("Util::ExecuteQueryReadOnly: " .  "colName: " . $fetch_array['colName'] . " | colDescription: " . $fetch_array['colDescription']);
                        $tbl_Moves[] = $fetch_array;
                    }
                    
                    //
                    // Format the master array into JSON encoding
                    //
                    Trace::WriteLine("Util::ExecuteQueryReadOnly: echoing json_encode() value...");
                    $json_encode = json_encode( array('tbl_Moves'=>$tbl_Moves));
                    Trace::EchoJson($json_encode);
                    
                    $mysqli_result->free();
                }        
                $mysqli->more_results();
            } while ($mysqli->next_result());
        }
        else
        {
            echo Trace::WriteLineFailure("Util::ExecuteQueryReadOnly: CALL failed: (" . $mysqli->errno . ") " . $mysqli->error);
        }
        
        /*
        CREATE TABLE `tbl_Moves` (
          `idtbl_Moves` int(11) NOT NULL AUTO_INCREMENT,
          `colName` varchar(45) DEFAULT NULL,
          `idtblDapplers` int(11) DEFAULT NULL,
          PRIMARY KEY (`idtbl_Moves`)
        ) ENGINE=InnoDB AUTO_INCREMENT=0 DEFAULT CHARSET=latin1;
        
        */
    }
}

?>
