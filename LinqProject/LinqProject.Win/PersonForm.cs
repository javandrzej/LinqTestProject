using LinqProject.Repository.Persons;
using LinqProject.Utils;
using LinqProject.Utils.FileOperators;
using LinqProject.Win.FactoryPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace LinqProject.Win
{
    public partial class PersonForm : Form
    {
        private DataAlgorithm<Person> repositoryAlgorithm;
        private Timer t = null;
        private BindingList<string> fileOperationStatus = new BindingList<string>();
        private IFileOperator fileOperator = null;
        private void StartTimer()
        {
            t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(ChangeTimeEvent);
            t.Enabled = true;
        }

        private void ChangeTimeEvent(object sender, EventArgs e)
        {
            ClockLabel.Text = DateTime.Now.ToString();
        }

        private void UpdateCreatedFileEvent()
        {
        }

        public PersonForm()
        {
            InitializeComponent();
            repositoryAlgorithm = new PersonAlgorithm(new PersonDbRepsitory());
            StartTimer();
            try
            {
                repositoryAlgorithm.Repository.InitData();
            }
            catch (Exception p)
            {
                MessageBox.Show("Problem with init data in DB");
            }
            FileOperationList.DataSource = fileOperationStatus;
        }

        private void ClickEventForGetDataFromDb(object sender, EventArgs e)
        {
            try
            {
                DataGridViewPersons.DataSource = repositoryAlgorithm.GetFromDatabase();
            }
            catch (Exception p)
            {
                MessageBox.Show("Problem with get data from DB");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void PersonForm_Load(object sender, EventArgs e)
        {

        }

        private void ClickEventForSaveTxt(object sender, EventArgs e)
        {
            fileOperator = new TxtOperator();
            fileOperationStatus.Add(StringOperators.GetCreatedFileStaus(fileOperator.Save((List<Person>)DataGridViewPersons.DataSource), fileOperator.FileType.ToString()));
        }

        private void ClickEventForSavePdf(object sender, EventArgs e)
        {
            fileOperator = new PdfOperator();
            fileOperationStatus.Add(StringOperators.GetCreatedFileStaus(fileOperator.Save((List<Person>)DataGridViewPersons.DataSource), fileOperator.FileType.ToString()));

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ClockLabel_Click(object sender, EventArgs e)
        {

        }

        private void ClickEventClearDb(object sender, EventArgs e)
        {
            repositoryAlgorithm.ClearDatebase();
        }

        private void ClickEventGenerateData(object sender, EventArgs e)
        {
            repositoryAlgorithm.GenerateData(RowCount());
        }

        private int RowCount()
        {
            int defaultCount = 10;
            int.TryParse(textBoxRowNumbers.Text, out defaultCount);
            return defaultCount;
        }

        private void ClickEventForAlorithm(object sender, EventArgs e)
        {
            try
            {
                DataGridViewPersons.DataSource = repositoryAlgorithm.Run(RowCount());
            }
            catch (Exception p)
            {
                MessageBox.Show("Problem with getting data from DB");
            }
        }

        private void ClickEventForSaveCsv(object sender, EventArgs e)
        {
            fileOperator = new CsvOperator();
            fileOperationStatus.Add(StringOperators.GetCreatedFileStaus(fileOperator.Save((List<Person>)DataGridViewPersons.DataSource), fileOperator.FileType.ToString()));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
