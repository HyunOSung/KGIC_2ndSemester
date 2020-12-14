using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform target;
    public Vector3 posRev = new Vector3(0f, 1.95f, -4.3f);



    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.position + posRev;
        //this.transform.rotation = target.rotation;
    }
}
