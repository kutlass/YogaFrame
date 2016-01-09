using System;
using System.Collections.Generic;

using YogaFrameDeploy;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.CharactersJsonTypes;
using YogaFrameWebAdapter.GamesJsonTypes;
using YogaFrameWebAdapter.DapplersJsonTypes;
using YogaFrameWebAdapter.InputSequencesJsonTypes;
using YogaFrameWebAdapter.MembersJsonTypes;
using YogaFrameWebAdapter.MovesJsonTypes;
using YogaFrameWebAdapter.PulsesJsonTypes;
using YogaFrameWebAdapter.SessionsJsonTypes;
using YogaFrameWebAdapter.Session;
using YogaFrameWebAdapter.TemplateEmailsJsonTypes;
using YogaFrameWebAdapter.JSessionJsonTypes;

namespace UnitTests
{
    using NUnit.Framework;
    
    [TestFixture]
    public class YogaFrameDeploymentTest
    {
        [Test]
        public void DeployFullService()
        {
            bool fResult = false;
            fResult = Deployment.DeployFullService();

            Assert.IsTrue(fResult);
        }

        [Test]
        public void DatabaseConnect()
        {
            // TODO: Write unit test. Fail test case while not implemented
            Assert.AreEqual(1, 2);
        }

        [Test]
        public void DatabaseDeploy()
        {
            // TODO: Write unit test. Fail test case while not implemented
            Assert.AreEqual(1, 2);
        }

        [Test]
        public void DatabaseBackup()
        {
            // TODO: Write unit test. Fail test case while not implemented
            Assert.AreEqual(1, 2);
        }

        [Test]
        public void DatabaseRestore()
        {
            const string strUserName = "TestDataUser01";
            const string strUserNameFirst = "Test";
            const string strUserNameLast = "DataUser01";
            const string strUserEmailAddress = "TestDataUser01@TestDataUser01.net";
            const string strPasswordMatchEntry1 = "PoweredBy#FGC8675309";
            const string strPasswordMatchEntry2 = "PoweredBy#FGC8675309";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = Session.Instance.MemberSignUp(
                strUserName,
                strUserNameFirst,
                strUserNameLast,
                strUserEmailAddress,
                strPasswordMatchEntry1,
                strPasswordMatchEntry2
                );
            Assert.NotNull(jSessionWebResponse);
            const string S_OK = "S_OK";
            Assert.AreEqual(S_OK, jSessionWebResponse.Dispatch.Message);

            jSessionWebResponse = null;
            jSessionWebResponse = Session.Instance.MemberSignIn(
                strUserName,
                strPasswordMatchEntry1
                );
            
            //
            // Restore MySQL data based on what's stored inside TestData.cs
            //
            // Step 1: Restore Games list
            TestData testData = new TestData();
            foreach (TblGame game in testData.listTblGames)
            {
                Games games = new Games();
                games.TblGames = new TblGame[1];
                games.TblGames[0] = game;
                bool fResult = false;
                fResult = Session.Instance.MemberPostGame(ref games);
                Assert.IsTrue(fResult);
            }
            // Step 2: Restore Characters list
            foreach (TblCharacter character in testData.listTblCharacters)
            {
                Characters characters = new Characters();
                characters.TblCharacters = new TblCharacter[1];
                characters.TblCharacters[0] = character;
                bool fResult = false;
                fResult = Session.Instance.MemberPostCharacter(ref characters);
                Assert.IsTrue(fResult);
            }
            // Step 3: Restore Moves list
            foreach (TblMove move in testData.listTblMoves)
            {
                Moves moves = new Moves();
                moves.TblMoves = new TblMove[1];
                moves.TblMoves[0] = move;
                bool fResult = false;
                fResult = Session.Instance.MemberPostMove(ref moves);
                Assert.IsTrue(fResult);
            }
        }
    }

    [TestFixture]
    public class YogaFrameClientTest
    {
        [Test]
        public void GetGames()
        {
            //
            // Make the fetch call with official API, ensure a non-null JSession object is returned
            //
            JSession jSession = null;
            jSession = WebAdapter.WebGetGames();
            Assert.NotNull(jSession);
            Assert.AreEqual("S_OK", jSession.Dispatch.Message);
        }

        [Test]
        public void PostGame()
        {
            //
            // Fill the Games object fields mimick a user-submited data row
            //
            Games gamesExpected = new Games();
            List<TblGame> tblGamesExpected = new List<TblGame>
            {
                new TblGame()
                {
                    ColName         = "Ultra Street Fighter IV",
                    ColDeveloper    = "Capcom",
                    ColDeveloperURL = "www.capcom.com",
                    ColPublisher    = "Capcom Publishing",
                    ColPublisherURL = "www.capcompublishing.com",
                    ColDescription  = "Best game EVARR!! YEEE!!!.",
                    IdtblDapplers   = "411"
                }
            };
            gamesExpected.TblGames = tblGamesExpected.ToArray();

            //
            // POST the above data with official WebPostGame() API
            //
            JSession jSessionWebResponseWebPostGame = null;
            jSessionWebResponseWebPostGame = WebAdapter.WebPostGame(ref gamesExpected);
            Assert.NotNull(jSessionWebResponseWebPostGame);
            Assert.AreEqual("S_OK", jSessionWebResponseWebPostGame.Dispatch.Message);

            //
            // Fetch actual results with official API
            //
            JSession jSessionWebResponseWebGetGames = null;
            jSessionWebResponseWebGetGames = WebAdapter.WebGetGames();
            Assert.NotNull(jSessionWebResponseWebGetGames);
            Assert.NotNull(jSessionWebResponseWebGetGames.Games);
            Assert.AreEqual("S_OK", jSessionWebResponseWebGetGames.Dispatch.Message);
            Games gamesActual = jSessionWebResponseWebGetGames.Games;      

            //============================
            // Validate the 2 result sets:
            //  - gamesExpected
            //  - gamesActual
            //============================

            // Are expected number of rows returned?           
            Assert.AreEqual(gamesExpected.TblGames.Length, gamesActual.TblGames.Length);

            // Are expected fields equal?
            for (int i = 0; i < gamesExpected.TblGames.Length; i++)
            {
                TblGame rowExpected = gamesExpected.TblGames[i];
                TblGame rowActual = gamesActual.TblGames[i];

                Assert.AreEqual(rowExpected.ColName,            rowActual.ColName);
                Assert.AreEqual(rowExpected.ColDeveloper,       rowActual.ColDeveloper);
                Assert.AreEqual(rowExpected.ColDeveloperURL,    rowActual.ColDeveloperURL);
                Assert.AreEqual(rowExpected.ColPublisher,       rowActual.ColPublisher);
                Assert.AreEqual(rowExpected.ColPublisherURL,    rowActual.ColPublisherURL);
                Assert.AreEqual(rowExpected.ColDescription,     rowActual.ColDescription);
                Assert.AreEqual(rowExpected.IdtblDapplers,      rowActual.IdtblDapplers);
            }
        }

