using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RexController : MonoBehaviour {
    [SerializeField] int jumpHeight = 5;
    [SerializeField] int movingSpeed = 5;
    
    bool onGround = true;
    bool isDead = false;
    Animator rexAnimator;

    private static bool isStart;
    Rigidbody2D rexRigidBody2D;

    public static bool IsStart
    {
        get
        {
            return isStart;
        }

        set
        {
            isStart = value;
        }
    }

    // Use this for initialization
    void Start () {
        Init();
    }
	
	// Update is called once per frame
	void Update () {
        if(isDead)
        {
            //PAUSE + LOCK INPUT
        }
        else
        {
            Jump();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LAND")
        {
            onGround = true;
            rexAnimator.SetBool("isJumping", false);
        }
    }
    void Init()
    {
        rexRigidBody2D = GetComponent<Rigidbody2D>();
        rexAnimator = GetComponent<Animator>();
        IsStart = false;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            rexAnimator.SetBool("isJumping", true);
            rexRigidBody2D.velocity = new Vector2(rexRigidBody2D.velocity.x, jumpHeight);
            onGround = false;
            StartCoroutine(GameStart());
        }
    }
    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(5);
        if (IsStart == false)
        {
            IsStart = true;
        }
    }
}
