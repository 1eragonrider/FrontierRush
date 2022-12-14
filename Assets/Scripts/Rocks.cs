using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollider2D;
    private float maxLifeTime = 10f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void SetMovement(Vector2 direction)
    {
        rb2d.AddForce(direction * speed * Time.deltaTime);
        Debug.Log("Rock Set Movement called");
        Destroy(gameObject, maxLifeTime);
    }
}
