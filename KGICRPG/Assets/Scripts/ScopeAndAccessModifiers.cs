using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeAndAccessModifiers : MonoBehaviour
{
    public int banana = 5;


    private AnotherClass myOtherClass;


    // Start is called before the first frame update
    void Start()
    {
        myOtherClass = new AnotherClass();
        myOtherClass.FruitMachine(banana, myOtherClass.apples);
        myOtherClass.apples = 20;
        Debug.Log(myOtherClass.apples);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class AnotherClass
    {
        public int apples = 10;

        public void FruitMachine(int _banana, int _apples)
        {
            Debug.Log("FruitMachine.banana=" + _banana);
            Debug.Log("FruitMachine.apples=" + _apples);
        }
    }
}
