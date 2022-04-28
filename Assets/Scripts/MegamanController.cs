using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegamanController : MonoBehaviour
{
    public float velocity = 8;
    public float jumpForce = 70;
    public GameObject smallBullet;
    public GameObject midBullet;
    public GameObject bigBullet;
    public float charge = 0;

    // Start is called before the first frame update

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    //const
    private const int IDLE = 0;
    private const int RUN = 1;
    private const int JUMP = 2;
    private const int SHOOT = 3;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(IDLE);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(RUN);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(RUN);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(JUMP);
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            Disparar();
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            Disparar2();
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            Disparar3();
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(SHOOT);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(SHOOT);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            charge += Time.deltaTime;

            if (sr.color == Color.blue)
            {
                sr.color = Color.white;
            }
            sr.color = Color.blue;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            if(sr.color == Color.blue)
            {
                sr.color = Color.white;
            }
            charge = 0;
        }
    }

    private void Disparar()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        var bulletGO=Instantiate(smallBullet, new Vector2(x, y), Quaternion.identity) as GameObject;
        if (sr.flipX)
        {
            var controller = bulletGO.GetComponent<BalaController>();
            controller.velocity *= -1; 
        }

    }

    private void Disparar2()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        var bulletGO2 = Instantiate(midBullet, new Vector2(x, y), Quaternion.identity) as GameObject;
        if (sr.flipX)
        {
            var controller = bulletGO2.GetComponent<MidBulletController>();
            controller.midVelocity *= -1;
        }

    }

    private void Disparar3()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        var bulletGO3 = Instantiate(bigBullet, new Vector2(x, y), Quaternion.identity) as GameObject;
        if (sr.flipX)
        {
            var controller = bulletGO3.GetComponent<BigBulletController>();
            controller.midVelocity *= -1;
        }

    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
