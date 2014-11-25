<?php

require_once ('./Trace.php');

//
// - Deserialize the json-encoded http POST payload
// - Convert deserialized PHP object into custom Characters object
// - Cross fingers and dump results. Looked good on initial debugging
//
$deserializedObject = json_decode($_POST['json']);
$pleaseWork = Characters::CreateInstanceFromJson($deserializedObject);
var_dump($pleaseWork);

//
// Object representation of client-submitted payload
//
class TblCharacter
{
    public $IdtblCharacters;
    public $ColName;
    public $ColDescription;
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
        $characters->TblCharacters = array( new TblCharacter() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $characters->TblCharacters[$i]->IdtblCharacters = $arraySource[$i]->idtbl_Characters;
            $characters->TblCharacters[$i]->ColName = $arraySource[$i]->colName;
            $characters->TblCharacters[$i]->ColDescription = $arraySource[$i]->colDescription;
        }
        
        return $characters;
    }
}

?>
