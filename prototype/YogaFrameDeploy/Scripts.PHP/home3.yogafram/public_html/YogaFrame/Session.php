<?php

require_once ('./Util.php');
require_once ('./GandalfBridge.php');
require_once ('./JSession.php');
require_once ('./Dispatch.php');
require_once ('./Dapplers.php');
require_once ('./GetDapplers.php');
require_once ('./PostDappler.php');
require_once ('./Characters.php');
require_once ('./GetCharacters.php');
require_once ('./PostCharacter.php');
require_once ('./InputSequences.php');
require_once ('./GetInputSequences.php');
require_once ('./PostInputSequence.php');
require_once ('./Sessions.php');
require_once ('./PostSession.php');
require_once ('./Members.php');
require_once ('./PostMember.php');
require_once ('./GetMembers.php');
require_once ('./Moves.php');
require_once ('./PostMove.php');
require_once ('./GetMoves.php');
require_once ('./Pulses.php');
require_once ('./PostPulse.php');
require_once ('./GetPulses.php');
require_once ('./TemplateEmails.php');
require_once ('./GetTemplateEmails.php');
require_once ('./PostTemplateEmail.php');
require_once ('./GetSessions.php');
require_once ('./Games.php');
require_once ('./PostGame.php');
require_once ('./GetGames.php');

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
        $jSessionResponse->Dapplers = new Dapplers();
        $jSessionResponse->Dapplers->TblDapplers = array( new TblDappler() );
        $jSessionResponse->InputSequences = new InputSequences();
        $jSessionResponse->InputSequences->TblInputSequences = array( new TblInputSequence() );
        $jSessionResponse->Sessions = new Sessions();
        $jSessionResponse->Sessions->TblSessions = array( new TblSession() );
        $jSessionResponse->Members = new Members();
        $jSessionResponse->Members->TblMembers = array( new TblMember() );
        $jSessionResponse->Moves = new Moves();
        $jSessionResponse->Moves->TblMoves = array( new TblMove() );
        $jSessionResponse->Pulses = new Pulses();
        $jSessionResponse->Pulses->TblPulses = array( new TblPulse() );
        $jSessionResponse->Games = new Games();
        $jSessionResponse->Games->TblGames = array( new TblGame() );
        $jSessionResponse->Characters = new Characters();
        $jSessionResponse->Characters->TblCharacters = array( new TblCharacter() );
        
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
        $dispatch       = $jSessionRequest->Dispatch;
        $dapplers       = $jSessionRequest->Dapplers;        
        $characters     = $jSessionRequest->Characters;
        $inputSequences = $jSessionRequest->InputSequences;
        $members        = $jSessionRequest->Members;
        $moves          = $jSessionRequest->Moves;
        $pulses         = $jSessionRequest->Pulses;
        $games          = $jSessionRequest->Games;
        $sessions       = $jSessionRequest->Sessions;

        switch ($dispatch->Message)
        {
            case "POSTREQUEST_MEMBER_SIGN_IN":
                $fResult = Session::MemberSignIn(
                    $jSessionResponse, /*ref*/
                    $members->TblMembers[0]->ColNameAlias,
                    $members->TblMembers[0]->ColPasswordSaltHash
                    );
                break;
            case "POSTREQUEST_MEMBER_SIGN_UP":
                $fResult = Session::MemberSignUp(
                    $jSessionResponse, /*ref*/
                    $members->TblMembers[0]->ColNameAlias,
                    $members->TblMembers[0]->ColNameFirst,
                    $members->TblMembers[0]->ColNameLast,
                    $members->TblMembers[0]->ColEmailAddress,
                    $members->TblMembers[0]->ColPasswordSaltHash,
                    $members->TblMembers[0]->ColBio
                    );
                break;
            case "POSTREQUEST_SESSION_CREATESESSION":
                $fResult = Session::CreateSession(
                    $jSessionResponse, /*ref*/
                    $sessions->TblSessions[0]->IdtblMembers
                    );
                break;
            case "POSTREQUEST_SESSION_POSTCHARACTER":
                $fResult = Session::MemberPostCharacter(
                    $sessions->TblSessions[0],
                    $dapplers->TblDapplers[0],
                    $characters->TblCharacters[0]
                    );
                break;
            case "POSTREQUEST_SESSION_POSTGAME":
                $fResult = Session::MemberPostGame(
                    $sessions->TblSessions[0],
                    $dapplers->TblDapplers[0],
                    $games->TblGames[0]
                    );
                break;
            case "POSTREQUEST_SESSION_POSTMOVE":
                $fResult = Session::MemberPostMove(
                    $sessions->TblSessions[0],
                    $dapplers->TblDapplers[0],
                    $moves->TblMoves[0]
                    );
                break;            
            case "POSTREQUEST_SESSION_POSTSESSION_RAW_PASSTHROUGH":
                $fResult = PostSessionHelper::PostSession(
                    $sessions->TblSessions[0]->GuidSession,
                    $sessions->TblSessions[0]->IdtblMembers,
                    $sessions->TblSessions[0]->DtLastHeartBeat
                    );
                break;
            case "POSTREQUEST_MEMBER_POSTMEMBER_RAW_PASSTHROUGH":
                $fResult = PostMemberHelper::PostMember(
                    $members->TblMembers[0]->ColNameAlias,
                    $members->TblMembers[0]->ColNameFirst,
                    $members->TblMembers[0]->ColNameLast,
                    $members->TblMembers[0]->ColEmailAddress,
                    $members->TblMembers[0]->ColIsEmailVerified,        
                    $members->TblMembers[0]->ColPasswordSaltHash,
                    $members->TblMembers[0]->ColBio,
                    $members->TblMembers[0]->ColDtMemberSince
                    );
                break;
            case "POSTREQUEST_CHARACTER_POSTCHARACTER_RAW_PASSTHROUGH":
                $fResult = PostCharacterHelper::PostCharacter(
                    $characters->TblCharacters[0]->ColName,
                    $characters->TblCharacters[0]->ColDescription,
                    $characters->TblCharacters[0]->IdtblGames,
                    $characters->TblCharacters[0]->IdtblDapplers
                    );
                break;
            case "POSTREQUEST_DAPPLER_POSTDAPPLER_RAW_PASSTHROUGH":
                $fResult = PostDapplerHelper::PostDappler(
                    $dapplers->TblDapplers[0]->IdtblDapplers,
                    $dapplers->TblDapplers[0]->IdtblParentTable,
                    $dapplers->TblDapplers[0]->ColtblParentTableName,
                    $dapplers->TblDapplers[0]->IdtblDapples,
                    $dapplers->TblDapplers[0]->ColDapplerState,
                    $dapplers->TblDapplers[0]->IdtblMembers
                    );
                break;
            case "POSTREQUEST_GAME_POSTGAME_RAW_PASSTHROUGH":
                $fResult = PostGameHelper::PostGame(
                    $games->TblGames[0]->ColName,
                    $games->TblGames[0]->ColDeveloper,
                    $games->TblGames[0]->ColDeveloperURL,
                    $games->TblGames[0]->ColPublisher,
                    $games->TblGames[0]->ColPublisherURL,
                    $games->TblGames[0]->ColDescription,
                    $games->TblGames[0]->IdtblDapplers
                    );
                break;
            case "POSTREQUEST_INPUTSEQUENCE_POSTINPUTSEQUENCE_RAW_PASSTHROUGH":
                $fResult = PostInputSequenceHelper::PostInputSequence(
                    $inputSequences->TblInputSequences[0]->IdtblMoves,
                    $inputSequences->TblInputSequences[0]->IdtblDapplers
                    );
                break;
            case "POSTREQUEST_MOVE_POSTMOVE_RAW_PASSTHROUGH":
                $fResult = PostMoveHelper::PostMove(
                    $moves->TblMoves[0]->ColName,
                    $moves->TblMoves[0]->IdtblCharacters,
                    $moves->TblMoves[0]->IdtblDapplers
                    );
                break;
            case "POSTREQUEST_PULSE_POSTPULSE_RAW_PASSTHROUGH":
                $fResult = PostPulseHelper::PostPulse(
                    $pulses->TblPulses[0]->ColDescription,
                    $pulses->TblPulses[0]->IdtblDapplers
                    );
                break;
            case "GETREQUEST_MEMBER_GETMEMBERS":
                $fResult = GetMembersHelper::GetMembers(
                    $jSessionResponse->Members /*ref*/
                    );
                break;
            case "GETREQUEST_CHARACTER_GETCHARACTERS":
                $fResult = GetCharactersHelper::GetCharacters(
                    $jSessionResponse->Characters /*ref*/
                    );
                break;
            case "GETREQUEST_DAPPLER_GETDAPPLERS":
                $fResult = GetDapplersHelper::GetDapplers(
                    $jSessionResponse->Dapplers /*ref*/
                    );
                break;
            case "GETREQUEST_GAME_GETGAMES":
                $fResult = GetGamesHelper::GetGames(
                    $jSessionResponse->Games /*ref*/
                    );
                break;
            case "GETREQUEST_INPUTSEQUENCE_GETINPUTSEQUENCES":
                $fResult = GetInputSequencesHelper::GetInputSequences(
                    $jSessionResponse->InputSequences /*ref*/    
                    );
                break;
            case "GETREQUEST_MOVE_GETMOVES":
                $fResult = GetMovesHelper::GetMoves(
                    $jSessionResponse->Moves /*ref*/
                    );
                break;
            case "GETREQUEST_PULSE_GETPULSES":
                $fResult = GetPulsesHelper::GetPulses(
                    $jSessionResponse->Pulses /*ref*/
                    );
                break;
            case "GETREQUEST_EMAIL_GETTEMPLATEEMAILS":
                $fResult = GetTemplateEmailsHelper::GetTemplateEmails(
                    $jSessionResponse->TemplateEmails /*ref*/
                    );
                break;
            case "GETREQUEST_SESSION_GETSESSIONS":
                $fResult = GetSessionsHelper::GetSessions(
                    $jSessionResponse->Sessions /*ref*/
                    );
                break;
            case "UPDATEREQUEST_MEMBER_UPDATEPROFILE":
                $fResult = PostMemberHelper::UpdateMemberProfile(
                    $members->TblMembers[0]->IdtblMembers,
                    $members->TblMembers[0]->ColNameFirst,
                    $members->TblMembers[0]->ColEmailAddress,
                    $members->TblMembers[0]->ColBio
                    );
                break;
            case "UPDATEREQUEST_MEMBER_SEND_EMAIL_VERIFICATION":
                $fResult = PostMemberHelper::UpdateSendEmailVerification(
                    $members->TblMembers[0]->IdtblMembers,
                    $members->TblMembers[0]->ColEmailAddress
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
    
    public static function CreateSession(
        &$jSessionOut, /*ref*/
        $strIdtblMembers
    )
    {
        $fResult = false;
        $strGuidSession = Util::GenerateGuid();
        $strDtLastHeartBeat = Util::GetDateTimeString();
        $fResult = PostSessionHelper::PostSession(
            $strGuidSession,
            $strIdtblMembers,
            $strDtLastHeartBeat
            );
        if (true == $fResult)
        {
            //
            // Successfully created a user session instance.
            // Fill our server response with the good tidings:
            //
            $jSessionOut->Sessions->TblSessions[0]->IdtblSessions   = "SUPPRESSED_BY_SERVICE";
            $jSessionOut->Sessions->TblSessions[0]->GuidSession     = $strGuidSession;
            $jSessionOut->Sessions->TblSessions[0]->IdtblMembers    = $strIdtblMembers;
            $jSessionOut->Sessions->TblSessions[0]->DtLastHeartBeat = $strDtLastHeartBeat;
        }
        else
        {
            $jSessionOut->Dispatch->Message = "Session::CreateSession: Call to PostSessionHelper::PostSession() failed.";
            Trace::RespondToClientWithFailures($jSessionOut);
        }
        
        return $fResult;
    }
    
    public static function MemberSignIn(
        &$jSessionOut, /*ref*/
        $strUserName,
        $strPassword
    )
    {
        $fResult = false;
        $fResult = GetMembersHelper::MemberValidateCredentials($strUserName, $strPassword);
        if (true == $fResult)
        {
            $fResult = GetMembersHelper::GetMemberByAlias(/*ref*/ $jSessionOut->Members, $strUserName);
        }
        else
        {
            $jSessionOut->Dispatch->Message = "Session::ValidateMemberCredentials: Failure. Incorrect username or password.";
            Trace::RespondToClientWithFailure($jSessionOut);
        }
        
        return $fResult;
    }
    
    public static function MemberSignUpValidateFields(
        &$jSessionOut, /*ref*/
        $strUserNameAlias,
        $strEmailAddress,
        $strPassword
    )
    {
        $fResult = false;
        $fResult = GandalfBridge::ShallPassMemberPassword($strPassword);
        if (true == $fResult)
        {
            $fResult = GetMembersHelper::MemberExistsAlias($strUserNameAlias);
            if (true == $fResult)
            {
                $fResult = GetMembersHelper::MemberExistsEmailAddress($strEmailAddress);
                if (false == $fResult)
                {
                    $jSessionOut->Dispatch->Message = "Session::MemberSignUp: Email address has been taken.";
                    Trace::RespondToClientWithFailure($jSessionOut);
                }
            }
            else
            {
                $jSessionOut->Dispatch->Message = "Session::MemberSignUp: User name has been taken.";
                Trace::RespondToClientWithFailure($jSessionOut);                
            }
        }
        else
        {
            $jSessionOut->Dispatch->Message = "Session::MemberSignUp: Your password is weak.";
            Trace::RespondToClientWithFailure($jSessionOut);
        }        
        
        return $fResult;
    }
    
    public static function MemberSignUp(
        &$jSessionOut, /*ref*/
        $strUserNameAlias,
        $strUserNameFirst,
        $strUserNameLast,
        $strEmailAddress,
        $strPassword
        )
    {
        $fResult = false;
        
        //
        // Prior to the call to PostMember, we run a battery
        // of validation checks against all the params submitted
        // by the client via _MemberSignUpValidateFields:
        //
        $fResult = Session::MemberSignUpValidateFields(
            $jSessionOut,
            $strUserNameAlias,
            $strEmailAddress,
            $strPassword
            );
        if (true == $fResult)
        {
            $fResult = true;
            
            //
            // If we got here, the  password met Strong criteria:
            //  - password must be at least 8 characters AND
            //  - must contain at least one lower case letter AND
            //  - one upper case letter AND
            //  - one digit
            //
            $strDtMemberSince = Util::GetDateTimeString();
            $fResult = PostMemberHelper::PostMember(
                $strUserNameAlias,
                $strUserNameFirst,
                $strUserNameLast,
                $strEmailAddress,
                "false",
                $strPassword,
                "No bio provided.",
                $strDtMemberSince
                );
            if (true == $fResult)
            {
                //
                // Successfully created a new user! Fill our server response
                // with pertinent sign-in info for the User
                //
                $fResult = GetMembersHelper::GetMemberByAlias(/*ref*/ $jSessionOut->Members, $strUserNameAlias);
                if (false == $fResult)
                {
                    $jSessionOut->Dispatch->Message = "Session::MemberSignUp: Call to GetMembersHelper::GetMemberByAlias() failed.";
                    Trace::RespondToClientWithFailure($jSessionOut);
                }
            }
            else
            {
                $jSessionOut->Dispatch->Message = "Session::MemberSignUp: Call to PostMemberHelper::PostMember() failed.";
                Trace::RespondToClientWithFailure($jSessionOut);
            }
        }

        return $fResult;
    }
    
    public static function MemberPostCharacter(
        $tblSession,
        $tblDappler,
        $tblCharacter
    )
    {
        $fResult = false;
        $IdtblParentTable = 0;
        $IdtblDapples = 0;
        $idTblDapplers = 0;
        $fResult = PostDapplerHelper::PostDappler(
            $idTblDapplers,
            $IdtblParentTable,
            $tblDappler->ColtblParentTableName,
            $IdtblDapples,
            $tblDappler->ColDapplerState,
            $tblSession->IdtblMembers 
            );
        if (true == $fResult)
        {
            
            $fResult = PostCharacterHelper::PostCharacter(
                $tblCharacter->ColName,
                $tblCharacter->ColDescription,
                $tblCharacter->IdtblGames,
                $idTblDapplers
                );
            if (true == $fResult)
            {
                $strPulseDescription = "MemberID " . $tblSession->IdtblMembers . " " . $tblDappler->ColDapplerState . " a new character: " . $tblCharacter->ColName;
                $fResult = PostPulseHelper::PostPulse(
                    $strPulseDescription,
                    $idTblDapplers
                    );
            }            
        }
        
        return $fResult;
    }
    
    public static function MemberPostGame(
        $tblSession,
        $tblDappler,
        $tblGame
        )
    {
        $fResult = false;
        $IdtblParentTable = 0;
        $IdtblDapples = 0;
        $idTblDapplers = 0;
        $fResult = PostDapplerHelper::PostDappler(
            $idTblDapplers,
            $IdtblParentTable,
            $tblDappler->ColtblParentTableName,
            $IdtblDapples,
            $tblDappler->ColDapplerState,
            $tblSession->IdtblMembers
            );
        if (true == $fResult)
        {
            $fResult = PostGameHelper::PostGame(
                $tblGame->ColName,
                $tblGame->ColDeveloper,
                $tblGame->ColDeveloperURL,
                $tblGame->ColPublisher,
                $tblGame->ColPublisherURL,
                $tblGame->ColDescription,
                $idTblDapplers
                );
            if (true == $fResult)
            {
                $strPulseDescription = "MemberID " . $tblSession->IdtblMembers . " " . $tblDappler->ColDapplerState . " a new game: " . $tblGame->ColName;
                $fResult = PostPulseHelper::PostPulse(
                    $strPulseDescription,
                    $idTblDapplers
                    );
            }
        }
        
        return $fResult;
    }
    
    public static function MemberPostMove(
        $tblSession,
        $tblDappler,
        $tblMove
    )
    {
        $fResult = false;
        $IdtblParentTable = 0;
        $IdtblDapples = 0;
        $fResult = PostDapplerHelper::PostDappler(
            $IdtblParentTable,
            $tblDappler->ColtblParentTableName,
            $IdtblDapples,
            $tblDappler->ColDapplerState,
            $tblSession->IdtblMembers    
            );
        if (true == $fResult)
        {
            $idTblDapplers = 0;
            $fResult = PostMoveHelper::PostMove(
                $tblMove->ColName,
                $tblMove->IdtblCharacters,
                $idTblDapplers
            );
            if (true == $fResult)
            {
                $strPulseDescription = "MemberID " . $tblSession->IdtblMembers . " " . $tblDappler->ColDapplerState . " a new move: " . $tblMove->ColName;
                $fResult = PostPulseHelper::PostPulse(
                    $strPulseDescription,
                    $idTblDapplers
                    );
            }            
        }
        
        return $fResult;
    }  
}

?>
