<?php

require_once ('./Util.php');
require_once ('./Dapplers.php');

class PostDapplerHelper
{
    public static function PostDappler(
        &$refIdtblDapplers,
        $valIdtblParentTable,
        $valColtblParentTableName,
        $valIdtblDapples,
        $valColDapplerState,
        $valIdtblMembers
        )
    {
        //
        // No param validation performed at this layer, which
        // facilitates RAW_PASSTHROUGH requests
        //        
        $fResult = false;
        $mysqli = Util::YogaConnect();
        if (null != $mysqli)
        {
            //
            // Query Step 1
            //
            $strQuery = "SET @sessionVar = 0"; 
            $fResult = Util::ExecuteQuery($mysqli, $strQuery);
            if (true == $fResult)
            {
                //
                // Query Step 2
                //
                $strQuery =
                    "CALL PostDappler("      .
                    "'"                      . "@sessionVar"             . "'," .
                    "'"                      . $valIdtblParentTable      . "'," .
                    "'"                      . $valColtblParentTableName . "'," .
                    "'"                      . $valIdtblDapples          . "'," .
                    "'"                      . $valColDapplerState       . "'," .
                    "'"                      . $valIdtblMembers          . "'"  .
                    ")";
                $mysqli_result = new mysqli_result();
                $fResult = Util::MysqliQuery($mysqli, $strQuery, /*ref*/ $mysqli_result);       
                if (true == $fResult)
                {
                    //
                    // Query Step 3
                    //
                    $strQuery = "SELECT @sessionVar as _p_out";
                    $fResult = Util::ExecuteQuery($mysqli, $strQuery);
                    if (true == $fResult)
                    {
                        $row = $mysqli_result->fetch_assoc();
                        //echo $row['_p_out'];
                        $refIdtblDapplers = $row['_p_out'];
                    }
                    else
                    {   
                        $jSession = JSession::Initialize();
                        $jSession->Dispatch->Message = "PostDapplerHelper::PostDappler: Failed to call the stored procedure.";
                        Trace::RespondToClientWithFailure($jSession);
                    }
                }
                else
                {   
                    $jSession = JSession::Initialize();
                    $jSession->Dispatch->Message = "PostDapplerHelper::PostDappler: Failed to call the stored procedure.";
                    Trace::RespondToClientWithFailure($jSession);
                }
            }
            else
            {   
                $jSession = JSession::Initialize();
                $jSession->Dispatch->Message = "PostDapplerHelper::PostDappler: Failed to call the stored procedure.";
                Trace::RespondToClientWithFailure($jSession);
            }
            
            $mysqli->close();
        }
        
        return $fResult;
    }
}

?>
