using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 upForce =new Vector3(0, 50,0);
    private GameObject ss;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.startTheGame == true)
        {
            rb.isKinematic = false;
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(upForce);
            }
        }
        else
        {
            rb.isKinematic = true;
        }

        
    }
}
