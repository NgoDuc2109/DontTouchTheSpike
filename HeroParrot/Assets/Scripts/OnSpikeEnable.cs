using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class OnSpikeEnable : MonoBehaviour
{
    [SerializeField]
    private float offset;
    private void OnEnable()
    {
        transform.DOMoveX(offset,0.3f);
    }
}
