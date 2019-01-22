using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SpikeControl : MonoBehaviour
{
    public static SpikeControl Instance;

    [Header("-------------SpikeController------------")]
    [SerializeField]
    private List<GameObject> SpikeRight;
    [SerializeField]
    private List<GameObject> SpikeLeft;
    private int spikeCount;
    [Header("------------Other GameObject")]
    public BoxCollider2D boxLeft;
    public BoxCollider2D boxRight;
    [SerializeField]
    private Animator rightAnim;
    [SerializeField]
    private Animator leftAnim;
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
    private void Start()
    {
        SetActiveRandomSpikeRight();
        if (UIStartManager.isHardMode == true)
        {
            rightAnim.SetTrigger("isHardMode");
            leftAnim.SetTrigger("isHardMode");
            UIStartManager.isHardMode = false;                                                   
        }
    }

    public void DisableSpikeLeft()
    {
        for (int i = 0; i < SpikeLeft.Count; i++)
        {
            if (SpikeLeft[i].activeSelf)
            {
                SpikeLeft[i].transform.DOMoveX(-8, 0.3f);
            }
        }
        StartCoroutine(Delay(SpikeLeft));
    }

    public void DisableSpikeRight()
    {
        for (int i = 0; i < SpikeRight.Count; i++)
        {
            if (SpikeRight[i].activeSelf)
            {
                SpikeRight[i].transform.DOMoveX(8, 0.3f);
            }
        }
        StartCoroutine(Delay(SpikeRight));
    }

    private IEnumerator Delay(List<GameObject> temp)
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < temp.Count; i++)
        {
            temp[i].SetActive(false);
        }
    }
    public void SetActiveRandomSpikeLeft()
    {
        if (PlayerMovement.Instance.isDead == false)
        {
            for (int i = 0; i < SetSpikeCount(); i++)
            {
                int spikeIndex = Random.Range(0, SpikeLeft.Count - 1);
                SpikeLeft[spikeIndex].SetActive(true);
            }
        }

    }

    public void SetActiveRandomSpikeRight()
    {
        if (PlayerMovement.Instance.isDead == false)
        {
            for (int i = 0; i < SetSpikeCount(); i++)
            {
                int spikeIndex = Random.Range(0, SpikeRight.Count - 1);
                SpikeRight[spikeIndex].SetActive(true);
            }
        }

    }


    private int SetSpikeCount()
    {
        if (ScoreManager.Instance.CurrentScore < 10)
        {
            spikeCount = Random.Range(2, 5);
        }
        else if (ScoreManager.Instance.CurrentScore >= 10 && ScoreManager.Instance.CurrentScore < 30)
        {
            spikeCount = Random.Range(3, 6);
        }
        else if (ScoreManager.Instance.CurrentScore >= 30 && ScoreManager.Instance.CurrentScore < 50)
        {
            spikeCount = Random.Range(4, 8);
        }
        else if (ScoreManager.Instance.CurrentScore >= 50 && ScoreManager.Instance.CurrentScore < 70)
        {
            spikeCount = Random.Range(5, 8);
        }
        else if (ScoreManager.Instance.CurrentScore >= 70 && ScoreManager.Instance.CurrentScore < 100)
        {
            spikeCount = Random.Range(5, 10);
        }
        else if (ScoreManager.Instance.CurrentScore >= 100)
        {
            spikeCount = Random.Range(7, 10);
        }
        return spikeCount;
    }
}
