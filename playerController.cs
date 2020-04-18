using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float initFallSpeed = 0.01f;
    public float speedUpFactor = 0.001f;
    

    Rigidbody2D rbod;
    bool onFloor = false;
    float fallSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rbod = GetComponent<Rigidbody2D>();
        fallSpeed = initFallSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (onFloor == false)
        {
            rbod.bodyType = RigidbodyType2D.Dynamic;           
        }
        else
        {
            fallSpeed = initFallSpeed;
            rbod.bodyType = RigidbodyType2D.Kinematic;
            rbod.useFullKinematicContacts = true;
            rbod.MovePosition(new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z));

            

        }


        

    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Floor")
        {
            onFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Floor")
        {
            onFloor = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        moveSpeed += speedUpFactor;

        if (collision.transform.tag == "JumpTrigger")
        {
            doJump();
           
        }
    }


    void doJump()
    {
        

        onFloor = false;
        rbod.bodyType = RigidbodyType2D.Dynamic;
        rbod.AddForce(new Vector2(100, 350));

       
    }


}
