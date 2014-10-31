using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YogaFrameWebAdapter
{
    public class Game
    {
        public Dappler m_dappler;
        public List<GameAttribute> m_listGameAttributes;
        public List<Character> m_listCharacters;

        //
        // Constructor
        //
        public Game(Dappler dappler, List<GameAttribute> listGameAttributes, List<Character>listCharacters)
        {
            m_dappler = dappler;
            m_listGameAttributes = listGameAttributes;
            m_listCharacters = listCharacters;
        }
    }

    public class GameAttribute
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
