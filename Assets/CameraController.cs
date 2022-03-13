using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    int start = 0;


    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 


        //CODE CAMERA

        //regarder test_addforce/assets/movecamera.cs pour plus d'infos
        if (start ==0)// je voulais juste faire <= 0 au début
        {

        Vector3 playerPosition = gameObject.transform.position;
        playerPosition.z -= 10;
        transform.position = playerPosition;
            start++;
            //FAUX : il semble qu'il faut que le player -> constraints -> freeze postion=Z soit mis pour ne pas se barrer

        }
        //transform.position += new Vector3(0, 0, 10);
        //transform.Translate(new Vector3(0, 0, 10), Space.World);
    }

}

