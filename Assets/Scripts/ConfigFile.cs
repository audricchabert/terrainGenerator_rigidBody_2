using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.MapGenerator.Generators;

public class ConfigFile : MonoBehaviour {

    //maybe need to import file from TerrainGenerator folder
    //public HeightsGenerator a;
    //public TestScript ts;
    HeightsGenerator haha;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().mass=140;

        /*
         * TRY TO ACCESS DEBUG TEXT, dont remember why ill do that
         */
        //ts.zou="a";
        Debug.Log(GameObject.Find("DebugText").GetComponent<Text>());
        print(GameObject.Find("DebugText").GetComponent<Text>());
        GameObject.Find("DebugText").GetComponent<Text>().text = "nouveau";
        //move _move = FindObjectOfType<DebugText>();


        /*
         * ACCESS AND MODIFY TERRAIN GENERATOR
         */

        //HeightsGenerator a = GetComponent<HeightsGenerator>();
        //https://docs.unity3d.com/ScriptReference/GameObject.Find.html
        haha = GameObject.Find("Terrain/Terrain").GetComponent<HeightsGenerator>();
        //haha.Width = 2;
        haha.Generate();
        //apparently better to not use find in update : https://forum.unity.com/threads/c-help-finding-an-object-in-hierarchy.281672/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
