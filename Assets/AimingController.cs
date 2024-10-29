using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingController : MonoBehaviour
{

    [SerializeField] public float angle;
    private Camera camera;
    private Vector3 mousePos;

    public GameObject projectile;
    public Transform projectileTransform;
    public bool canFire; 
    public float time;
    public float timeBetween;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    { 
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation =   transform.position - mousePos;
        angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (!canFire) {
            time += Time.deltaTime;
            if (time > timeBetween) {
                canFire = true;
                time = 0;
            }
        }

        if(Input.GetMouseButton(0) && canFire) {
            canFire = false;
            Instantiate(projectile, projectileTransform.position, Quaternion.identity);
        }
    }
}
