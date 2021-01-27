using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    int numEnemies = 3;

    int cupsIntheSink = 5;

    bool shouldContinue = false;

    // Start is called before the first frame update
    void Start()
    {
        //ForLoop();
        //whileLoop();
        //DoWhileLoop();
        ForEachLoop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ForLoop()
    {
        for(int i = 0; i < numEnemies; i++)
        {
            Debug.Log("Creating enemy number : " + i);
        }
    }

    void whileLoop()
    {
        while(cupsIntheSink > 0)
        {
            Debug.Log("I've washed a cup!");
            cupsIntheSink--;
        }
    }

    void DoWhileLoop()
    {
        do
        {
            print("Hello World!");
        } while (shouldContinue == true);
    }

    void ForEachLoop()
    {
        string[] strings = new string[3];

        strings[0] = "first string";
        strings[1] = "second string";
        strings[2] = "third string";

        foreach(string item in strings)
        {
            print(item);
        }

        for(int i = 0; i<strings.Length; i++)
        {
            print(strings[i]);
        }

    }
}
