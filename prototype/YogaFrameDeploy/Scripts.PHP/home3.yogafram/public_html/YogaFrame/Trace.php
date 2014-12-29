<?php

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
    
    public static function WriteDispatchFailure($dispatch)
    {
        $strJsonDispatch = json_encode($dispatch);
        if (FALSE != $strJsonDispatch)
        {
            echo $strJsonDispatch;
        }
        else
        {
            Trace::WriteLineFailure("Trace::WriteDispatchFailure: FALSE returned from json_encode()");
        }
    }

    public static function WriteDispatchSuccess($dispatch)
    {
        $strJsonDispatch = json_encode($dispatch);
        if (FALSE != $strJsonDispatch)
        {
            echo $strJsonDispatch;
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
