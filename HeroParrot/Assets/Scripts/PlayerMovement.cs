using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [Header("-------------PlayerInfo---------------")]
    private Rigidbody2D rb;
    [SerializeField]
    [Range(1, 500)]
    private float speed;
    public int direction = 1;
    public bool isDead;

    [Header("-----------------Animation")]
    [SerializeField]
    private Animator playerAnim;
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
        rb = GetComponent<Rigidbody2D>();
    }

    public void PlayMove()
    {
        rb.velocity = (new Vector2(40 * direction, 75) * speed * Time.deltaTime);
        AudioManager.Instance.PlayFlapClip();
        playerAnim.Play(Constant.Animation.BIRDFLY);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Constant.Tag.WALL)
        {
            direction = direction * -1;
            rb.velocity = new Vector2(40 * direction, 40)*7 * Time.deltaTime;
            transform.localScale = new Vector3(1 * direction, 1, 1);
            ScoreManager.Instance.AddScore();
            UIManager.Instance.SetCurrentScoreText();
            AudioManager.Instance.PlaySpringClip();
        }
        else if (col.tag == Constant.Tag.SPIKE)
        {
            rb.AddTorque(-100);
            UIManager.Instance.ShowGameOverPanel();
            playerAnim.Play(Constant.Animation.BIRDDEAD);
            AudioManager.Instance.PlayDeadClip();
            ScoreManager.Instance.SetBestScore();
            gameObject.tag = Constant.Tag.UNTAGGED;
            isDead = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(4.5f);
        gameObject.SetActive(false);
    }
}
