using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YogaFrameWebAdapter
{
    //
    // UniversalButtons will be one thing unchangeable by #FGC
    // Some things must be absolute in order to be built upon
    //
    enum UniversalButtons
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

    class InputSchema
    {
        private Dappler m_dappler;

        public string name;          // i.e. Heavy Punch
        public string nameShorthand; // i.e. HP
        public string nameAlternate; // i.e. Fierce

        //
        // Constructor
        //
        public InputSchema()
        {
            //m_dappler = new Dappler(
        }
    }
}
