using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.Managers;

public class HintButton : MonoBehaviour
{
 
    public void StopPlayerMovement()
    {
        GameManager.Instance.SetZoomInState(true);
    }

    public void ActivePlayerMovement()
    {
        GameManager.Instance.SetZoomInState(false);

    }
}
