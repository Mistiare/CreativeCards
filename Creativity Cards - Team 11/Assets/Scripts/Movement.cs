using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    public Vector2 jump;
    public bool jumped = false;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + moveHorizontal, transform.position.y);

        if ((Input.GetKeyDown(KeyCode.W)) & (!jumped))  //makes player jump
        {
            jumped = true;
            rb.AddForce(jump, ForceMode2D.Impulse);

        }

    }
    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            jumped = false;
        }

        if (other.gameObject.tag == "Platform")
        {
            jumped = false;
        }

    }

}