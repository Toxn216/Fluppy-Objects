using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] wallPrefabs;
    private float spawnX = 17;
    private float spawnY = 0 ;
    private float startDelay = 1;
    private float spawnInterval = 5;
    public bool isGameActive = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomWall());
        //InvokeRepeating("SpawnRandomWall",startDelay,spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnRandomWall()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            int wallIndex = Random.Range(0,wallPrefabs.Length);
            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
            Instantiate(wallPrefabs[wallIndex], spawnPos, wallPrefabs[wallIndex].transform.rotation);
        }
    }
}
