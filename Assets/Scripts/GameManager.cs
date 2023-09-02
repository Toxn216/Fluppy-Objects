using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] wallPrefabs;
    [SerializeField] private GameObject monetPrefab;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverUi;
    [SerializeField] private Button restartButton;

    [SerializeField] private float spawnXMonet = 19.5f;
    private float randomYspawn = 7;
    private float startDelay = 2;
    private float spawnInterval = 12;

    private float spawnX = 17f;
    private float spawnY = 0f;
    private float score;
    private float spawnWallInterval = 6f;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnRandomWall());
        InvokeRepeating("SpawnRandomMonet", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }
    IEnumerator SpawnRandomWall()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnWallInterval);
            int wallIndex = Random.Range(0, wallPrefabs.Length);
            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
            Instantiate(wallPrefabs[wallIndex], spawnPos, wallPrefabs[wallIndex].transform.rotation);
        }
    }
    void SpawnRandomMonet()
    {
        Vector3 spawnPos = new Vector3(spawnXMonet, Random.Range(randomYspawn, -randomYspawn), 0);
        Instantiate(monetPrefab, spawnPos, monetPrefab.transform.rotation);
    }
    public void GameOver()
    {
        if (isGameActive == false)//Когда игра закончена все обьекты останавливаются
        {
            Time.timeScale = 0;
            gameOverUi.SetActive(true);
            //restartButton.gameObject.SetActive(true);
        }
    }
    public void UpdateScore(int scoreToAdd)// подсчет счета
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
        Time.timeScale = 1f;
        isGameActive = true;
    }
    
}
