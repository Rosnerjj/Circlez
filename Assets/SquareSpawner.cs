using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{

    public GameObject squarePrefab; 
    public float startX = -5.63f;   
    public float gap = 0.25f;       
    public float squareWidth = 1f;  
    public float spawnY = 3.35f;    

    [SerializeField] public int spawnRateL = 1;
    [SerializeField] public int spawnRateR = 11;

    private List<float> validXPositions = new List<float>();
    private List<GameObject> spawnedSquares = new List<GameObject>();


    void Start()
    {
        PopulateValidXPositions();  
        SpawnSquares(1);
    }

    void PopulateValidXPositions()
    {
        validXPositions.Clear(); 
        for (int i = 0; i < 10; i++)
        {
            float xPos = startX + i * (squareWidth + gap);
            validXPositions.Add(xPos); 
        }
    }

    public void SpawnSquares(int round)
    {
        int numberOfSquaresToSpawn = Random.Range(spawnRateL, spawnRateR);
        
        List<float> shuffledPositions = new List<float>(validXPositions);
        ShuffleList(shuffledPositions);

        for (int i = 0; i < numberOfSquaresToSpawn; i++)
        {
            Vector3 spawnPosition = new Vector3(shuffledPositions[i], spawnY, 0);
            GameObject square = Instantiate(squarePrefab, spawnPosition, Quaternion.identity);
            spawnedSquares.Add(square);

            SquareScript squareScript = square.GetComponent<SquareScript>();
            squareScript.SetHealth(round);
        }
    }

    void ShuffleList(List<float> list)
    {
        int n = list.Count;
        System.Random rng = new System.Random();
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            float value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public void MoveSquaresDown(int round)
    {
        foreach (GameObject square in spawnedSquares)
        {
            // Move each square down by 1.25 units
            if (square != null)
            {
                Vector3 newPosition = square.transform.position;
                newPosition.y -= 1.25f;
                square.transform.position = newPosition;
            }
        }
        SpawnSquares(round);
    }
}
