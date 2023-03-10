using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    [SerializeField] float magnitude;
    private float newX = 0;
    bool top = false;
    void Start()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        while (true)
        {
            if (transform.localPosition.x >= -1.0f && !top)
            {
                newX = transform.localPosition.x - 0.01f;

            }
             else
            {
                top = true;
                newX = transform.localPosition.x + 0.01f;

                if (transform.localPosition.x > 1.0f)
                {
                    top = false;
                }
            }

            transform.localPosition = new Vector3(newX, -0.8600001f, -10);

            yield return new WaitForSeconds(0.001f);
        }   
    }
}
