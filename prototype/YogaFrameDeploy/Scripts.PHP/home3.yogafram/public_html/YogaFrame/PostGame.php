<?php

require_once ('./Util.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom Games object
// - Call stored procedure, passing Games instance fields as input
//
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
$games = Games::CreateInstanceFromJson($deserializedPhpObjectFromJson);
var_dump($games);

$valColName         = $games[0]->colName;
$valColDeveloper    = $games[0]->colDeveloper;
$valColDeveloperURL = $games[0]->colDeveloperURL;
$vaColPublisher     = $games[0]->colPublisher;
$valColPublisherURL = $games[0]->colPublisherURL;
$valColDescription  = $games[0]->colDescription;

$strQuery =
    "CALL PostGame("         .
    "'"                      . $valColName         . "'," .
    "'"                      . $valColDeveloper    . "'," .
    "'"                      . $valColDeveloperURL . "'," .
    "'"                      . $valColPublisher    . "'," .
    "'"                      . $valColPublisherURL . "'," .
    "'"                      . $valColDescription  . "'"  .
    ")";

$mysqli = Util::YogaConnect();
if (null != $mysqli)
{
    Util::ExecuteQuery($strQuery);
    
    $mysqli->close();
}


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

public class Games
{
    public $TblGames;
    
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
            $games->TblGame[$i]->IdtblGames; = $arraySource[$i]->idtbl_Games;
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

/*

CREATE TABLE `tbl_Games` (
  `idtbl_Games` int(11) NOT NULL AUTO_INCREMENT,
  `colName` varchar(45) DEFAULT NULL,
  `colDeveloper` varchar(45) DEFAULT NULL,
  `colDeveloperURL` varchar(45) DEFAULT NULL,
  `colPublisher` varchar(45) DEFAULT NULL,
  `colPublisherURL` varchar(45) DEFAULT NULL,
  `colDescription` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idtbl_Games`)
) ENGINE=MyISAM AUTO_INCREMENT=259 DEFAULT CHARSET=latin1; 
 
*/

?>
