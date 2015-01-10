<?php

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
    public $TblDapplers;
    
    public static function CreateInstanceFromJson(/*ref*/ &$deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Dapplers
        //
        $arraySource = $deserializedPhpObjectFromJson->TblDapplers;
        $dapplers = new Dapplers();
        $dapplers->TblDapplers = array( new TblDappler() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $dapplers->TblDapplers[$i]->IdtblDapplers         = $arraySource[$i]->IdtblDapplers;
            $dapplers->TblDapplers[$i]->IdtblParentTable      = $arraySource[$i]->IdtblParentTable;
            $dapplers->TblDapplers[$i]->ColtblParentTableName = $arraySource[$i]->ColtblParentTableName;
            $dapplers->TblDapplers[$i]->IdtblDapples          = $arraySource[$i]->IdtblDapples;
            $dapplers->TblDapplers[$i]->ColDapplerState       = $arraySource[$i]->ColDapplerState;
            $dapplers->TblDapplers[$i]->IdtblMember           = $arraySource[$i]->IdtblMember;
        }
        
        return $dapplers;
    }
}

?>
