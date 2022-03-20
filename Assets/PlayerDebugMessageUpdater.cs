using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDebugMessageUpdater : MonoBehaviour
{
    public string debugMessage;
    public Text testText1;
    // Start is caslled before the first frame update
    void Start()
    {
        
    }

    public void setDebugMessage(string tempDebugMessage)
    {
        debugMessage = tempDebugMessage;
    }

    // Update is called once per frame
    void Update()
    {
        testText1.text = debugMessage;
    }
}
