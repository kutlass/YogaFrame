<?php

require_once ('./Util.php');
require_once ('./Members.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom Members object
// - Call stored procedure, passing Members instance fields as input
//
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
if (null != $deserializedPhpObjectFromJson)
{
    var_dump($deserializedPhpObjectFromJson);
    $members = Members::CreateInstanceFromJson($deserializedPhpObjectFromJson);
    
    $valColNameAlias        = $members->TblMember[0]->ColNameAlias;
    $valColNameFirst        = $members->TblMember[0]->ColNameFirst;
    $valColNameLast         = $members->TblMember[0]->ColNameLast;
    $valColEmailAddress     = $members->TblMember[0]->ColEmailAddress;
    $valColPasswordSaltHash = $members->TblMember[0]->ColPasswordSaltHash;
    $valColBio              = $members->TblMember[0]->ColBio;
    
    $fResult = false;
    $fResult = PostMemberHelper::PostMember(
        $valColNameAlias,
        $valColNameFirst,
        $valColNameLast,
        $valColEmailAddress,
        $valColPasswordSaltHash,
        $valColBio
        );
}
else
{
    Trace::WriteLineFailure("PostMember.php: Failure: null object returned from json_decode.");
}

class PostMemberHelper
{
    public static function PostMember(
        $valColNameAlias,
        $valColNameFirst,
        $valColNameLast,
        $valColEmailAddress,
        $valColPasswordSaltHash,
        $valColBio
    )
    {
        $strQuery =
            "CALL PostMember("       .
            "'"                      . $valColNameAlias         . "'," .
            "'"                      . $valColNameFirst         . "'," .
            "'"                      . $valColNameLast          . "'," .
            "'"                      . $valColEmailAddress      . "'," .
            "'"                      . $valColPasswordSaltHash  . "'," .
            "'"                      . $valColBio               . "'"  .
            ")";
        $fResult = false;
        $mysqli = Util::YogaConnect();
        if (null != $mysqli)
        {
            $fResult = true;
            $fResult = Util::ExecuteQuery($mysqli, $strQuery);
            if (true != $fResult)
            {
                Trace::WriteLineFailure("PostMemper.php: Failed to call the stored procedure.");
            }
            
            $mysqli->close();
        }
        else
        {
            $fResult = false;
        }
        
        return $fResult;
    }
}

?>
