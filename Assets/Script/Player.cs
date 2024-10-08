using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private Rigidbody2D rb;
    public float jumpForce = 100;
    public int score = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (rb.velocity.y <0)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
        }
}
