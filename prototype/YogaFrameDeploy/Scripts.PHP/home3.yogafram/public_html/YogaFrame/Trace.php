<?php

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
    
    public static function EchoJson($string)
    {
        echo $string;
    }
}

?>
