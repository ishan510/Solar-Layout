using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class LoadSaveOptions : MonoBehaviour
{
    public GameObject loadArea;
    public Button button;
    public GameObject savingManager;

    public void ShowRoofLoadScreen()
    {
        string path = Application.persistentDataPath + " /roofs";
        DirectoryInfo levelDirectoryPath = new DirectoryInfo(path);
        FileInfo[] fInfo = levelDirectoryPath.GetFiles();

        foreach (Button button in loadArea.GetComponentsInChildren<Button>())
        {
            Destroy(button.gameObject);
        }

        for (int i = 0; i < fInfo.Length; i++)
        {
            var index = i;
            GameObject buttonObject = Instantiate(button.gameObject);
            buttonObject.transform.SetParent(loadArea.transform, false);

            buttonObject.transform.position = new Vector3(buttonObject.transform.position.x, (float)(buttonObject.transform.position.y - (50 * i)), buttonObject.transform.position.z); 

            buttonObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                savingManager.GetComponent<SaveDataRoof>().Load(fInfo[index].Name);
                loadArea.GetComponent<EnablePopup>().ToggleState();
            });

            buttonObject.GetComponentInChildren<TextMeshProUGUI>().text = fInfo[index].Name;
        }
    }
}
