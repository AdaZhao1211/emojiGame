using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {
    Rigidbody2D rb;
    Transform tt;
    float distance_to_screen;

    void Start() {
        
        rb = GetComponent<Rigidbody2D>();
        tt = GetComponent<Transform>();
        distance_to_screen = (gameObject.transform.position).z;

    }
    // Use this for initialization
    void OnMouseDrag()
    {

        Vector3 mousePositon = Input.mousePosition;
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePositon);
        objPosition.z = distance_to_screen;
        rb.velocity = (objPosition - tt.position) * 20;
    }

    void OnMouseUp()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ss trigger test");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("ss c test");
    }



}
