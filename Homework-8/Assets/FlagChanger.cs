using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagChanger : MonoBehaviour
{
    public GameObject Flag;

    private void OnEnable()
    {       
        MovingScript.FlagChanged += ChangeFlag;
    }

    private void OnDisable()
    {
        MovingScript.FlagChanged -= ChangeFlag;
    }

    private void ChangeFlag(GameObject CurrenGrabHand)
    {
        Flag.transform.SetParent(CurrenGrabHand.transform);
        Flag.transform.position = CurrenGrabHand.transform.position;
       
    }
}
