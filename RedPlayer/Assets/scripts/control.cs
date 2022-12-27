using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnim;

    public float moveSpeed = 1f;
    public float jumpSpeed = 1f;
    bool facingRigth = true;
    public bool isGrounded = false;

    public float jumpFrequency=1f, nextJumpTime;

    public Transform gcPosition;
    public float gcRadius;
    public LayerMask gcLayer;
    
    

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    
    void Update()
    {
        horizontalMove();
        onGroundCheck();


        if (playerRB.velocity.x<0 && facingRigth)
        {
            flipFace();

        }
        else if(playerRB.velocity.x>0 && !facingRigth)
        {
            flipFace();
        }

        if(Input.GetAxis("Vertical")>0 && isGrounded && (nextJumpTime<Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad+jumpFrequency;
            jump();
        }
    
    }

    void horizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnim.SetFloat("playerSpeed",Mathf.Abs(playerRB.velocity.x));
    }

    void flipFace()
    {
        facingRigth = !facingRigth;
        Vector3 tempLocalScale=transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void jump()
    {
        playerRB.AddForce(new Vector2(0f, jumpSpeed));
    }

    void onGroundCheck()
    {
       isGrounded = Physics2D.OverlapCircle(gcPosition.position,gcRadius ,gcLayer);
        playerAnim.SetBool("isGrounded",isGrounded);
    }
}
