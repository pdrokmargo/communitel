using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Communitel.Common.Controls
{
    public class TextBoxOnlyNumber : TextBox
    {
        public TextBoxOnlyNumber()
        {
            this.PreviewTextInput += TextBoxOnlyNumber_PreviewTextInput;
        }

        private void TextBoxOnlyNumber_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