        [Test]
        public void PostCharacter()
        {
            //
            // Fill the Characters object fields mimick a user-submited data row
            //
            List<TblCharacter> tblCharactersExpected = new List<TblCharacter>
            {
                new TblCharacter(){ ColName = "Max", ColDescription = "Leader of the clan.", IdtblGames = "671", IdtblDapplers = "411" }
            };
            Characters charactersExpected = new Characters();
            charactersExpected.TblCharacters = tblCharactersExpected.ToArray();

            //
            // POST the above data with official WebPostCharacter() API
            //
            JSession jSessionWebResponseWebPostCharacter = null;
            jSessionWebResponseWebPostCharacter = WebAdapter.WebPostCharacter(ref charactersExpected);
            Assert.NotNull(jSessionWebResponseWebPostCharacter);
            Assert.AreEqual("S_OK", jSessionWebResponseWebPostCharacter.Dispatch.Message);

            //
            // Fetch actual results with official WebGetCharacters() API
            //
            JSession jSessionWebResponseWebGetCharacters = null;
            jSessionWebResponseWebGetCharacters = WebAdapter.WebGetCharacters();
            Assert.NotNull(jSessionWebResponseWebGetCharacters);
            Assert.AreEqual("S_OK", jSessionWebResponseWebGetCharacters.Dispatch.Message);
            Assert.NotNull(jSessionWebResponseWebGetCharacters.Characters);
            Assert.NotNull(jSessionWebResponseWebGetCharacters.Characters.TblCharacters);
            Characters charactersActual = jSessionWebResponseWebGetCharacters.Characters;

            //============================
            // Validate the 2 result sets:
            //  - charactersExpected
            //  - charactersActual
            //============================

            // Are expected number of rows returned?           
            Assert.AreEqual(charactersExpected.TblCharacters.Length, charactersActual.TblCharacters.Length);

            // Are expected fields equal?
            for (int i = 0; i < charactersExpected.TblCharacters.Length; i++)
            {
                TblCharacter rowExpected = charactersExpected.TblCharacters[i];
                TblCharacter rowActual = charactersActual.TblCharacters[i];

                Assert.AreEqual(rowExpected.ColName, rowActual.ColName);
                Assert.AreEqual(rowExpected.ColDescription, rowActual.ColDescription);
                Assert.AreEqual(rowExpected.IdtblGames, rowActual.IdtblGames);
                Assert.AreEqual(rowExpected.IdtblDapplers, rowActual.IdtblDapplers);
            }
        }

        [Test]
        public void PostDappler()
        {
            //
            // Fill the Dapplers object fields mimicking a user-submited data row
            //
            List<TblDappler> tblDapplersExpected = new List<TblDappler>
            {
                new TblDappler()
                {
                    IdtblDapplers = "69",
                    IdtblParentTable = "86",
                    ColtblParentTableName = "Games",
                    IdtblDapples = "75",
                    ColDapplerState = "SEEDED",
                    IdtblMembers = "309"
                }
            };
            Dapplers dapplersExpected = new Dapplers();
            dapplersExpected.TblDapplers = tblDapplersExpected.ToArray();

            //
            // POST the above data with official WebPostDappler() API
            //
            JSession jSessionWebResponseWebPostDappler = null;
            jSessionWebResponseWebPostDappler = WebAdapter.WebPostDappler(ref dapplersExpected);
            Assert.NotNull(jSessionWebResponseWebPostDappler);
            Assert.AreEqual("S_OK", jSessionWebResponseWebPostDappler.Dispatch.Message);

            //
            // FETCH actual results with official API
            //
            JSession jSessionWebResponseWebGetDapplers = null;
            jSessionWebResponseWebGetDapplers = WebAdapter.WebGetDapplers();
            Assert.NotNull(jSessionWebResponseWebGetDapplers);
            Assert.AreEqual("S_OK", jSessionWebResponseWebGetDapplers.Dispatch.Message);
            Assert.NotNull(jSessionWebResponseWebGetDapplers.Dapplers);
            Dapplers dapplersActual = jSessionWebResponseWebGetDapplers.Dapplers;

            //============================
            // Validate the 2 result sets:
            //  - dapplersExpected
            //  - dapplersActual
            //============================

            // Are expected number of rows returned?           
            Assert.AreEqual(dapplersExpected.TblDapplers.Length, dapplersActual.TblDapplers.Length);

            // Are expected fields equal?
            for (int i = 0; i < dapplersExpected.TblDapplers.Length; i++)
            {
                TblDappler rowExpected = dapplersExpected.TblDapplers[i];
                TblDappler rowActual = dapplersActual.TblDapplers[i];

                Assert.AreEqual(rowExpected.IdtblParentTable, rowActual.IdtblParentTable);
                Assert.AreEqual(rowExpected.ColtblParentTableName, rowActual.ColtblParentTableName);
                Assert.AreEqual(rowExpected.IdtblDapples, rowActual.IdtblDapples);
                Assert.AreEqual(rowExpected.ColDapplerState, rowActual.ColDapplerState);
                Assert.AreEqual(rowExpected.IdtblMembers, rowActual.IdtblMembers);
            }
        }

