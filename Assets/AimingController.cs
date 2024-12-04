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

    [SerializeField]
    public bool allProjectilesDestroyed => activeProjectiles.Count == 0;

    private CircleHandler circleHandler;
    private List<GameObject> activeProjectiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        circleHandler = GameObject.FindGameObjectWithTag("Circle").GetComponent<CircleHandler>();
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

        if(Input.GetMouseButton(0) && canFire && circleHandler.HasAmmo()) {
            canFire = false;
            circleHandler.DecreaseAmmo();
            
            GameObject newProjectile = Instantiate(projectile, projectileTransform.position, Quaternion.identity);
            activeProjectiles.Add(newProjectile);

            ProjectileScript projectileScript = newProjectile.GetComponent<ProjectileScript>();
            if (projectileScript != null)
            {
                projectileScript.aimingController = this;
            }
        }
    }

    public void RemoveProjectile(GameObject projectile)
    {
        if (activeProjectiles.Contains(projectile))
        {
            activeProjectiles.Remove(projectile);
        }
    }
}
