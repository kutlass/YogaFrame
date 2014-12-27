<?php

require_once ('./Dispatch.php');

//
// Object representation of client-submitted payload
//
class TblMember
{
    public $ColNameAlias;
    public $ColNameFirst;
    public $ColNameLast;
    public $ColEmailAddress;
    public $ColPasswordSaltHash;
    public $ColBio;
}

class Members
{
    public $Dispatch;
    public $TblMember;
    
    public static function CreateInstanceFromJson($deserializedPhpObjectFromJson)
    {
        //
        // Manually reconstruct my user-defined PHP object: Members
        //
        $members = new Members();
        $Dispatch = Dispatch::CreateInstanceFromJson($deserializedPhpObjectFromJson);
        if (null != $Dispatch)
        {
            $arraySource = $deserializedPhpObjectFromJson->tbl_Members;
            $members->TblMember = array( new TblMember() );
            for ($i = 0; $i < count($arraySource); $i++)
            {
                $members->TblMember[$i]->ColNameAlias        = $arraySource[$i]->colNameAlias;
                $members->TblMember[$i]->ColNameFirst        = $arraySource[$i]->colNameFirst;
                $members->TblMember[$i]->ColNameLast         = $arraySource[$i]->colNameLast;
                $members->TblMember[$i]->ColEmailAddress     = $arraySource[$i]->colEmailAddress;
                $members->TblMember[$i]->ColPasswordSaltHash = $arraySource[$i]->colPasswordSaltHash;
                $members->TblMember[$i]->ColBio              = $arraySource[$i]->colBio;
            }          
        }
        else
        {
            $members = null;
            Trace::WriteLineFailure("Members::CreateInstanceFromJson: null returned from Dispatch::CreateInstanceFromJson().");
        }
        
        return $members;
    }
}

?>
