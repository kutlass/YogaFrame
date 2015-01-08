<?php

//
// Object representation of client-submitted payload
//
class TblMember
{
    public $IdtblMembers;
    public $ColNameAlias;
    public $ColNameFirst;
    public $ColNameLast;
    public $ColEmailAddress;
    public $ColPasswordSaltHash;
    public $ColBio;
    public $ColDtMemberSince;
}

class Members
{
    public $TblMembers;
    
    public static function CreateInstanceFromJson(&$deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Members
        //
        $members = new Members();
        $arraySource = $deserializedPhpObjectFromJson->TblMembers;
        $members->TblMembers = array( new TblMember() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $members->TblMembers[$i]->IdtblMembers        = $arraySource[$i]->IdtblMembers;                
            $members->TblMembers[$i]->ColNameAlias        = $arraySource[$i]->ColNameAlias;
            $members->TblMembers[$i]->ColNameFirst        = $arraySource[$i]->ColNameFirst;
            $members->TblMembers[$i]->ColNameLast         = $arraySource[$i]->ColNameLast;
            $members->TblMembers[$i]->ColEmailAddress     = $arraySource[$i]->ColEmailAddress;
            $members->TblMembers[$i]->ColPasswordSaltHash = $arraySource[$i]->ColPasswordSaltHash;
            $members->TblMembers[$i]->ColBio              = $arraySource[$i]->ColBio;
            $members->TblMembers[$i]->ColDtMemberSince    = $arraySource[$i]->ColDtMemberSince;
        }
        
        return $members;
    }
}

?>
