<?php

//
// Object representation of client-submitted payload
//

class Dispatch
{
    public $Message;
    
    public static function CreateInstanceFromJson(&$deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Dispatch
        //
        $dispatch = new Dispatch();
        $dispatch->Message = $deserializedPhpObjectFromJson->Dispatch->Message;
        
        return $dispatch;
    }    
}

?>
