<?php

//
// Object representation of client-submitted payload
//
class TblPulse
{
    public $IdtblPulses;
    public $ColDescription;
    public $IdtblDapplers;
}

class Pulses
{
    public $TblPulses;
    
    public static function CreateInstanceFromJson(/*ref*/ &$deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Pulses
        //  
        $arraySource = $deserializedPhpObjectFromJson->TblPulses;
        $pulses = new Pulses();
        $pulses->TblPulses = array( new TblPulse() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $pulses->TblPulses[$i]->IdtblPulses     = $arraySource[$i]->IdtblPulses;
            $pulses->TblPulses[$i]->ColDescription  = $arraySource[$i]->ColDescription;
            $pulses->TblPulses[$i]->IdtblDapplers   = $arraySource[$i]->IdtblDapplers;
        }
        
        return $pulses;
    }
}

?>
