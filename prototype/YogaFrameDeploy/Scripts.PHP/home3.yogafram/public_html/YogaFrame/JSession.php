<?php

require_once ('./Util.php');
require_once ('./Dispatch.php');
require_once ('./Dapplers.php');
require_once ('./Characters.php');
require_once ('./Games.php');
require_once ('./InputSequences.php');
require_once ('./Moves.php');
require_once ('./Sessions.php');
require_once ('./Members.php');

class JSession
{
    public $Dispatch;
    public $Dapplers;
    public $Characters;
    public $Games;
    public $InputSequences;
    public $Members;
    public $Moves;
    public $Sessions;
    
    public static function CreateInstanceFromJson(/*ref*/ &$deserializedPhpObjectFromJson)
    {
        $jSession = new JSession();
        $jSession->Dispatch = Dispatch::CreateInstanceFromJson(/*ref*/ $deserializedPhpObjectFromJson);
        if (null != $jSession->Dispatch)
        {
            $jSession->Dapplers = Dapplers::CreateInstanceFromJson(/*ref*/ $deserializedPhpObjectFromJson->Dapplers);
            if (null != $jSession->Dapplers)
            {
                $jSession->Characters = Characters::CreateInstanceFromJson(/*ref*/ $deserializedPhpObjectFromJson->Characters);
                if (null != $jSession->Characters)
                {
                    $jSession->InputSequences = InputSequences::CreateInstanceFromJson(/*ref*/ $deserializedPhpObjectFromJson->InputSequences);
                    if (null != $jSession->InputSequences)
                    {
                        $jSession->Members = Members::CreateInstanceFromJson(/*ref*/ $deserializedPhpObjectFromJson->Members);
                        if (null != $jSession->Members)
                        {
                            $jSession->Moves = Moves::CreateInstanceFromJson(/*ref*/ $deserializedPhpObjectFromJson->Moves);
                            if (null != $jSession->Moves)
                            {
                                $jSession->Games = Games::CreateInstanceFromJson(/*ref*/ $deserializedPhpObjectFromJson->Games);
                                if (null != $jSession->Games)
                                {
                                    $jSession->Sessions = Sessions::CreateInstanceFromJson(/*ref*/ $deserializedPhpObjectFromJson->Sessions);
                                }                            
                            }
                        }
                    }
                }
            }
        }
        
        return $jSession;
    }
    
    public static function Initialize()
    {
        $jSession = new JSession();

        $jSession->Dispatch = new Dispatch();
        $jSession->Dapplers = new Dapplers();
        $jSession->Dapplers->TblDapplers = array( new TblDappler() );
        $jSession->InputSequences = new InputSequences();
        $jSession->InputSequences->TblInputSequences = array( new TblInputSequence() );
        $jSession->Sessions = new Sessions();
        $jSession->Sessions->TblSessions = array( new TblSession() );
        $jSession->Members = new Members();
        $jSession->Members->TblMembers = array( new TblMember() );
        $jSession->Moves = new Moves();
        $jSession->Moves->TblMoves = array( new TblMove() );
        $jSession->Games = new Games();
        $jSession->Games->TblGames = array( new TblGame() );
        $jSession->Characters = new Characters();
        $jSession->Characters->TblCharacters = array( new TblCharacter() );
                
        return $jSession;
    }
}

?>
