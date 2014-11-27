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
            Trace::WriteLine("Util::YogaConnect: mysqli() connection failed: (" . $mysqli->connect_errno . ") " . $mysqli->connect_error);
        }
        
        return $mysqli;
    }
    
    public static function ExecuteQuery($mysqli, $strQuery)
    {
        Trace::WriteLine("Util::ExecuteQuery: strQuery = " . $strQuery);
        Trace::WriteLine("Util::ExecuteQuery: Calling mysqli->query(strQuery)...");
        if ( $mysqli->multi_query($strQuery) )
        {
            Trace::WriteLine("Util::ExecuteQuery: mysqli->query() succeeded.");
        }
        else
        {
            Trace::WriteLine("Util::ExecuteQuery: mysqli->query() failed: (" . $mysqli->errno . ") " . $mysqli->error);
        }
    }
}

?>
