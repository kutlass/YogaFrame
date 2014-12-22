<?php

require_once ('./Util.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom Dapplers object
// - Call stored procedure, passing Dapplers instance fields as input
//
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
if (null != $deserializedPhpObjectFromJson)
{
    var_dump($deserializedPhpObjectFromJson);
    $dapplers = Dapplers::CreateInstanceFromJson($deserializedPhpObjectFromJson);
    
    $valIdtblDapplers         = $dapplers->TblDappler[0]->IdtblDapplers;
    $valIdtblParentTable      = $dapplers->TblDappler[0]->IdtblParentTable;
    $valColtblParentTableName = $dapplers->TblDappler[0]->ColtblParentTableName;
    $valIdtblDapples          = $dapplers->TblDappler[0]->IdtblDapples;
    $valColDapplerState       = $dapplers->TblDappler[0]->ColDapplerState;
    $valIdtblMember           = $dapplers->TblDappler[0]->IdtblMember;
    
    $strQuery =
        "CALL PostDappler("      .
        "'"                      . $valIdtblDapplers         . "'," .
        "'"                      . $valIdtblParentTable      . "'," .
        "'"                      . $valColtblParentTableName . "'," .
        "'"                      . $valIdtblDapples          . "'," .
        "'"                      . $valColDapplerState       . "'," .
        "'"                      . $valIdtblMember           . "'"  .
        ")";
    
    $mysqli = Util::YogaConnect();
    if (null != $mysqli)
    {
        Util::ExecuteQuery($mysqli, $strQuery);
        
        $mysqli->close();
    }
}
else
{
    echo "PostDappler.php: Failure: null object returned from json_decode";
}

//
// Object representation of client-submitted payload
//
class TblDappler
{
    public $IdtblDapplers;
    public $IdtblParentTable;
    public $ColtblParentTableName;
    public $IdtblDapples;
    public $ColDapplerState;
    public $IdtblMember;
}

class Dapplers
{
    public $TblDappler;
    
    public static function CreateInstanceFromJson($deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Dapplers
        //
        $arraySource = $deserializedPhpObjectFromJson->tbl_Dapplers;
        $dapplers = new Dapplers();
        $dapplers->TblDappler = array( new TblDappler() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $dapplers->TblDappler[$i]->IdtblDapplers = $arraySource[$i]->idtbl_Dapplers;
            $dapplers->TblDappler[$i]->IdtblParentTable = $arraySource[$i]->idtblParentTable;
            $dapplers->TblDappler[$i]->ColtblParentTableName = $arraySource[$i]->coltblParentTableName;
            $dapplers->TblDappler[$i]->IdtblDapples = $arraySource[$i]->idtblDapples;
            $dapplers->TblDappler[$i]->ColDapplerState = $arraySource[$i]->colDapplerState;
            $dapplers->TblDappler[$i]->IdtblMember = $arraySource[$i]->idtbl_Member;
        }
        
        return $dapplers;
    }
}

?>
