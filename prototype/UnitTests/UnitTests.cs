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
            deployment.DatabaseConnect();
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
            Deployment.DatabaseRestore();
        }
    }

    [TestFixture]
    public class YogaFrameClientTest
    {
        [Test]
        public void GetGames()
        {
            WebAdapter.WebGetGames();
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
