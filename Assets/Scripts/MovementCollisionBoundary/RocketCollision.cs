using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketCollision : MonoBehaviour
{

    public Text genericTopText;
    int objectiveScore = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            objectiveScore++;
            //genericTopText.text = objectiveScore.ToString();
            Debug.Log("rocket debug : "+objectiveScore);

            //GameObject.Find("PlayerDebugMessageUpdater").GetComponent<Text>().text = objectiveScore.ToString();
            //GetComponent<PlayerDebugMessageUpdater>().testText1.text = objectiveScore.ToString();

        }
        else
        {
            Debug.Log("player hit!");
        }
    }
}
