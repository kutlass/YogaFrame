using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YogaFrameWebAdapter;
using YogaFrameWebAdapter.CharactersJsonTypes;

namespace TestLauncher
{
    class PreUnitTests
    {
        public static void TestPost()
        {
            /*
            const string uriGetCharacters = "https://www.yogaframe.net/YogaFrame/GetCharacters.php";
            string strJsonResponse = WebAdapter.CallPhpScriptSingle(uriGetCharacters);
            */

            const string uriPostCharacter = "https://www.yogaframe.net/YogaFrame/PostCharacter.php";
            //string strPostResponse = WebAdapter.SendPost(uriPostCharacter, strJsonResponse);

            List<TblCharacter> tblCharactersExpected = new List<TblCharacter>
            {
                new TblCharacter(){ ColName = "Sagat",      ColDescription = "Better when he was SF2 Skinny Sagat." },
                new TblCharacter(){ ColName = "Dhalsim",    ColDescription = "Stretchy limb dood. Enjoys meditation and fighting." },
                new TblCharacter(){ ColName = "Guile",      ColDescription = "In the wrong hands, turtles to no end." },
                new TblCharacter(){ ColName = "Ryu",        ColDescription = "Rare character." },
                new TblCharacter(){ ColName = "Ken",        ColDescription = "Underpowered dragon punch. Loves dining." },
                new TblCharacter(){ ColName = "Blanka",     ColDescription = "Shocker. Baller. Troller." },
                new TblCharacter(){ ColName = "Bison",      ColDescription = "Boots. Roundhouse. Scissors." }
            };
            Characters characters = new Characters();
            characters.TblCharacters = tblCharactersExpected.ToArray();

            string strSerializedCharacters = String.Empty;
            strSerializedCharacters = HelperJson.JsonSerialize(characters);
            //WebAdapter.SendPost(uriPostCharacter, strSerializedCharacters);
        }
    }
}
