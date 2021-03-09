using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
public class DiscardPhotonCode : MonoBehaviour
{
    public MonoBehaviour[] ignoreCode;
    private PhotonView _pv;
    // Start is called before the first frame update
    void Start()
    {
        _pv = GetComponent<PhotonView>();

        if(!_pv.IsMine)
        {
            foreach (var code in ignoreCode)
            {
                code.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
