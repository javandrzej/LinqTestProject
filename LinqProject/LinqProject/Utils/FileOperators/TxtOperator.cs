using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace LinqProject.Utils.FileOperators
{
    public class TxtOperator : IFileOperator, IFileOpenOperator
    {

        public TxtOperator()
        {
            FileType = FileTypes.TXT.ToString();
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
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                {
                    foreach (var element in list)
                    {
                        sw.WriteLine(element.ToString());
                    }
                }
                return true;
            }
            return false;
        }

        protected static SaveFileDialog SetSaveOptions()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "ListOfPersons.txt";
            savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            return savefile;
        }
    }
}
