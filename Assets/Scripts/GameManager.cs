using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPlayerCollided { get; set; }
    public GameObject player;
    public List<GameObject> enemies;
    private int activeEnemies = 1;
    private int supportVariable = 10;
    public GameObject gameOver;
    public GameObject play;
    public GameObject score;
    public static int gameCount = 1;
    private bool playing = false;
    

    //private Player playerCode = new Player();

    // Start is called before the first frame update
    void Start()
    {
        print(gameCount);
        if (gameCount != 1)
        {
            GameStarted();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.score == supportVariable && Player.score <= 40)
        {
            SpawnEnemy();
        }
    }


    public bool getPlayerCollided()
    {
        return isPlayerCollided;
    }

    public void setPlayerCollided()
    {
        isPlayerCollided = true;
    }
  



    private void SpawnEnemy()
    {
        //Vector2 playerPosition = player.transform.position;
        //Vector2 enemyPosition = enemies[activeEnemies - 1].transform.position;
        //if (playerPosition != spawningPos && enemyPosition != spawningPos)
        //{
        enemies[activeEnemies].SetActive(true);
        //}
        supportVariable += 10;
        activeEnemies += 1;
    }

    private void PlayAgain()
    {
        gameOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isPlayerCollided = false;
    }

    public void GameStarted()
    {
        play.SetActive(false);
        player.SetActive(true);
        enemies[0].SetActive(true);
        score.SetActive(true);
        playing = true;
        
    }

    public bool GetPlaying()
    {
        return playing;
    }


    

}
