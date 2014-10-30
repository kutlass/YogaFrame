using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YogaFrameWebAdapter
{
    //
    // Jargon: A Dappler is an atomic unit that represents practically
    //         all data elements within YogaFrame. Be it a Game, Character, Move, User,
    //         or Comment. These elements inherit Dappler DNA in order to facilitate the
    //         community's manipulation of Names, Values, Positions, Seeds and Roots.
    //
    class Dappler
    {
        int dapplerId;
        List<Dapple> m_listDapples;

        //
        // Constructor
        //
        public Dappler()
        {
            m_listDapples = _WebGetDapples();
        }

        //
        // Methods prefixed with "_WebGet" signify any over-the-wire transaction
        //
        private List<Dapple> _WebGetDapples()
        {
            return new List<Dapple>();
        }        

        public void GiveDaps()
        {
        }

        public void GiveDips()
        {
        }
    }
    
    //
    // Jargon: Think of a Dapple as a Vote.
    //         - Daps = Vote Up   = true
    //         - Dips = Vote Down = false
    //
    class Dapple
    {
        public int dapplerId;
        public int userId;
        public bool gaveDaps;

        public Dapple() { }
    }
}
