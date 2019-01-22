using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class SpritePlayer
{
    public Sprite playerNormal;
    public Sprite playerFly;
}
public class ChangeSpritePlayerUI : MonoBehaviour
{
    [SerializeField]
    private List<SpritePlayer> listPlayer;

    private void Start()
    {
        InvokeRepeating("ChangeSprite", 0,1);
    }

    private void ChangeSprite()
    {
            transform.GetComponent<Image>().sprite = listPlayer[PlayerPrefs.GetInt(Constant.PlayerInfo.CURRENTPLAYER)].playerNormal;
            StartCoroutine( DelayTime());
            
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(0.5f);
        transform.GetComponent<Image>().sprite = listPlayer[PlayerPrefs.GetInt(Constant.PlayerInfo.CURRENTPLAYER)].playerFly;
    }
}
