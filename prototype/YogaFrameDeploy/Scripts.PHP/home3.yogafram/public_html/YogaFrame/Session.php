﻿<?php

require_once ('./Util.php');
require_once ('./JSession.php');
require_once ('./Dispatch.php');
require_once ('./Sessions.php');
require_once ('./PostSession.php');
require_once ('./Members.php');
require_once ('./PostMember.php');

//
// - Deserialize the json-encoded http POST payload string
// - Convert deserialized PHP object into custom JSession object
// - Call ProcessRequest, passing JSession instance as input
//
$deserializedPhpObjectFromJson = json_decode($_POST['json']);
if (null != $deserializedPhpObjectFromJson)
{
    //
    // See what the Client wanted
    //
    $jSessionRequest = JSession::CreateInstanceFromJson($deserializedPhpObjectFromJson);
    if (null != $jSessionRequest)
    {
        //
        // Initialize a server response utilizing a JSession.
        // Some of these allocations may be premature but we'll
        // investigate once more UX functionality is flowing
        //
        $jSessionResponse = new JSession();
        $jSessionResponse->Dispatch = new Dispatch();
        $jSessionResponse->Sessions = new Sessions();
        $jSessionResponse->Sessions->TblSessions = array( new TblSession() );
        
        $fResult = Session::ProcessRequest($jSessionRequest, $jSessionResponse);
        if (true == $fResult)
        {
            $jSessionResponse->Dispatch->Message = "S_OK";
            Trace::RespondToClientWithSuccess($jSessionResponse);
        }
    }
}
else
{
    $dispatch = new Dispatch();
    $dispatch->Message = "Session.php: Failure: null object returned from json_decode.";
    Trace::WriteDispatchFailure($dispatch);
}

class Session
{
    public static function ProcessRequest(&$jSessionRequest, &$jSessionResponse)
    {
        $fResult = false;
        
        //
        // Flatten out the hierarchy for readability during processing
        //
        $dispatch = $jSessionRequest->Dispatch;
        $members  = $jSessionRequest->Members;
        $sessions = $jSessionRequest->Sessions;
        
        $valColNameAlias        = $members->TblMember[0]->ColNameAlias;
        $valColNameFirst        = $members->TblMember[0]->ColNameFirst;
        $valColNameLast         = $members->TblMember[0]->ColNameLast;
        $valColEmailAddress     = $members->TblMember[0]->ColEmailAddress;
        $valColPasswordSaltHash = $members->TblMember[0]->ColPasswordSaltHash;
        $valColBio              = $members->TblMember[0]->ColBio;
        
        $valGuidSession     = $sessions->TblSessions[0]->GuidSession;
        $valIdTblMembers    = $sessions->TblSessions[0]->IdtblMembers;
        $valDtLastHeartBeat = $sessions->TblSessions[0]->DtLastHeartBeat;
        
        switch ($dispatch->Message)
        {
            case "POSTREQUEST_MEMBER_SIGN_IN":
                $fResult = Session::MemberSignIn(
                    $valColNameAlias,
                    $valColPasswordSaltHash
                    );
                break;
            case "POSTREQUEST_MEMBER_SIGN_UP":
                $fResult = Session::MemberSignUp(
                    $jSessionResponse,
                    $valColNameAlias,
                    $valColNameFirst,
                    $valColNameLast,
                    $valColEmailAddress,
                    $valColPasswordSaltHash,
                    $valColBio
                    );
                if (true == $fResult)
                {
                    $fResult = PostSessionHelper::PostSession(
                        $valGuidSession,
                        $valIdTblMembers,
                        $valDtLastHeartBeat
                        );
                }
                break;
            case "POSTREQUEST_SESSION_POSTMSESSION_RAW_PASSTHROUGH":
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
                $jSession = new JSession();
                $jSession->Dispatch = new Dispatch();
                $jSession->Dispatch->Message = "Session::ProcessRequest: Invalid request: " . $dispatch->Message;
                Trace::RespondToClientWithFailure($jSession);
        }
        
        return $fResult;
    }
    public static function MemberSignIn(
        $strUserName,
        $strPassword
    )
    {
        
    }
    public static function MemberSignUp(
        &$jSessionOut,
        $strUserNameAlias,
        $strUserNameFirst,
        $strUserNameLast,
        $strEmailAddress,
        $strPassword
        )
    {
        $fResult = false;
        
        //
        // TODO: Here, prior to the call to PostMember, is where
        // we'll likely do a series of regular expression checks against
        // all the params submitted by the client.
        //
        if ( preg_match("/^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$/", $strPassword) )
        {
            $fResult = true;
            
            //
            // If we got here, the  password met Strong criteria:
            //  - password must be at least 8 characters AND
            //  - must contain at least one lower case letter AND
            //  - one upper case letter AND
            //  - one digit
            //
            $fResult = PostMemberHelper::PostMember(
                $strUserNameAlias,
                $strUserNameFirst,
                $strUserNameLast,
                $strEmailAddress,
                $strPassword,
                "No bio provided."
                );
            if (true == $fResult)
            {
                //$strGuidRandom = com_create_guid();
                $strGuidRandom = "This is TOTALLY a valid Guid.";
                if (null != $strGuidRandom)
                {
                    $jSessionOut->Sessions->TblSessions[0]->GuidSession = $strGuidRandom;
                }
            }
            else
            {
                $jSession = new JSession();
                $jSession->Dispatch = new Dispatch();
                $jsession->Dispatch->Message = "Session::MemberSignUp: Call to PostMemberHelper::PostMember() failed.";
                Trace::RespondToClientWithFailure($jSession);
            }
        }
        else
        {
            $fResult = false;
            $jSession = new JSession();
            $jSession->Dispatch = new Dispatch();
            $jSession->Dispatch->Message = "Session::MemberSignUp: Your password is weak.";
            Trace::RespondToClientWithFailure($jSession);
        }

        return $fResult;
    }
}

?>