using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YogaFrameWebAdapter
{
    class User
    {
        //
        // Typical Social-networkie user profile fields.
        // Evolve this list as I go.
        //
        int m_userId;
        string m_userName;
        string m_userLongName;
        string m_userBio;
        
        // m_listDapples = Any VOTE (Dap or Dip) that the user has ever made towards
        //                 any YogaFrame #FGC-driven entity, since the conception
        //                 of his/her YogaFrame membership.
        List<Dapple> m_listDapples;

        //
        // Constructor
        //
        public User()
        {
            m_userId = 0;
            m_userName = "";
            m_userLongName = "";
            m_userBio = "";

            m_listDapples = new List<Dapple>();
        }
    }
}
