using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody Player;
    Vector3 direction;
    public float pSpeed = 10f;
    public float coinPurse = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal") * 10 * Time.deltaTime * pSpeed;
        direction.z = Input.GetAxis("Vertical") * 10 * Time.deltaTime * pSpeed;
    }

    private void FixedUpdate()
    {
        
        Player.AddForce(direction, ForceMode.Impulse);

    }

    //Coin Collection system using custom object tag "coin" and disabling them on collision.
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "coin")
        {
            collision.gameObject.SetActive(false);
            coinPurse = coinPurse + 1;
            Debug.Log(coinPurse);
        }
    }
}
