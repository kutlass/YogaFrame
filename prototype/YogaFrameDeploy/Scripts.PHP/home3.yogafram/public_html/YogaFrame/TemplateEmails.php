<?php

//
// Object representation of client-submitted payload
//
class TblTemplateEmail
{
    public $IdtblTemplateEmails;
    public $ColSubject;
    public $ColMessage;
    public $ColHeaders;
}

class TemplateEmails
{
    public $TblTemplateEmails;
    
    public static function CreateInstanceFromJson(/*ref*/ &$deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: TemplateEmails
        //  
        $arraySource = $deserializedPhpObjectFromJson->TblTemplateEmails;
        $templateEmails = new TemplateEmails();
        $templateEmails->TblTemplateEmails = array( new TblTemplateEmail) );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $templateEmails->TblTemplateEmails[$i]->IdtblTemplateEmails  = $arraySource[$i]->IdtblTemplateEmails;
            $templateEmails->TblTemplateEmails[$i]->ColSubject           = $arraySource[$i]->ColSubject;
            $templateEmails->TblTemplateEmails[$i]->ColMessage           = $arraySource[$i]->ColMessage;
            $templateEmails->TblTemplateEmails[$i]->ColHeaders           = $arraySource[$i]->ColHeaders;
        }
        
        return $templateEmails;
    }
}

?>
