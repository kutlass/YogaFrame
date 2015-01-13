<?php

require_once ('./Util.php');
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
        $games          = $jSessionRequest->Games;
        $sessions       = $jSessionRequest->Sessions;
        
        $valDapplersIdtblParentTable      = $dapplers->TblDapplers[0]->IdtblParentTable;
        $valDapplersColtblParentTableName = $dapplers->TblDapplers[0]->ColtblParentTableName;
        $valDapplersIdtblDapples          = $dapplers->TblDapplers[0]->IdtblDapples;
        $valDapplersColDapplerState       = $dapplers->TblDapplers[0]->ColDapplerState;
        $valDapplersIdtblMembers           = $dapplers->TblDapplers[0]->IdtblMembers;
    
        $valCharactersColName        = $characters->TblCharacters[0]->ColName;
        $valCharactersColDescription = $characters->TblCharacters[0]->ColDescription;
        $valCharactersIdtblGames     = $characters->TblCharacters[0]->IdtblGames;
        
        $valColName         = $games->TblGames[0]->ColName;
        $valColDeveloper    = $games->TblGames[0]->ColDeveloper;
        $valColDeveloperURL = $games->TblGames[0]->ColDeveloperURL;
        $valColPublisher    = $games->TblGames[0]->ColPublisher;
        $valColPublisherURL = $games->TblGames[0]->ColPublisherURL;
        $valColDescription  = $games->TblGames[0]->ColDescription;
        
        $valInputSequencesIdtblMoves    = $inputSequences->TblInputSequences[0]->IdtblMoves;
        $valInputSequencesIdtblDapplers = $inputSequences->TblInputSequences[0]->IdtblDapplers;
        
        $valColNameAlias        = $members->TblMembers[0]->ColNameAlias;
        $valColNameFirst        = $members->TblMembers[0]->ColNameFirst;
        $valColNameLast         = $members->TblMembers[0]->ColNameLast;
        $valColEmailAddress     = $members->TblMembers[0]->ColEmailAddress;
        $valColIsEmailVerified  = $members->TblMembers[0]->ColIsEmailVerified;        
        $valColPasswordSaltHash = $members->TblMembers[0]->ColPasswordSaltHash;
        $valColBio              = $members->TblMembers[0]->ColBio;
        $valColDtMemberSince    = $members->TblMembers[0]->ColDtMemberSince;
        
        $valMovesColName       = $moves->TblMoves[0]->ColName;
        $valMovesIdtblDapplers = $moves->TblMoves[0]->IdtblDapplers;
        
        $valGuidSession     = $sessions->TblSessions[0]->GuidSession;
        $valIdtblMembers    = $sessions->TblSessions[0]->IdtblMembers;
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
                    $jSessionResponse, /*ref*/
                    $valColNameAlias,
                    $valColNameFirst,
                    $valColNameLast,
                    $valColEmailAddress,
                    $valColPasswordSaltHash,
                    $valColBio
                    );
                break;
            case "POSTREQUEST_SESSION_POSTSESSION_RAW_PASSTHROUGH":
                $fResult = PostSessionHelper::PostSession(
                    $valGuidSession,
                    $valIdtblMembers,
                    $valDtLastHeartBeat
                    );
                break;
            case "POSTREQUEST_MEMBER_POSTMEMBER_RAW_PASSTHROUGH":
                $fResult = PostMemberHelper::PostMember(
                    $valColNameAlias,
                    $valColNameFirst,
                    $valColNameLast,
                    $valColEmailAddress,
                    $valColIsEmailVerified,
                    $valColPasswordSaltHash,
                    $valColBio,
                    $valColDtMemberSince
                    );
                break;
            case "POSTREQUEST_CHARACTER_POSTCHARACTER_RAW_PASSTHROUGH":
                $fResult = PostCharacterHelper::PostCharacter(
                    $valCharactersColName,
                    $valCharactersColDescription,
                    $valCharactersIdtblGames        
                    );
                break;
            case "POSTREQUEST_DAPPLER_POSTDAPPLER_RAW_PASSTHROUGH":
                $fResult = PostDapplerHelper::PostDappler(
                    $valDapplersIdtblParentTable,
                    $valDapplersColtblParentTableName,
                    $valDapplersIdtblDapples,
                    $valDapplersColDapplerState,
                    $valDapplersIdtblMembers
                    );
                break;
            case "POSTREQUEST_GAME_POSTGAME_RAW_PASSTHROUGH":
                $fResult = PostGameHelper::PostGame(
                    $valColName,
                    $valColDeveloper,
                    $valColDeveloperURL,
                    $valColPublisher,
                    $valColPublisherURL,
                    $valColDescription
                    );
                break;
            case "POSTREQUEST_INPUTSEQUENCE_POSTINPUTSEQUENCE_RAW_PASSTHROUGH":
                $fResult = PostInputSequenceHelper::PostInputSequence(
                    $valInputSequencesIdtblMoves,
                    $valInputSequencesIdtblDapplers
                    );
                break;
            case "POSTREQUEST_MOVE_POSTMOVE_RAW_PASSTHROUGH":
                $fResult = PostMoveHelper::PostMove(
                    $valMovesColName,
                    $valMovesIdtblDapplers
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
            case "GETREQUEST_SESSION_GETSESSIONS":
                $fResult = GetSessionsHelper::GetSessions(
                    $jSessionResponse->Sessions /*ref*/
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
                $fResult = GetMembersHelper::GetMemberByAlias(/*ref*/ $jSessionOut->Members, $strUserNameAlias);
                if (true == $fResult)
                {
                    //
                    // Successfully added a new user account! Now that we have that
                    // under our belts, let's give him/her a new YogaFrame Session
                    // token to facilitate their trods along our amusement park.
                    //
                    $strNewlyCreatedMemberId = $jSessionOut->Members->TblMembers[0]->IdtblMembers;
                    $sessionToken = new Sessions();
                    $sessionToken->TblSessions = array( new TblSession() );
                    $sessionToken->TblSessions[0]->GuidSession = Util::GenerateGuid();
                    $sessionToken->TblSessions[0]->IdtblMembers = $strNewlyCreatedMemberId;
                    $sessionToken->TblSessions[0]->DtLastHeartBeat = Util::GetDateTimeString();
                    $fResult = PostSessionHelper::PostSession(
                        $sessionToken->TblSessions[0]->GuidSession,
                        $sessionToken->TblSessions[0]->IdtblMembers,
                        $sessionToken->TblSessions[0]->DtLastHeartBeat
                        );
                    if (true == $fResult)
                    {
                        //
                        // Session token creation succeeded. Record as such
                        // in our server response: $jSessionOut->Sessions
                        //
                        $fResult = GetSessionsHelper::GetSessionByMemberId(/*ref*/ $jSessionOut->Sessions, $strNewlyCreatedMemberId);
                        if (false == $fResult)
                        {
                            $jSession = new JSession();
                            $jSession->Dispatch = new Dispatch();
                            $jsession->Dispatch->Message = "Session::MemberSignUp: Call to PostSessionHelper::PostSession() failed.";
                            Trace::RespondToClientWithFailure($jSession);
                        }
                    }
                    else
                    {
                        $jSession = new JSession();
                        $jSession->Dispatch = new Dispatch();
                        $jsession->Dispatch->Message = "Session::MemberSignUp: Call to GetSessionsHelper::GetSessionByMemberId() failed.";
                        Trace::RespondToClientWithFailure($jSession);
                    }
                }
                else
                {
                    $jSession = new JSession();
                    $jSession->Dispatch = new Dispatch();
                    $jsession->Dispatch->Message = "Session::MemberSignUp: Call to GetMembersHelper::GetMemberByAlias() failed.";
                    Trace::RespondToClientWithFailure($jSession);
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
