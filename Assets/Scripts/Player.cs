using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] private int playerSpeed;
    Vector2 movement;
    [SerializeField] Rigidbody2D rb;
    public static int bestScore;
    public static int score;
    float timer;
    Text text;
    Text finalText;
    Text highScore;
    public GameManager gameManager;
    //public Enemy enemy;
    public ParticleSystem particle;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        timer = 0f;
        text = GameObject.Find("Score").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {

        text.text = score.ToString();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        timer += Time.deltaTime;
        if (timer >= 1)
        {
            score += 1;
            timer = 0;
            
        }

        particle.transform.position = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        if (gameManager.getPlayerCollided() == false && gameManager.GetPlaying() == true) 
        {
            rb.velocity = movement * playerSpeed * Time.fixedDeltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        particle.Play();
        gameObject.SetActive(false);
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemy>().particleEnemy.Play();
            enemy.SetActive(false);
            
        }
        GameManager.gameCount += 1;
        Invoke("GameOver", 0.5f);

    }

    public void GameOver()
    {
        gameManager.gameOver.SetActive(true);
        finalText = GameObject.Find("FinalScore").GetComponent<Text>();
        highScore = GameObject.Find("BestScore").GetComponent<Text>();
        finalText.text = "Final score: " + score;

        if (score > bestScore)
        {
            bestScore = score;
        }
        score = 0;

        highScore.text = "High score: " + bestScore;

        gameManager.setPlayerCollided();
    }


    public int getScore()
    {
        return score;
    }





}
