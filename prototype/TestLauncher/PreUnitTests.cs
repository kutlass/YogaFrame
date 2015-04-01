
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
            //yogaFrameClientTest.PostMove();
            //yogaFrameClientTest.PostSession();

            //YogaFrameDeploymentTest yogaFrameDeploymentTest = new YogaFrameDeploymentTest();
            //yogaFrameDeploymentTest.DatabaseRestore();

            YogaFrameSessionTest yogaFrameSessionTest = new YogaFrameSessionTest();
            yogaFrameSessionTest.SessionCacheStep0_MemberSignUp();
            //yogaFrameSessionTest.SessionMemberSignUpWeakPassword();
            //yogaFrameSessionTest.SessionMemberSignIn();
            //yogaFrameSessionTest.SessionMemberSignUp();
            //yogaFrameSessionTest.SessionMemberSignInWrongUserName();
            //yogaFrameSessionTest.SessionMemberSignInWrongUserPassword();
        }
    }
}
