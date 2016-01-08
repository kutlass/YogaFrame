<?php

require_once ('./Util.php');
require_once ('./TemplateEmails.php');

class PostTemplateEmailHelper
{
    public static function PostTemplateEmail(
        $valColSubject,
        $valColMessage,
        $valColHeaders
    )
    {
        //
        // No param validation performed at this layer, which
        // facilitates RAW_PASSTHROUGH requests
        //
        $strQuery =
            "CALL PostTemplateEmail("    .
            "'"                      . $valColSubject . "'," .
            "'"                      . $valColMessage . "'," .
            "'"                      . $valColHeaders . "'"  .
            ")";
        $fResult = false;
        $mysqli = Util::YogaConnect();
        if (null != $mysqli)
        {
            $fResult = false;
            $fResult = Util::ExecuteQuery($mysqli, $strQuery);
            if (true != $fResult)
            {
                $jSession = JSession::Initialize();
                $jSession->Dispatch->Message = "PostTemplateEmailHelper::PostTemplateEmail: Failed to call the stored procedure.";
                Trace::RespondToClientWithFailure($jSession /*ref*/);
            }
            
            $mysqli->close();
        }
        
        return $fResult;
    }
}

?>
