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
            return null;
        }
        public static Character WebGetCharacters()
        {
            List<Move> listMoves = new List<Move>();
            return new Character(null, listMoves);
        }
        public static Move WebGetMoves()
        {
            return new Move(null, null); // TODO: Add real params
        }
        public static InputSchema WebGetInputSchema()
        {            
            return null;
        }
        public static InputSequence WebGetInputSequence()
        {
            return null;
        }

        public static QuorumCriteria WebGetQuorumCriteria()
        {
            return null;
        }

        //
        // POST methods - database WRITE related operations
        //
        public static Game WebPostGames()
        {
            return null;
        }
        public static Character WebPostCharacters()
        {
            List<Move> listMoves = new List<Move>();
            return new Character(null, listMoves);
        }
        public static Move WebPostMoves()
        {
            return null;
        }
        public static InputSchema WebPostInputSchema()
        {
            return null;
        }
        public static InputSequence WebPostInputSequence()
        {
            return null;
        }

        public static QuorumCriteria WebPostQuorumCriteria()
        {
            return null;
        }
    }
}
