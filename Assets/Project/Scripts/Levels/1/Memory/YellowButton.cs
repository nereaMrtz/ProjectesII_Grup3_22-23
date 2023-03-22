using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowButton : Combination
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Yellow");
            AddColor(2);
        }

    }
}
