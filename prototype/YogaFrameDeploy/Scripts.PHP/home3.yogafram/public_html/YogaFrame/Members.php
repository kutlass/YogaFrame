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
        $arraySource = $deserializedPhpObjectFromJson->tbl_Members;
        $members->TblMembers = array( new TblMember() );
        for ($i = 0; $i < count($arraySource); $i++)
        {
            $members->TblMembers[$i]->IdtblMembers        = $arraySource[$i]->idtbl_Members;                
            $members->TblMembers[$i]->ColNameAlias        = $arraySource[$i]->colNameAlias;
            $members->TblMembers[$i]->ColNameFirst        = $arraySource[$i]->colNameFirst;
            $members->TblMembers[$i]->ColNameLast         = $arraySource[$i]->colNameLast;
            $members->TblMembers[$i]->ColEmailAddress     = $arraySource[$i]->colEmailAddress;
            $members->TblMembers[$i]->ColPasswordSaltHash = $arraySource[$i]->colPasswordSaltHash;
            $members->TblMembers[$i]->ColBio              = $arraySource[$i]->colBio;
        }
        
        return $members;
    }
}

?>
