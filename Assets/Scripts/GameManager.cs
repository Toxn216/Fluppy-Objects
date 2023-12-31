using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
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
    public GameObject menuUI;

    [SerializeField] private float spawnXMonet = 20.5f;
    private float randomYspawn = 7;
    private float startDelay = 1.5f;
    private float spawnInterval = 11;

    private float spawnX = 17f;
    private float spawnY = 0f;
    private float score;
    private float spawnWallInterval = 6f;

    public bool startTheGame = false;
    public bool isGameActive;

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }
    IEnumerator SpawnRandomWall()
    {
        while (isGameActive)
        {
            if(startTheGame == true)
            {
                yield return new WaitForSeconds(spawnWallInterval);
                int wallIndex = Random.Range(0, wallPrefabs.Length);
                Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
                Instantiate(wallPrefabs[wallIndex], spawnPos, wallPrefabs[wallIndex].transform.rotation);
            }      
        }
    }
    void SpawnRandomMonet()
    {
        if(startTheGame == true)
        {
            Vector3 spawnPos = new Vector3(spawnXMonet, Random.Range(randomYspawn, -randomYspawn), 0);
            Instantiate(monetPrefab, spawnPos, monetPrefab.transform.rotation);
        }    
    }
    public void GameOver()
    {
        if (isGameActive == false)//����� ���� ��������� ��� ������� ���������������
        {
            startTheGame = false;
            gameOverUi.SetActive(true);
        }
    }
    public void UpdateScore(int scoreToAdd)// ������� �����
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        isGameActive = true;
    }
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        startTheGame = true ;
        score = 0;
        spawnWallInterval /= difficulty;
        UpdateScore(0);
        StartCoroutine(SpawnRandomWall());
        InvokeRepeating("SpawnRandomMonet", startDelay, spawnInterval);
        menuUI.gameObject.SetActive(false);
    }
    public void Exit()//��� ��� ��������� ���� ����� ��� ��� ������ ��� ������ �� ��� ������ �������� ��� ����� � ���, � ��� ������������ � �� �� ��� ��
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
