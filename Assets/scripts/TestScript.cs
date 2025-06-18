using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public int apples = 10;
    private float speed = 15.5f;
    public bool haskey = false;
    public string myname = "vanya";
    void Start()
    {
        Debug.Log("hello "+ name);
        Debug.Log("aplles "+ apples);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hello world!");
        if (Input.GetKeyDown(KeyCode.Space)) {
            apples++; //это тоже самое что += 1
            Debug.Log("aplles " + apples);
        }
        if (Input.GetKey(KeyCode.RightShift)) {
            speed += 0.5f;
            Debug.Log("spedd " + speed);

        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (haskey)
            {
                Debug.Log (name + "у вас есть ключ");
            }
            else
            {
                Debug.Log(name + "у вас нет ключа");
            }
        }
    }

}
