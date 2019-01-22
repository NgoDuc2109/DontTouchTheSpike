using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIStartManager : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> playerSprite;
    [SerializeField]
    private GameObject shopPanel;
    [SerializeField]
    private Text bestScoreText;
    [SerializeField]
    private Text totalGemText;
    [SerializeField]
    private Text totalGemTextInShop;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    Animator shopAnim;

    public static int currentPlayer;
    public static bool isHardMode;
    private void Start()
    {
        bestScoreText.text = Constant.String.BESTSCORE + ScoreManager.Instance.BestScore().ToString();
        totalGemText.text = ScoreManager.Instance.TotalGem().ToString();
        totalGemTextInShop.text = ScoreManager.Instance.TotalGem().ToString();
        player.GetComponent<Image>().sprite = playerSprite[PlayerPrefs.GetInt(Constant.PlayerInfo.CURRENTPLAYER)];
        currentPlayer = PlayerPrefs.GetInt(Constant.PlayerInfo.CURRENTPLAYER);
    }
    public void OnClickStartBtn()
    {       
        SceneManager.LoadScene(Constant.Scenes.MAINSCENE);
    }

    public void OnClickShopBtn()
    {
        //player.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void OnClickBackBtn()
    {
        shopAnim.Play(Constant.Animation.HIDESHOPPANEL);
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        shopPanel.SetActive(false);
    }

    public void OnClickHardModeBtn()
    {
        isHardMode = true;
        SceneManager.LoadScene(Constant.Scenes.MAINSCENE);
    }
}
