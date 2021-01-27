using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifStatements : MonoBehaviour
{
    float coffeeTemperatuer = 85.0f;
    float hotLimitTemperature = 70.0f;
    float coldLimitTemperature = 40.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TemperatureTest();

            coffeeTemperatuer -= Time.deltaTime * 5f;
            print("coffeeTemperatuer is " + coffeeTemperatuer);
        }
        
    }

    void TemperatureTest()
    {
        if (coffeeTemperatuer > hotLimitTemperature)
        {
            print("Coffee is too hot");
        }
        else if (coffeeTemperatuer < coldLimitTemperature)
        {
            print("Coffee is too cold");
        }
        else
        {
            print("Coffee is just right");
        }
    }
}
