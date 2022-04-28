using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBulletController : MonoBehaviour
{
    public float midVelocity = 15;

    private Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = new Vector2(midVelocity, rbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.gameObject.tag;
        if (tag == "Enemy")
        {
            Destroy(this.gameObject);
            
        }
    }
}
