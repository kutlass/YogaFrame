<?php

require_once ('./Trace.php');
require_once ('./Connect.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom Characters object
// - Call stored procedure, passing Characters instance fields as input
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
$characters = Characters::CreateInstanceFromJson($deserializedPhpObjectFromJson);
var_dump($characters);
$valColName = $characters->TblCharacter[0]->ColName;
$valColDescription = $characters->TblCharacter[0]->ColDescription;
$valIdtblGames = $characters->TblCharacter[0]->IdtblGames;
$strQuery =
    "CALL PostCharacter("    .
    "'"                      . $valColName        . "'," .
    "'"                      . $valColDescription . "'," .
    "'"                      . $valIdtblGames     . "'"  .
    ")";
PostCharacterHelper::ExecuteQuery($strQuery);

class PostCharacterHelper
{
    public static function ExecuteQuery($strQuery)
    {     
        $mysqli = YogaConnect();
        Trace::WriteLine("PostCharacterHelper: strQuery = " . $strQuery);
        Trace::WriteLine("PostCharacterHelper: Calling mysqli->query(strQuery)...");
        if ( $mysqli->multi_query($strQuery) )
        {
            Trace::WriteLine("PostCharacterHelper: mysqli->query() succeeded.");
        }
        else
        {
            Trace::WriteLine("PostCharacterHelper: mysqli->query() failed: (" . $mysqli->errno . ") " . $mysqli->error);
        }
    }
}

//
// Object representation of client-submitted payload
//
class TblCharacter
{
    public $IdtblCharacters;
    public $ColName;
    public $ColDescription;
    public $IdtblGames;
}

class Characters
{
    public $TblCharacters;
    
    public static function CreateInstanceFromJson($deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Characters
        //  
        $arraySource = $deserializedPhpObjectFromJson->tbl_Characters;
        $characters = new Characters();
        $characters->TblCharacter = array( new TblCharacter() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $characters->TblCharacter[$i]->IdtblCharacters = $arraySource[$i]->idtbl_Characters;
            $characters->TblCharacter[$i]->ColName = $arraySource[$i]->colName;
            $characters->TblCharacter[$i]->ColDescription = $arraySource[$i]->colDescription;
            $characters->TblCharacter[$i]->IdtblGames = $arraySource[$i]->idtblGames;
        }
        
        return $characters;
    }
}

?>
