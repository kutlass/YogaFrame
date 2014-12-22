using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YogaFrameWebAdapter.Session
{
    public class Character
    {
        public Dappler m_dappler;
        public List<Move> m_listMoves;

        //
        // Constructor
        //
        public Character(Dappler dappler, List<Move> listMoves)
        {
            m_dappler = dappler;
            m_listMoves = listMoves;
        }
    }

    class CharacterAttribute
    {
        public Dappler m_dappler;
        public Dappler m_parentDappler;
        public string m_name;
        public string m_value;

        //
        // Constructor
        //
        public CharacterAttribute(string name, string value)
        {
            m_name = name;
            m_value = value;
        }
    }
}
