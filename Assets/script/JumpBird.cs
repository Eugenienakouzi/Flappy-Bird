using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JumpBird : MonoBehaviour
{
    public Rigidbody2D BirdRigidbody2D;

    public int jumpForce;
    public int score = 0; 

    public Animator anim;

    public bool play;

    public GameObject GameOver;
    public GameObject restartButton;

    public TextMeshProUGUI scoreText; 
    // Start is called before the first frame update
    void Start()
    {
        play = true;
        scoreText.text = "Score: " + score.ToString();
        GameOver.SetActive(false); 


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (play) {
                BirdRigidbody2D.velocity = Vector2.zero;
                BirdRigidbody2D.AddForce(new Vector2(0f, 1f) * jumpForce);
                anim.SetBool("Middle", true);
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        { 
            anim.SetBool("Middle", false);
        }
        if (!play) {
            BirdRigidbody2D.gravityScale = 0f;
            BirdRigidbody2D.velocity= Vector2.zero;

        }
        scoreText.text = "Score: " + score.ToString();



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            play=false;
            GameOver.SetActive(true); 
            restartButton.SetActive(true);


        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScoreZone")) 
        {
            score++; 
        }
    }
   
}
