using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor.UI;

public class TextUpdater : MonoBehaviour
{

    public Text testText1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        testText1.text = "zou";
    }
}
