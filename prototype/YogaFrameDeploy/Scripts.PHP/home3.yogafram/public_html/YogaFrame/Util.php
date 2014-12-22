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
}

?>