        [Test]
        public void PostInputSequence()
        {
            //
            // Fill the InputSequences object fields mimicking a user-submited data row
            //
            List<TblInputSequence> TblInputSequencesExpected = new List<TblInputSequence>
            {
                new TblInputSequence(){IdtblMoves = "41", IdtblDapplers = "8675309"}
            };
            InputSequences inputSequencesExpected = new InputSequences();
            inputSequencesExpected.TblInputSequences = TblInputSequencesExpected.ToArray();

            //
            // POST the above data with official WebPostInputSequence() API
            //
            JSession jSessionWebResponseWebPostInputSequence = null;
            jSessionWebResponseWebPostInputSequence = WebAdapter.WebPostInputSequence(ref inputSequencesExpected);
            Assert.NotNull(jSessionWebResponseWebPostInputSequence);
            Assert.AreEqual("S_OK", jSessionWebResponseWebPostInputSequence.Dispatch.Message);

            //
            // FETCH actual results with official WebGetInputSequences API
            //
            JSession jSessionWebResponseWebGetInputSequences = null;
            jSessionWebResponseWebGetInputSequences = WebAdapter.WebGetInputSequences();
            Assert.NotNull(jSessionWebResponseWebGetInputSequences);
            Assert.NotNull(jSessionWebResponseWebGetInputSequences.InputSequences);
            InputSequences inputSequencesActual = jSessionWebResponseWebGetInputSequences.InputSequences;

            //============================
            // Validate the 2 result sets:
            //  - inputSequencesExpected
            //  - inputSequencesActual
            //============================

            // Are expected number of rows returned?           
            Assert.AreEqual(inputSequencesExpected.TblInputSequences.Length, inputSequencesActual.TblInputSequences.Length);

            // Are expected fields equal?
            for (int i = 0; i < inputSequencesExpected.TblInputSequences.Length; i++)
            {
                TblInputSequence rowExpected = inputSequencesExpected.TblInputSequences[i];
                TblInputSequence rowActual = inputSequencesActual.TblInputSequences[i];

                Assert.AreEqual(rowExpected.IdtblMoves, rowActual.IdtblMoves);
                Assert.AreEqual(rowExpected.IdtblDapplers, rowActual.IdtblDapplers);
            }
        }

        [Test]
        public void PostMember()
        {
            //
            // Fill the Members object fields mimicking a user-submited data row
            //
            List<TblMember> TblMembersExpected = new List<TblMember>
            {
                new TblMember(){ColNameAlias = "kutlassx", ColNameFirst = "Karl", ColNameLast = "Flores", ColEmailAddress = "kutlassx@hotmail.com", ColIsEmailVerified = "1", ColPasswordSaltHash = "asdf;lkjUnitTestPostMember()", ColBio = "Oh HEY!! I did not see you there! Bio provided via RAW PASSTHROUGH.", ColDtMemberSince = "Since Ever Since..."}
            };
            Members membersExpected = new Members();
            membersExpected.TblMembers = TblMembersExpected.ToArray();

            const string POSTREQUEST_MEMBER_POSTMEMBER_RAW_PASSTHROUGH = "POSTREQUEST_MEMBER_POSTMEMBER_RAW_PASSTHROUGH";
            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            jSessionWebRequest.Dispatch.Message = POSTREQUEST_MEMBER_POSTMEMBER_RAW_PASSTHROUGH;
            jSessionWebRequest.Members = membersExpected;

            //
            // POST the above data with official WebPostMember() API
            //
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);
            Assert.NotNull(jSessionWebResponse);
            Assert.NotNull(jSessionWebRequest);
            JSession jSessionExpected = new JSession();
            jSessionExpected.Dispatch = new Dispatch();
            const string S_OK = "S_OK";
            jSessionExpected.Dispatch.Message = S_OK;
            Assert.AreEqual(jSessionExpected.Dispatch.Message, jSessionWebResponse.Dispatch.Message);

            //
            // FETCH actual results with official WebGetMembers API
            //
            JSession jSessionWebResponseWebGetMembers = null;
            jSessionWebResponseWebGetMembers = WebAdapter.WebGetMembers();
            Assert.NotNull(jSessionWebResponseWebGetMembers);
            Assert.AreEqual("S_OK", jSessionWebResponseWebGetMembers.Dispatch.Message);
            Members membersActual = jSessionWebResponseWebGetMembers.Members;

            //============================
            // Validate the 2 result sets:
            //  - membersExpected
            //  - membersActual
            //============================

            // Are expected number of rows returned?           
            Assert.AreEqual(membersExpected.TblMembers.Length, membersActual.TblMembers.Length);

            // Are expected fields equal?
            for (int i = 0; i < membersExpected.TblMembers.Length; i++)
            {
                TblMember rowExpected = membersExpected.TblMembers[i];
                TblMember rowActual = membersActual.TblMembers[i];

                Assert.AreEqual(rowExpected.ColNameAlias,           rowActual.ColNameAlias);
                Assert.AreEqual(rowExpected.ColNameFirst,           rowActual.ColNameFirst);
                Assert.AreEqual(rowExpected.ColNameLast,            rowActual.ColNameLast);
                Assert.AreEqual(rowExpected.ColEmailAddress,        rowActual.ColEmailAddress);
                Assert.AreEqual(rowExpected.ColIsEmailVerified,     rowActual.ColIsEmailVerified);
                Assert.AreEqual(rowExpected.ColPasswordSaltHash,    rowActual.ColPasswordSaltHash);
                Assert.AreEqual(rowExpected.ColBio,                 rowActual.ColBio);
                Assert.AreEqual(rowExpected.ColDtMemberSince,       rowActual.ColDtMemberSince);
            }
        }

        [Test]
        public void PostMove()
        {
            //
            // Fill the Moves object fields mimicking a user-submited data row
            //
            List<TblMove> TblMovesExpected = new List<TblMove>
            {
                new TblMove(){ColName = "Yoga Flame", IdtblCharacters = "41", IdtblDapplers = "671"}
            };
            Moves movesExpected = new Moves();
            movesExpected.TblMoves = TblMovesExpected.ToArray();

            //
            // POST the above data with official WebPostMove() API
            //
            JSession jSessionWebResponseWebPostMove = null;
            jSessionWebResponseWebPostMove = WebAdapter.WebPostMove(ref movesExpected);
            Assert.NotNull(jSessionWebResponseWebPostMove);
            Assert.AreEqual("S_OK", jSessionWebResponseWebPostMove.Dispatch.Message);

            //
            // FETCH actual results with official API
            //
            JSession jSessionWebResponseWebGetMoves = null;
            jSessionWebResponseWebGetMoves = WebAdapter.WebGetMoves();
            Assert.NotNull(jSessionWebResponseWebGetMoves);
            Assert.AreEqual("S_OK", jSessionWebResponseWebGetMoves.Dispatch.Message);
            Assert.NotNull(jSessionWebResponseWebGetMoves.Moves);
            Assert.NotNull(jSessionWebResponseWebGetMoves.Moves.TblMoves);
            Moves movesActual = jSessionWebResponseWebGetMoves.Moves;

            //============================
            // Validate the 2 result sets:
            //  - movesExpected
            //  - movesActual
            //============================

            // Are expected number of rows returned?           
            Assert.AreEqual(movesExpected.TblMoves.Length, movesActual.TblMoves.Length);

            // Are expected fields equal?
            for (int i = 0; i < movesExpected.TblMoves.Length; i++)
            {
                TblMove rowExpected = movesExpected.TblMoves[i];
                TblMove rowActual = movesActual.TblMoves[i];

                Assert.AreEqual(rowExpected.ColName, rowActual.ColName);
                Assert.AreEqual(rowExpected.IdtblCharacters, rowActual.IdtblCharacters);
                Assert.AreEqual(rowExpected.IdtblDapplers, rowActual.IdtblDapplers);
            }
        }

