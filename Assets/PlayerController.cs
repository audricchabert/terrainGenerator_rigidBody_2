using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 inputs;
    //ref https://www.youtube.com/watch?v=wlZUu-I05Bk


    int go = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            
        GetInputs();
        CodeUpdate2();
        
    }


    void GetInputs()
    {
        float x = Input.GetAxis("Vertical");

        float y = Input.GetAxis("Horizontal");
        float z = 0;
        if (Input.GetButton("Jump"))
        {
            z = 1;
        }
        else
        {
            z = 0;
        }
        inputs = new Vector3(x * 4, y * 5,z*10);

    }

    void CodeUpdate2()
    {
       
        GetComponent<Rigidbody>().AddForce(new Vector3(0,  go,0));

        GetComponent<Rigidbody>().AddForce(new Vector3(inputs.y, inputs.z, inputs.x));

    }
}
