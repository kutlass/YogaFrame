<?php

class GandalfBridge
{
    const REG_EX_VALID_MEMBER_USER_NAME     = "/^[a-zA-Z0-9]{2,14}$/";
    const REG_EX_VALID_MEMBER_EMAIL_ADDRESS = "/^[a-zA-Z_]{2,18}@[a-zA-Z_]{2,18}.[a-zA-Z]{2,10}/$";
    const REG_EX_VALID_MEMBER_PASSWORD      = "/^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$/";

    public static function ShallPassMemberUserName($strUserName)
    {
        $fResult = false;
        $fResult = preg_match(self::REG_EX_VALID_MEMBER_USER_NAME, $strUserName);

        return $fResult;
    }
  
    public static function ShallPassMemberEmailAddress($strEmailAddress)
    {
        $fResult = false;
        $fResult = preg_match(self::REG_EX_VALID_MEMBER_EMAIL_ADDRESS, $strEmailAddress);

        return $fResult;
    }
    
    public static function ShallPassMemberPassword($strPassword)
    {
        $fResult = false;
        $fResult = preg_match(self::REG_EX_VALID_MEMBER_PASSWORD, $strPassword);

        return $fResult;
    }    
}

?>
