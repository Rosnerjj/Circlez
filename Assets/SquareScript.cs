using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SquareScript : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Destroy(gameObject);
            SceneManager.LoadSceneAsync(0);
            Debug.Log("Game Over");
        }
    }
}
