using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GenericDebugTextUpdater : MonoBehaviour
{
    public Text testo;
    public string testoInputText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        testo.text = testoInputText;
    }
}
