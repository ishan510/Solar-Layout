using UnityEngine;
public class EnablePopup : MonoBehaviour
{
    public void ToggleState()
    {
        GameObject obj = this.gameObject;
        bool isActive = obj.activeSelf;
        obj.SetActive(!isActive);
    }
}
