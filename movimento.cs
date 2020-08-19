using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{
    public float runSpeed,walkSpeed,crouchSpeed;
    private float speed;
    private float direction;
    public Rigidbody2D rb;
    private bool faceRight = true;

    public int maxjumps;
    private int jump;
    public float jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = maxjumps;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }else if(Input.GetKey(KeyCode.LeftControl))
        {
            speed = crouchSpeed;
        }else
        {
            speed = walkSpeed;
        }
        rb.velocity = new Vector2(direction*speed*Time.fixedDeltaTime,rb.velocity.y);
        
        if(faceRight && direction < 0)
        {
            turn();
        }else if(!faceRight && direction > 0)
        {
            turn();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        if(jump > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * Time.fixedDeltaTime);
            jump--;
        }
    }

    void turn()
    {
        faceRight = !faceRight;
        transform.Rotate(0,180,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jump = maxjumps;
    }
}
