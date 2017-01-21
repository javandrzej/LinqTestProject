using LinqProject.Repository.Persons;
using LinqProject.Utils.FileOperators;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LinqProject.Win
{
    public partial class PersonForm : Form
    {
        private IPersonRepository repository = new PersonDbRepsitory();
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
            StartTimer();
            try
            {
                repository.InitData();
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
                DataGridViewPersons.DataSource = repository.GetPersons();
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
    }
}
