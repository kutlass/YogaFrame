<?php

require_once ('./Dispatch.php');

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
    public $Dispatch;
    public $TblSessions;
    
    public static function CreateInstanceFromJson(&$deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Sessions
        //
        $sessions = new Sessions();
        $sessions->Dispatch = Dispatch::CreateInstanceFromJson($deserializedPhpObjectFromJson);
        if (null != $sessions->Dispatch)
        {
            $arraySource = $deserializedPhpObjectFromJson->tbl_Sessions;
            $sessions->TblSessions = array( new TblSession() );
            for ($i = 0; $i < count($arraySource); $i++)
            {
                $sessions->TblSessions[$i]->GuidSession     = $arraySource[$i]->guidSession;
                $sessions->TblSessions[$i]->IdtblMembers    = $arraySource[$i]->idtblMembers;
                $sessions->TblSessions[$i]->DtLastHeartBeat = $arraySource[$i]->dtLastHeartBeat;
            }            
        }
        else
        {
            $sessions = null;
            $dispatch = new Dispatch();
            $dispatch->Message = "Sessions::CreateInstanceFromJson: null returned from Dispatch::CreateInstanceFromJson().";
            Trace::WriteDispatchFailure($dispatch);
        }
        
        return $sessions;
    }
}


?>
