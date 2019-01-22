using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private List<float> costBirds;
    [SerializeField]
    private List<GameObject> buyBtn;

    [SerializeField]
    private Text totalGemText;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetFloat(Constant.ScoreInfo.TOTALGEM, 10000);
        for (int i = 0; i < buyBtn.Count; i++)
        {
            if (PlayerPrefs.GetInt(Constant.PlayerInfo.LISTPLAYER[i]) ==1)
            {
                buyBtn[i].SetActive(false);
            }
        }
    }
    public void OnClickBuyBird(int number)
    {
        if (PlayerPrefs.GetFloat(Constant.ScoreInfo.TOTALGEM) >= costBirds[number])
        {
            PlayerPrefs.SetInt(Constant.PlayerInfo.LISTPLAYER[number],1);
            PlayerPrefs.SetFloat(Constant.ScoreInfo.TOTALGEM,PlayerPrefs.GetFloat(Constant.ScoreInfo.TOTALGEM)- costBirds[number]);
            totalGemText.text = ScoreManager.Instance.TotalGem().ToString();
            buyBtn[number].SetActive(false);
            AudioManager.Instance.PlayBuySuccessClip();
        }
        else
        {
            Debug.Log("Not enough money");
            AudioManager.Instance.PlayBuyFailClip();
        }
    }

    public void OnClickSelectBtn(int number)
    {
        UIStartManager.currentPlayer = number;
        PlayerPrefs.SetInt(Constant.PlayerInfo.CURRENTPLAYER,number);
        SceneManager.LoadScene(Constant.Scenes.MAINSCENE);
    }
}
