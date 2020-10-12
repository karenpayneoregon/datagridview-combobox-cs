using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataGridViewComboCS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private List<string> _vendorNames;
        private string _vendorName;
        public Form2(List<string> vendorNames, string vendorName)
        {
            InitializeComponent();
            _vendorNames = vendorNames;
            _vendorName = vendorName;
            Shown += Form2_Shown;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            comboBox1.DataSource = _vendorNames;
            var pos = comboBox1.FindString(_vendorName);
            if (pos > -1)
            {
                comboBox1.SelectedIndex = pos;
            }
        }
    }
}
