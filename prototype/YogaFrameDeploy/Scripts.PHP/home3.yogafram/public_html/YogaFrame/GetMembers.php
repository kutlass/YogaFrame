<?php
header('Content-type: application/json');

require_once ('Connect.php');
$mysqli = YogaConnect();

$strQuery = "CALL GetMembers()";
Trace::WriteLine("GetMembers: strQuery = " . $strQuery);
Trace::WriteLine("GetMembers: Calling mysqli->multi_query(strQuery)...");
if ( $mysqli->multi_query($strQuery) )
{
    Trace::WriteLine("GetMembers: mysqli->multi_query() succeeded.");    
    do
    {
        Trace::WriteLine("GetMembers: (INSIDE DO WHILE LOOP) Calling mysqli->store_result()...");
        if ( $mysqli_result = $mysqli->store_result() )
        {
            Trace::WriteLine("GetMembers: mysqli->store_result() succeeded.");
            
            //
            // Create one master array of the records
            //
            $tbl_Members = array();
            
            // Associative array.
            while ( $fetch_array = $mysqli_result->fetch_array(MYSQLI_ASSOC) )
            {
                //Trace::WriteLine("GetMembers: " .  "colName: " . $fetch_array['colName'] . " | colDescription: " . $fetch_array['colDescription']);
                $tbl_Members[] = $fetch_array;
            }
            
            //
            // Format the master array into JSON encoding
            //
            Trace::WriteLine("GetMembers: echoing json_encode() value...");
            $json_encode = json_encode( array('tbl_Members'=>$tbl_Members));
            Trace::EchoJson($json_encode);
            
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
