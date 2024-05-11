using UnityEngine;

[System.Serializable]
public class RoofData
{
    public bool flattop;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale; 

    public RoofData(GameObject obj)
    {
        this.position = obj.transform.position;
        this.rotation = obj.transform.rotation;
        this.scale = obj.transform.lossyScale;

        if (obj.GetComponent<IsFlattop>().getFlattop())
        {
            this.flattop = true;
        }
        else
        {
            this.flattop = false;
        }
    }
}
