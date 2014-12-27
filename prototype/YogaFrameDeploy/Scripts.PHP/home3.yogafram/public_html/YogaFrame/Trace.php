﻿<?php

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
        echo "PHP FAILURE: " . $string;
        echo nl2br("\n\r");
    }
    
    public static function WriteDispatchFailure($dispatch)
    {
        $strJsonDispatch = json_encode($dispatch);
        if (FALSE != $strJsonDispatch)
        {
            var_dump($strJsonDispatch);
        }
        else
        {
            Trace::WriteLineFailure("Trace::WriteDispatchFailure: FALSE returned from json_encode()");
        }
    }
    
    public static function EchoJson($string)
    {
        echo $string;
    }
}

?>
