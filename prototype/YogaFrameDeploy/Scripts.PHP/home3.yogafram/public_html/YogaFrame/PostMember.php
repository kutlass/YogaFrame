<?php

require_once ('./Util.php');
require_once ('./Members.php');

class PostMemberHelper
{
    public static function PostMember(
        $valColNameAlias,
        $valColNameFirst,
        $valColNameLast,
        $valColEmailAddress,
        $valColIsEmailVerified,
        $valColPasswordSaltHash,
        $valColBio,
        $valColDtMemberSince
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
            "'"                      . $valColIsEmailVerified   . "'," .
            "'"                      . $valColPasswordSaltHash  . "'," .
            "'"                      . $valColBio               . "'," .
            "'"                      . $valColDtMemberSince     . "'"  .            
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
