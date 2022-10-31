using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb2d;
    private BoxCollider2D BoxCollider2D;
    private float maxLifeTime = 10f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void SetMovement(Vector2 direction)
    {
        rb2d.AddForce(direction * speed * Time.deltaTime);
        Debug.Log("Cactus Set Movement called");
        Destroy(gameObject, maxLifeTime);
    }
}
