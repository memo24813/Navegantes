using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MisionCode : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text,code;
    public AudioClip t,f;
    private AudioSource _as;
    private int _number;
    
    private PlayerDescription _playerDescription;
    void Start()
    {
        _playerDescription = new PlayerDescription();
        text.text = "";
        _number = Random.Range(12345,99999);
        _as = GetComponent<AudioSource>();

        code.text = _number.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void concatText(string c)
    {
        if(text.text.Equals("Incorrecto"))
        {
            text.color = Color.white;
            text.text="";
        }
        if(text.text.Length<5)
        {
            text.text+=c;
        }
    }


    public void validateCode()
    {
        if(_number.ToString().Equals(text.text))
        {
            // _playerDescription.MisionsCount = 1;
            _playerDescription.UpdateHashTablePlayer(_playerDescription.MisionsMax,_playerDescription.MisionsCount+1,_playerDescription.IsNavigator,_playerDescription.IsAlive);
            text.text="Correcto";
            text.color = Color.green;
            _as.PlayOneShot(t);
            Destroy(gameObject,2f);
        }
        else
        {
            text.color = Color.red;
            text.text = "Incorrecto";
            _as.PlayOneShot(f);
        }
    }

    public void eraseCode()
    {
        if(text.color ==Color.red)
            text.color = Color.white;
        text.text="";
    }
}
