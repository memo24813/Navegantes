using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMision : MonoBehaviour
{
    public GameObject prefab;

    public void OnClick_DestroyPrefab()
    {
        GameObject.Destroy(prefab,1f);
    }
}
