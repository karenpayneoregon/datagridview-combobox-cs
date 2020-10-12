using DataGridViewComboCS.Controls;
using System.Windows.Forms;

namespace DataGridViewComboCS.Extensions
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
