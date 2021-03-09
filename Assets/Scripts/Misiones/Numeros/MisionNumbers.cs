using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MisionNumbers : MonoBehaviour
{
    public AudioClip lose,win;
    private AudioSource _as;
    public Button[] buttons;
    private int counter;

    private List<int> numbersRand = new List<int>();
    private PlayerDescription _playerDescription;

    void Start()
    {
        _playerDescription = new PlayerDescription();
        counter = 0;
        _as = GetComponent<AudioSource>();
        generatedRands();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void valideButton(int index)
    {
        if(buttons[index].GetComponentInChildren<TextMeshProUGUI>().text.Equals(counter.ToString()))
        {
            counter++;
            buttons[index].GetComponent<Image>().color = Color.green;
        }
        else
        {
            _as.PlayOneShot(lose);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Image>().color = Color.white;  
            }
            counter=0;
        }
        if(counter == buttons.Length)
        {
            _playerDescription.UpdateHashTablePlayer(_playerDescription.MisionsMax,_playerDescription.MisionsCount+1,_playerDescription.IsNavigator,_playerDescription.IsAlive);
            _as.PlayOneShot(win);
            Destroy(gameObject,2f);
        }
    }

    void generatedRands()
    {
        int number;
        for (int i = 0; i <10; i++)
        {
            do
            {
                number =  Random.Range(0,10);
            }while(numbersRand.Contains(number));
            numbersRand.Add(number);
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text= number.ToString();
        }
    }
}
