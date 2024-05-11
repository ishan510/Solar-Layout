
using UnityEngine;

public class Panel : MonoBehaviour
{
    public SupportMaterial material;
    public enum SupportMaterial
    {
        Rail,
        Railless,
        SharedRail,
        Ballasted
    }

    public void SetMaterial(int i)
    {
        this.material = (SupportMaterial)i;
    }

    public int GetMaterial()
    {
        return (int)material;
    }
}
