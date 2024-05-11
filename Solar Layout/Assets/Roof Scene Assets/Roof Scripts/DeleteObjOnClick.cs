using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjOnClick : MonoBehaviour
{
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
        DeleteObj();
    }

    void DeleteObj()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject.tag == "Roof")
                {
                    Destroy(hit.collider.gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.enabled = false;
        }
    }
}

