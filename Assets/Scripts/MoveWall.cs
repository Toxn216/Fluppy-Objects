using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveWall : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TransformWall();
    }
    private void TransformWall()
    {
        transform.position = wall.transform.position - Vector3.right * 1f * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.UpdateScore(1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.isGameActive = false;
            gameManager.GameOver();
            Destroy(collision.gameObject);
        }
    }
}
