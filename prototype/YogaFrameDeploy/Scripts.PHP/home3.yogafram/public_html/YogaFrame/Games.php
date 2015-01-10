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
    public $TblGame;
    
    public static function CreateInstanceFromJson($deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Games
        //  
        $arraySource = $deserializedPhpObjectFromJson->tbl_Games;
        $games = new Games();
        $games->TblGame = array( new TblGame() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $games->TblGame[$i]->IdtblGames = $arraySource[$i]->idtbl_Games;
            $games->TblGame[$i]->ColName = $arraySource[$i]->colName;
            $games->TblGame[$i]->ColDeveloper = $arraySource[$i]->colDeveloper;
            $games->TblGame[$i]->ColDeveloperURL = $arraySource[$i]->colDeveloperURL;
            $games->TblGame[$i]->ColPublisher = $arraySource[$i]->colPublisher;
            $games->TblGame[$i]->ColPublisherURL = $arraySource[$i]->colPublisherURL;
            $games->TblGame[$i]->ColDescription = $arraySource[$i]->colDescription;
        }
        
        return $games;
    }
}

?>
