<?php

require_once ('Connect.php');
$mysqli = YogaConnect();

$query = "CALL GetCharacters()";
printf("SUP DOOOD!!!");
printf("Calling mysqli->multi_query()...");
if ( $mysqli->multi_query($query) )
{
    printf("mysqli->multi_query() succeeded.");   
    printf("Calling mysqli->store_result()...");
    do
    {
        if ($result = $mysqli->store_result())
        {
            printf("mysqli->store_result() succeeded.");
            
            // Associative array.
            while ($row = $result->fetch_array(MYSQLI_ASSOC))
            {
                printf("%s\n", $row['colName']);
            }

            $result->free();
        }        
        $mysqli->more_results();
    } while ($mysqli->next_result());
}
else
{
    echo "CALL failed: (" . $mysqli->errno . ") " . $mysqli->error;
}

?>
