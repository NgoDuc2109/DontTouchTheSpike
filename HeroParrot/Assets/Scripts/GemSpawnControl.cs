using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawnControl : MonoBehaviour {

    public static GemSpawnControl Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        isTrigger = true;
    }

    private void Start()
    {
                ActiveCoinRight();
    }

    [SerializeField]
    private float xLeft, xRight,yMin, yMax;
    public static bool isTrigger;
    public void ActiveCoinLeft()
    {
        if (isTrigger == true && PlayerMovement.Instance.isDead == false)
        {
            GameObject clone = PoolsManager.Instance.RetrieveCoinFromPool();
            clone.transform.position = new Vector2(xLeft, Random.Range(yMin, yMax));
            clone.transform.rotation = Quaternion.identity;
            isTrigger = false;
        }
    }
    public void ActiveCoinRight()
    {
        if (isTrigger == true && PlayerMovement.Instance.isDead == false)
        {
            GameObject clone = PoolsManager.Instance.RetrieveCoinFromPool();
            clone.transform.position = new Vector2(xRight, Random.Range(yMin, yMax));
            clone.transform.rotation = Quaternion.identity;
            isTrigger = false;
        }
    }
}
