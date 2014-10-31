using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YogaFrameWebAdapter
{
    class WebAdapter
    {
        //
        // Methods prefixed with "_WebGet" signify any over-the-wire transaction
        //
        private List<Dapple> _WebGetDapples()
        {
            // TODO: Return List<Dapple>() from TestData.cs
            return new List<Dapple>();
        }

        //
        // A series of pseudo methods for now:
        //
        public void Initialize()
        {
            WebGetGames();
            WebGetCharacters();
            WebGetMoves();
            WebGetInputSchema();
            WebGetInputSequence();
        }
        public Game WebGetGames()
        {
            TestData testData = new TestData();
            Game game = testData.GenerateGames();
            return game;
        }
        public Character WebGetCharacters()
        {
            return new Character();
        }
        public Move WebGetMoves()
        {
            return new Move();
        }
        public InputSchema WebGetInputSchema()
        {
            TestData testData = new TestData();
            InputSchema inputSchema = testData.GenerateInputSchema();
            return inputSchema;
        }
        public InputSequence WebGetInputSequence()
        {
            return new InputSequence();
        }
    }
}
