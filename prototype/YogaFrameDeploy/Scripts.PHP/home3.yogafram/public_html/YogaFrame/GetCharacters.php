<?php
header('Content-type: application/json');


require_once ('Connect.php');
$mysqli = YogaConnect();

$strQuery = "CALL GetCharacters()";
Trace::WriteLine("GetCharacters: strQuery = " . $strQuery);
Trace::WriteLine("GetCharacters: Calling mysqli->multi_query(strQuery)...");
if ( $mysqli->multi_query($strQuery) )
{
    Trace::WriteLine("GetCharacters: mysqli->multi_query() succeeded.");    
    do
    {
        Trace::WriteLine("GetCharacters: (INSIDE DO WHILE LOOP) Calling mysqli->store_result()...");
        if ( $mysqli_result = $mysqli->store_result() )
        {
            Trace::WriteLine("GetCharacters: mysqli->store_result() succeeded.");
            
            //
            // Create one master array of the records
            //
            $masterArray = array();
            
            // Associative array.
            while ( $fetch_array = $mysqli_result->fetch_array(MYSQLI_ASSOC) )
            {
                //Trace::WriteLine("GetCharacters: " .  "colName: " . $fetch_array['colName'] . " | colDescription: " . $fetch_array['colDescription']);
                $masterArray[] = $fetch_array;
            }
            
            //
            // Format the master array into JSON encoding
            //
            //header('Content-type: application/json');
            Trace::WriteLine("GetCharacters: returning json_encode() value...");
            $json_encode = json_encode( array('masterArray'=>$masterArray) );
            Trace::WriteLine($json_encode);

            $mysqli_result->free();
        }        
        $mysqli->more_results();
    } while ($mysqli->next_result());
}
else
{
    echo Trace::WriteLine("CALL failed: (" . $mysqli->errno . ") " . $mysqli->error);
}

?>
