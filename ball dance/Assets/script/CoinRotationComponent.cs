using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotationComponent : MonoBehaviour
{
  // Update is called once per frame, this makes the coins rotate in place.
    void Update()
    {
        transform.Rotate(0f, 0f, -120f * Time.deltaTime);
    }
}