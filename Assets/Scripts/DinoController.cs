using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float velocity = 6;
    public int vidas = 5;
    // Start is called before the first frame update

    private SpriteRenderer sr;
    private Rigidbody2D rb;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-velocity, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("smallBullet"))
        {
            vidas = vidas - 1;
            if(vidas <= 0)
            {
                Destroy(this.gameObject);
                Destroy(collider.gameObject);
            }
        }

        if (collider.gameObject.CompareTag("midBullet"))
        {
            vidas = vidas - 3;
            if (vidas <= 0)
            {
                Destroy(this.gameObject);
                Destroy(collider.gameObject);
            }
        }


        if (collider.gameObject.CompareTag("bigBullet"))
        {
            vidas = vidas - 5;
            if (vidas <= 0)
            {
                Destroy(this.gameObject);
                Destroy(collider.gameObject);
            }
        }


    }
}
