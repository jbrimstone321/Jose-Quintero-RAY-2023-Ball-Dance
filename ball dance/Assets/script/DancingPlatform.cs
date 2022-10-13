using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingPlatform : MonoBehaviour
{
    [SerializeField]
    GameObject stops;
    public float dancingPlatZ = 0.2f;
    public float dancingPlatX = -0.2f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(dancingPlatX, 0f, dancingPlatZ * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == stops)
        {
            dancingPlatZ *= -1;
            dancingPlatX *= -1;
            Debug.Log("colision");
        }
    }
}

