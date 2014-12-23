<?php

require_once ('./Util.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom Moves object
// - Call stored procedure, passing Moves instance fields as input
//
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
if (null != $deserializedPhpObjectFromJson)
{
    var_dump($deserializedPhpObjectFromJson);
    $moves = Moves::CreateInstanceFromJson($deserializedPhpObjectFromJson);
    
    $valColName       = $moves->TblMove[0]->ColName;
    $valIdtblDapplers = $moves->TblMove[0]->IdtblDapplers;
    
    $strQuery =
        "CALL PostMove("    .
        "'"                 . $valColName         . "'," .
        "'"                 . $valIdtblDapplers   . "'"  .
        ")";
    
    $mysqli = Util::YogaConnect();
    if (null != $mysqli)
    {
        $fResult = false;
        $fResult = Util::ExecuteQuery($mysqli, $strQuery);
        if (true != $fResult)
        {
            Trace::WriteLineFailure("PostMove.php: Failed to call the stored procedure.");
        }
        
        $mysqli->close();
    }
}
else
{
    Trace::WriteLineFailure("PostMove.php: Failure: null object returned from json_decode.");
}

//
// Object representation of client-submitted payload
//
class TblMove
{
    public $ColName;
    public $IdtblDapplers;
}

class Moves
{
    public $TblMove;
    
    public static function CreateInstanceFromJson($deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Moves
        //
        $arraySource = $deserializedPhpObjectFromJson->tbl_Moves;
        $moves = new Moves();
        $moves->TblMove = array( new TblMove() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $moves->TblMove[$i]->ColName        = $arraySource[$i]->colName;
            $moves->TblMove[$i]->IdtblDapplers  = $arraySource[$i]->idtblDapplers;
        }
        
        return $moves;
    }
}

?>
