using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YogaFrameWebAdapter
{
    public enum DapplerMaturity {Seed, Root};
    
    //
    // Jargon: A Dappler is an atomic unit that represents practically
    //         all data elements within YogaFrame. Be it a Game, Character, Move, User,
    //         or Comment. These elements inherit Dappler DNA in order to facilitate the
    //         community's manipulation of Names, Values, Positions, Seeds and Roots.
    //
    public class Dappler
    {
        int m_dapplerId;
        int m_userIdOwner;
        DapplerMaturity m_dapplerMaturity;
        List<Dapple> m_listDapples;

        //
        // Constructor
        //
        public Dappler(int dapplerId, int userIdOwner, DapplerMaturity dapplerMaturity, List<Dapple>listDapples)
        {
            m_dapplerId = dapplerId;
            m_userIdOwner = userIdOwner;
            m_dapplerMaturity = dapplerMaturity;
            m_listDapples = listDapples;
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
    public class Dapple
    {
        public int dapplerId;
        public int userId;
        public bool gaveDaps;

        public Dapple() { }
    }
}
