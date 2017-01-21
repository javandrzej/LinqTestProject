using System.Collections;

namespace LinqProject.Utils.FileOperators
{
    public interface IFileOperator
    {
        bool Save(IEnumerable list);
    }
}
