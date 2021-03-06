﻿<?php

//
// Object representation of client-submitted payload
//
class TblSession
{
    public $IdtblSessions;
    public $GuidSession;
    public $IdtblMembers;
    public $DtLastHeartBeat;
}

class Sessions
{
    public $TblSessions;
    
    public static function CreateInstanceFromJson(&$deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Sessions
        //
        $sessions = new Sessions();     
        $arraySource = $deserializedPhpObjectFromJson->TblSessions;
        $sessions->TblSessions = array( new TblSession() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $sessions->TblSessions[$i]->IdtblSessions   = $arraySource[$i]->IdtblSessions;
            $sessions->TblSessions[$i]->GuidSession     = $arraySource[$i]->GuidSession;
            $sessions->TblSessions[$i]->IdtblMembers    = $arraySource[$i]->IdtblMembers;
            $sessions->TblSessions[$i]->DtLastHeartBeat = $arraySource[$i]->DtLastHeartBeat;
        }
        
        return $sessions;
    }
}


?>
