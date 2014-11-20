<?php
header('Content-type: application/json');

require_once ('Connect.php');
$mysqli = YogaConnect();

$strQuery = "CALL GetGames()";
Trace::WriteLine("GetGames: strQuery = " . $strQuery);
Trace::WriteLine("GetGames: Calling mysqli->multi_query(strQuery)...");
if ( $mysqli->multi_query($strQuery) )
{
    Trace::WriteLine("GetGames: mysqli->multi_query() succeeded.");    
    do
    {
        Trace::WriteLine("GetGames: (INSIDE DO WHILE LOOP) Calling mysqli->store_result()...");
        if ( $mysqli_result = $mysqli->store_result() )
        {
            Trace::WriteLine("GetGames: mysqli->store_result() succeeded.");
            
            //
            // Create one master array of the records
            //
            $tbl_Games = array();
            
            // Associative array.
            while ( $fetch_array = $mysqli_result->fetch_array(MYSQLI_ASSOC) )
            {                
                $tbl_Games[] = $fetch_array;
            }
            
            //
            // Format the master array into JSON encoding
            //
            Trace::WriteLine("GetGames: echoing json_encode() value...");
            $json_encode = json_encode( array('tbl_Games'=>$tbl_Games));
            Trace::EchoJson($json_encode);
            
            $mysqli_result->free();
        }        
        $mysqli->more_results();
    } while ($mysqli->next_result());
}
else
{
    echo Trace::WriteLine("mysqli->multi_query() failed (" . $mysqli->errno . ") " . $mysqli->error);
}


?>
