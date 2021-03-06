using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector3 inputs;
    public Text ptext;
    public Text genericTopText;
    
    //ref https://www.youtube.com/watch?v=wlZUu-I05Bk

    string debugAction="";
    public Vector3 velocityz;

    //x = forward / backward
    public float XforwardBackwardAcceleration = 1000;
    //y = up/down
    public float YupDownAcceleration = 500;
    //z = left or right
    public float ZrightLeftAcceleration = 1000;

    public PhysicMaterial slide;


    public float horizontalSpeed;
      ForceMode forceMode = ForceMode.Force;

    int maxSpawn = 0;
    public GameObject objectivePrefabRigid;
    public GameObject objectivePrefabScript;
    public GameObject rocketPrefabBall;

    public int objectiveScore=0;
    CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
            
        ProcessInputs();
        MovePlayer();

        if(cameraController.cameraRotation.eulerAngles.x > 45)
        {
            //Debug.Log("regard vers le haut");
        }
    }


    void ProcessInputs()
    {
        float XupDown = Input.GetAxis("Vertical");

        float ZleftRight = Input.GetAxis("Horizontal");
        float YupDown = 0;
        if (Input.GetButton("Fire2"))
        {
            YupDown = 1;
        }
        else
        {
            YupDown = 0;
        }
        inputs = new Vector3(XupDown,YupDown, ZleftRight);


        //hover when left clicking
        if (Input.GetButton("Fire1"))
        {
            //changeDrag(6.0f);
            //slide.dynamicFriction = 0;
            //slide.staticFriction = 0;

            //cycleForceModes();
            if(maxSpawn < 3)
            {
                Instantiate(objectivePrefabRigid, new Vector3(290, 82, 234), objectivePrefabRigid.transform.rotation);
                Instantiate(objectivePrefabScript, new Vector3(295, 77, 234), objectivePrefabScript.transform.rotation);

                maxSpawn++;
            }
            if (maxSpawn < 10)
            {
                Quaternion rocketRotation = transform.rotation;
                rocketRotation.SetEulerAngles(cameraController.cameraRotation.x ,transform.rotation.y, transform.rotation.z);
                
                Instantiate(rocketPrefabBall, transform.position, rocketRotation);
                
                maxSpawn++;
            }
        }
        else
        {
            //slide.dynamicFriction = 1;
            //slide.staticFriction = 1;
            //changeDrag(0.0f);
        }

    }

    void cycleForceModes()
    {
        //cycle through force modes
        if (forceMode == ForceMode.Force)
        {
            forceMode = ForceMode.Impulse;
        }
        if (forceMode == ForceMode.Impulse)
        {
            forceMode = ForceMode.VelocityChange;
        }
        if (forceMode == ForceMode.VelocityChange)
        {
            forceMode = ForceMode.Acceleration;
        }
        if (forceMode == ForceMode.Acceleration)
        {
            forceMode = ForceMode.Force;
        }
    }

    void MovePlayer()
    {
        //log the velocity for the PlayerSpeedUpdater
        velocityz = GetComponent<Rigidbody>().velocity;

        //Add force to the rigidbody
        AddForce();
        LimitSpeed();
        CheckBoundary();
    }

    void CheckBoundary()
    {
        //check height boundary
        CheckBoundarySideY(0, 600, 0);


        //checck sideways boundary;
        CheckBoundarySideX(0, 1024, 70);
        //check forward/backward boundary
        CheckBoundarySideZ(0, 1024, 59);

    }

    void LimitSpeed()
    {
        Vector3 velocityrezr = GetComponent<Rigidbody>().velocity;
        horizontalSpeed = velocityrezr.x * velocityrezr.x + velocityrezr.y * velocityrezr.y;
        Mathf.Sqrt(horizontalSpeed);
        
    }

    void changeDrag(float value)
    {
        GetComponent<Rigidbody>().drag = value;
    }

    void AddForce()
    {
        //TODO : get rotation anglel to use a trigo function 

        //TODO : check different addforce ForceMode : https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html

        //TODO : mettre les vecteurs dans l'ordre x,y,z ; peut ?tre changer l'ordre dans lequel on set le vecteur dans GetInputs?
        //GetComponent<Rigidbody>().AddRelativeForce(new Vector3(inputs.y * xAcceleration, inputs.z * yAcceleration, inputs.x * zAcceleration));
        GetComponent<Rigidbody>().AddRelativeForce(inputs.z * XforwardBackwardAcceleration, inputs.y * YupDownAcceleration, inputs.x * ZrightLeftAcceleration,forceMode);
      

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
            ptext.text = debugAction;
        }
        if (transform.position.y >= maxValue - padding)
        {
            Vector3 newVector = transform.position;
            newVector.y = maxValue - padding;
            GetComponent<Rigidbody>().MovePosition(newVector);
            
            debugAction = "transform.position.y >= maxValue + padding";
            debugAction += transform.position.ToString() ;
            ptext.text = debugAction;
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
            ptext.text = debugAction;
        }
        if (transform.position.x >= maxValue - padding)
        {
            Vector3 newVector = transform.position;
            newVector.x = maxValue - padding;
            GetComponent<Rigidbody>().MovePosition(newVector);
            debugAction = "transform.position.x >= maxValue + padding";
            debugAction += transform.position.ToString();
            ptext.text = debugAction;
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
            ptext.text = debugAction;
        }
        if (transform.position.z >= maxValue - padding)
        {
            Vector3 newVector = transform.position;
            newVector.z = maxValue - padding;
            GetComponent<Rigidbody>().MovePosition(newVector);
            debugAction = "transform.position.z >= maxValue + padding";
            debugAction += transform.position.ToString();
            ptext.text = debugAction;
        }
    }


    //collision detection
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            objectiveScore++;
            genericTopText.text = objectiveScore.ToString();
            Debug.Log(objectiveScore);

            //GameObject.Find("PlayerDebugMessageUpdater").GetComponent<Text>().text = objectiveScore.ToString();
            //GetComponent<PlayerDebugMessageUpdater>().testText1.text = objectiveScore.ToString();

        }
    }
}
