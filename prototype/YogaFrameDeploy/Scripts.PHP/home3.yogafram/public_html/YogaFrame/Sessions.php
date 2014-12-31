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
    public $TblSession;
    
    public static function CreateInstanceFromJson($deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Sessions
        //
        $sessions = new Sessions();
        $sessions->Dispatch = Dispatch::CreateInstanceFromJson($deserializedPhpObjectFromJson);
        if (null != $sessions->Dispatch)
        {
            $arraySource = $deserializedPhpObjectFromJson->tbl_Sessions;
            $sessions->TblSession = array( new TblSession() );
            for ($i = 0; $i < count($arraySource); $i++)
            {
                $sessions->TblSession[$i]->GuidSession     = $arraySource[$i]->guidSession;
                $sessions->TblSession[$i]->IdtblMembers    = $arraySource[$i]->idtblMembers;
                $sessions->TblSession[$i]->DtLastHeartBeat = $arraySource[$i]->dtLastHeartBeat;
            }            
        }
        else
        {
            $sessions = null;
            Trace::WriteLineFailure("Sessions::CreateInstanceFromJson: null returned from Dispatch::CreateInstanceFromJson().");
        }
        
        return $sessions;
    }
}


?>
