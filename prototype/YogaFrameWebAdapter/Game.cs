using System.Collections.Generic;

namespace YogaFrameWebAdapter.Session
{
    public class Game
    {
        public Dappler m_dappler;
        public List<GameAttribute> m_listGameAttributes;
        public List<Character> m_listCharacters;
        public List<InputSchema> m_listInputSchemas;

        //
        // Constructor
        //
        public Game(
            Dappler dappler,
            List<GameAttribute> listGameAttributes,
            List<Character> listCharacters,
            List<InputSchema> listInputSchemas
            )
        {
            m_dappler = dappler;
            m_listGameAttributes = listGameAttributes;
            m_listCharacters = listCharacters;
            m_listInputSchemas = listInputSchemas;
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
