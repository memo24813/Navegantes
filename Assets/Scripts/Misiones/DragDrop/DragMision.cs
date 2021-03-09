using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMision : MonoBehaviour
{
    public int elements=0;
    public int sizeElements;

    private AudioSource _as;
    public AudioClip success;
    private PlayerDescription _playerDescription;


    private void Awake() {
        _playerDescription = new PlayerDescription();

        _as = GetComponent<AudioSource>();
    }
    public void validateElements()
    {
        if(elements==sizeElements)
        {
            _playerDescription.UpdateHashTablePlayer(_playerDescription.MisionsMax,_playerDescription.MisionsCount+1,_playerDescription.IsNavigator,_playerDescription.IsAlive);
            _as.PlayOneShot(success);
            Destroy(gameObject,2f);
        }
    }
}
