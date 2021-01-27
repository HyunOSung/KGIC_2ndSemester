using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class BehaviourScript : MonoBehaviour
{
    //:콜론은 상속
    //보통 private가 생략되어 있음

    int myint = 5;

    // Start is called before the first frame update
    void Start()
    {
        myint = multiplyTwo(myint, 10);
        Debug.Log(myint);
        myint = multiplyTwo(myint, 10);
        Debug.Log(myint);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    int multiplyTwo(int arg0, int arg1)
    {
        return arg0 * arg1;
    }
}
