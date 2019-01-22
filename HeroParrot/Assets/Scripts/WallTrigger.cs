using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Constant.Tag.PLAYER)
        {
            if (PlayerMovement.Instance.direction == 1)
            {
                SpikeControl.Instance.SetActiveRandomSpikeRight();
                SpikeControl.Instance.DisableSpikeLeft();
            }
            else if (PlayerMovement.Instance.direction == -1)
            {
                SpikeControl.Instance.SetActiveRandomSpikeLeft();
                SpikeControl.Instance.DisableSpikeRight();
            }
        }
    }
}
