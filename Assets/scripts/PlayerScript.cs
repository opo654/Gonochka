using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10f;
    public float vertical;
    public float horizontal;
    public float rotationspeed = 100f;
    void Start()
    {

    }


    void Update()
    {

        //transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.back * speed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //}

        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vertical);
        horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotationspeed * Time.deltaTime * horizontal);
    }


}
