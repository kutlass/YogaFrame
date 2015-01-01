<?php

require_once ('./Util.php');
require_once ('./Dispatch.php');
require_once ('./Sessions.php');
require_once ('./Members.php');

class JSession
{
    public $Dispatch;
    public $Members;
    public $Sessions;
    
    public static function CreateInstanceFromJson(&$deserializedPhpObjectFromJson)
    {
        $jSession = new JSession();
        $jSession->Dispatch = Dispatch::CreateInstanceFromJson($deserializedPhpObjectFromJson);
        if (null != $jSession->Dispatch)
        {
            $jSession->Members = Members::CreateInstanceFromJson($deserializedPhpObjectFromJson->members);
            if (null != $jSession->Members)
            {
                $jSession->Sessions = Sessions::CreateInstanceFromJson($deserializedPhpObjectFromJson->sessions);
            }
        }
        
        return $jSession;
    }
}

?>
