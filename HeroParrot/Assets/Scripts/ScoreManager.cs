using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

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

    [SerializeField]
    private float currentScore;

    public float CurrentScore
    {
        get
        {
            return currentScore;
        }

        set
        {
            currentScore = value;
        }
    }

    public void AddScore()
    {
        if (PlayerMovement.Instance.isDead == false)
        {
            CurrentScore++;
        }
    }
    
    public void AddGem()
    {
        PlayerPrefs.SetFloat(Constant.ScoreInfo.TOTALGEM,PlayerPrefs.GetFloat(Constant.ScoreInfo.TOTALGEM) +1);
    }


    public void SetBestScore()
    {
        if (currentScore > PlayerPrefs.GetFloat(Constant.ScoreInfo.BESTSCORE))
        {
            PlayerPrefs.SetFloat(Constant.ScoreInfo.BESTSCORE,currentScore);
        }
    }
    public float BestScore()
    {
        return PlayerPrefs.GetFloat(Constant.ScoreInfo.BESTSCORE);
    }

    public float TotalGem()
    {
        return PlayerPrefs.GetFloat(Constant.ScoreInfo.TOTALGEM);
    }
}
