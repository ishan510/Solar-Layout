using System.Collections.Generic;
using UnityEngine;
public class LoadRoofToScale : MonoBehaviour
{
    public GameObject flatTop;
    public GameObject pointed;
    public List<RoofData> roofs;
    public GameObject refObj; 
    public void LoadToScale(string fname)
    {
        string path = Application.persistentDataPath + "/roofs/" + fname;

        if (SerializationManager.Load(path) != null)
        {
            // Take all roofs stil lying about and destroying them 
            GameObject[] oldRoofs = GameObject.FindGameObjectsWithTag("Roof");
            for (int i = 0; i < oldRoofs.Length; i++)
            {
                Destroy(oldRoofs[i]);
            }

            // Load up the list of roof data
            try { roofs = (List<RoofData>)SerializationManager.Load(path); } catch { }

            // Spawn in each item, giving them a mesh, position, rotation, and scale 
            foreach (RoofData roofData in roofs)
            {
                if (roofData.flattop) // Flattop 
                {
                    GameObject roof = Instantiate(flatTop, refObj.transform.position - roofData.position, roofData.rotation);
                    roof.transform.SetParent(refObj.transform);

                    roof.transform.localScale = new Vector3(roofData.scale.x , roofData.scale.y , roofData.scale.z );
                    //roof.transform.localScale = roofData.scale;
                }
                else //Pointed 
                {
                    GameObject roof = Instantiate(pointed, refObj.transform.position, roofData.rotation);
                    roof.transform.SetParent(refObj.transform);
                    roof.transform.localScale = new Vector3(roofData.scale.x - 1f, roofData.scale.y - 0.4f, roofData.scale.z - 1f);
                }
            }
        }
        else
        {
            Debug.Log("Cannot Find Obj!");
        }
    }
}
