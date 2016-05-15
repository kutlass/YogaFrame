
using UnitTests;


namespace TestLauncher
{
    class PreUnitTests
    {
        public static void TestAPIs()
        {
            YogaFrameClientTest yogaFrameClientTest = new YogaFrameClientTest();
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
            //yogaFrameClientTest.PostTemplateEmail();

            YogaFrameSessionTest yogaFrameSessionTest = new YogaFrameSessionTest();
            yogaFrameSessionTest.SessionCacheStep0_MemberSignUp();
            yogaFrameSessionTest.SessionCacheStep01_MemberSignIn();
            yogaFrameSessionTest.SessionCacheStep1_MemberPostGame();
            yogaFrameSessionTest.SessionCacheStep7_MemberUpdateProfile();
            yogaFrameSessionTest.SessionCacheStep02_MemberIsEmailVerifiedYet();
            //yogaFrameSessionTest.SessionMemberSignUpWeakPassword();
            //yogaFrameSessionTest.SessionMemberSignIn();
            //yogaFrameSessionTest.SessionMemberSignUp();
            //yogaFrameSessionTest.SessionMemberSignInWrongUserName();
            //yogaFrameSessionTest.SessionMemberSignInWrongUserPassword();
        }

        public static void UnitTests_DatabaseRestore()
        {
            YogaFrameDeploymentTest yogaFrameDeploymentTest = new YogaFrameDeploymentTest();
            yogaFrameDeploymentTest.DatabaseRestore();
        }
    }
}
