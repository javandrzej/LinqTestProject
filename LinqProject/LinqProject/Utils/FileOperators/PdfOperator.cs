using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace LinqProject.Utils.FileOperators
{
    public class PdfOperator : IFileOperator
    {
        public bool Save(IEnumerable list)
        {
            SaveFileDialog savefile = SetSaveOptions();
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(savefile.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                foreach (var element in list)
                {
                    doc.Add(new Paragraph(element.ToString()));
                }

                doc.Close();
            }
            return true;
        }

        protected static SaveFileDialog SetSaveOptions()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "ListInPdf.pdf";
            savefile.Filter = "Text files (*.pdf)|*.pdf|All files (*.*)|*.*";
            return savefile;
        }
    }
}
