using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector3 inputs;
    public Text p;
    //ref https://www.youtube.com/watch?v=wlZUu-I05Bk

    string debugAction="";

    
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
        float forward = Input.GetAxis("Vertical");

        float sideways = Input.GetAxis("Horizontal");
        float height = 0;
        if (Input.GetButton("Fire2"))
        {
            height = 1;
        }
        else
        {
            height = 0;
        }
        inputs = new Vector3(forward * 4, sideways * 5,height*10);

    }

    void CodeUpdate2()
    {
        //TODO : verifier si la variable est utilisée
        Quaternion q = transform.rotation;

        AddForce();

        //check height boundary
        CheckBoundarySideY(0, 200, 0);
        //checck sideways boundary;
        CheckBoundarySideX(0, 1024, 70);
        //check forward/backward boundary
        CheckBoundarySideZ(0, 1024, 59);

    }

    void AddForce()
    {
        //TODO : get rotation anglel to use a trigo function 

        //TODO : check different addforce ForceMode : https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html

        //TODO : mettre les vecteurs dans l'ordre x,y,z ; peut être changer l'ordre dans lequel on set le vecteur dans GetInputs?
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(inputs.y * 3, inputs.z * 1, inputs.x * 3));

        
    }

    void CheckBoundarySideY(float minValue,float maxValue, float padding)
    {
        if (transform.position.y <= minValue + padding)
        {
            Vector3 newVector = transform.position;
            newVector.y = minValue + padding;
            GetComponent<Rigidbody>().MovePosition(newVector);
            //transform.position = newVector;
            debugAction = "transform.position.y <= minValue + padding";
            debugAction += transform.position.ToString();
            p.text = debugAction;
        }
        if (transform.position.y >= maxValue - padding)
        {
            Vector3 newVector = transform.position;
            newVector.y = maxValue - padding;
            GetComponent<Rigidbody>().MovePosition(newVector);
            
            debugAction = "transform.position.y >= maxValue + padding";
            debugAction += transform.position.ToString() ;
            p.text = debugAction;
        }
    }

    void CheckBoundarySideX(float minValue, float maxValue, float padding)
    {
        if (transform.position.x <= minValue + padding)
        {
            Vector3 newVector = transform.position;
            newVector.x = minValue + padding;
            GetComponent<Rigidbody>().MovePosition(newVector);
            debugAction = "transform.position.x <= minValue + padding";
            debugAction += transform.position.ToString();
            p.text = debugAction;
        }
        if (transform.position.x >= maxValue - padding)
        {
            Vector3 newVector = transform.position;
            newVector.x = maxValue - padding;
            GetComponent<Rigidbody>().MovePosition(newVector);
            debugAction = "transform.position.x >= maxValue + padding";
            debugAction += transform.position.ToString();
            p.text = debugAction;
        }
    }


    void CheckBoundarySideZ(float minValue, float maxValue, float padding)
    {
        if (transform.position.z <= minValue + padding)
        {
            Vector3 newVector = transform.position;
            newVector.z = minValue + padding;
            GetComponent<Rigidbody>().MovePosition(newVector);
            debugAction = "transform.position.z <= minValue + padding";
            debugAction += transform.position.ToString();
            p.text = debugAction;
        }
        if (transform.position.z >= maxValue - padding)
        {
            Vector3 newVector = transform.position;
            newVector.z = maxValue - padding;
            GetComponent<Rigidbody>().MovePosition(newVector);
            debugAction = "transform.position.z >= maxValue + padding";
            debugAction += transform.position.ToString();
            p.text = debugAction;
        }
    }
}
