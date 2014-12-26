<?php

//
// Object representation of client-submitted payload
//
class TblSession
{
    public $GuidSession;
    public $IdtblMembers;
    public $DtLastHeartBeat;
}

class Sessions
{
    public $TblSession;
    
    public static function CreateInstanceFromJson($deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Sessions
        //
        $arraySource = $deserializedPhpObjectFromJson->tbl_Sessions;
        $sessions = new Sessions();
        $sessions->TblSession = array( new TblSession() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $sessions->TblSession[$i]->GuidSession     = $arraySource[$i]->guidSession;
            $sessions->TblSession[$i]->IdtblMembers    = $arraySource[$i]->idtblMembers;
            $sessions->TblSession[$i]->DtLastHeartBeat = $arraySource[$i]->dtLastHeartBeat;
        }
        
        return $sessions;
    }
}


?>
