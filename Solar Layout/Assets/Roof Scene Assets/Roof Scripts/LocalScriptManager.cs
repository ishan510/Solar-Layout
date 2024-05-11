using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class LocalScriptManager : MonoBehaviour
{
    //Gathering all of the buttons from the canvas that pertain to local button presses 
    Button DeleteModeButton = GameObject.Find("Canvas/DeleteModeButton").GetComponent<Button>();
    Button SpawnFlattopButton = GameObject.Find("Canvas/SpawnFlattopButton").GetComponent<Button>();
    Button SpawnPointedRoofButton = GameObject.Find("Canvas/SpawnPointedRoofButton").GetComponent<Button>();
    Button MoveObjectButton = GameObject.Find("Canvas/MoveObjectButton").GetComponent<Button>();
    Button TransformObjectButton = GameObject.Find("Canvas/TransformObjectButton").GetComponent<Button>();
    Button MergeObjectButton = GameObject.Find("Canvas/MergeObjectButton").GetComponent<Button>();

    // All of the Scripts that could be potentially called
    GameObject DeleteObjectScript;
    GameObject FlatopSpawnerScript;
    GameObject PointedRoofSpawnerScript;
    GameObject MoveObjectScript;
    GameObject TransformObjectScript;
    GameObject MergeObjectScript;
    

    private void Awake()
    {
        //NOTE TO SELF: DO NOT CHANGE THE ORDERING OF THE OBJECTS IN THE HEIARCHY!!!! 
        //THIS WILL DISRUPT HOW THE OBJECTS ARE POINTED TO AND INNITIATED!!!!!
        DeleteObjectScript = this.transform.GetChild(0).gameObject;
        FlatopSpawnerScript = this.transform.GetChild(1).gameObject;
        PointedRoofSpawnerScript = this.transform.GetChild(2).gameObject;
        MoveObjectScript = this.transform.GetChild(3).gameObject;
        TransformObjectScript = this.transform.GetChild(4).gameObject;
        MergeObjectScript = this.transform.GetChild(6).gameObject;

        //Finding the scripts attached to the gameobjects and disabling them
        DeleteObjectScript.GetComponent<DeleteObjOnClick>().enabled = false;
        FlatopSpawnerScript.GetComponent<SpawnObjReferenceCamera>().enabled = false;
        PointedRoofSpawnerScript.GetComponent<SpawnObjReferenceCamera>().enabled = false;
        MoveObjectScript.GetComponent<MoveObject>().enabled = false;
        TransformObjectScript.GetComponent<TransformObject>().enabled = false;
        MergeObjectScript.GetComponent<MergeObject>().enabled = false; 

    }
    void Start()
    {
        
    }

    private void Update()
    {
        
    }
}

