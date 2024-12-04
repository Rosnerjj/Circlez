using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class SquareScript : MonoBehaviour
{
    public int health = 1;
    public TextMeshProUGUI squareText;
    public RoundController roundController;
    public GameObject musicPlayer;
    public bool isGameOver = false;

    [SerializeField] private ParticleSystem destroyedParticles;
    private ParticleSystem destroyedParticlesInstance;

    // Start is called before the first frame update
    void Start()
    {
        squareText.text = health.ToString();;
    }

    // Update is called once per frame
    void Update()
    {
        squareText.text = health.ToString();
        if (health <= 0) 
        {
            destroyedParticlesInstance = Instantiate(destroyedParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(transform.position.y <= -4.15f && !isGameOver)
        {
            isGameOver = true;
            
            StartCoroutine(HandleGameOver());
            
        }
    }

    public void SetHealth(int round)
    {
        health = round;
    }

    private IEnumerator HandleGameOver()
    {
        musicPlayer.GetComponent<AudioSource>().Pause();
        roundController.gameOver.Play(); 
        Debug.Log("Game over");
        yield return new WaitForSeconds(2f); 
        SceneManager.LoadSceneAsync(0);
        
    }
}