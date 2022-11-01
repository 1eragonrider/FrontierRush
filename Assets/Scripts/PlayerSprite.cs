using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    public float speed = 1000f;
    public bool gameEndingCollision = false;
    public GameManager gameManager;

    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollider2D;
    private Vector2 movement;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = 0;
        movement.y = Input.GetAxisRaw("Vertical");
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
            gameManager.points += 1;
            gameManager.countText.text = "Gold Collected: " + gameManager.points.ToString();
        } 
        else if(collision.gameObject.CompareTag("GameEnder"))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.angularVelocity = 0;
            rb2d.isKinematic = true;
            boxCollider2D.enabled = false;

            Debug.Log("GAME OVER!");

            Time.timeScale = 0f;
            gameEndingCollision = true;
        }
    }
}
