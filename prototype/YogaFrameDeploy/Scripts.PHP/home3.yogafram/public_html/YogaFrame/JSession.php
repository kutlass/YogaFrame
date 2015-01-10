<?php

require_once ('./Util.php');
require_once ('./Dispatch.php');
require_once ('./Characters.php');
require_once ('./Games.php');
require_once ('./Sessions.php');
require_once ('./Members.php');

class JSession
{
    public $Dispatch;
    public $Characters;
    public $Games;
    public $Members;
    public $Sessions;
    
    public static function CreateInstanceFromJson(/*ref*/ &$deserializedPhpObjectFromJson)
    {
        $jSession = new JSession();
        $jSession->Dispatch = Dispatch::CreateInstanceFromJson(/*ref*/ $deserializedPhpObjectFromJson);
        if (null != $jSession->Dispatch)
        {
            $jSession->Characters = Characters::CreateInstanceFromJson(/*ref*/ $deserializedPhpObjectFromJson->Characters);
            if (null != $jSession->Characters)
            {
                $jSession->Members = Members::CreateInstanceFromJson(/*ref*/ $deserializedPhpObjectFromJson->Members);
                if (null != $jSession->Members)
                {
                    $jSession->Games = Games::CreateInstanceFromJson(/*ref*/ $deserializedPhpObjectFromJson->Games);
                    if (null != $jSession->Games)
                    {
                        $jSession->Sessions = Sessions::CreateInstanceFromJson(/*ref*/ $deserializedPhpObjectFromJson->Sessions);
                    }
                }
            }
        }
        
        return $jSession;
    }
}

?>
