using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 5;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 10f;
    private float timeMoveHorizontal = 0;
    private float timeMoveVertical = 0;
    private float timeCountHorizontal = 0;
    private float timeCountVertical = 0;
    private int horizontalMove = 0;
    private int verticalMove = 0;
    private float canJump = 0f;
    Animator anim;
    Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 20f);
    }

    void Update()
    {
        ControllPlayer();
    }

    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal3");
        float moveVertical = Input.GetAxisRaw("Vertical3");

        if (timeCountHorizontal > timeMoveHorizontal)
        {
            horizontalMove = Random.Range(-1, 2);
            timeMoveHorizontal = Random.Range(1, 4);
            timeCountHorizontal = 0;
        }
        else if (timeCountVertical > timeMoveVertical)
        {
            verticalMove = Random.Range(-1, 2);
            timeMoveVertical = Random.Range(1, 4);
            timeCountVertical = 0;
        }

        Vector3 movement = new Vector3(horizontalMove, 0.0f, verticalMove);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            //float turn = moveVertical * 180f * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(0f, turn, 0f);
            anim.SetInteger("Walk", 1);
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        timeCountHorizontal += Time.deltaTime;
        timeCountVertical += Time.deltaTime;

        if (Time.time > canJump)
        {
            rb.AddForce(0, jumpForce, 0);
            canJump = Time.time + timeBeforeNextJump;
            anim.SetTrigger("jump");
        }
    }
}