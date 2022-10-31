using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSpriteMovement : MonoBehaviour
{
    public float speed = 10f;
    public Text countText;
    public bool gameOver = false;

    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollider2D;
    private Vector2 movement;
    private int points;


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        points = 0;
        countText.text = "Gold Collected: " + points.ToString();

        if (gameOver==true && Input.GetKeyDown("R"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = 0;
        movement.y = Input.GetAxisRaw("Vertical");

        if (gameOver == true)
        {
            CancelInvoke();
        }
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pickup"))
        {
            collision.gameObject.SetActive(false);
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            points += 1;
            countText.text = "Gold Collected: " + points.ToString();
        } 
        else if(collision.gameObject.CompareTag("GameEnder"))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.angularVelocity = 0;
            rb2d.isKinematic = true;
            boxCollider2D.enabled = false;

            Debug.Log("GAME OVER!");

            Time.timeScale = 0f;
            gameOver = true;
        }
    }
}
