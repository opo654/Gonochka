using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerScript : MonoBehaviour
{

    private Vector3 startposition;
    private Quaternion startrotation;
    public float speed;
    public float maxspeed = 30f;
    public float maxreversespeed = -20f;
    public float acceleration = 20f;
    public float deceleration = 10f;
    private float vertical;
    private float horizontal;
    public float rotationspeed = 100f;
    public GameManager manager;

    void Start()
    {
        startposition = transform.position;
        startrotation = transform.rotation;
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        if (vertical > 0)
        {
            speed = Mathf.MoveTowards(speed, maxspeed, acceleration * Time.deltaTime);
        }
        else if (vertical < 0)
        {
            speed = Mathf.MoveTowards(speed, maxreversespeed, acceleration * Time.deltaTime);
        }
        else
        {
            //speed = Mathf.MoveTowards(speed, 0, deceleration * Time.deltaTime);
            speed = 0;
        }


        transform.Translate(Vector3.forward * speed * Time.deltaTime * vertical);
        transform.Rotate(Vector3.up * rotationspeed * Time.deltaTime * horizontal);
        if (OutOfBounds())
        {
            ResetToStartPosition();
        }
    }

    bool OutOfBounds()
    {
        if (transform.position.y < -3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void ResetToStartPosition ()
    {
        transform.position = startposition;
        transform.rotation = startrotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("checkpoint"))
        {
            Debug.Log("касание сработало с чекпоинтом");
            manager.CheckpointTouched(other.gameObject);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            manager.FinishTouched(other.gameObject);
        }
    }
}
