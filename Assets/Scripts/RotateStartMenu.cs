using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() 
    {
        transform.Rotate(new Vector3(0,0.1f,0));
    }
    // Update is called once per frame
    void Update()
    {
            // transform.Rotate(new Vector3(0,0.1f,0));
    }
}
