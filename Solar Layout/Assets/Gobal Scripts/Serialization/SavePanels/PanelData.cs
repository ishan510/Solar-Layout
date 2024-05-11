using UnityEngine;

[System.Serializable]
public class PanelData
{
    public Vector3 scale;
    public SupportMaterial material;
    public enum SupportMaterial
    {
        Rail,
        Railless,
        SharedRail,
        Ballasted
    }

    public PanelData(GameObject obj, int i)
    {
        this.scale = obj.transform.lossyScale;
        this.material = (SupportMaterial)i;
        Debug.Log("Material Saved " + (SupportMaterial)i);
        //GameObject lowerCube = obj.transform.GetChild(0).gameObject;

       /* if (isColorEqual(lowerCube.GetComponent<Renderer>().material.color, new Color(250,14,6,121)))
        {
            this.material = SupportMaterial.Rail;
        }else if (isColorEqual(lowerCube.GetComponent<Renderer>().material.color, new Color(6, 72, 241, 255)))
        {
            this.material = SupportMaterial.Railless;
        }
        else if (isColorEqual(lowerCube.GetComponent<Renderer>().material.color, new Color(30, 255, 55, 255)))
        {
            this.material = SupportMaterial.SharedRail;
        }
        else
        {
            this.material = SupportMaterial.Ballasted;
        }*/
    }

    public bool isColorEqual(Color a, Color b)
    {
        return a.r == b.r && a.g == b.g && a.b == b.b && a.a == b.a;
    }
}
