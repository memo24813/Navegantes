using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
public class MisionBar : MonoBehaviour
{
    private Image _misionBar;
    private MisionSystem _misionSystem;


    private void Start() {
        _misionBar = GetComponent<Image>();
        _misionSystem = new MisionSystem();

        // maxMisions = PhotonNetwork.PlayerList.Length * (int)PhotonNetwork.PlayerList[0].CustomProperties["misionsMax"];
    }


    public void MisionComplete()
    {

        _misionBar.fillAmount = (float)_misionSystem.misionsComplete/(float)_misionSystem.maxMisions;
        Debug.Log(_misionSystem.misionsComplete);
        Debug.Log(_misionSystem.maxMisions);
    }

    private void Update() {
        MisionComplete();
    }
}
