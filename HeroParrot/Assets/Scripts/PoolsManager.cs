using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolsManager : MonoBehaviour
{
    public static PoolsManager Instance;
    [SerializeField]
    private ObjectPoolScript coin;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
  

    public GameObject RetrieveCoinFromPool()
    {
        GameObject obj;
        //new GameObject named obj and it calls GetPooledObejct on the tempPool. 
        obj = coin.GetPooledObject();
        obj.SetActive(true);
        //objectPoolScript named tempPool gets accesses the elements in the array at position R
        return obj;
    }
}