        [Test]
        public void PostPulse()
        {
            //
            // Fill the Pulses object fields mimicking a user-submited data row
            //
            List<TblPulse> TblPulsesExpected = new List<TblPulse>
            {
                new TblPulse(){ColDescription = "kutlass SEEDED a new FGC game called [Dive Kick]. Legit? VOTE NOW!", IdtblDapplers = "8675309"}
            };
            Pulses pulsesExpected = new Pulses();
            pulsesExpected.TblPulses = TblPulsesExpected.ToArray();

            //
            // POST the above data with official WebPostPulse() API
            //
            JSession jSessionWebResponseWebPostPulse = null;
            jSessionWebResponseWebPostPulse = WebAdapter.WebPostPulse(ref pulsesExpected);
            Assert.NotNull(jSessionWebResponseWebPostPulse);
            Assert.AreEqual("S_OK", jSessionWebResponseWebPostPulse.Dispatch.Message);

            //
            // FETCH actual results with official WebGetPulses() API
            //
            JSession jSessionWebResponseWebGetPulses = null;
            jSessionWebResponseWebGetPulses = WebAdapter.WebGetPulses();
            Assert.NotNull(jSessionWebResponseWebGetPulses);
            Assert.AreEqual("S_OK", jSessionWebResponseWebGetPulses.Dispatch.Message);
            Assert.NotNull(jSessionWebResponseWebGetPulses.Pulses);
            Assert.NotNull(jSessionWebResponseWebGetPulses.Pulses.TblPulses);
            Pulses pulsesActual = jSessionWebResponseWebGetPulses.Pulses;

            //============================
            // Validate the 2 result sets:
            //  - pulsesExpected
            //  - pulsesActual
            //============================

            // Are expected number of rows returned?           
            Assert.AreEqual(pulsesExpected.TblPulses.Length, pulsesActual.TblPulses.Length);

            // Are expected fields equal?
            for (int i = 0; i < pulsesExpected.TblPulses.Length; i++)
            {
                TblPulse rowExpected = pulsesExpected.TblPulses[i];
                TblPulse rowActual = pulsesActual.TblPulses[i];

                Assert.AreEqual(rowExpected.ColDescription, rowActual.ColDescription);
                Assert.AreEqual(rowExpected.IdtblDapplers, rowActual.IdtblDapplers);
            }
        }

        [Test]
        public void PostTemplateEmail()
        {
            //
            // Fill the TemplateEmails object fields mimicking a user-submited data row
            //
            List<TblTemplateEmail> TblTemplateEmailsExpected = new List<TblTemplateEmail>
            {
                new TblTemplateEmail()
                {
                    ColHeaders = "From: webmaster@example.com",
                    ColSubject = "Automated Email: Welcome to YogaFrame!",
                    ColMessage = "Dear UserX, welcome to YogaFrame! We are glad to have you aboard. Get ready to LIVE!"
                }
            };
            TemplateEmails templateEmailsExpected = new TemplateEmails();
            templateEmailsExpected.TblTemplateEmails = TblTemplateEmailsExpected.ToArray();

            //
            // POST the above data with official WebPostTemplateEmail() API
            //
            JSession jSessionWebResponseWebPostTemplateEmail = null;
            jSessionWebResponseWebPostTemplateEmail = WebAdapter.WebPostTemplateEmail(ref templateEmailsExpected);
            Assert.NotNull(jSessionWebResponseWebPostTemplateEmail);
            Assert.AreEqual("S_OK", jSessionWebResponseWebPostTemplateEmail.Dispatch.Message);

            //
            // FETCH actual results with official WebGetTemplateEmails() API
            //
            JSession jSessionWebResponseWebGetTemplateEmails = null;
            jSessionWebResponseWebGetTemplateEmails = WebAdapter.WebGetTemplateEmails();
            Assert.NotNull(jSessionWebResponseWebGetTemplateEmails);
            Assert.AreEqual("S_OK", jSessionWebResponseWebGetTemplateEmails.Dispatch.Message);
            Assert.NotNull(jSessionWebResponseWebGetTemplateEmails.TemplateEmails);
            Assert.NotNull(jSessionWebResponseWebGetTemplateEmails.TemplateEmails.TblTemplateEmails);
            TemplateEmails templateEmailsActual = jSessionWebResponseWebGetTemplateEmails.TemplateEmails;

            //============================
            // Validate the 2 result sets:
            //  - templateEmailsExpected
            //  - templateEmailsActual
            //============================

            // Are expected number of rows returned?           
            Assert.AreEqual(templateEmailsExpected.TblTemplateEmails.Length, templateEmailsActual.TblTemplateEmails.Length);

            // Are expected fields equal?
            for (int i = 0; i < templateEmailsExpected.TblTemplateEmails.Length; i++)
            {
                TblTemplateEmail rowExpected = templateEmailsExpected.TblTemplateEmails[i];
                TblTemplateEmail rowActual = templateEmailsActual.TblTemplateEmails[i];

                Assert.AreEqual(rowExpected.ColHeaders, rowActual.ColHeaders);
                Assert.AreEqual(rowExpected.ColSubject, rowActual.ColSubject);
                Assert.AreEqual(rowExpected.ColMessage, rowActual.ColMessage);
            }
        }

