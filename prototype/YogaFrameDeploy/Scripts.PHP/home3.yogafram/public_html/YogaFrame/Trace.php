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
    
    public static function RespondToClientWithSuccess(&$jSession)
    {
        if (null != $jSession)
        {
            if ( "JSession" == get_class($jSession) )
            {
                //
                // Send response payload to Client in the
                // form of a serialized JSession string
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
            else
            {
                Trace::WriteLineFailure("Trace::RespondToClientWithSuccess: Incorrect param type passed by caller. Not a JSession instance.");
            }
        }
        else
        {
            Trace::WriteLineFailure("Trace::RespondToClientWithSuccess: A NULL JSession passed by the caller.");
        }
    }
    
    public static function RespondToClientWithFailure(&$jSession)
    {
        if (null != $jSession)
        {
            if ( "JSession" == get_class($jSession) )
            {
                //
                // Send response payload to Client in the
                // form of a serialized JSession string
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
            else
            {
                Trace::WriteLineFailure("Trace::RespondToClientWithFailure: Incorrect param type passed by caller. Not a JSession instance.");
            }
        }
        else
        {
            Trace::WriteLineFailure("Trace::RespondToClientWithFailure: A NULL JSession passed by the caller.");
        }
    }
    
    public static function EchoJson($string)
    {
        echo $string;
    }
}

?>
