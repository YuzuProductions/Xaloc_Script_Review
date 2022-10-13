using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject ob;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ob.transform.position += Vector3.up*Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ob.transform.position += Vector3.down*Time.deltaTime;
        }
    }
}
