using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Walking : Collidable
{
    Rigidbody2D rb;
    Vector2 mousePos;
    public Vector3 direction;
    public Vector3 movement;
    public float speed;
    public bool canLook = true;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (!canLook) //Stops if it cant move
            return;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3 { x = horizontal, y = vertical };
        direction = ((Vector2)transform.position - mousePos).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fence")
        {
            GetComponent<Charge>().hitFence = true;
        }
    }

}
