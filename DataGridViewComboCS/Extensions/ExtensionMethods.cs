using System.Windows.Forms;
using DataGridViewCombo1.Controls;

namespace DataGridViewCombo1.Extensions
{
    public static class ExtensionMethods
    {
        public static bool IsComboBoxCell(this DataGridViewCell sender)
        {
            bool result = false;
            if (sender.EditType != null)
            {
                if (sender.EditType == typeof(DataGridViewComboBoxEditingControl))
                {
                    result = true;
                }
            }
            return result;
        }
        public static bool IsNumericControl(this DataGridViewCell sender)
        {
            bool result = false;
            if (sender.EditType != null)
            {
                if (sender.EditType == typeof(NumericUpDownRightEditingControl))
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
