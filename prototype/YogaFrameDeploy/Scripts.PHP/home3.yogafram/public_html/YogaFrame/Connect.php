<html>
 <head>
  <title>PHP YogaFrame Connection Test</title>
 </head>
 <body>

<?php

require_once ('../../ConnectData.php');

function YogaConnect()
{
    $mysqli = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_NAME);
    if (true != $mysqli->connect_errno)
    {
        echo "mysqli() connection succeeded.";
        echo nl2br("\n\r");
        echo $mysqli->host_info . "\n\r";
        echo nl2br("\n\r");
    }
    else
    {
        echo "mysqli() connection failed: (" . $mysqli->connect_errno . ") " . $mysqli->connect_error;
    }
    	
    return $mysqli;
}

?>
 
 </body>
</html>
