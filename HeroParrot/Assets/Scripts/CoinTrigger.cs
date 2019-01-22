using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Constant.Tag.PLAYER)
        {
            GemSpawnControl.isTrigger = true;
            ScoreManager.Instance.AddGem();
            AudioManager.Instance.PlayGemClip();
            if (gameObject.transform.position.x > 0)
            {
                GemSpawnControl.Instance.ActiveCoinLeft();
            }
            else
            {
                GemSpawnControl.Instance.ActiveCoinRight();
            }
            gameObject.SetActive(false);
        }
    }
}
