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
            //
            // Character 1
            //
            new TblMove()
            {// IdtblMoves        1
                ColName         = "Character1_Move1",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        2
                ColName         = "Character1_Move2",
                IdtblCharacters = "1"
            },
            new TblMove()
            {// IdtblMoves        3
                ColName         = "Character1_Move3",
                IdtblCharacters = "1"
            },
            //
            // Character 2
            //
            new TblMove()
            {// IdtblMoves        4
                ColName         = "Character2_Move4",
                IdtblCharacters = "2"
            },
            new TblMove()
            {// IdtblMoves        5
                ColName         = "Character2_Move5",
                IdtblCharacters = "2"
            },
            new TblMove()
            {// IdtblMoves        6
                ColName         = "Character2_Move6",
                IdtblCharacters = "2"
            },
            //
            // Character 3
            //
            new TblMove()
            {// IdtblMoves        7
                ColName         = "Character3_Move7",
                IdtblCharacters = "3"
            },
            new TblMove()
            {// IdtblMoves        8
                ColName         = "Character3_Move8",
                IdtblCharacters = "3"
            },
            new TblMove()
            {// IdtblMoves        9
                ColName         = "Character3_Move9",
                IdtblCharacters = "3"
            },
            //
            // Character 4
            //
            new TblMove()
            {// IdtblMoves        10
                ColName         = "Character4_Move10",
                IdtblCharacters = "4"
            },
            new TblMove()
            {// IdtblMoves        11
                ColName         = "Character4_Move11",
                IdtblCharacters = "4"
            },
            new TblMove()
            {// IdtblMoves        12
                ColName         = "Character4_Move12",
                IdtblCharacters = "4"
            },
            //
            // Character 5
            //
            new TblMove()
            {// IdtblMoves        13
                ColName         = "Character5_Move13",
                IdtblCharacters = "5"
            },
            new TblMove()
            {// IdtblMoves        14
                ColName         = "Character5_Move14",
                IdtblCharacters = "5"
            },
            new TblMove()
            {// IdtblMoves        15
                ColName         = "Character5_Move15",
                IdtblCharacters = "5"
            },
            //
            // Character 6
            //
            new TblMove()
            {// IdtblMoves        16
                ColName         = "Character6_Move16",
                IdtblCharacters = "6"
            },
            new TblMove()
            {// IdtblMoves        17
                ColName         = "Character6_Move17",
                IdtblCharacters = "6"
            },
            new TblMove()
            {// IdtblMoves        18
                ColName         = "Character6_Move18",
                IdtblCharacters = "6"
            },
            //
            // Character 7
            //
            new TblMove()
            {// IdtblMoves        19
                ColName         = "Character7_Move19",
                IdtblCharacters = "7"
            },
            new TblMove()
            {// IdtblMoves        20
                ColName         = "Character7_Move20",
                IdtblCharacters = "7"
            },
            new TblMove()
            {// IdtblMoves        21
                ColName         = "Character7_Move21",
                IdtblCharacters = "7"
            },
            //
            // Character 8
            //
            new TblMove()
            {// IdtblMoves        22
                ColName         = "Character8_Move22",
                IdtblCharacters = "8"
            },
            new TblMove()
            {// IdtblMoves        23
                ColName         = "Character8_Move23",
                IdtblCharacters = "8"
            },
            new TblMove()
            {// IdtblMoves        24
                ColName         = "Character8_Move24",
                IdtblCharacters = "8"
            },
            //
            // Character 9
            //
            new TblMove()
            {// IdtblMoves        25
                ColName         = "Character9_Move25",
                IdtblCharacters = "9"
            },
            new TblMove()
            {// IdtblMoves        26
                ColName         = "Character9_Move26",
                IdtblCharacters = "9"
            },
            new TblMove()
            {// IdtblMoves        27
                ColName         = "Character9_Move27",
                IdtblCharacters = "9"
            },
            //
            // Character 10
            //
            new TblMove()
            {// IdtblMoves        28
                ColName         = "Character10_Move28",
                IdtblCharacters = "10"
            },
            new TblMove()
            {// IdtblMoves        29
                ColName         = "Character10_Move29",
                IdtblCharacters = "10"
            },
            new TblMove()
            {// IdtblMoves        30
                ColName         = "Character10_Move29",
                IdtblCharacters = "10"
            },
        };
    }
}
