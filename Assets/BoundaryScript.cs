using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    public Rigidbody playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckBoundary();
    }

    void CheckBoundary()
    {
        //check height boundary
        CheckBoundarySideY(0, 200, 0);


        //checck sideways boundary;
        CheckBoundarySideX(0, 1024, 70);
        //check forward/backward boundary
        CheckBoundarySideZ(0, 1024, 59);

    }


    void CheckBoundarySideY(float minValue, float maxValue, float padding)
    {
        if (playerRigidBody.transform.position.y <= minValue + padding)
        {
            Vector3 newVector = playerRigidBody.transform.position;
            newVector.y = minValue + padding;
            playerRigidBody.MovePosition(newVector);
            //transform.position = newVector;

        }
        if (playerRigidBody.transform.position.y >= maxValue - padding)
        {
            Vector3 newVector = transform.position;
            newVector.y = maxValue - padding;
            GetComponent<Rigidbody>().MovePosition(newVector);


        }
    }

    void CheckBoundarySideX(float minValue, float maxValue, float padding)
    {
        if (playerRigidBody.transform.position.x <= minValue + padding)
        {
            Vector3 newVector = transform.position;
            newVector.x = minValue + padding;
            playerRigidBody.MovePosition(newVector);
 
        }
        if (playerRigidBody.transform.position.x >= maxValue - padding)
        {
            Vector3 newVector = transform.position;
            newVector.x = maxValue - padding;
            playerRigidBody.MovePosition(newVector);

        }
    }


    void CheckBoundarySideZ(float minValue, float maxValue, float padding)
    {
        if (playerRigidBody.transform.position.z <= minValue + padding)
        {
            Vector3 newVector = transform.position;
            newVector.z = minValue + padding;
            playerRigidBody.MovePosition(newVector);

        }
        if (transform.position.z >= maxValue - padding)
        {
            Vector3 newVector = transform.position;
            newVector.z = maxValue - padding;
            GetComponent<Rigidbody>().MovePosition(newVector);

        }
    }
}
