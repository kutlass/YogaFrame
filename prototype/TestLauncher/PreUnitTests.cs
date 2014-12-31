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
        public static void TestPost()
        {
            //YogaFrameClientTest yogaFrameClientTest = new YogaFrameClientTest();
            //yogaFrameClientTest.PostDappler();
            //yogaFrameClientTest.PostCharacter();
            //yogaFrameClientTest.GetCharacters();
            //yogaFrameClientTest.GetMoves();
            //yogaFrameClientTest.PostMember();
            //yogaFrameClientTest.PostSession();

            YogaFrameSessionTest yogaFrameSessionTest = new YogaFrameSessionTest();
            //yogaFrameSessionTest.SessionMemberSignUpWeakPassword();
            yogaFrameSessionTest.SessionMemberSignUp();
        }
    }
}
