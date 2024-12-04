using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleHandler : MonoBehaviour
{ 
    public int circleCount = 10;
    public GameObject circlePrefab;
    public SquareSpawner squareSpawner;
    public bool outOfCircles = false;

    [SerializeField] public float startingYLocation = -4.75f;

    private Renderer circleRenderer;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0, startingYLocation, 0); //starting location for the game

        circleRenderer = GetComponent<Renderer>();

        // Load saved color
        string savedColorHex = PlayerPrefs.GetString("BallColor", "FFFFFF"); // Default to white
        if (ColorUtility.TryParseHtmlString("#" + savedColorHex, out Color savedColor))
        {
            circleRenderer.material.color = savedColor;
        }
    }

    void Update()
    {
        if(circleCount == 0) 
        {
            outOfCircles = true;
        }
    }

    public void DecreaseAmmo()
    {
        if (circleCount > 0)
        {
            circleCount--;
        }
    }

    // Method to check if there's ammo available
    public bool HasAmmo()
    {
        return circleCount > 0;
    }

    public void ResetAmmo(int ammoCount)
    {
        circleCount = ammoCount;
        outOfCircles = false;
    }
}
