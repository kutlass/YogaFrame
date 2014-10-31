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
            return new Game(null, listGameAttributes, listCharacters);
        }
    }
}