        [Test]
        public void PostSession()
        {
            //
            // Fill the Sessions object fields mimicking a user-submited data row
            //
            List<TblSession> TblSessionsExpected = new List<TblSession>
            {
                new TblSession(){GuidSession = "{62b4eb67-80f0-4c70-bfc4-bcfa09a10073}", IdtblMembers = "17", DtLastHeartBeat = "01/12/2015_PostSessionUnitTest"}
            };         
            const string POSTREQUEST_SESSION_POSTSESSION_RAW_PASSTHROUGH = "POSTREQUEST_SESSION_POSTSESSION_RAW_PASSTHROUGH";
            Dispatch dsptchWebRequest = new Dispatch();
            dsptchWebRequest.Message = POSTREQUEST_SESSION_POSTSESSION_RAW_PASSTHROUGH;
            Sessions sessionsExpected = new Sessions();
            sessionsExpected.TblSessions = TblSessionsExpected.ToArray();
            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = dsptchWebRequest;
            jSessionWebRequest.Sessions = sessionsExpected;

            //
            // POST the above data with official WebPostJSession() API
            //
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);

            //
            // FETCH actual results with official API
            //
            JSession jSessionWebResponseWebGetSessions = null;
            jSessionWebResponseWebGetSessions = WebAdapter.WebGetSessions();
            Assert.NotNull(jSessionWebResponseWebGetSessions);
            Assert.AreEqual("S_OK", jSessionWebResponseWebGetSessions.Dispatch.Message);
            Sessions sessionsActual = jSessionWebResponseWebGetSessions.Sessions;

            //============================
            // Validate the 2 result sets:
            //  - sessionsExpected
            //  - sessionsActual
            //============================

            // Are expected number of rows returned?           
            Assert.AreEqual(sessionsExpected.TblSessions.Length, sessionsActual.TblSessions.Length);

