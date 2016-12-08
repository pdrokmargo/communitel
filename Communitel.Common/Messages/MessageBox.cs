using Communitel.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Common.Messages
{
    public class MessageBox
    {


        public static DialogResultV Show(string Message)
        {

            Views.MessageBoxView ms = new Views.MessageBoxView();
            ms.Mensaje = Message;
            ms.ShowDialog();
            return ms.DialogResult;
        }

        public static DialogResultV Show(string Message, string Text)
        {

            Views.MessageBoxView ms = new Views.MessageBoxView();
            ms.Mensaje = Message;
            ms.Text = Text;
            ms.ShowDialog();
            return ms.DialogResult;
        }

        public static DialogResultV Show(string Message, string Text, MessageBoxButtonsV messageBoxButtons)
        {

            Views.MessageBoxView ms = new Views.MessageBoxView();
            ms.Mensaje = Message;
            ms.Text = Text;
            ms.MessageBoxButton = messageBoxButtons;
            ms.ShowDialog();
            return ms.DialogResult;
        }

        public static DialogResultV Show(string Message, string Text, MessageBoxButtonsV messageBoxButtons, MessageBoxIconV messageBoxIcon)
        {

            Views.MessageBoxView ms = new Views.MessageBoxView();
            ms.Mensaje = Message;
            ms.Text = Text;
            ms.MessageBoxButton = messageBoxButtons;
            ms.MessageBoxIcon = messageBoxIcon;
            ms.ShowDialog();
            return ms.DialogResult;
        }

        public static DialogResultV Show(string Message, string Text, MessageBoxIconV messageBoxIcon)
        {

            Views.MessageBoxView ms = new Views.MessageBoxView();
            ms.Mensaje = Message;
            ms.Text = Text;
            ms.MessageBoxIcon = messageBoxIcon;
            ms.ShowDialog();
            return ms.DialogResult;
        }

        public static DialogResultV Show(string Message, MessageBoxIconV messageBoxIcon)
        {

            Views.MessageBoxView ms = new Views.MessageBoxView();
            ms.Mensaje = Message;
            //ms.Text = "";
            ms.MessageBoxIcon = messageBoxIcon;
            ms.ShowDialog();
            return ms.DialogResult;
        }

        public static DialogResultV Show(string Message, string Text, MessageBoxButtonsV messageBoxButtons, MessageBoxIconV messageBoxIcon, MessageBoxDefaultButtonV messageBoxDefaultButton)
        {

            Views.MessageBoxView ms = new Views.MessageBoxView();
            ms.Mensaje = Message;
            ms.Text = Text;
            ms.MessageBoxButton = messageBoxButtons;
            ms.MessageBoxIcon = messageBoxIcon;
            ms.MessageBoxDefaultButton = messageBoxDefaultButton;
            ms.ShowDialog();
            return ms.DialogResult;
        }

    }
}
