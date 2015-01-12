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
}

?>
