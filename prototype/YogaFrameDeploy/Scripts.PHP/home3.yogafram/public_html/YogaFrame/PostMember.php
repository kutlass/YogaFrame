<?php

require_once ('./Util.php');
require_once ('./Members.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom Members object
// - Call stored procedure, passing Members instance fields as input
//
/*
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
if (null != $deserializedPhpObjectFromJson)
{
    $members = Members::CreateInstanceFromJson($deserializedPhpObjectFromJson);
    if (null != $members)
    {
        $fResult = false;
        $fResult = PostMemberHelper::ProcessRequest($members);
        if (false != $fResult)
        {
            $dispatch = new Dispatch();
            $dispatch->Message = "S_OK";
            Trace::WriteDispatchSuccess($dispatch);
        }
    }
}
else
{
    $dispatch = new Dispatch();
    $dispatch->Message = "PostMember.php: Failure: null object returned from json_decode.";
    Trace::WriteDispatchFailure($dispatch);
}
*/
class PostMemberHelper
{
    public static function ProcessRequest($members)
    {
        $fResult = false;
        
        $valColNameAlias        = $members->TblMember[0]->ColNameAlias;
        $valColNameFirst        = $members->TblMember[0]->ColNameFirst;
        $valColNameLast         = $members->TblMember[0]->ColNameLast;
        $valColEmailAddress     = $members->TblMember[0]->ColEmailAddress;
        $valColPasswordSaltHash = $members->TblMember[0]->ColPasswordSaltHash;
        $valColBio              = $members->TblMember[0]->ColBio;
        
        $dispatch = $members->Dispatch;
        
        switch ($dispatch->Message)
        {
            case "POSTREQUEST_MEMBER_POSTMEMBER_RAW_PASSTHROUGH":
                $fResult = PostMemberHelper::PostMember(
                    $valColNameAlias,
                    $valColNameFirst,
                    $valColNameLast,
                    $valColEmailAddress,
                    $valColPasswordSaltHash,
                    $valColBio
                    );
                break;            
            default:
                $fResult = false;
                $dispatchFailure = new Dispatch();
                $dispatchFailure->Message = "PostMemberHelper::ProcessRequest: Invalid request: " . $dispatch->Message;
                Trace::WriteDispatchFailure($dispatchFailure);
        }
        
        return $fResult;
    }
    public static function PostMember(
        $valColNameAlias,
        $valColNameFirst,
        $valColNameLast,
        $valColEmailAddress,
        $valColPasswordSaltHash,
        $valColBio
    )
    {
        //
        // No param validation performed at this layer, which
        // facilitates RAW_PASSTHROUGH requests
        //
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
                $dispatch = new Dispatch();
                $dispatch->Message = "PostMemberHelper::PostMemper.php: Failed to call the stored procedure.";
                Trace::WriteDispatchFailure($dispatch);
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
