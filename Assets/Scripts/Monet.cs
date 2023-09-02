using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Monet : MonoBehaviour
{
    //[SerializeField] private GameObject monetPrefab;
    [SerializeField] private float spawnXMonet = 19.5f;

    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TransformMonet();      
    }

    private void TransformMonet()
    {
        transform.position = transform.position - Vector3.right * 1f * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.UpdateScore(10);
            Destroy(gameObject);
        }
    }

}
