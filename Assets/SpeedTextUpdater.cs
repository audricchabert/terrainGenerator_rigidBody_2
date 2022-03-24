using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTextUpdater : MonoBehaviour
{
    public GameObject player;
    public Text testo;
    Vector3 previousPosition;
    Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(previousPosition.Equals(new Vector3(0.0f, 0.0f, 0.0f)))
        {
            previousPosition = player.transform.position;
            print("init");
        }
        else
        {
            //faire en sore qu'on ait un fixedTime pour prendre la valeur de vitesse uniquement la premère frame de chaque seconde paire
            //comme a=ça on if Time.fixedTime modulo 2, then pairNew =true et vitesse=vitesse, et lorsque seconde impaire, remettre pairNew = false
            //Time.fixedTime
            Vector3 velociry = this.player.GetComponent<Rigidbody>().velocity;
            print(velociry);
            testo.text = string.Concat(velociry.ToString(), this.player.GetComponent<Rigidbody>().velocity.magnitude);
            
                /*;
            currentPosition = player.transform.position;
            Vector3 currentSpeed = new Vector3((previousPosition.x - currentPosition.x)*Time.deltaTime , previousPosition.y - currentPosition.y - previousPosition.z -currentPosition.z);
            print(currentSpeed);
            testo.text = currentSpeed.ToString();
            previousPosition = currentPosition;
                */
        }
        
        
    }
}
