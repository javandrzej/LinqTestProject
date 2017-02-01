using LinqProject.Utils.ModelWrapper;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LinqProject.Utils.FileOperators
{
    public class CsvOperator : IFileOperator, IFileOpenOperator
    {
        public CsvOperator()
        {
            FileType = FileTypes.CSV.ToString();
        }
        public bool Read()
        {
            return true;
        }

        public override bool Save(IEnumerable list)
        {
            if (list == null) return false;
            SaveFileDialog savefile = SetSaveOptions();
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csvBuilder = new StringBuilder();
                // headers
                csvBuilder.AppendLine(PersonWrapper.GetHeadersForPerson());
                // data
                foreach (var element in list)
                {
                    csvBuilder.AppendLine(element.ToString());
                }
                File.AppendAllText(savefile.FileName, csvBuilder.ToString());
                return true;
            }
            return false;
        }

        protected static SaveFileDialog SetSaveOptions()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "ListInCvs.csv";
            savefile.Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*";
            return savefile;
        }
    }
}
