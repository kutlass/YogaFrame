<?php

//
// Object representation of client-submitted payload
//
class TblCharacter
{
    public $IdtblCharacters;
    public $ColName;
    public $ColDescription;
    public $IdtblGames;
}

class Characters
{
    public $TblCharacters;
    
    public static function CreateInstanceFromJson(/*ref*/ &$deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Characters
        //  
        $arraySource = $deserializedPhpObjectFromJson->TblCharacters;
        $characters = new Characters();
        $characters->TblCharacters = array( new TblCharacter() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $characters->TblCharacters[$i]->IdtblCharacters  = $arraySource[$i]->IdtblCharacters;
            $characters->TblCharacters[$i]->ColName          = $arraySource[$i]->ColName;
            $characters->TblCharacters[$i]->ColDescription   = $arraySource[$i]->ColDescription;
            $characters->TblCharacters[$i]->IdtblGames       = $arraySource[$i]->IdtblGames;
        }
        
        return $characters;
    }
}

?>
