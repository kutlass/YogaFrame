<?php

require_once ('./Util.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom Members object
// - Call stored procedure, passing Members instance fields as input
//
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
if (null != $deserializedPhpObjectFromJson)
{
    var_dump($deserializedPhpObjectFromJson);
    $members = Members::CreateInstanceFromJson($deserializedPhpObjectFromJson);
    
    $valColNameAlias        = $members->TblMember[0]->ColNameAlias;
    $valColNameFirst        = $members->TblMember[0]->ColNameFirst;
    $valColNameLast         = $members->TblMember[0]->ColNameLast;
    $valColEmailAddress     = $members->TblMember[0]->ColEmailAddress;
    $valColPasswordSaltHash = $members->TblMember[0]->ColPasswordSaltHash;
    $valColBio              = $members->TblMember[0]->ColBio;
    
    $strQuery =
        "CALL PostMember("       .
        "'"                      . $valColNameAlias         . "'," .
        "'"                      . $valColNameFirst         . "'," .
        "'"                      . $valColNameLast          . "'," .
        "'"                      . $valColEmailAddress      . "'," .
        "'"                      . $valColPasswordSaltHash  . "'," .
        "'"                      . $valColBio               . "'"  .
        ")";
    
    $mysqli = Util::YogaConnect();
    if (null != $mysqli)
    {
        $fResult = false;
        $fResult = Util::ExecuteQuery($mysqli, $strQuery);
        if (true != $fResult)
        {
            Trace::WriteLineFailure("PostMemper.php: Failed to call the stored procedure.");
        }
        
        $mysqli->close();
    }
}
else
{
    Trace::WriteLineFailure("PostMember.php: Failure: null object returned from json_decode.");
}

//
// Object representation of client-submitted payload
//
class TblMember
{
    public $ColNameAlias;
    public $ColNameFirst;
    public $ColNameLast;
    public $ColEmailAddress;
    public $ColPasswordSaltHash;
    public $ColBio;
}

class Members
{
    public $TblMember;
    
    public static function CreateInstanceFromJson($deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Members
        //
        $arraySource = $deserializedPhpObjectFromJson->tbl_Members;
        $members = new Members();
        $members->TblMember = array( new TblMember() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $members->TblMember[$i]->ColNameAlias        = $arraySource[$i]->colNameAlias;
            $members->TblMember[$i]->ColNameFirst        = $arraySource[$i]->colNameFirst;
            $members->TblMember[$i]->ColNameLast         = $arraySource[$i]->colNameLast;
            $members->TblMember[$i]->ColEmailAddress     = $arraySource[$i]->colEmailAddress;
            $members->TblMember[$i]->ColPasswordSaltHash = $arraySource[$i]->colPasswordSaltHash;
            $members->TblMember[$i]->ColBio              = $arraySource[$i]->colBio;
        }
        
        return $members;
    }
}

?>
