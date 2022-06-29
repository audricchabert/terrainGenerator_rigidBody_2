using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpeedUpdater : MonoBehaviour
{
    public GameObject player;
    public Vector3 previousPosition;
    public Vector3 currentPosition;
    public Text text3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (previousPosition == null)
        {
            print("pascool");
            previousPosition = player.transform.position;
        }
        else
        {
            currentPosition = player.transform.position;
            Vector3 positionDelta = new Vector3(previousPosition.x - currentPosition.x,previousPosition.y-currentPosition.y, previousPosition.z- currentPosition.z);
            print(positionDelta);
            text3.text = positionDelta.ToString();

            float velocityz = player.GetComponent<Rigidbody>().velocity.magnitude;
            text3.text += "magnitude:"+velocityz.ToString();
            

            previousPosition = currentPosition;
        }
    }
}
