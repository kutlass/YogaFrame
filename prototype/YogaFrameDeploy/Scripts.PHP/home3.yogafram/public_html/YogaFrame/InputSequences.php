<?php

//
// Object representation of client-submitted payload
//
class TblInputSequence
{
    public $IdtblInputSequences;
    public $IdtblMoves;
    public $IdtblDapplers;
}

class InputSequences
{
    public $TblInputSequences;
    
    public static function CreateInstanceFromJson(/*ref*/ &$deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: InputSequences
        //
        $arraySource = $deserializedPhpObjectFromJson->TblInputSequences;
        $inputSequences = new InputSequences();
        $inputSequences->TblInputSequences = array( new TblInputSequence() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $inputSequences->TblInputSequences[$i]->IdtblInputSequences = $arraySource[$i]->IdtblInputSequences;
            $inputSequences->TblInputSequences[$i]->IdtblMoves          = $arraySource[$i]->IdtblMoves;
            $inputSequences->TblInputSequences[$i]->IdtblDapplers       = $arraySource[$i]->IdtblDapplers;
        }
        
        return $inputSequences;
    }
}

?>
