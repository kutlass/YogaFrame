<?php

//
// Test out the new PostCharacter MySQL stored procedure.
// Later we'll wire it to the Characters object to enable client user posting
//
require_once ('./Trace.php');
require_once ('./Connect.php');
$mysqli = YogaConnect();
$strQuery = "CALL PostCharacter('Balrog', 'My fight money!!')";
Trace::WriteLine("PostCharacter: strQuery = " . $strQuery);
Trace::WriteLine("PostCharacter: Calling mysqli->query(strQuery)...");
if ( $mysqli->multi_query($strQuery) )
{
    Trace::WriteLine("PostCharacter: mysqli->multi_query() succeeded.");
}
else
{
    echo Trace::WriteLine("mysqli->multi_query() failed: (" . $mysqli->errno . ") " . $mysqli->error);
}


//
// - Deserialize the json-encoded http POST payload
// - Convert deserialized PHP object into custom Characters object
// - Cross fingers and dump results. Looked good on initial debugging
//
$deserializedObject = json_decode($_POST['json']);
$pleaseWork = Characters::CreateInstanceFromJson($deserializedObject);
var_dump($pleaseWork);

// CALL `yogafram_yogaframe`.`PostCharacter`(<{IN paramColName VARCHAR(45)}>, <{IN paramColDescription VARCHAR(45)}>);

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
