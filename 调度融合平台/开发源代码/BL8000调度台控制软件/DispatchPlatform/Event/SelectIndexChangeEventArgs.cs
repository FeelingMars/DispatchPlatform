using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DispatchPlatform.Event
{
    internal class SelectIndexChangeEventArgs : EventArgs
    {
        internal int Index { get; set; }
    }

    internal class BeforeSelectIndexChangeEventArgs : EventArgs
    {
        internal int BeforeIndex { get; set; }
        internal bool Cancel { get; set; }
    }

    internal class PropertyChangedEventArgs : EventArgs
    {
        internal int Index { get; set; }
    }
}
