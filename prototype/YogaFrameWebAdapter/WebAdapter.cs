using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YogaFrameWebAdapter
{
    public static class WebAdapter
    {
        //
        // Methods prefixed with "_WebGet" signify any over-the-wire transaction
        //
        private static List<Dapple> _WebGetDapples()
        {
            // TODO: Return List<Dapple>() from TestData.cs
            return new List<Dapple>();
        }

        //
        // A series of pseudo methods for now:
        //
        public static void Initialize()
        {
            WebGetGames();
            WebGetCharacters();
            WebGetMoves();
            WebGetInputSchema();
            WebGetInputSequence();
        }
        public static Game WebGetGames()
        {
            return TestData.GenerateGames();
        }
        public static Character WebGetCharacters()
        {
            List<Move> listMoves = new List<Move>();
            return new Character(null, listMoves);
        }
        public static Move WebGetMoves()
        {
            return new Move();
        }
        public static InputSchema WebGetInputSchema()
        {            
            return TestData.GenerateInputSchema(); 
        }
        public static InputSequence WebGetInputSequence()
        {
            return new InputSequence();
        }

        public static QuorumCriteria WebGetQuorumCriteria()
        {
            return TestData.GenerateQuorumCriteria();
        }
    }
}
