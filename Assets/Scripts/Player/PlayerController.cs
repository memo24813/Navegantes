using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 
    private float x,y;
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        transform.Rotate(0,x*Time.deltaTime*velocidadRotacion,0);
        transform.Translate(0,0,y*Time.deltaTime*velocidadMovimiento);   
    }

    void Update()
    {  
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("VelX",x);
        anim.SetFloat("VelY",y);
    }
}
