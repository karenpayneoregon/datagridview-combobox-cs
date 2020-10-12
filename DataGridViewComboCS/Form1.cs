﻿using DataGridViewComboCS.Classes;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewComboCS
{
    public partial class Form1 : Form
    {
        readonly Operations _operations = new Operations();

        readonly BindingSource _customerBindingSource = new BindingSource();
        readonly BindingSource _vendorBindingSource = new BindingSource(); 
        readonly BindingSource _colorBindingSource = new BindingSource(); 

        public Form1()
        {
            InitializeComponent();

            CustomersDataGridView.CurrentCellDirtyStateChanged += _CurrentCellDirtyStateChanged;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Setup();

            CustomersDataGridView.AllowUserToAddRows = false ;

            LoadData();

            CurrentValuesView();

        }

        private void Setup()
        {

            _operations.LoadColorsReferenceTable();
            _operations.LoadVendorsReferenceTable();
            _vendorBindingSource.DataSource = _operations.VendorTable;
            _colorBindingSource.DataSource = _operations.ColorTable;


            ColorComboBoxColumn.DisplayMember = "ColorText";
            ColorComboBoxColumn.ValueMember = "ColorId";
            ColorComboBoxColumn.DataPropertyName = "ColorId";
            ColorComboBoxColumn.DataSource = _colorBindingSource;
            ColorComboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            VendorComboBoxColumn.DisplayMember = "VendorName";
            VendorComboBoxColumn.ValueMember = "VendorId";
            VendorComboBoxColumn.DataPropertyName = "VendorId";
            VendorComboBoxColumn.DataSource = _vendorBindingSource;
            VendorComboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            QtyNumericUpDownColumn.DataPropertyName = "qty";
            InCartCheckBoxColumn.DataPropertyName = "InCart";

        }
        private void LoadData()
        {

            _operations.LoadDataGridViewTable();

            CustomersDataGridView.AutoGenerateColumns = false;

            ItemTextBoxColumn.DataPropertyName = "Item";
            _customerBindingSource.DataSource = _operations.CustomerTable;

            CustomersDataGridView.DataSource = _customerBindingSource;

        }
        private void _CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            CustomersDataGridView.CurrentCellDirtyStateChanged -= _CurrentCellDirtyStateChanged;
            CustomersDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            CustomersDataGridView.CurrentCellDirtyStateChanged += _CurrentCellDirtyStateChanged;
        }
       
        private void CurrentRowViewButton_Click(object sender, EventArgs e)
        {
            CurrentValuesView();
        }

        private void CurrentValuesView()
        {
            var customerRow = ((DataRowView) _customerBindingSource.Current).Row;
            var customerPrimaryKey = customerRow.Field<int>("Id");
            var colorKey = customerRow.Field<int>("ColorId");
            var vendorKey = customerRow.Field<int>("VendorId");

            var vendorName = ((DataTable) _vendorBindingSource.DataSource)
                .AsEnumerable()
                .FirstOrDefault(row => row.Field<int>("VendorId") == vendorKey)
                .Field<string>("VendorName");

            var colorName = ((DataTable) _colorBindingSource.DataSource)
                .AsEnumerable()
                .FirstOrDefault(row => row.Field<int>("ColorId") == colorKey)
                .Field<string>("ColorText");


            DisplayInformationTextBox.Text =
                $"PK: {customerPrimaryKey} Vendor key {vendorKey} vendor: {vendorName} color id: {colorKey} - {colorName}";
        }
    }
}

