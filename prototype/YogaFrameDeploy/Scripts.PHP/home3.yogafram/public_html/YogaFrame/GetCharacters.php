<?php

require_once ('Connect.php');
$mysqli = YogaConnect();

$strQuery = "CALL GetCharacters()";
Trace::WriteLine("GetCharacters: Calling mysqli->multi_query()...");
if ( $mysqli->multi_query($strQuery) )
{
    Trace::WriteLine("GetCharacters: mysqli->multi_query() succeeded.");
    Trace::WriteLine("GetCharacters: Calling mysqli->store_result()...");
    do
    {
        if ( $mysqli_result = $mysqli->store_result() )
        {
            Trace::WriteLine("GetCharacters: mysqli->store_result() succeeded.");
            // Associative array.
            while ( $fetch_array = $mysqli_result->fetch_array(MYSQLI_ASSOC) )
            {
                Trace::WriteLine("GetCharacters: " .  $fetch_array['colName']);
            }

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
