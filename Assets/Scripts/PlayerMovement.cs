using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{    
    public int speed = 10;
    public float xRange = 5.85f;
    public float yRange = 4.4f;
    public GameObject Puck;
    public GameObject Blocky;
    public int Score;
    public GameObject scoreText;
    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        //function: 
        SpawnPuck();
        SpawnBlocky();       
    }

    void SpawnPuck()
    {
        Instantiate(Puck, new Vector2(Random.Range(-5.85f,5.85f),Random.Range(-4.4f,4.4f)), Quaternion.identity);
    }

    void SpawnBlocky()
    {
        Instantiate(Blocky, new Vector2(Random.Range(-5.85f, 5.85f), Random.Range(-4.4f, 4.4f)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime);     
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if tagged as "Blocky"...
        if (collision.gameObject.tag == "Blocky")
        {           
            Destroy(collision.gameObject);
            SpawnBlocky();
            SpawnPuck();
            scoreText.GetComponent<ScoreKeeper>().UpdateScore();
        }
        //if tagged as "Puck"...
        if (collision.gameObject.tag == "Puck")
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    private void LateUpdate()
    {
        //keep player in bounds
        if(transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }
    }
}
