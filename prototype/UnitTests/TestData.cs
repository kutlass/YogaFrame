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
            {// IdtblCharacters   1
                ColName         = "Ryu",
                ColDescription  = "Rare character.",
                IdtblGames      = "1"
            },
            new TblCharacter()
            {// IdtblCharacters   2
                ColName         = "Ken",
                ColDescription  = "Underpowered dragon punch. Humble minded.",
                IdtblGames      = "1"
            },
            new TblCharacter()
            {// IdtblCharacters   3
                ColName         = "Guile",
                ColDescription  = "Hair. Comb. Shades.",
                IdtblGames      = "1"
            },
            new TblCharacter()
            {// IdtblCharacters   4
                ColName         = "Dhalsim",
                ColDescription  = "Stretchy limb dood. Loves meditation and villages.",
                IdtblGames      = "1"
            },
            new TblCharacter()
            {// IdtblCharacters   5
                ColName         = "Scorpion",
                ColDescription  = "Come thou hither.",
                IdtblGames      = "2"
            },
            new TblCharacter()
            {// IdtblCharacters   6
                ColName         = "Sub Zero",
                ColDescription  = "Inspires others to dance on ice.",
                IdtblGames      = "2"
            },
            new TblCharacter()
            {// IdtblCharacters   7
                ColName         = "Raiden",
                ColDescription  = "Best hat. Soars during free time.",
                IdtblGames      = "2"
            },
            new TblCharacter()
            {// IdtblCharacters   8
                ColName         = "Bowser",
                ColDescription  = "Boss. Pro. Spikes. Slow to anger.",
                IdtblGames      = "3"
            },
            new TblCharacter()
            {// IdtblCharacters   9
                ColName         = "Mario",
                ColDescription  = "Rare character.",
                IdtblGames      = "3"
            },
            new TblCharacter()
            {// IdtblCharacters   10
                ColName         = "Donkey Kong",
                ColDescription  = "Slender. Strong. Ape-like in manner.",
                IdtblGames      = "3"
            }
        };

        public List<TblMove> listTblMoves = new List<TblMove>
        {
            new TblMove()
            {// IdtblMoves        1

                ColName         = "Hadouken",
                IdtblCharacters = "1"
            }
        };
    }
}
