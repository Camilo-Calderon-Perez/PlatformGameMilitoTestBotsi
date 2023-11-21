using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Serializable]
    public class Test
    {
        public float speed2;
    }

    [SerializeField]
    private List<GameObject> test;

    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    //private CharacterCreator(float speedMovement, Rigidbody2D rBody, Animator anim)
    //{
    //    this.speed = speedMovement;
    //    this.body = rBody;
    //    this.anim = anim;
    //}

    public float getSpeed()
    {
        return speed;
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public Rigidbody2D getRigidbody()
    {
        return body;
    }


    public void setBody(Rigidbody2D rb)
    {
        this.body = rb;
    }

    public Animator getAnim()
    {
        return anim;
    }

    public void setAnim(Animator anim)
    {
        this.anim = anim;
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;

        else if (horizontalInput < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
            grounded = false;
        }

        anim.SetBool("stop", horizontalInput == 0);
        anim.SetBool("grounded", grounded);

    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Collision")
        {
            grounded = true;
        }
    }

}
