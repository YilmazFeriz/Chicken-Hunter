using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScEnemyController : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;
    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    public GameObject friedEnemy;


    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }
    private void Update(){
        anim.SetBool("isRunning", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
        
        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if(shouldRotate){
            anim.SetFloat("goX", dir.x);
            anim.SetFloat("goY", dir.y);
        }
    }
    private void FixedUpdate(){
        if(isInChaseRange && isInAttackRange){
            MoveCharacter(movement);
        }
        if(isInAttackRange){
            rb.velocity = Vector2.zero;
        }
    }
    private void MoveCharacter(Vector2 dir){
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
           
            Destroy (GameObject.FindWithTag("Enemy"));
            GameObject new_friedEnemy = Instantiate(friedEnemy, transform.position, Quaternion.identity);
        }
        
    }
}
