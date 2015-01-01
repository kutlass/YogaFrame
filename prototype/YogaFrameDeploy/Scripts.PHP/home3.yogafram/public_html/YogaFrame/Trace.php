<?php

require_once ('./JSession.php');
require_once ('./Dispatch.php');

class Trace
{
    public static function WriteLine($string)
    {
        //echo $string;
        //echo nl2br("\n\r");
    }
    
    public static function Write($string)
    {
        echo $string;
    }
    
    public static function WriteLineFailure($string)
    {
        echo "PHP_FAILURE: " . $string;
        echo nl2br("\n\r");
    }
    
    public static function WriteFailure($string)
    {
        echo "PHP_FAILURE: " . $string;
    }
    
    public static function RespondToClientWithSuccess($jSession)
    {
        //
        // Send response payload to Client in the
        // form of a deserialized JSession string
        //
        $strJsonJSession = json_encode($jSession);
        if (FALSE != $strJsonJSession)
        {
            echo $strJsonJSession;
        }
        else
        {
            Trace::WriteLineFailure("Trace::RespondToClientWithSuccess: FALSE returned from json_encode()");
        }
    }
    
    public static function RespondToClientWithFailure($jSession)
    {
        //
        // Send response payload to Client in the
        // form of a deserialized JSession string
        //
        $strJsonJSession = json_encode($jSession);
        if (FALSE != $strJsonJSession)
        {
            echo $strJsonJSession;
        }
        else
        {
            Trace::WriteLineFailure("Trace::RespondToClientWithFailure: FALSE returned from json_encode()");
        }
    }

    public static function WriteDispatchSuccess($dispatch)
    {
        $jSession = new JSession();
        $jSession->Dispatch = $dispatch;
        
        $strJsonJSession = json_encode($jSession);
        if (FALSE != $strJsonJSession)
        {
            echo $strJsonJSession;
        }
        else
        {
            Trace::WriteLineFailure("Trace::WriteDispatchSuccess: FALSE returned from json_encode()");
        }
    }
    
    public static function EchoJson($string)
    {
        echo $string;
    }
}

?>
