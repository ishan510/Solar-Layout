using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnObjReferenceCamera : MonoBehaviour
{
    public GameObject objToSpawn;
    public Camera cam;
    
    void Awake()
    {
        this.enabled = false;
    }
    
    public void ToggleState()
    {
        this.enabled = !this.enabled;
    }

    void Update()
    {
        SpawnObjectOnClick();
    }

    void SpawnObjectOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject.tag == "SpawnPlate")
                {
                    Instantiate(objToSpawn, new Vector3(hit.point.x, hit.point.y + objToSpawn.transform.position.y, hit.point.z), Quaternion.identity);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.enabled = false;
        }
    }
}
