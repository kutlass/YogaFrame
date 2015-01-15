using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YogaFrameWebAdapter;
using YogaFrameWebAdapter.CharactersJsonTypes;
using YogaFrameWebAdapter.GamesJsonTypes;
using UnitTests;


namespace TestLauncher
{
    class PreUnitTests
    {
        public static void TestAPIs()
        {
            //YogaFrameClientTest yogaFrameClientTest = new YogaFrameClientTest();
            //yogaFrameClientTest.PostDappler();
            //yogaFrameClientTest.PostCharacter();
            //yogaFrameClientTest.PostGame();
            //yogaFrameClientTest.GetCharacters();
            //yogaFrameClientTest.GetGames();
            //yogaFrameClientTest.GetMoves();
            //yogaFrameClientTest.GetMembers();
            //yogaFrameClientTest.PostMember();
            //yogaFrameClientTest.PostSession();

            YogaFrameSessionTest yogaFrameSessionTest = new YogaFrameSessionTest();
            //yogaFrameSessionTest.SessionMemberSignUpWeakPassword();
            //yogaFrameSessionTest.SessionMemberSignIn();
            yogaFrameSessionTest.SessionMemberSignUp();
            //yogaFrameSessionTest.SessionMemberSignInWrongUserName();
            //yogaFrameSessionTest.SessionMemberSignInWrongUserPassword();
        }
    }
}
