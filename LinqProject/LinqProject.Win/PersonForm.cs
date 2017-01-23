using LinqProject.Repository.Persons;
using LinqProject.Utils.FileOperators;
using LinqProject.Win.FactoryPattern;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LinqProject.Win
{
    public partial class PersonForm : Form
    {
        private DataAlgorithm<Person> repositoryAlgorithm;
        private Timer t = null;
        IFileOperator fileOperator = null;
        private void StartTimer()
        {
            t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(ChangeTime);
            t.Enabled = true;
        }

        private void ChangeTime(object sender, EventArgs e)
        {
            ClockLabel.Text = DateTime.Now.ToString();
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


        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            fileOperator = new TxtOperator();
            fileOperator.Save((List<Person>)DataGridViewPersons.DataSource);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fileOperator = new PdfOperator();
            fileOperator.Save((List<Person>)DataGridViewPersons.DataSource);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ClockLabel_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            repositoryAlgorithm.ClearDatebase();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            repositoryAlgorithm.GenerateData(RowCount());
        }

        private int RowCount()
        {
            int defaultCount = 10;
            int.TryParse(textBoxRowNumbers.Text, out defaultCount);
            return defaultCount;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewPersons.DataSource = repositoryAlgorithm.Run(RowCount());
            }
            catch (Exception p)
            {
                MessageBox.Show("Problem with get data from DB");
            }
        }
    }
}
