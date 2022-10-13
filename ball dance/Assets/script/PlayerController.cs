using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Coin Particles Serialization.
    [SerializeField]
    GameObject coinParticles;

    //World Music object
    [SerializeField]
    GameObject worldMusic;

    //Game UI
    [SerializeField]
    GameObject gameUI;
    [SerializeField]
    TextMeshProUGUI coinsLeft;

    //Winners Screen
    [SerializeField]
    TextMeshProUGUI coinsPicked;
    [SerializeField]
    GameObject endScreen;

    //Loser's Screen
    [SerializeField]
    GameObject uDeadBoi;


    //--------------------------------------------
    Rigidbody Player;

    Vector3 direction;

    public float pSpeed = 10f;

    public float coinPurse = 0f;

    float coinsToPick = 0f;

    bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        coinsToPick = 12 - coinPurse;
        if (isGameActive == true)
        {
            //Selection of vector3 axises for Movement plus their values.
            direction.x = Input.GetAxis("Horizontal") * 10 * Time.deltaTime * pSpeed;
            direction.z = Input.GetAxis("Vertical") * 10 * Time.deltaTime * pSpeed;
            //coins counter
            coinsLeft.text = coinsToPick.ToString();
        }
        if (coinPurse == 12)
        {
            Debug.Log("Victory");
            isGameActive = false;
            worldMusic.SetActive(false);
            gameUI.SetActive(false);
            endScreen.SetActive(true);
            coinParticles.SetActive(false);
        }

        coinsPicked.text = coinPurse.ToString();
    }

    private void FixedUpdate()
    {

        Player.AddForce(direction, ForceMode.VelocityChange);

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

            //particle spawning on coin pickup
            Instantiate(coinParticles, collision.transform.position, collision.transform.rotation);
            Debug.Log("particles wewo");
        }

        if (collision.gameObject.tag == "killzone")
        {
            Debug.Log("U ded boi");
            isGameActive = false;
            worldMusic.SetActive(false);
            gameUI.SetActive(false);
            uDeadBoi.SetActive(true);
            coinParticles.SetActive(false);
        }
    }


        public void ClickOnButton()
        {
            Debug.Log("Click");
            SceneManager.LoadScene(0);
        }
    }


