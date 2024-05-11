using UnityEngine;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SerializationManager : MonoBehaviour
{
    public static bool SaveRoof(string saveName, object saveData)
    {
        BinaryFormatter formatter = GetBinaryFormatter();

        if(!Directory.Exists(Application.persistentDataPath + "/roofs"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/roofs");
        }
        string path = Application.persistentDataPath + "/roofs/" + saveName + ".roof";

        if (Directory.Exists(path))
        {
            path = Application.persistentDataPath + "/roofs/" + System.DateTime.Now + saveName + ".roof";
        }

        FileStream file = File.Create(path);
        formatter.Serialize(file, (List<RoofData>)saveData);

        file.Close();
        return true;
    }

    public static bool SavePanel(string saveName, object saveData)
    {
        BinaryFormatter formatter = GetBinaryFormatter();

        if (!Directory.Exists(Application.persistentDataPath + "/panels"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/panels");
        }
        string path = Application.persistentDataPath + "/panels/" + saveName + ".panel";

        FileStream file = File.Create(path);
        formatter.Serialize(file, (PanelData)saveData);

        file.Close();
        return true;
    }
    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        SurrogateSelector selector = new SurrogateSelector();

        Vector3SerializationSurrogate vector3Surrogate = new Vector3SerializationSurrogate();
        QuaternionSerializationSurrogate quanterionSurrogate = new QuaternionSerializationSurrogate();
        //BoolSerializtionSurrogate boolSerializtionSurrogate = new BoolSerializtionSurrogate();

        selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3Surrogate);
        selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), quanterionSurrogate);
       // selector.AddSurrogate(typeof(bool), new StreamingContext(StreamingContextStates.All), boolSerializtionSurrogate);

        formatter.SurrogateSelector = selector; 
        return formatter;
    }

    public static object Load(string path)
    {
        if (!File.Exists(path))
        {
            Debug.LogError("Object not Found at: " + path);
            return null; 
        }

        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to load file at {0}", path);
            file.Close();
            return null;
        }
        finally
        {
            file.Close();
        }
    }
}
