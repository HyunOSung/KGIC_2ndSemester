using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float moveSpeed = 10.0f;


    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime), Space.Self);
    }
}
