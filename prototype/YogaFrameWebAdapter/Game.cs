using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YogaFrameWebAdapter
{
    class Game
    {
        public Dappler m_dappler;
        public List<GameAttribute> m_listGameAttributes;

        //
        // Constructor
        //
        public Game(Dappler dappler, List<GameAttribute> listGameAttributes)
        {
            m_dappler = dappler;
            m_listGameAttributes = listGameAttributes;
        }
    }

    class GameAttribute
    {
        public Dappler m_dappler;
        public Dappler m_parentDappler;
        public string m_name;
        public string m_value;

        //
        // Constructor
        //
        public GameAttribute(string name, string value)
        {
            m_name = name;
            m_value = value;
        }
    }
}
