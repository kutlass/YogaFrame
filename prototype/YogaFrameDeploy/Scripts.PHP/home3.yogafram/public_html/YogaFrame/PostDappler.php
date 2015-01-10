<?php

require_once ('./Util.php');
require_once ('./Dapplers.php');

class PostDapplerHelper
{
    public static function PostDappler(
        $valIdtblParentTable,
        $valColtblParentTableName,
        $valIdtblDapples,
        $valColDapplerState,
        $valIdtblMember
        )
    {
        //
        // No param validation performed at this layer, which
        // facilitates RAW_PASSTHROUGH requests
        //
        $strQuery =
            "CALL PostDappler("      .
            "'"                      . $valIdtblParentTable      . "'," .
            "'"                      . $valColtblParentTableName . "'," .
            "'"                      . $valIdtblDapples          . "'," .
            "'"                      . $valColDapplerState       . "'," .
            "'"                      . $valIdtblMember           . "'"  .
            ")";
            $fResult = false;
            $mysqli = Util::YogaConnect();
            if (null != $mysqli)
            {
                $fResult = false;
                $fResult = Util::ExecuteQuery($mysqli, $strQuery);
                if (true != $fResult)
                {
                    $dispatchFailure = new Dispatch();
                    $dispatchFailure->Message = "PostDapplerHelper::PostDappler: Failed to call the stored procedure.";
                    Trace::WriteDispatchFailure($dispatchFailure);
                }
                
                $mysqli->close();
            }
            
            return $fResult;
    }
}

?>
