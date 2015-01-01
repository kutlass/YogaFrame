using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YogaFrameDeploy;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.CharactersJsonTypes;
using YogaFrameWebAdapter.GamesJsonTypes;
using YogaFrameWebAdapter.DapplersJsonTypes;
using YogaFrameWebAdapter.InputSequencesJsonTypes;
using YogaFrameWebAdapter.MembersJsonTypes;
using YogaFrameWebAdapter.MovesJsonTypes;
using YogaFrameWebAdapter.SessionsJsonTypes;
using YogaFrameWebAdapter.Session;
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
            // TODO: Write unit test. Fail test case while not implemented
            Assert.AreEqual(1, 2);
        }
    }

    [TestFixture]
    public class YogaFrameClientTest
    {
        [Test]
        public void GetGames()
        {
            //
            // Make the fetch call with official API, ensure a non-null Games object is returned
            //
            Games games = null;
            games = WebAdapter.WebGetGames();
            Assert.NotNull(games);
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
                    ColDescription  = "Best game EVARR!! YEEE!!!."
                }
            };
            gamesExpected.TblGames = tblGamesExpected.ToArray();

            //
            // POST the above data with official WebPostCharacter() API
            //
            WebAdapter.WebPostGame(ref gamesExpected);

            //
            // Fetch actual results with official API
            //
            Games gamesActual = WebAdapter.WebGetGames();

            //============================
            // Validate the 2 result sets:
            //  - charactersExpected
            //  - charactersActual
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
                new TblCharacter(){ ColName = "Max", ColDescription = "Leader of the clan.", IdtblGames = "671"}
            };
            Characters charactersExpected = new Characters();
            charactersExpected.TblCharacters = tblCharactersExpected.ToArray();

            //
            // POST the above data with official WebPostCharacter() API
            //
            WebAdapter.WebPostCharacter(ref charactersExpected);

            //
            // Fetch actual results with official API
            //
            Characters charactersActual = WebAdapter.WebGetCharacters();

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
                new TblDappler(){IdtblParentTable = "671", ColtblParentTableName = "Games", IdtblDapples = "671", ColDapplerState = "SEEDED", IdtblMember = "671"}//,
                //new TblDappler(){IdtblParentTable = "671", ColtblParentTableName = "Characters", IdtblDapples = "671", ColDapplerState = "ROOTED", IdtblMember = "671"}
            };
            Dapplers dapplersExpected = new Dapplers();
            dapplersExpected.TblDapplers = tblDapplersExpected.ToArray();

            //
            // POST the above data with official WebPostDappler() API
            //
            string strJsonWebResponse = string.Empty;
            strJsonWebResponse = WebAdapter.WebPostDappler(ref dapplersExpected);
            Assert.IsNotEmpty(strJsonWebResponse);

            //
            // FETCH actual results with official API
            //
            Dapplers dapplersActual = null;
            dapplersActual = WebAdapter.WebGetDapplers();
            Assert.NotNull(dapplersActual);

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
                Assert.AreEqual(rowExpected.IdtblMember, rowActual.IdtblMember);
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
            string strJsonWebResponse = string.Empty;
            strJsonWebResponse = WebAdapter.WebPostInputSequence(ref inputSequencesExpected);
            Assert.IsNotEmpty(strJsonWebResponse);

            //
            // FETCH actual results with official API
            //
            InputSequences inputSequencesActual = null;
            inputSequencesActual = WebAdapter.WebGetInputSequences();
            Assert.NotNull(inputSequencesActual);

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
                new TblMember(){ColNameAlias = "kutlass", ColNameFirst = "Karl", ColNameLast = "Flores", ColEmailAddress = "kutlass@yogaframe.net", ColPasswordSaltHash = "asdf;lkjUnitTestPostMember()", ColBio = "Oh HEY!! I did not see you there! Bio provided via RAW PASSTHROUGH."}
            };
            const string POSTREQUEST_MEMBER_POSTMEMBER_RAW_PASSTHROUGH = "POSTREQUEST_MEMBER_POSTMEMBER_RAW_PASSTHROUGH";
            Dispatch dispatch = new Dispatch();
            dispatch.Message = POSTREQUEST_MEMBER_POSTMEMBER_RAW_PASSTHROUGH;
            Members membersExpected = new Members();
            membersExpected.Dispatch = dispatch;
            membersExpected.TblMembers = TblMembersExpected.ToArray();

            //
            // POST the above data with official WebPostMember() API
            //
            Dispatch dsptchWebResponseExpected = new Dispatch();
            const string S_OK = "S_OK";
            dsptchWebResponseExpected.Message = S_OK;
            Dispatch dsptchWebResponseActual = null;
            dsptchWebResponseActual = WebAdapter.WebPostMemberEx(ref membersExpected);
            Assert.NotNull(dsptchWebResponseActual);
            Assert.AreEqual(dsptchWebResponseExpected.Message, dsptchWebResponseActual.Message);

            //
            // FETCH actual results with official API
            //
            Members membersActual = null;
            membersActual = WebAdapter.WebGetMembers();
            Assert.NotNull(membersActual);

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
                Assert.AreEqual(rowExpected.ColPasswordSaltHash,    rowActual.ColPasswordSaltHash);
                Assert.AreEqual(rowExpected.ColBio,                 rowActual.ColBio);
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
                new TblMove(){ColName = "Yoga Flame", IdtblDapplers = "671"}
            };
            Moves movesExpected = new Moves();
            movesExpected.TblMoves = TblMovesExpected.ToArray();

            //
            // POST the above data with official WebPostMove() API
            //
            string strJsonWebResponse = string.Empty;
            strJsonWebResponse = WebAdapter.WebPostMove(ref movesExpected);
            Assert.IsNotEmpty(strJsonWebResponse);

            //
            // FETCH actual results with official API
            //
            Moves movesActual = null;
            movesActual = WebAdapter.WebGetMoves();
            Assert.NotNull(movesActual);

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
                Assert.AreEqual(rowExpected.IdtblDapplers, rowActual.IdtblDapplers);
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
            Dispatch dispatch = new Dispatch();
            const string POSTREQUEST_SESSION_POSTSESSION_RAW_PASSTHROUGH = "POSTREQUEST_SESSION_POSTSESSION_RAW_PASSTHROUGH";
            dispatch.Message = POSTREQUEST_SESSION_POSTSESSION_RAW_PASSTHROUGH;
            Sessions sessionsExpected = new Sessions();
            sessionsExpected.Dispatch = dispatch;
            sessionsExpected.TblSessions = TblSessionsExpected.ToArray();

            //
            // POST the above data with official WebPostSession() API
            //
            Dispatch dsptchWebResponse = null;
            dsptchWebResponse = WebAdapter.WebPostSessionEx(ref sessionsExpected);
            Assert.NotNull(dsptchWebResponse);
            Assert.AreEqual("S_OK", dsptchWebResponse.Message);

            //
            // FETCH actual results with official API
            //
            Sessions sessionsActual = null;
            sessionsActual = WebAdapter.WebGetSessions();
            Assert.NotNull(sessionsActual);
            

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
            // Make the fetch call with official API, ensure a non-null Characters object is returned
            //
            Characters charactersActual = null;
            charactersActual = WebAdapter.WebGetCharacters();
            Assert.NotNull(charactersActual);
        }

        [Test]
        public void GetMembers()
        {
            //
            // Make the fetch call with official API, ensure a non-null Members object is returned
            //
            Members members = null;
            members = WebAdapter.WebGetMembers();
            Assert.NotNull(members);
        }

        [Test]
        public void GetSessions()
        {
            //
            // Make the fetch call with official API, ensure a non-null Sessions object is returned
            //
            Sessions sessions = null;
            sessions = WebAdapter.WebGetSessions();
            Assert.NotNull(sessions);
        }

        [Test]
        public void GetMoves()
        {
            //
            // Make the fetch call with official API, ensure a non-null Members object is returned
            //
            Moves moves = null;
            moves = WebAdapter.WebGetMoves();
            Assert.NotNull(moves);
        }
        [Test]
        public void GetInputSequences()
        {
            InputSequences inputSequences = null;
            inputSequences = WebAdapter.WebGetInputSequences();
            Assert.NotNull(inputSequences);
        }

        [Test]
        public void GetInputSchema()
        {
            WebAdapter.WebGetInputSchema();

            // TODO: Write unit test. Fail test case while not implemented
            Assert.AreEqual(1, 2);
        }

        [Test]
        public void GetDapplers()
        {
            //
            // Make the fetch call with official API, ensure a non-null Dapplers object is returned
            //
            Dapplers dapplers = null;
            dapplers = WebAdapter.WebGetDapplers();
            Assert.NotNull(dapplers);
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
            Session session = null;
            session = Session.MemberSignIn(strUserName, strPassword);

            Assert.NotNull(session);
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
            Session session = null;
            JSession jSessionWebResponse = null;
            jSessionWebResponse = Session.MemberSignUp(
                out session,
                strUserNameAlias,
                strUserNameFirst,
                strUserNameLast,
                strEmailAddress,
                strPasswordMatchEntry1,
                strPasswordMatchEntry2
                );

            Assert.NotNull(jSessionWebResponse);

            Assert.AreEqual("S_OK", jSessionWebResponse.Dispatch.Message);
            //Assert.NotNull(session);
        }

        [Test]
        public void SessionMemberSignUpWeakPassword()
        {
            const string strUserNameAlias = "kutlass";
            const string strUserNameFirst = "Karl";
            const string strUserNameLast = "Flores";
            const string strEmailAddress = "kutlass@yogaframe.net";
            const string strPasswordMatchEntry1 = "weak";
            const string strPasswordMatchEntry2 = "weak";
            Session session = null;
            JSession jSessionActual = null;
            jSessionActual = Session.MemberSignUp(
                out session,
                strUserNameAlias,
                strUserNameFirst,
                strUserNameLast,
                strEmailAddress,
                strPasswordMatchEntry1,
                strPasswordMatchEntry2
                );

            Assert.NotNull(jSessionActual);
            Assert.Null(session);

            Dispatch dsptchExpected = new Dispatch();
            dsptchExpected.Message = "Session::MemberSignUp: Your password is weak.";

            Assert.AreEqual(dsptchExpected.Message, jSessionActual.Dispatch.Message);
        }
    }
}
