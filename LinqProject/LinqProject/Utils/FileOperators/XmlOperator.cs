using System.Collections;
using System.Windows.Forms;
using System.Xml;

namespace LinqProject.Utils.FileOperators
{
    public class XmlOperator : IFileOperator, IFileOpenOperator
    {
        public XmlOperator()
        {
            FileType = FileTypes.XML.ToString();
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
                using (XmlWriter writer = XmlWriter.Create(savefile.FileName))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Persons");
                    foreach (Person person in list)
                    {
                        writer.WriteStartElement("Person");
                        writer.WriteElementString("Id", person.Id.ToString());
                        writer.WriteElementString("FirstName", person.FirstName.ToString());
                        writer.WriteElementString("LastName", person.LastName.ToString());
                        writer.WriteElementString("EmailAddress", person.EmailAddress.ToString());
                        writer.WriteElementString("BirthDate", person.BirthDate.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        protected static SaveFileDialog SetSaveOptions()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "ListOfPersons.xml";
            savefile.Filter = "Text files (*.xml)|*.xml|All files (*.*)|*.*";
            return savefile;
        }
    }
}
