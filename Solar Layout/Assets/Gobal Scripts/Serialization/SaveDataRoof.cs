using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SaveDataRoof: MonoBehaviour 
{
    public GameObject flatTop;
    public GameObject pointed;
    public List<RoofData> roofs;
    public InputField input;
    public void Save()
    {
        string fname;
        if (input.text == null) {
            Debug.Log("There is no input here, gonna make fname temp");
            fname = "temp";
        }
        else
        {
            fname = input.text;
        }

        if (GameObject.FindGameObjectWithTag("ParentNode")!=null)
        {
            //Targets the parent node after the user merges all of the roofs together
            GameObject parentNode = GameObject.FindGameObjectWithTag("ParentNode");

            for (int i = 0; i < parentNode.transform.childCount; i++)
            {
                RoofData roof = new RoofData(parentNode.transform.GetChild(i).gameObject);
                //wrapping all of the roofs in a mother object

                roofs.Add(roof);
            }

            try { SerializationManager.SaveRoof(fname, roofs); } catch { }
        }
        else
        {
            Debug.Log("Cannot Find the Parent Node to Recognise Child Objecs. Merge Objects Together First Please");
        }
    }

    public void Load(string fName)
    {
        string path = Application.persistentDataPath + "/roofs/" + fName;
     
        if (SerializationManager.Load(path) != null)
        {
            // Take all roofs stil lying about and destroying them 
            GameObject[] oldRoofs = GameObject.FindGameObjectsWithTag("Roof"); 
            for(int i=0; i < oldRoofs.Length; i++)
            {
                Destroy(oldRoofs[i]);
            }

            GameObject pnode = GameObject.FindGameObjectWithTag("ParentNode");

            if (pnode!= null)
            {
                Destroy(pnode);
            }
            // Load up the list of roof data
            try { roofs = (List<RoofData>)SerializationManager.Load(path); } catch {}
            
            // Spawn in each item, giving them a mesh, position, rotation, and scale 
            foreach (RoofData roofData in roofs)
            {
                if (roofData.flattop) // Flattop 
                {
                    GameObject roof = Instantiate(flatTop, roofData.position, roofData.rotation);
                    roof.transform.localScale = roofData.scale;
                }
                else //Pointed 
                {
                    GameObject roof = Instantiate(pointed, roofData.position, roofData.rotation);
                    roof.transform.localScale = roofData.scale;
                }
            }
        }
        else
        {
            Debug.Log("Cannot Find Obj!");
        }
    }
}

 
