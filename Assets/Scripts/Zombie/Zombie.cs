using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Transform groundCheck;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool tochedWall;
    private bool facingRight;
    
    private int layerMask;
    public int health;
    public float speed;
    public bool isDead;

    public GameObject particleDead;
    public GameObject particleDamage;
    public AudioClip fxDead;

    void Start()
    {
        tochedWall = false;
        facingRight = true;
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        layerMask = 1 << LayerMask.NameToLayer("Ground");
    }


    void Update()
    {
        if (isDead)
            return;

        if (tochedWall)
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            speed *= -1;
        }

        tochedWall = Physics2D.Linecast(transform.position, groundCheck.position, layerMask);
    }

    private void FixedUpdate()
    {
        if (isDead)
            return;

        rb2d.velocity = new Vector2(speed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            DamageEnemy();
        }
    }

    private void DamageEnemy()
    {
        health--;

        StartCoroutine(DamageEffect());

        if (health == 0)
        {
            isDead = true;

            Instantiate(particleDead, gameObject.transform.position, gameObject.transform.rotation);

            rb2d.velocity = new Vector2(0f, 0f);
            anim.SetBool("isDead", true);
            StartCoroutine(DeadEnemy());

        }
        else 
        {
            Instantiate(particleDamage, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    IEnumerator DamageEffect() 
    {
        float auxSpeed = speed;
        speed = speed * -1;
        sprite.color = Color.red;
        rb2d.AddForce(new Vector2(0f, 200f));
        yield return new WaitForSeconds(.1f);
        speed = speed * -1;
        speed = auxSpeed;
        sprite.color = Color.white;
    }

    IEnumerator DeadEnemy() 
    {
        yield return new WaitForSeconds(.8f);
        Destroy(gameObject);
        AudioManager.instance.PlaySound(fxDead);
    }

}
