using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace LinqProject.Utils.FileOperators
{
    public class TxtOperator : IFileOpenOperator
    {
        public bool Read()
        {
            return true;
        }

        public bool Save(IEnumerable list)
        {
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
            }
            return true;
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
