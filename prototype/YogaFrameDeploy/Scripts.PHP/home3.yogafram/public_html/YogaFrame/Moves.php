<?php

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
    public $TblMoves;
    
    public static function CreateInstanceFromJson(/*ref*/ &$deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Moves
        //
        $arraySource = $deserializedPhpObjectFromJson->TblMoves;
        $moves = new Moves();
        $moves->TblMoves = array( new TblMove() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $moves->TblMoves[$i]->ColName        = $arraySource[$i]->ColName;
            $moves->TblMoves[$i]->IdtblDapplers  = $arraySource[$i]->IdtblDapplers;
        }
        
        return $moves;
    }
}

?>
