<html>
 <head>
  <title>PHP YogaFrame Connection Test</title>
 </head>
 <body>

<?php

requireonce ('../ConnectData.php');

$mysqli = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_NAME);
if (true != $mysqli->connect_errno)
{
     echo "mysqli() connection succeeded.";
     echo nl2br("\n\r");
     echo $mysqli->host_info . "\n\r";
     echo nl2br("\n\r");
     $results = $mysqli->query("SELECT * FROM tbl_Characters");
     if (false != $results )
     {
          echo "mysqli->query() succeeded.";
          echo nl2br("\n\r");
          for ($i = 0; $i < $results->num_rows; $i++) 
          {
               $results->data_seek($i);
               $row = $results->fetch_assoc();
               echo "Name: " . $row['colName'] . " | Description: " . $row[colDescription];
               echo nl2br("\n\r");
          }
     }
     else
     {
          echo "mysqli->query() failed: (" . $mysqli->errno . ") " . $mysqli->error;
     }
}
else
{
     echo "mysqli() connection failed: (" . $mysqli->connect_errno . ") " . $mysqli->connect_error;
}

?>

 
 </body>
</html>