using System.Collections.Generic;

namespace YogaFrameWebAdapter.Session
{
    public class Move
    {
        public Dappler m_dappler;
        public List<MoveColumn> m_listMoveColumns;

        //
        // Constructor
        //
        public Move(Dappler dappler, List<MoveColumn> listMoveColumns)
        {
            m_dappler = dappler;
            m_listMoveColumns = listMoveColumns;
        }
    }

    public class MoveColumn
    {        
        public Dappler m_dappler;
        
        public MoveColumnType m_movementColumnType;
        
        public string m_name;
        public int m_valueInteger;
        public string m_valueText;
        public string m_valueBolean;
    }

    public enum MoveColumnType
    {
        integer,
        text,
        boolean
    };
}
