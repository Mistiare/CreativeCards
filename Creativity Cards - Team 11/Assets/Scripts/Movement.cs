using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    public float jumpforce;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 leftright = new Vector2(moveHorizontal, 0.0f);
        Vector2 jump = new Vector2(0.0f, moveVertical);

        rb.AddForce(leftright * speed);
        rb.AddForce(jump * jumpforce);

    }
}
