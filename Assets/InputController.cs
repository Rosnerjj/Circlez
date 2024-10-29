using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public CircleHandler circlePrefab;

    public ProjectileBehavior projectileBehavior;
    public Transform circleTransform;


    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0, -4.75f, 0); //starting location for the game
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
