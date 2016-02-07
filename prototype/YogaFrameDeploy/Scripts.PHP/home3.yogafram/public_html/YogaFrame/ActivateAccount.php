<?php

require_once ('./Util.php');
require_once ('./GandalfBridge.php');
require_once ('./PostMember.php');

Trace::WriteLine2("What's good FGC?!?!");

$strParamMemberId = $_GET["memberId"];
$strParamGuid     = $_GET["guid"];
Trace::WriteLine2("MemberId param = " . $strParamMemberId);
Trace::WriteLine2("Guid param = "     . $strParamGuid);

$fResult = false;
$fResult = ActivateAccountHelper::ActivateAccount($strParamMemberId, $strParamGuid);
if (true == fResult)
{
    Trace::WriteLine("Account Activation succeeded!");
}
else
{
    Trace::WriteLine("Account Activation failed.");
}

class ActivateAccountHelper
{
    public static function ActivateAccount($strMemberId, $strGuid)
    {
        if (null == $strMemberId || null $strGuid)
        {
            Trace::WriteLine2("ActivateAccountHelper::ActivateAccount: Invalid NULL arguments");
            return false;                          
        }
        
        $fResult = false;
        fResult = GandalfBridge::ShallPassGuid($strGuid);
        if (true == $fResult)
        {
            $fResult = MemberHelper::MemberValidateActivationGuid($strMemberId, $strGuid);
        }
        
        return $fResult;
    }
}

?>
