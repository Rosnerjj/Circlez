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
    public int life = 100;
    private Vector2 direction; 

    public SquareScript squarePrefab;
    public AimingController aimingController;
     
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = this.GetComponent<Rigidbody2D>();

        string savedColorHex = PlayerPrefs.GetString("BallColor", "FFFFFF"); // Default to white
        if (UnityEngine.ColorUtility.TryParseHtmlString("#" + savedColorHex, out Color savedColor))
        {
            GetComponent<Renderer>().material.color = savedColor;
        }

        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = transform.localPosition - mousePos;
        Vector3 rotation = transform.localPosition - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;  

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot); 

        velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        if(screenPos.y <= 0) 
        {
            DestroyProjectile();
        }
        
    }

    public void Bounce(Vector2 direction) 
    {
        this.direction = direction;
        rb.velocity = this.velocity * force;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        life--;
        if (collision.gameObject.CompareTag("Square"))
        {
            var normal = collision.contacts[0];
            Vector2 newVelocity = Vector2.Reflect(direction.normalized, normal.normal);
            Bounce(newVelocity.normalized);

            SquareScript squareScript = collision.gameObject.GetComponent<SquareScript>();
            if (squareScript != null)
            {
                squareScript.health--;
                Debug.Log("Square hit");
            }
            
        }
        if(life == 0) 
        {
            DestroyProjectile();
        }

        
    }
    private void DestroyProjectile()
    {
        if (aimingController != null)
        {
            aimingController.RemoveProjectile(gameObject);
        }

        Destroy(gameObject);
    }
    
}