using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI;
public class Storage<T> where T : ISerializable, new()
{
    private readonly string _fileName = @"../../../../CLI/Data/{0}";
    private readonly Serializer<T> _serializer = new();

    public Storage(string fileName)
    {
        _fileName = string.Format(_fileName, fileName);
    }
    public List<T> Load()
    {
      
        if (!File.Exists(_fileName))
        {
            FileStream fs = File.Create(_fileName);
            fs.Close();
        }

        IEnumerable<string> lines = File.ReadLines(_fileName);
        List<T> objects = _serializer.FromCSV(lines);

        return objects;
    }

    public void Save(List<T> objects)
    {
        string serializedObjects = _serializer.ToCSV(objects);
        using (StreamWriter streamWriter = new StreamWriter(_fileName))
        {
            streamWriter.Write(serializedObjects);
        }
    }
}
//Kopirano sa vezbi