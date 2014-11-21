using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YogaFrameDeploy;
using YogaFrameWebAdapter;

namespace UnitTests
{
    using NUnit.Framework;
    
    [TestFixture]
    public class YogaFrameDeploymentTest
    {
        [Test]
        public void DatabaseConnect()
        {
            Deployment deployment = new Deployment();
            //deployment.DatabaseConnect();
        }

        [Test]
        public void DatabaseDeploy()
        {
            Deployment.DatabaseBackup();
        }

        [Test]
        public void DatabaseBackup()
        {
            Deployment.DatabaseBackup();
        }

        [Test]
        public void DatabaseRestore()
        {
            //Deployment.tbl_Characters_insert();
        }
    }

    [TestFixture]
    public class YogaFrameClientTest
    {
        [Test]
        public void GetGames()
        {     
            WebAdapter.WebGetGames();

            List<Game> listGames = TestData.GenerateGames();

            Game game = listGames.ElementAt(0);
            
            Assert.AreNotEqual("STRENGTH", game.m_listGameAttributes.ElementAt(0).m_name);
            Assert.AreEqual(TestData.GAME_NAME_PAIR_KEY, game.m_listGameAttributes.ElementAt(0).m_name);
            Assert.AreEqual(TestData.GAME_NAME_PAIR_VALUE, game.m_listGameAttributes.ElementAt(0).m_value);

            Assert.AreEqual(TestData.GAME_DEVELOPER_PAIR_KEY, game.m_listGameAttributes.ElementAt(1).m_name);
            Assert.AreEqual(TestData.GAME_DEVELOPER_PAIR_VALUE, game.m_listGameAttributes.ElementAt(1).m_value);

            Assert.AreEqual(TestData.GAME_DEVELOPER_URL_PAIR_KEY, game.m_listGameAttributes.ElementAt(2).m_name);
            Assert.AreEqual(TestData.GAME_DEVELOPER_URL_PAIR_VALUE, game.m_listGameAttributes.ElementAt(2).m_value);

            Assert.AreEqual(TestData.GAME_PUBLISHER_PAIR_KEY, game.m_listGameAttributes.ElementAt(3).m_name);
            Assert.AreEqual(TestData.GAME_PUBLISHER_PAIR_VALUE, game.m_listGameAttributes.ElementAt(3).m_value);            

            Assert.AreEqual(TestData.GAME_PUBLISHER_URL_PAIR_KEY, game.m_listGameAttributes.ElementAt(4).m_name);
            Assert.AreEqual(TestData.GAME_PUBLISHER_URL_PAIR_VALUE, game.m_listGameAttributes.ElementAt(4).m_value);

            Assert.AreEqual(TestData.GAME_DESCRIPTION_PAIR_KEY, game.m_listGameAttributes.ElementAt(5).m_name);
            Assert.AreEqual(TestData.GAME_DESCRIPTION_PAIR_VALUE, game.m_listGameAttributes.ElementAt(5).m_value);
        }

        [Test]
        public void GetCharacters()
        {
            WebAdapter.WebGetCharacters();
        }

        [Test]
        public void GetMoves()
        {
            WebAdapter.WebGetMoves();
        }

        [Test]
        public void GetInputSequence()
        {
            WebAdapter.WebGetInputSequence();
        }

        [Test]
        public void GetInputSchema()
        {
            WebAdapter.WebGetInputSchema();
        }
    }

    //
    // TODO: Remove AccountTest. This is cut and paste gunk from NUnit tutorial
    //
    [TestFixture]
    public class AccountTest
    {
        [Test]
        public void TransferFunds()
        {
            Account source = new Account();
            source.Deposit(200m);

            Account destination = new Account();
            destination.Deposit(150m);

            source.TransferFunds(destination, 100m);

            Assert.AreEqual(250m, destination.Balance);
            Assert.AreEqual(100m, source.Balance);
        }
    }
}
