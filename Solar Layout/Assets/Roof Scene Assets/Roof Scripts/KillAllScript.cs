using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllScript : MonoBehaviour
{
    GameObject DeleteObjectScript;
    GameObject FlatopSpawnerScript;
    GameObject PointedRoofSpawnerScript;
    GameObject MoveObjectScript;
    GameObject TransformObjectScript;
    GameObject MergeObjectScript;
    private void Start()
    {
        DeleteObjectScript = this.transform.GetChild(0).gameObject;
        FlatopSpawnerScript = this.transform.GetChild(1).gameObject;
        PointedRoofSpawnerScript = this.transform.GetChild(2).gameObject;
        MergeObjectScript = this.transform.GetChild(3).gameObject;
    }

    // A kill method that stops all local scripts from running so that the desired script is isolated
    // Note: Add to this method if more buttons are needed for the user to use other than menue options
    public void KillAllLocalScripts()
    {
        //Finding the scripts attached to the gameobjects and disabling them
        DeleteObjectScript.GetComponent<DeleteObjOnClick>().enabled = false;
        FlatopSpawnerScript.GetComponent<SpawnObjReferenceCamera>().enabled = false;
        PointedRoofSpawnerScript.GetComponent<SpawnObjReferenceCamera>().enabled = false;
        MergeObjectScript.GetComponent<MergeObject>().enabled = false;
    }
}
