﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

namespace TestLauncher
{
    class ListBoxTraceListener : TraceListener
    {
        private ListBox m_listBox;

        //
        // Constructor
        //
        public ListBoxTraceListener(ListBox listBox)
        {
            m_listBox = listBox;
        }

        public override void WriteLine(string message)
        {
            m_listBox.Items.Add(message);            
        }

        public override void Write(string message)
        {
            m_listBox.Items.Add(message);            
        }
    }
}