using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 inputs;
    //ref https://www.youtube.com/watch?v=wlZUu-I05Bk


    
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
        if (Input.GetButton("Fire2"))
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
        Quaternion q = transform.rotation;
        //TODO : get rotation anglel to use a trigo function 

        //TODO : check different addforce ForceMode : https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html

        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(inputs.y*3, inputs.z*1, inputs.x*3));
        

        if (transform.position.y <= 0)
        {
            Vector3 newVector = transform.position;
            newVector.y = 0;
            GetComponent<Rigidbody>().MovePosition(newVector);
            //transform.position = newVector;
        }
        if (transform.position.z <= 0)
        {
            Vector3 newVector = transform.position;
            newVector.y = 0;
            GetComponent<Rigidbody>().MovePosition(newVector);
            //transform.position = newVector;
        }
        if (transform.position.y >= 1024)
        {
            Vector3 newVector = transform.position;
            newVector.y = 1024;
            transform.position = newVector;
        }
        if (transform.position.z >= 1024)
        {
            Vector3 newVector = transform.position;
            newVector.y = 1024;
            transform.position = newVector;
        }
        if (transform.position.y <= 0)
        {
            Vector3 newVector = transform.position;
            newVector.y = 0;
            transform.position = newVector;
        }
    }
}
