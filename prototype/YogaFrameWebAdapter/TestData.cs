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
    class TestData
    {
        List<Dapple> m_listDapples;

        //
        // Private methods
        //
        private void _GenerateTestData()
        {
            m_listDapples.Add(new Dapple());
        }

        //
        // Constructor
        //
        public TestData()
        {
            m_listDapples = new List<Dapple>();
        }

        //
        // Public methods
        //
        public InputSchema GenerateInputSchema()
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
    }
}
