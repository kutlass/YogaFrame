using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YogaFrameDeploy;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.CharactersJsonTypes;
using YogaFrameWebAdapter.GamesJsonTypes;
using YogaFrameWebAdapter.DapplersJsonTypes;

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
                new TblDappler(){IdtblParentTable = "671", ColtblParentTableName = "Games", IdtblDapples = "671", ColDapplerState = "SEEDED", IdtblMember = "671"},
                new TblDappler(){IdtblParentTable = "671", ColtblParentTableName = "Characters", IdtblDapples = "671", ColDapplerState = "ROOTED", IdtblMember = "671"}
            };
            Dapplers dapplersExpected = new Dapplers();
            dapplersExpected.TblDapplers = tblDapplersExpected.ToArray();

            //
            // POST the above data with official WebPostCharacter() API
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
        public void GetMoves()
        {
            WebAdapter.WebGetMoves();

            // TODO: Write unit test. Fail test case while not implemented
            Assert.AreEqual(1, 2);
        }

        [Test]
        public void GetInputSequence()
        {
            WebAdapter.WebGetInputSequence();

            // TODO: Write unit test. Fail test case while not implemented
            Assert.AreEqual(1, 2);
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
}
