﻿<?php

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
            
            $mysqli->close();
        }
        else
        {
            $fResult = false;
        }
        
        return $fResult;
    }
    
    public static function UpdateMemberProfile(
        $valIdtblMembers,
        $valColNameFirst,
        $valColEmailAddress,
        $valColBio
    )
    {
        $fResult = false;
        
        //
        // Param validation:
        // ----------------
        // Minimum requirements for us to take action:
        // 1. $valIdtblMembers MUST be filled
        // 2. At least ONE of the non-$valIdtblMembers
        //    must be filled
        //
/*1.*/  if (null == $valIdtblMembers)
        {
            $jSession = JSession::Initialize();
            $jSession->Dispatch->Message = "PostMemberHelper::UpdateMemberProfile: Failure: NULL IdtblMembers";
            Trace::RespondToClientWithFailure($jSession);
            $fResult = false;
            return $fResult;
        }
/*2.*/  if (null == $valColNameFirst &&
            null == $valColEmailAddress &&
            null == $valColBio
            )
        {
            $jSession = JSession::Initialize();
            $jSession->Dispatch->Message = "PostMemberHelper::UpdateMemberProfile: Failure: Minimum of 1 field needed.";
            Trace::RespondToClientWithFailure($jSession);
            $fResult = false;
            return $fResult;
        }
        
        //
        // Construct query string then execute
        //
        $strQuery =
            "CALL UpdateMember("     .
            "'"                      . $valIdtblMembers         . "'," .
            "'"                      . $valColNameFirst         . "'," .
            "'"                      . $valColEmailAddress      . "'," .
            "'"                      . $valColBio               . "'"  .
            ")";
        $mysqli = Util::YogaConnect();
        if (null != $mysqli)
        {
            $fResult = true;
            $fResult = Util::ExecuteQuery($mysqli, $strQuery);
            
            $mysqli->close();
        }
        else
        {
            $fResult = false;
        }
            
        return $fResult;
    }
    
    public static function UpdateSendEmailVerification(
        $valIdtblMembers,
        $valColEmailAddress,
        $valSubject,
        $valMessage,
        $valHeaders
        )
    {
        $fResult = false;
        $to      = $valColEmailAddress;
        $subject = $valSubject;
        $message = $valMessage;
        $headers = $valHeaders . " " . phpversion();

        $fResult = mail($to, $subject, $message, $headers);
        
        return $fResult;
    }
    
    public static function UpdateMemberAccountVerificationStatus(
        $valIdtblMembers,
        $valColEmailVerificationGuid,
        $valColEmailVerificationGuidCreationDate,
        $valColIsEmailVerified
    )
    {
        $fResult = false;
        
        //
        // Construct query string then execute
        //
        $strQuery =
            "CALL UpdateMemberAccountVerificationStatus("                       .
            "'"                      . $valIdtblMembers                         . "'," .
            "'"                      . $valColEmailVerificationGuid             . "'," .
            "'"                      . $valColEmailVerificationGuidCreationDate . "'," .
            "'"                      . $valColIsEmailVerified                   . "'"  .
            ")";
        $mysqli = Util::YogaConnect();
        if (null != $mysqli)
        {
            $fResult = true;
            $fResult = Util::ExecuteQuery($mysqli, $strQuery);
            
            $mysqli->close();
        }
        else
        {
            $fResult = false;
        }
        
        return $fResult;
    }
    
    public static function MemberValidateActivationGuid(
                $valIdtblMembers, 
                $valGuid
        )
    {
        $fResult = false;
        $jSessionResponse = new JSession();
        $jSessionResponse->Dispatch = new Dispatch();
        $strStoredFunctionName =
            "MemberValidateActivationGuid(" .
            "'"                             . $valIdtblMembers  . "'," .
            "'"                             . $valGuid          . "'"  .
            ")";
        $fResult = Util::ExecuteStoredFunction(
            /*ref*/ $jSessionResponse,
                    $strStoredFunctionName,
            /*ref*/ $scalarResult
            );            
        if (true == $fResult)
        {
            if (true == $scalarResult)
            {
                $fResult = true;
            }
            else
            {
                $fResult = false;
            }
        }
        
        return $fResult;
    }
    
    public static function MemberIsEmailVerifiedYet(
        /*ref*/ &$jSessionResponse,
                $valIdtblMembers
                )
    {
        //
        // Important: $fResult solely signifies whether the web call *succeeded*
        // ---------------------------------------------------------------------
        // The direct answer to "IsEmailVerifiedYet?" is stored in the web reponse structure:
        // &$jSessionResponse->Members->TblMembers[0]->ColIsEmailVerified
        //
        $fResult = false;
        $strStoredFunctionName =
            "MemberIsEmailVerifiedYet("     .
            "'"                             . $valIdtblMembers  . "'" .
            ")";
        $fResult = Util::ExecuteStoredFunction(
            /*ref*/ $jSessionResponse,
                    $strStoredFunctionName,
            /*ref*/ $scalarResult
            );
        
        //
        // We only bother filling in the response struct if the MySQL call succeeded
        //
        if (true == $fResult)
        {
            if (true == $scalarResult)
            {
                $jSessionResponse->Members->TblMembers[0]->ColIsEmailVerified = "true";
            }
            else
            {
                $jSessionResponse->Members->TblMembers[0]->ColIsEmailVerified = "false";
            }
        }
        
        return $fResult;
    }
}

?>
