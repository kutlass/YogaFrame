<?php

require_once ('./Util.php');
require_once ('./GandalfBridge.php');
require_once ('./PostMember.php');

print("What's good FGC?!?!");

$strParamMemberId = $_GET["memberId"];
$strParamGuid     = $_GET["guid"];
print("MemberId param = " . $strParamMemberId);
print("Guid param = "     . $strParamGuid);

class ActivateAccountHelper
{
    public static function ActivateAccount()
    {
        //
        // TODO: Implement API: ActivateAccount
        //
        $fResult = false;
        
        return $fResult;
    }
}

?>
