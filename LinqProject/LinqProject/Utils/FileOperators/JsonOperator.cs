using Newtonsoft.Json;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace LinqProject.Utils.FileOperators
{
    public class JsonOperator : IFileOperator
    {
        public JsonOperator()
        {
            FileType = FileTypes.JSON.ToString();
        }

        public override bool Save(IEnumerable list)
        {
            if (list == null) return false;
            SaveFileDialog savefile = SetSaveOptions();
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string serializedList = JsonConvert.SerializeObject(list);
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, serializedList);
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
            savefile.FileName = "ListInJson.json";
            savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            return savefile;
        }
    }
}
