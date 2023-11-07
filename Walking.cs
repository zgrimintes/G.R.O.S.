using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : Collidable
{
    public Vector3 direction;
    public float speed;
    public bool canLook = true;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (canLook)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            direction = ((Vector2)transform.position - mousePos).normalized;
            gameObject.transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed;
        }

    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fence")
        {
            //transform.position = Vector3.Reflect(gameObject.transform.position ,Vector3.right);
            //Debug.Log("fence!");
        }
    }
}
