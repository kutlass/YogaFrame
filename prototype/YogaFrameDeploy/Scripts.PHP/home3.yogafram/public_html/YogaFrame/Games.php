<?php

//
// Object representation of client-submitted payload
//
class TblGame
{
    public $IdtblGames;
    public $ColName;
    public $ColDeveloper;
    public $ColDeveloperURL;
    public $ColPublisher;
    public $ColPublisherURL;
    public $ColDescription;
}

class Games
{
    public $TblGames;
    
    public static function CreateInstanceFromJson(/*ref*/ &$deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Games
        //  
        $arraySource = $deserializedPhpObjectFromJson->TblGames;
        $games = new Games();
        $games->TblGames = array( new TblGame() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $games->TblGames[$i]->IdtblGames      = $arraySource[$i]->IdtblGames;
            $games->TblGames[$i]->ColName         = $arraySource[$i]->ColName;
            $games->TblGames[$i]->ColDeveloper    = $arraySource[$i]->ColDeveloper;
            $games->TblGames[$i]->ColDeveloperURL = $arraySource[$i]->ColDeveloperURL;
            $games->TblGames[$i]->ColPublisher    = $arraySource[$i]->ColPublisher;
            $games->TblGames[$i]->ColPublisherURL = $arraySource[$i]->ColPublisherURL;
            $games->TblGames[$i]->ColDescription  = $arraySource[$i]->ColDescription;
        }
        
        return $games;
    }
}

?>
