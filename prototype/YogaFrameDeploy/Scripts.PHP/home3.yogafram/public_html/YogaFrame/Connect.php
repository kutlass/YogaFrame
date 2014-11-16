<?php

require_once ('../../ConnectData.php');
require_once ('./Trace.php');

function YogaConnect()
{
    Trace::WriteLine("YogaConnect: Calling mysqli()...");
    $mysqli = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_NAME);
    if (true != $mysqli->connect_errno)
    {
        Trace::WriteLine("YogaConnect: mysqli() connection succeeded.");
        Trace::WriteLine("YogaConnect: " . $mysqli->host_info);
    }
    else
    {
        Trace::WriteLine("YogaConnect: mysqli() connection failed: (" . $mysqli->connect_errno . ") " . $mysqli->connect_error);
    }
    
    return $mysqli;
}

?>
