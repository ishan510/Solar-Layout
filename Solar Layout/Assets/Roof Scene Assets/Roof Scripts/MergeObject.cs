using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeObject : MonoBehaviour
{
    public GameObject parentNode;
    GameObject[] childrenObjects;
    //public Camera cam;
    void Awake()
    {
        this.enabled = false;
    }
    public void ToggleState()
    {
        this.enabled = !this.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        AddObjectsTogether();
    }

    void AddObjectsTogether()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            childrenObjects = GameObject.FindGameObjectsWithTag("Roof");
            GameObject par = Instantiate(parentNode, new Vector3(1, 1, 1), Quaternion.identity);
            if (childrenObjects.Length == 0)
            {
                Debug.Log("Nothing has been placed, please spawn some roofs to merge objects together.");
            }
            else
            {
                foreach (GameObject roof in childrenObjects)
                {
                    roof.transform.parent = par.transform;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            DestroyImmediate(parentNode);
            this.enabled = false;
        }
    }
    
}
