using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsScript : MonoBehaviour
{
    private int maxDistance=300;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < -maxDistance || transform.position.y > maxDistance)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -maxDistance || transform.position.x > maxDistance)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < -maxDistance || transform.position.z > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
