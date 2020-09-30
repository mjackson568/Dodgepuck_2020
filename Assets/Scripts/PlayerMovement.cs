using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int score = 4;
    public int highscore = 8;
    public float location;
    public float loc2 = 1.5f;
    public int speed = 10;
    public float xRange = 5.85f;
    public float yRange = 4.4f;
    public GameObject Puck;
    public GameObject Blocky;
    
    // Start is called before the first frame update
    void Start()
    {
        //function: 
        SpawnPuck();
        SpawnBlocky();
    }

    void SpawnPuck()
    {
        Debug.Log(Random.Range(1.0f,10.0f));
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
