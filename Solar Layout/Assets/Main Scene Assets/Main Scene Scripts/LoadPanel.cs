using UnityEngine;

public class LoadPanel : MonoBehaviour
{
    public GameObject refObj;
    public GameObject panelRef;
    PanelData pandata;
    public void Load(string fName)
    {
        string path = Application.persistentDataPath + "/panels/" + fName;

        if (SerializationManager.Load(path) != null)
        {
            try { pandata = (PanelData)SerializationManager.Load(path); } catch { }

            // Delete old Panel
            GameObject oldPanel = GameObject.FindGameObjectWithTag("Panel");
            Destroy(oldPanel);
            
            GameObject solarPanel = Instantiate(panelRef,new Vector3(1,0,3.5f),Quaternion.identity);
            solarPanel.transform.localScale = pandata.scale;
            Debug.Log((int)pandata.material);
            GameObject lowerCube = solarPanel.transform.GetChild(0).gameObject;
            if (pandata.material == PanelData.SupportMaterial.Rail)
            {
                lowerCube.GetComponent<Renderer>().material.SetColor("_Color", new Color(250, 14, 6, 121));
            }
            else if (pandata.material == PanelData.SupportMaterial.Railless)
            {
                lowerCube.GetComponent<Renderer>().material.SetColor("_Color", new Color(6, 72, 241, 255));
            }
            else if (pandata.material == PanelData.SupportMaterial.SharedRail)
            {
                lowerCube.GetComponent<Renderer>().material.SetColor("_Color", new Color(30, 255, 55, 255));
            }
            else
            {
                lowerCube.GetComponent<Renderer>().material.SetColor("_Color", new Color(255, 167, 11, 255));
            }
        }
        else
        {
            Debug.Log("Cannot Find Obj!");
        }
    }
}
