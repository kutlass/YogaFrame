using System.Collections.Generic;

namespace YogaFrameWebAdapter.Session
{
    //
    // UniversalButtons will be one thing unchangeable by #FGC
    // Some things must be absolute in order to be built upon
    //
    public enum UniversalButton
    {
        // Visualize counter-clockwise 360 motion starting Down and ending DownBack:
        Down,
        DownForward,
        Forward,
        UpForward,
        Up,
        UpBack,
        Back,
        DownBack,
        // End 360 motion
        
        // 6 button stick layout:
        A, B, C,
        X, Y, Z
    };

    public class SingleInput
    {
        public UniversalButton m_universalButton;

        public string m_name;          // i.e. Heavy Punch
        public string m_nameShorthand; // i.e. HP
        public string m_nameAlternate; // i.e. Fierce

        //
        // Constructor
        //
        public SingleInput(
            UniversalButton universalButton,
            string name,
            string nameShorthand,
            string nameAlternate
            )
        {
            m_universalButton = universalButton;
            m_name = name;
            m_nameShorthand = nameShorthand;
            m_nameAlternate = nameAlternate;
        } 
    }

    public class InputSchema
    {
        private Dappler m_dappler;
        public string m_schemaName; // e.g. Street Fighter IV, Mortal Kombat, etc
        public List<SingleInput> m_listSingleInput;

        //
        // Constructor
        //
        public InputSchema(string schemaName, List<SingleInput> listSingleInput)
        {
            //m_dappler = new Dappler(
            listSingleInput = m_listSingleInput;
        }
    }

    // TODO: Not sure where MovementState should live, slap it here for now.
    //       Also, not sure yet whether it should be an enum, class, etc.
    public enum MovementState
    {
        Crouch,
        CrouchForward,
        Forward,
        JumpForward,
        JumpNeutral,
        JumpBack,
        Back,
        CrouchBack
    };
}
