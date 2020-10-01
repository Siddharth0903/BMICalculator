using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FinalExam.Presentation
{
    class NavMenuItem
    {
        public String Label { get; set; }

        public Symbol Symbol { get; set; }

        public char SymbolAsChar => (char)Symbol;
    }
}
