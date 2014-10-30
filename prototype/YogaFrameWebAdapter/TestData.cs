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
    }
}
