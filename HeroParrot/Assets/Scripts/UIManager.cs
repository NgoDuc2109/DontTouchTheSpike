using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField]
    private Text currentScoreText;
    [SerializeField]
    private Text gameOverScoreText;
    [SerializeField]
    private Text bestScoreText;
    [SerializeField]
    private Text totalGemText;
    [SerializeField]
    private Text gamesPlayedText;
    [SerializeField]
    private GameObject gameoverPanel;
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
    }
    public void SetCurrentScoreText()
    {
        currentScoreText.text = ScoreManager.Instance.CurrentScore.ToString();
    }

    public void ShowGameOverPanel()
    {
        bestScoreText.text = Constant.String.BESTSCORE + ScoreManager.Instance.BestScore().ToString();
        gameOverScoreText.text = ScoreManager.Instance.CurrentScore.ToString();
        totalGemText.text = ScoreManager.Instance.TotalGem().ToString();
        gameoverPanel.SetActive(true);
    }

    public void OnClickReplayBtn()
    {
        SceneManager.LoadScene(Constant.Scenes.STARTSCENE);
    }
}
