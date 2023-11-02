using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public  Vector3 direction;
    public float speed;
    public bool canLook = true;

    // Update is called once per frame
    void Update()
    {
        if (canLook)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.up = mousePos - new Vector2(transform.position.x, transform.position.y); //The character is rotating after de cursor
 
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            direction = ((Vector2)transform.position - mousePos).normalized;
            gameObject.transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed;
        }

    }
}
