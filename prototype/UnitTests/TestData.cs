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
            },
            new TblMove()
            {// IdtblMoves        2
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        3
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        4
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        5
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        6
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        7
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        8
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        9
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        10
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        11
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        12
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        13
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        14
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        15
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        16
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        17
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        18
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        19
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        20
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        21
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        22
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        23
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        24
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        25
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        26
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        27
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        28
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        29
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        30
                ColName         = "Hadouken",
                IdtblCharacters = "1"
            },
        };
    }
}
