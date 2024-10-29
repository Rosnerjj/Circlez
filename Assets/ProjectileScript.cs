using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Camera camera;
    private Vector3 mousePos;
    public Vector3 velocity;
    private Rigidbody2D rb;
    public float force = 1f;
    public float speed = 5f;

    public SquareScript squarePrefab;
     
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = this.GetComponent<Rigidbody2D>();
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = transform.localPosition - mousePos;
        Vector3 rotation = transform.localPosition - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;  

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot); 

        velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;

        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPos.x <= 0 || screenPos.x >= 1)
        {
            velocity.x = -velocity.x;
        }
        if (screenPos.y >= .9)
        {
            velocity.y = -velocity.y;
        }
        if(screenPos.y <= 0) 
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Square"))
        {
            squarePrefab = collision.GetComponent<SquareScript>();
            if(squarePrefab != null) {
                squarePrefab.health--;
                Debug.Log("Square hit");
            }
        }
    }
}
