using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setsize : MonoBehaviour
{
    public GameObject sp;

    public void setSixtyCell()
    {
        //3.25 X 5.5 ft
        sp.transform.localScale = new Vector3(0.9906f,1.6764f, 1);
    }
    public void setSventyTwoCell()
    {
        // 3.25 X 6.42
        sp.transform.localScale = new Vector3(0.9906f,1.956816f, 1);
    }

    public void SetNinetySixCell()
    {
        //3.45 X 5.21
        sp.transform.localScale = new Vector3(1.05156f,1.588008f, 1);
    }

}
