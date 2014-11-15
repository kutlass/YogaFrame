<?php

class Trace
{
    public static function WriteLine($string)
    {
        echo $string;
        echo nl2br("\n\r");
    }
    
    public static function Write($string)
    {
        echo $string;
    }
}

?>
