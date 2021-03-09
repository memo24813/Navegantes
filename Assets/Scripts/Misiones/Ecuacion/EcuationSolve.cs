using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EcuationSolve : MonoBehaviour
{

    public TextMeshProUGUI operation,input;

    private AudioSource _as;
    public AudioClip win,lose;

    [System.Serializable]
    public struct Operations
    {
        public string operation;
        public float result;

        public Operations(string operation,float result)
        {
            this.operation = operation;
            this.result = result;
        }
    }
    public Operations[] operationResolve;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
        index = Random.Range(0,operationResolve.Length-1);
        operation.text= operationResolve[index].operation;
        input.text="";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setNumber(string n)
    {
        if(input.color == Color.red)
        {
            input.color = Color.white;
            input.text = "";
        }
        if(input.text.Length<6)
        {
            input.text+=n;
        }
    }

    public void clearInput()
    {
        if(input.color == Color.red)
        {
            input.color = Color.white;
            input.text = "";
        }
        input.text="";
    }

    public void validateOperation()
    {
        if(int.Parse(input.text)==operationResolve[index].result)
        {
            input.color  = Color.green;
            input.text = "Correcto";
            _as.PlayOneShot(win);
            Destroy(gameObject,2f);
        }
        else
        {
            input.color = Color.red;
            input.text = "Incorrecto";
            _as.PlayOneShot(lose);
        }
    }

}
