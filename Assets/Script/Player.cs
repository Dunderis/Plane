using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TextMeshProUGUI scoreText;
    private Rigidbody2D rb;
    public float jumpForce = 100;
    public int score = 0;
    public AudioClip successSound;
    public AudioClip flap;
    public AudioClip hitSound;
    private AudioSource audioSource;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (rb.velocity.y <0)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                audioSource.PlayOneShot(flap);
            }
            
        }
        //animation
        if (rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -30);
            
        }

        
    }
    void OnTriggerExit2D(Collider2D col) 
        {
            score++;
            scoreText.text = score.ToString("D4");
            audioSource.PlayOneShot(successSound);
        }

     void OnCollisionEnter2D(Collision2D col) 
     {
        audioSource.PlayOneShot(hitSound);
        scoreManager.ShowScoreBoard(score);
        
        Invoke("Die", 0.5f);
    }

    void Die()
    {
        gameObject.SetActive(false);//deactivates the player
        //enabled = false;//deactivates the script
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
