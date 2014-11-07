using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YogaFrameWebAdapter
{
    //
    // This TestData will act as stub data in lieu of actual database access.
    // Focus is to get Dappler data flow functioning as expected for the Client app
    //
    public static class TestData
    {
        //
        // public constants
        //
        //
        public static string GAME_NAME_PAIR_KEY = "Name";
        public static string GAME_NAME_PAIR_VALUE = "Ultra Street Fighter IV";

        public static string GAME_DEVELOPER_PAIR_KEY = "Developer";
        public static string GAME_DEVELOPER_PAIR_VALUE = "Capcom";

        public static string GAME_DEVELOPER_URL_PAIR_KEY = "DeveloperURL";
        public static string GAME_DEVELOPER_URL_PAIR_VALUE = "www.capcom.com";

        public static string GAME_PUBLISHER_PAIR_KEY = "Publisher";
        public static string GAME_PUBLISHER_PAIR_VALUE = "Capcom";

        public static string GAME_PUBLISHER_URL_PAIR_KEY = "PublisherURL";
        public static string GAME_PUBLISHER_URL_PAIR_VALUE = "www.capcom.com";

        public static string GAME_DESCRIPTION_PAIR_KEY = "Description";
        public static string GAME_DESCRIPTION_PAIR_VALUE = "Best game EVAR!!";

        // Public methods
        //
        public static InputSchema GenerateInputSchema()
        {
            List<SingleInput> listSingleInput = new List<SingleInput>();
            listSingleInput.Add(new SingleInput(UniversalButton.X, "Light Punch", "LP", "Jab"));
            listSingleInput.Add(new SingleInput(UniversalButton.Y, "Medium Punch", "MP", "Strong"));
            listSingleInput.Add(new SingleInput(UniversalButton.Z, "Heavy Punch", "HP", "Fierce"));
            listSingleInput.Add(new SingleInput(UniversalButton.X, "Light Kick", "LK", "Short"));
            listSingleInput.Add(new SingleInput(UniversalButton.Y, "Medium Kick", "MK", "Forward"));
            listSingleInput.Add(new SingleInput(UniversalButton.Z, "Heavy Kick", "HK", "Roundhouse"));

            return new InputSchema("Street Fighter IV", listSingleInput);
        }

        public static Game GenerateGames()
        {
            const string GAME_NAME = "Ultra Street Fighter IV";
            List<GameAttribute> listGameAttributes = new List<GameAttribute>();
            listGameAttributes.Add(new GameAttribute("Name", GAME_NAME));
            listGameAttributes.Add(new GameAttribute("Developer", "Capcom"));
            listGameAttributes.Add(new GameAttribute("DeveloperURL", "www.capcom.com"));
            listGameAttributes.Add(new GameAttribute("Publisher", "Capcom"));
            listGameAttributes.Add(new GameAttribute("PublisherURL", "www.capcom.com"));
            listGameAttributes.Add(new GameAttribute("Description", "Best game EVAR!!"));

            List<Character> listCharacters = new List<Character>();
            List<InputSchema> listInputSchemas = new List<InputSchema>();
            return new Game(null, listGameAttributes, listCharacters, listInputSchemas);
        }

        public static QuorumCriteria GenerateQuorumCriteria()
        {
            return new QuorumCriteria();
        }
    }
}
