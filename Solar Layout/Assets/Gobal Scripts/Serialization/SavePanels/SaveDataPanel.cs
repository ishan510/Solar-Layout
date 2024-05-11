using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SaveDataPanel : MonoBehaviour
{
    public PanelData pData;
    public InputField input;
    public GameObject panelRef;
    PanelData pandata;
    public void Save()
    {
        string fname;
        if (input.text == null)
        {
            Debug.Log("There is no input here, gonna make fname temp");
            fname = "temp";
        }
        else
        {
            fname = input.text;
        }

        GameObject panel = GameObject.FindGameObjectWithTag("Panel");
        pData = new PanelData(panel, panel.GetComponent<Panel>().GetMaterial());
        try { SerializationManager.SavePanel(fname, pData); } catch { }
    }

    public void Load(string fName)
    {
        
        string path = Application.persistentDataPath + "/panels/" + fName;

        if (SerializationManager.Load(path) != null)
        {
            
            try { PanelData pandata = (PanelData)SerializationManager.Load(path); } catch { }

            // Delete old Panel
            GameObject oldPanel = GameObject.FindGameObjectWithTag("Panel");
            Destroy(oldPanel);

            GameObject solarPanel = Instantiate(panelRef);
            solarPanel.transform.localScale = pandata.scale;

            GameObject lowerCube = solarPanel.transform.GetChild(0).gameObject;
            
            if (pandata.material == PanelData.SupportMaterial.Rail)
            {
                lowerCube.GetComponent<Renderer>().material.color = new Color(250, 14, 6, 121);
            }
            else if(pandata.material == PanelData.SupportMaterial.Railless)
            {
                lowerCube.GetComponent<Renderer>().material.color = new Color(6, 72, 241, 255);
            }
            else if (pandata.material == PanelData.SupportMaterial.SharedRail)
            {
                lowerCube.GetComponent<Renderer>().material.color = new Color(30, 255, 55, 255);
            }
            else
            {
                lowerCube.GetComponent<Renderer>().material.color = new Color(255, 167, 11, 255);
            }
        }
        else
        {
            Debug.Log("Cannot Find Obj!");
        }
    }
}
