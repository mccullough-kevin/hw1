// Author: Kevin McCullough
// Date: 9/22/24
// Description: Controls the player



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public Text countText;
    public Text loseText;
    public Text winText;
    public Text invincibleText;
    public Button restartButton;



    private float timer = 0.0f;  //tracks time
    private bool gameActive = true;
    private int totalElapsedSeconds = 0;
    private bool isInvincible = false;  //invincibilty flag for twist
    private float invincibilityTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  
        winText.text = "";
        loseText.text = "";
        invincibleText.text = "";
        restartButton.gameObject.SetActive(false); // hide button
    }

    void Update()
    {
        if (gameActive)
        {

            timer += Time.deltaTime; // adds to timer
            totalElapsedSeconds = (int)timer;

            int seconds = totalElapsedSeconds % 60; // gets current seconds

            int remainingSeconds = 60 - totalElapsedSeconds; // finds remaining time

            // countdown timer update
            if (remainingSeconds >= 0)
            {
                countText.text = "Time: " + remainingSeconds.ToString("00");
            }
            // win condition check
            if (remainingSeconds == 0)
            {
                winText.text = "You Win!";
                loseText.gameObject.SetActive(false);
                winText.gameObject.SetActive(true);
                rb2d.velocity = Vector2.zero;
                gameActive = false;
                restartButton.gameObject.SetActive(true);
            }
            // invinciblity update for twist - sets a timer and displays message
            if (isInvincible)
            {
                invincibleText.text = "Invincible for 5 seconds!";
                invincibilityTimer -= Time.deltaTime;
                if (invincibilityTimer <= 0f)
                {
                    isInvincible = false; // Reset invincibility
                    invincibleText.text = "";
                }
            }
        }
    }

    // fixedUpdate is in sync with physics engine
    void FixedUpdate()
    {


        if (gameActive)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.velocity = (movement * speed);
        }
    }
    // twist method for granting invincibility
    public void GrantInvincibility()
    {
        isInvincible = true;
        invincibilityTimer = 5f; // Set invincibility time to 5 seconds
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameActive && other.gameObject.CompareTag("PickUp") && !isInvincible) // checks if active game and collision occured while NOT invincible
        {
            loseText.text = "Game Over!";
            restartButton.gameObject.SetActive(true); // Show button
            rb2d.velocity = Vector2.zero; // Stop UFO movement
            gameActive = false;
        }
    }

    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene("SampleScene"); //restart game
    }

}


