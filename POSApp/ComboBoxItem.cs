using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSApp
{
    internal class ComboBoxItem
    {
        public object Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text; // This is what will be shown in the ComboBox
        }
    }
}
