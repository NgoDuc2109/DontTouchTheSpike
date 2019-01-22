using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> listPlayers;
    private void Awake()
    {
        Instantiate(listPlayers[UIStartManager.currentPlayer],Vector3.zero,Quaternion.identity);
    }

}
