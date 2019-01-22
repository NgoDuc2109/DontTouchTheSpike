using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class OnClickEventScript : MonoBehaviour, IPointerDownHandler/*,IPointerUpHandler*/
{
    [SerializeField]
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Constant.Tag.PLAYER);
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (Input.touchCount >1)
        {
            return;
        }
        else
        {
            player.GetComponent<PlayerMovement>().PlayMove();
        }
    }
     

    //public void OnPointerUp(PointerEventData data)
    //{

    //}
}
