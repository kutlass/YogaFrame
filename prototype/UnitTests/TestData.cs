using System.Collections.Generic;
using YogaFrameWebAdapter.Session;
using YogaFrameWebAdapter.GamesJsonTypes;
using YogaFrameWebAdapter.CharactersJsonTypes;
using YogaFrameWebAdapter.MovesJsonTypes;

namespace UnitTests
{
    public class TestData
    {
        public List<TblGame> listTblGames = new List<TblGame>
        {
            new TblGame()
            {// Idtblgames      = 1
                ColName         = "Street Fighter II",
                ColPublisher    = "Capcom",
                ColDescription  = "Where it all began for many!"
            },
            new TblGame()
            {// Idtblgames      = 2 
                ColName         = "Mortal Kombat",
                ColPublisher    = "Midwest",
                ColDescription  = "Finish him. Uppercut. Blood. Spikes."
            },
            new TblGame()
            {// Idtblgames      = 3
                ColName         = "Super Smash Bros",
                ColPublisher    = "Nintendo",
                ColDescription  = "Still haven't played this game but heard great things!"
            }
        };

        public List<TblCharacter> listTblCharacters = new List<TblCharacter>
        {
            new TblCharacter()
            {// Idtblgames      = 1
                ColName         = "Ryu",
                ColDescription  = "Rare character."
            },
            new TblCharacter()
            {// Idtblgames      = 1
                ColName         = "Ken",
                ColDescription  = "Underpowered dragon punch. Humble minded."
            },
            new TblCharacter()
            {// Idtblgames      = 1
                ColName         = "Guile",
                ColDescription  = "Hair. Comb. Shades."
            },            new TblCharacter()
            {// Idtblgames      = 1
                ColName         = "Dhalsim",
                ColDescription  = "Stretchy limb dood. Loves meditation and villages."
            },
            new TblCharacter()
            {// Idtblgames      = 2
                ColName         = "Scorpion",
                ColDescription  = "Come thou hither."
            },
            new TblCharacter()
            {// Idtblgames      = 2
                ColName         = "Sub Zero",
                ColDescription  = "Inspires others to dance on ice."
            },
            new TblCharacter()
            {// Idtblgames      = 2
                ColName         = "Raiden",
                ColDescription  = "Best hat. Soars during free time."
            },
            new TblCharacter()
             {// Idtblgames     = 3
                ColName         = "Bowser",
                ColDescription  = "Boss. Pro. Spikes. Slow to anger."
            },            new TblCharacter()
            {// Idtblgames      = 3
                ColName         = "Mario",
                ColDescription  = "Rare character."
            },            new TblCharacter()
            {// Idtblgames      = 3
                ColName         = "Donkey Kong",
                ColDescription  = "Slender. Strong. Ape-like in manner."
            }
        };

        public List<TblMove> listTblMoves = new List<TblMove>
        {
            new TblMove()
            {
            }
        };
    }
}
