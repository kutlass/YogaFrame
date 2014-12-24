<?php

require_once ('./Util.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom InputSequences object
// - Call stored procedure, passing InputSequences instance fields as input
//
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
if (null != $deserializedPhpObjectFromJson)
{
    var_dump($deserializedPhpObjectFromJson);
    $inputSequences = InputSequences::CreateInstanceFromJson($deserializedPhpObjectFromJson);
    
    $valIdtblMoves    = $inputSequences->TblInputSequence[0]->IdtblMoves;
    $valIdtblDapplers = $inputSequences->TblInputSequence[0]->IdtblDapplers;
    
    $strQuery =
        "CALL PostInputSequence("    .
        "'"                 . $valIdtblMoves      . "'," .
        "'"                 . $valIdtblDapplers   . "'"  .
        ")";
    
    $mysqli = Util::YogaConnect();
    if (null != $mysqli)
    {
        $fResult = false;
        $fResult = Util::ExecuteQuery($mysqli, $strQuery);
        if (true != $fResult)
        {
            Trace::WriteLineFailure("PostInputSequence.php: Failed to call the stored procedure.");
        }
        
        $mysqli->close();
    }
}
else
{
    Trace::WriteLineFailure("PostInputSequence.php: Failure: null object returned from json_decode.");
}

//
// Object representation of client-submitted payload
//
class TblInputSequence
{
    public $ColName;
    public $IdtblDapplers;
}

class InputSequences
{
    public $TblInputSequence;
    
    public static function CreateInstanceFromJson($deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: InputSequences
        //
        $arraySource = $deserializedPhpObjectFromJson->tbl_InputSequences;
        $inputSequences = new InputSequences();
        $inputSequences->TblInputSequence = array( new TblInputSequence() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $inputSequences->TblInputSequence[$i]->IdtblMoves     = $arraySource[$i]->idtblMoves;
            $inputSequences->TblInputSequence[$i]->IdtblDapplers  = $arraySource[$i]->idtblDapplers;
        }
        
        return $inputSequences;
    }
}

?>
