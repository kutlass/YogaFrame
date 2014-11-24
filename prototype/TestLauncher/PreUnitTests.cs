using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YogaFrameWebAdapter;

namespace TestLauncher
{
    class PreUnitTests
    {
        public static void TestPost()
        {
            const string uriGetCharacters = "https://www.yogaframe.net/YogaFrame/GetCharacters.php";
            string strJsonResponse = WebAdapter.CallPhpScriptSingle(uriGetCharacters);

            const string uriPostCharacter = "https://www.yogaframe.net/YogaFrame/PostCharacter.php";
            string strPostResponse = WebAdapter.SendPost(uriPostCharacter, strJsonResponse);            
        }
    }
}
