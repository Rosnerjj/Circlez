using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallColorController : MonoBehaviour
{
    public CircleHandler circle;

    private Renderer circleRenderer;
    public Button buttonWhite;
    public Button buttonRed;
    public Button buttonBlue;
    public Button buttonGreen;
    public Button buttonPurple;

    Color orange = new Color(1f, 0.65f, 0f);

    Color purple = new Color(0.5f, 0f, 0.5f);

    // Update is called once per frame
    void Start()
    {
        circleRenderer = circle.GetComponent<Renderer>();

        buttonWhite.onClick.AddListener(() => colorChange(Color.white));
        buttonRed.onClick.AddListener(() => colorChange(Color.red));
        buttonBlue.onClick.AddListener(() => colorChange(Color.blue));
        buttonGreen.onClick.AddListener(() => colorChange(Color.green));
        buttonPurple.onClick.AddListener(() => colorChange(purple));
    }

    void colorChange(Color newColor) {
        PlayerPrefs.SetString("BallColor", ColorUtility.ToHtmlStringRGB(newColor));
        PlayerPrefs.Save();

        if (circleRenderer != null)
        {
            circleRenderer.material.color = newColor;
        }

        Debug.Log("Color selected: " + newColor);
    }
}
