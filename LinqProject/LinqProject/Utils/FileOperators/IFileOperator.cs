using System.Collections;

namespace LinqProject.Utils.FileOperators
{
    public abstract class IFileOperator
    {
        public string FileType { get; set; }
        public abstract bool Save(IEnumerable list);
    }
}
