using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace СSharpLB4.Core
{
    public static class Validator
    {
        private static MessageBroker _messageBroker = MessageBroker.GetInstance();
        public static bool IsTextBoxValid(TextBox textBox)
        {
            if(textBox.Text != null && textBox.Text.Length > 0)
            {               
                return true;
            }
            _messageBroker.RaiseMessage("Check input data!");
            return false;
        }

        public static bool IsComboBoxValid(ComboBox comboBox)
        {
            if(comboBox.SelectedItem != null && comboBox.Items.Count > 0)
            {
                return true;
            }
            _messageBroker.RaiseMessage("Check input data!");
            return false;
        }
    }
}