            // Are expected fields equal?
            for (int i = 0; i < sessionsExpected.TblSessions.Length; i++)
            {
                TblSession rowExpected = sessionsExpected.TblSessions[i];
                TblSession rowActual = sessionsActual.TblSessions[i];

                Assert.AreEqual(rowExpected.GuidSession, rowActual.GuidSession);
                Assert.AreEqual(rowExpected.IdtblMembers, rowActual.IdtblMembers);
                Assert.AreEqual(rowExpected.DtLastHeartBeat, rowActual.DtLastHeartBeat);
            }
        }

        [Test]
        public void GetCharacters()
        {
            //
            // Make the fetch call with official API, ensure a non-null JSession object is returned
            //
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebGetCharacters();
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);
        }

        [Test]
        public void GetMembers()
        {
            //
            // Make the fetch call with official API, ensure a non-null JSession object is returned
            //
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebGetMembers();
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);
        }

        [Test]
        public void GetPulses()
        {
            //
            // Make the fetch call with official API, ensure a non-null JSession object is returned
            //
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebGetPulses();
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);
        }

        [Test]
        public void GetSessions()
        {
            //
            // Make the fetch call with official API, ensure a non-null JSession object is returned
            //
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebGetSessions();
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);
        }

        [Test]
        public void GetTemplateEmails()
        {
            //
            // Make the fetch call with official API, ensure a non-null JSession object is returned
            //
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebGetTemplateEmails();
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);
        }

        [Test]
        public void GetMoves()
        {
            //
            // Make the fetch call with official API, ensure a non-null JSession object is returned
            //
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebGetMoves();
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);
        }

        [Test]
        public void GetInputSequences()
        {
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebGetInputSequences();
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);
        }

        /* Perhaps a test for a post-V1 version of YogaFrame
        [Test]
        public void GetInputSchema()
        {
            WebAdapter.WebGetInputSchema();

            // TODO: Write unit test. Fail test case while not implemented
            Assert.AreEqual(1, 2);
        }
        */

        [Test]
        public void GetDapplers()
        {
            //
            // Make the fetch call with official API, ensure a non-null Dapplers object is returned
            //
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebGetDapplers();
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);
        }
    }

    [TestFixture]
    public class YogaFrameSessionTest
    {
        [Test]
        public void SessionMemberSignIn()
        {
            const string strUserName = "kutlass";
            const string strPassword = "PoweredBy#FGC8675309";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = Session.Instance.MemberSignIn(strUserName, strPassword);
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);
            Assert.NotNull(jSessionWebResponse.Members);
            Assert.NotNull(jSessionWebResponse.Members.TblMembers);
            Assert.NotNull(jSessionWebResponse.Sessions);
            Assert.NotNull(jSessionWebResponse.Sessions.TblSessions);

            //
            // Did we recieve a well-formed session GUID from the service?
            //
            //Guid guid = new Guid();
            //bool fResultGuidTryParse = false;
            // TODO: Find alternative API now that we're down-compiling to .NET 2.0 // fResultGuidTryParse = Guid.TryParse(jSessionWebResponse.Sessions.TblSessions[0].GuidSession, out guid);
            //Assert.IsTrue(fResultGuidTryParse);

            //
            // Did we recieve a well-formed DateTime session heartbeat?
            //
            DateTime datetime = new DateTime();
            bool fResultDateTimeTryParse = false;
            fResultDateTimeTryParse = DateTime.TryParse(jSessionWebResponse.Sessions.TblSessions[0].DtLastHeartBeat, out datetime);
            Assert.IsTrue(fResultDateTimeTryParse);

            //
            // Did we recieve all expected Members fields?
            //
            List<TblMember> tblMembersExpected = new List<TblMember>
            {
                new TblMember()
                {
                    ColNameAlias = strUserName,
                }
            };
            Members membersExpected = new Members();
            membersExpected.TblMembers = tblMembersExpected.ToArray();
            Members membersActual = jSessionWebResponse.Members;
            Assert.AreEqual(membersExpected.TblMembers.Length, membersActual.TblMembers.Length);
            Assert.AreEqual(membersExpected.TblMembers[0].ColNameAlias, membersActual.TblMembers[0].ColNameAlias);
        }

        [Test]
        public void SessionMemberSignInWrongUserName()
        {
            const string strUserName = "kutlassWRONG";
            const string strPassword = "PoweredBy#FGC8675309";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = Session.Instance.MemberSignIn(strUserName, strPassword);
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("Session::ValidateMemberCredentials: Failure. Incorrect username or password.", jSessionWebResponse.Dispatch.Message);
        }

        [Test]
        public void SessionMemberSignInMalformedUserName()
        {
            const string strUserName = "√kutlass";
            const string strPassword = "PoweredBy#FGC8675309";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = Session.Instance.MemberSignIn(strUserName, strPassword);
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("Session::ValidateMemberName Failure. Malformed member name.", jSessionWebResponse.Dispatch.Message);
        }

        [Test]
        public void SessionMemberSignUpMalformedUserName()
        {
            const string strUserName = "√kutlass";
            const string strUserNameFirst = "Karl";
            const string strUserNameLast = "Flores";
            const string strUserEmailAddress = "SessionMemberSignUnMalformedUserName@SessionMemberSignUnMalformedUserName.net";
            const string strPasswordMatchEntry1 = "PoweredBy#FGC8675309";
            const string strPasswordMatchEntry2 = "PoweredBy#FGC8675309";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = Session.Instance.MemberSignUp(
                strUserName,
                strUserNameFirst,
                strUserNameLast,
                strUserEmailAddress,
                strPasswordMatchEntry1,
                strPasswordMatchEntry2
                );
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("Session::ValidateMemberName Failure. Malformed member name.", jSessionWebResponse.Dispatch.Message);
        }

        [Test]
        public void SessionMemberSignInWrongUserPassword()
        {
            const string strUserName = "kutlass";
            const string strPassword = "PoweredBy#FGC8675309WRONG";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = Session.Instance.MemberSignIn(strUserName, strPassword);
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("Session::ValidateMemberCredentials: Failure. Incorrect username or password.", jSessionWebResponse.Dispatch.Message);
        }

        [Test]
        public void SessionMemberSignUp_MemberExistsAlias()
        {
            //
            // Prep fields utilized by Call_1 and Call_2
            //
            const string strUserNameAlias_Call_1_Call_2 = "kutlass_1";
            const string strUserNameFirst = "Karl";
            const string strUserNameLast = "Flores";
            const string strEmailAddress_Call_1 = "kutlass_call_1@yogaframe.net";
            const string strEmailAddress_Call_2 = "kutlass_call_2@yogaframe.net";
            const string strPasswordMatchEntry1 = "PoweredBy#FGC8675309";
            const string strPasswordMatchEntry2 = "PoweredBy#FGC8675309";

            //
            // Call_1 - Session.MemberSignUp()
            //
            JSession jSessionWebResponse_Call_1 = null;
            jSessionWebResponse_Call_1 = Session.Instance.MemberSignUp(
                strUserNameAlias_Call_1_Call_2,
                strUserNameFirst,
                strUserNameLast,
                strEmailAddress_Call_1,
                strPasswordMatchEntry1,
                strPasswordMatchEntry2
                );
            Assert.NotNull(jSessionWebResponse_Call_1);
            const string EXPECTED_MESSAGE_SUCCESS = "S_OK";
            Assert.AreEqual(EXPECTED_MESSAGE_SUCCESS, jSessionWebResponse_Call_1.Dispatch.Message);
            Assert.NotNull(jSessionWebResponse_Call_1.Members);
            //Assert.Null(jSessionWebResponse_Call_1.Members.TblMembers);

            //
            // Call_2 - Session.MemberSignUp()
            //
            JSession jSessionWebResponse_Call_2 = null;
            jSessionWebResponse_Call_2 = Session.Instance.MemberSignUp(
                strUserNameAlias_Call_1_Call_2,
                strUserNameFirst,
                strUserNameLast,
                strEmailAddress_Call_2,
                strPasswordMatchEntry1,
                strPasswordMatchEntry2
                );
            Assert.NotNull(jSessionWebResponse_Call_2);
            const string EXPECTED_MESSAGE_ERROR = "Session::MemberSignUp: User name has been taken.";
            Assert.AreEqual(EXPECTED_MESSAGE_ERROR, jSessionWebResponse_Call_2.Dispatch.Message);
            //Assert.NotNull(jSessionWebResponse_Call_2.Members);
            //Assert.Null(jSessionWebResponse_Call_2.Members.TblMembers);     
        }

        [Test]
        public void SessionMemberSignUp_MemberExistsEmailAddress()
        {
            //
            // Prep fields utilized by Call_1 and Call_2
            //
            const string strUserNameAlias_Call_1 = "Call_1";
            const string strUserNameAlias_Call_2 = "Call_2";
            const string strUserNameFirst = "Karl";
            const string strUserNameLast = "Flores";
            const string strEmailAddress_Call_1_Call_2 = "kutlass_Call_1_Call_2@yogaframe.net";
            const string strPasswordMatchEntry1 = "PoweredBy#FGC8675309";
            const string strPasswordMatchEntry2 = "PoweredBy#FGC8675309";

            //
            // Call_1 - Session.MemberSignUp()
            //
            JSession jSessionWebResponse_Call_1 = null;
            jSessionWebResponse_Call_1 = Session.Instance.MemberSignUp(
                strUserNameAlias_Call_1,
                strUserNameFirst,
                strUserNameLast,
                strEmailAddress_Call_1_Call_2,
                strPasswordMatchEntry1,
                strPasswordMatchEntry2
                );
            Assert.NotNull(jSessionWebResponse_Call_1);
            const string EXPECTED_MESSAGE_SUCCESS = "S_OK";
            Assert.AreEqual(EXPECTED_MESSAGE_SUCCESS, jSessionWebResponse_Call_1.Dispatch.Message);
            Assert.NotNull(jSessionWebResponse_Call_1.Members);
            //Assert.Null(jSessionWebResponse_Call_1.Members.TblMembers);

            //
            // Call_2 - Session.MemberSignUp()
            //
            JSession jSessionWebResponse_Call_2 = null;
            jSessionWebResponse_Call_2 = Session.Instance.MemberSignUp(
                strUserNameAlias_Call_2,
                strUserNameFirst,
                strUserNameLast,
                strEmailAddress_Call_1_Call_2,
                strPasswordMatchEntry1,
                strPasswordMatchEntry2
                );
            Assert.NotNull(jSessionWebResponse_Call_2);
            const string EXPECTED_MESSAGE_ERROR = "Session::MemberSignUp: Email address has been taken.";
            Assert.AreEqual(EXPECTED_MESSAGE_ERROR, jSessionWebResponse_Call_2.Dispatch.Message);
            //Assert.NotNull(jSessionWebResponse_Call_2.Members);
            //Assert.Null(jSessionWebResponse_Call_2.Members.TblMembers);
        }

        [Test]
        public void SessionMemberSignUp()
        {
            const string strUserNameAlias = "kutlass";
            const string strUserNameFirst = "Karl";
            const string strUserNameLast = "Flores";
            const string strEmailAddress = "kutlass@yogaframe.net";
            const string strPasswordMatchEntry1 = "PoweredBy#FGC8675309";
            const string strPasswordMatchEntry2 = "PoweredBy#FGC8675309";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = Session.Instance.MemberSignUp(
                strUserNameAlias,
                strUserNameFirst,
                strUserNameLast,
                strEmailAddress,
                strPasswordMatchEntry1,
                strPasswordMatchEntry2
                );

            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);
            Assert.AreNotEqual(jSessionWebResponse.Members.TblMembers[0].IdtblMembers, "0");

            //
            // Did we recieve all expected Members fields?
            //
            List<TblMember> tblMembersExpected = new List<TblMember>
            {
                new TblMember()
                {
                    ColNameAlias = strUserNameAlias,
                    ColNameFirst = strUserNameFirst,
                    ColNameLast = strUserNameLast,
                    ColEmailAddress = strEmailAddress
                }
            };
            Members membersExpected = new Members();
            membersExpected.TblMembers = tblMembersExpected.ToArray();
            Members membersActual = jSessionWebResponse.Members;
            Assert.AreEqual(membersExpected.TblMembers.Length, membersActual.TblMembers.Length);
            Assert.AreEqual(membersExpected.TblMembers[0].ColNameFirst, membersActual.TblMembers[0].ColNameFirst);
            Assert.AreEqual(membersExpected.TblMembers[0].ColNameLast, membersActual.TblMembers[0].ColNameLast);
            Assert.AreEqual(membersExpected.TblMembers[0].ColNameAlias, membersActual.TblMembers[0].ColNameAlias);
            Assert.AreEqual(membersExpected.TblMembers[0].ColEmailAddress, membersActual.TblMembers[0].ColEmailAddress);
        }

        [Test]
        public void SessionMemberSignUpWeakPassword()
        {
            const string strUserNameAlias = "kutlass";
            const string strUserNameFirst = "Karl";
            const string strUserNameLast = "Flores";
            const string strEmailAddress = "kutlass1234@yogaframe.net";
            const string strPasswordMatchEntry1 = "weak";
            const string strPasswordMatchEntry2 = "weak";
            JSession jSessionActual = null;
            jSessionActual = Session.Instance.MemberSignUp(
                strUserNameAlias,
                strUserNameFirst,
                strUserNameLast,
                strEmailAddress,
                strPasswordMatchEntry1,
                strPasswordMatchEntry2
                );

            Assert.NotNull(jSessionActual);

            Dispatch dsptchExpected = new Dispatch();
            dsptchExpected.Message = "Session::MemberSignUp: Your password is weak.";

            Assert.AreEqual(dsptchExpected.Message, jSessionActual.Dispatch.Message);
        }

        //
        // Session Cache tests
        // ===================
        // For session cache tests, we need to ensure
        // that the Session.cs singleton is persisting
        // data containers across multiple caller instances.
        // 
        // To accomplish this in unit tests, we'll execute
        // a series of CacheStep1, CacheStep2, etc tests.
        // Step2 should see the data state created by Step1
        // and so on.
        //
        [Test]
        public void SessionCacheStep0_MemberSignUp()
        {
            const string strUserNameAlias = "CacheStep0";
            const string strUserNameFirst = "SessionCacheStep0FirstName";
            const string strUserNameLast = "SessionCacheStep0LastName";
            const string strEmailAddress = "SessionCacheStep0Email@yogaframe.net";
            const string strPasswordMatchEntry1 = "PoweredBy#FGC8675309";
            const string strPasswordMatchEntry2 = "PoweredBy#FGC8675309";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = Session.Instance.MemberSignUp(
                strUserNameAlias,
                strUserNameFirst,
                strUserNameLast,
                strEmailAddress,
                strPasswordMatchEntry1,
                strPasswordMatchEntry2
                );

            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);
        }
        [Test]
        public void SessionCacheStep01_MemberSignIn()
        {
            const string strUserName = "CacheStep0";
            const string strPassword = "PoweredBy#FGC8675309";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = Session.Instance.MemberSignIn(strUserName, strPassword);
            Assert.NotNull(jSessionWebResponse);
            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);
            Assert.NotNull(jSessionWebResponse.Members);
            Assert.NotNull(jSessionWebResponse.Members.TblMembers);
            Assert.NotNull(jSessionWebResponse.Sessions);
            Assert.NotNull(jSessionWebResponse.Sessions.TblSessions);
            const string strUserNameAlias = "CacheStep0";
            const string strUserNameFirst = "SessionCacheStep0FirstName";
            const string strUserNameLast = "SessionCacheStep0LastName";
            const string strEmailAddress = "SessionCacheStep0Email@yogaframe.net";
            Assert.AreEqual(strUserNameAlias, Session.Instance.Cache.Members.TblMembers[0].ColNameAlias);
            Assert.AreEqual(strUserNameFirst, Session.Instance.Cache.Members.TblMembers[0].ColNameFirst);
            Assert.AreEqual(strUserNameLast, Session.Instance.Cache.Members.TblMembers[0].ColNameLast);
            Assert.AreEqual(strEmailAddress, Session.Instance.Cache.Members.TblMembers[0].ColEmailAddress);
        }
        [Test]
        public void SessionCacheStep1_MemberPostGame()
        {
            List<TblGame> listTblGames = new List<TblGame>
            {
                new TblGame()
                {
                    ColName = "SessionCacheStep1: Killer Instinct",
                    ColDescription = "SessionCacheStep1: Game with lots of combos and stuff."
                }
            };
            Games games = new Games();
            games.TblGames = listTblGames.ToArray();
            bool fResult = false;
            fResult = Session.Instance.MemberPostGame(ref games);
            Assert.AreEqual(true, fResult);
        }

        [Test]
        public void SessionCacheStep1_N_WebGetPulses()
        {
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebGetPulses();
            Assert.NotNull(jSessionWebResponse);
            const string S_OK = "S_OK";
            Assert.AreEqual(S_OK, jSessionWebResponse.Dispatch.Message);
            const string EXPECTED_PULSE_VALUE = "MemberID 1 SEEDED a new game: SessionCacheStep1: Killer Instinct";
            Assert.AreEqual(EXPECTED_PULSE_VALUE, jSessionWebResponse.Pulses.TblPulses[0].ColDescription);
        }

        [Test]
        public void SessionCacheStep2_MemberGetGames()
        {
            bool fResult = false;
            fResult = Session.Instance.MemberGetGames();
            Assert.IsTrue(fResult);
            const int EXPECTED_NUM_GAMES_POSTED_FROM_STEP_1 = 1;
            Assert.AreEqual(EXPECTED_NUM_GAMES_POSTED_FROM_STEP_1, Session.Instance.Cache.Games.TblGames.Length);           
        }

        [Test]
        public void SessionCacheStep3_MemberPostCharacter()
        {
            List<TblCharacter> listTblCharacters = new List<TblCharacter>
            {
                new TblCharacter()
                {
                    ColName = "SessionCacheStep3: Glacius",
                    ColDescription = "SessionCacheStep3: Ice sword hand dood."
                }
            };
            Characters characters = new Characters();
            characters.TblCharacters = listTblCharacters.ToArray();
            bool fResult = false;
            fResult = Session.Instance.MemberPostCharacter(ref characters);
            Assert.AreEqual(true, fResult);
        }

        [Test]
        public void SessionCacheStep4_MemberGetCharacters()
        {
            bool fResult = false;
            fResult = Session.Instance.MemberGetCharacters();
            Assert.IsTrue(fResult);
            const int EXPECTED_NUM_GAMES_POSTED_FROM_STEP_1 = 1;
            const int EXPECTED_NUM_CHARACTERS_POSTED_FROM_STEP_3 = 1;
            Assert.AreEqual(EXPECTED_NUM_GAMES_POSTED_FROM_STEP_1, Session.Instance.Cache.Games.TblGames.Length);
            Assert.AreEqual(EXPECTED_NUM_CHARACTERS_POSTED_FROM_STEP_3, Session.Instance.Cache.Characters.TblCharacters.Length);
        }

        [Test]
        public void SessionCacheStep5_MemberPostMove()
        {
            List<TblMove> listMoves = new List<TblMove>
            {
                new TblMove(){ColName = "Shoryuken"}
            };
            Moves moves = new Moves();
            moves.TblMoves = listMoves.ToArray();
            bool fResult = false;
            fResult = Session.Instance.MemberPostMove(ref moves);
            Assert.IsTrue(fResult);
        }

        [Test]
        public void SessionCacheStep6_MemberGetMoves()
        {
            bool fResult = false;
            fResult = Session.Instance.MemberGetMoves();
            Assert.IsTrue(fResult);

            const int EXPECTED_NUM_GAMES_POSTED_FROM_STEP_1 = 1;
            const int EXPECTED_NUM_CHARACTERS_POSTED_FROM_STEP_3 = 1;
            const int EXPECTED_NUM_MOVES_POSTED_FROM_STEP_5 = 1;
            const string EXPECTED_MOVE_NAME_POSTED_FROM_STEP_5 = "Shoryuken";
            Assert.AreEqual(EXPECTED_NUM_GAMES_POSTED_FROM_STEP_1, Session.Instance.Cache.Games.TblGames.Length);
            Assert.AreEqual(EXPECTED_NUM_CHARACTERS_POSTED_FROM_STEP_3, Session.Instance.Cache.Characters.TblCharacters.Length);
            Assert.AreEqual(EXPECTED_NUM_MOVES_POSTED_FROM_STEP_5, Session.Instance.Cache.Moves.TblMoves.Length);
            Assert.AreEqual(EXPECTED_MOVE_NAME_POSTED_FROM_STEP_5, Session.Instance.Cache.Moves.TblMoves[0].ColName);
        }

        [Test]
        public void SessionCacheStep7_MemberUpdateProfile()
        {
            const string EXPECTED_MEMBER_NAME_FIRST = "My new first name";
            const string EXPECTED_MEMBER_EMAIL_ADDRESS = "kutlass@yogaframe.net";
            const string EXPECTED_MEMBER_BIO = "I just updated my bio. Is this thing working?!";
            const string FALSE = "0";
            const string EXPECTED_MEMBER_IS_EMAIL_VERIFIED = FALSE;
            
            bool fResult = false;
            fResult = Session.Instance.MemberUpdateProfile(
                EXPECTED_MEMBER_NAME_FIRST,
                EXPECTED_MEMBER_EMAIL_ADDRESS,
                EXPECTED_MEMBER_BIO
                );
            Assert.IsTrue(fResult);

            TblMember ACTUAL_MEMBER = Session.Instance.Cache.Members.TblMembers[0];
            Assert.AreEqual(EXPECTED_MEMBER_NAME_FIRST, ACTUAL_MEMBER.ColNameFirst);
            Assert.AreEqual(EXPECTED_MEMBER_EMAIL_ADDRESS, ACTUAL_MEMBER.ColEmailAddress);
            Assert.AreEqual(EXPECTED_MEMBER_BIO, ACTUAL_MEMBER.ColBio);
            Assert.AreEqual(EXPECTED_MEMBER_IS_EMAIL_VERIFIED, ACTUAL_MEMBER.ColIsEmailVerified);
        }

        [Test]
        public void SessionCacheStep8_MemberSendEmailVerification()
        {
            //
            // Create a new system template email "Verify your YogaFrame email" for
            // the YogaFrame service. This task is typically carried out by
            // the YogaFrame web administrator.
            //
            List<TblTemplateEmail> listTemplateEmails = new List<TblTemplateEmail>
            {
                new TblTemplateEmail()
                {
                    ColHeaders = "Unit test HEADERS string",
                    ColSubject = "Unit test SUBJECT string",
                    ColMessage = "Unit test MESSAGE string"
                }
            };
            TemplateEmails templateEmails = new TemplateEmails();
            templateEmails.TblTemplateEmails = listTemplateEmails.ToArray();
            JSession jSessionWebResponseWebPostTemplateEmail = null;
            jSessionWebResponseWebPostTemplateEmail = WebAdapter.WebPostTemplateEmail(ref templateEmails);
            Assert.NotNull(jSessionWebResponseWebPostTemplateEmail);
            Assert.AreEqual("S_OK", jSessionWebResponseWebPostTemplateEmail.Dispatch.Message);

            bool fResult = false;
            fResult = Session.Instance.MemberSendEmailVerification();
            Assert.IsTrue(fResult);
        }
    }

    [TestFixture]
    public class YogaFrameSessionTestNegative
    {
        [Test]
        public void NotSignedIn_GetGames()
        {
            bool fResult = false;
            fResult = Session.Instance.MemberGetGames();

            Assert.IsFalse(fResult);
        }
    }
}
