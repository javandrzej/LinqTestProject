using System.Collections;

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
            return true;
        }
    }
}
