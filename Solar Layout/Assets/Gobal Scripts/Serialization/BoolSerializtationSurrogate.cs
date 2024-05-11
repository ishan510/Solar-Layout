using System.Collections;
using UnityEngine;
using System.Runtime.Serialization;


public class BoolSerializtionSurrogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        bool objb = (bool)obj;
        if (objb)
        {
            info.AddValue("true", objb);
        }
        else
        {
            info.AddValue("false",objb);
        }
        
    }
    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        bool objb = (bool)obj;
        if (info.GetBoolean("true"))
        {
            objb = true;
            return objb;
        }
        else
        {
            objb = false;
            return objb;
        }
    }
}
