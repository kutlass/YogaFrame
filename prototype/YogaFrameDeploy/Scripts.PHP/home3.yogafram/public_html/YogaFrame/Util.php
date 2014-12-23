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
    
    public static function ExecuteQueryReadOnly($strStoredProcedureName, $tbl_Array)
    {
        $fResult = false;
        if (null == $strStoredProcedureName || null == $tbl_Array)
        {
            Trace::WriteLineFailure("Util::ExecuteQueryReadOnly: Detected at least 1 null parameter. Fail and bail...");
            return $fResult;
        }
        header('Content-type: application/json');
        
        $mysqli = Util::YogaConnect();     
        $strQuery = "CALL " . $strStoredProcedureNameGetMoves;
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
                    
                    // Associative array.
                    while ( $fetch_array = $mysqli_result->fetch_array(MYSQLI_ASSOC) )
                    {
                        $tbl_Array[] = $fetch_array;
                    }
                    
                    $mysqli_result->free();
                }        
                $mysqli->more_results();
            } while ($mysqli->next_result());
            
            //
            // If we got this far, the function succeeded:
            //
            $fResult = true;
        }
        else
        {
            $fResult = false;
            Trace::WriteLineFailure("Util::ExecuteQueryReadOnly: CALL failed: (" . $mysqli->errno . ") " . $mysqli->error);
        }
        
        return $fResult;
    }
}

?>
