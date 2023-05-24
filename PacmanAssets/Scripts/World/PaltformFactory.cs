using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaltformFactory : MonoBehaviour
{
    public GameObject StoneyPlatform;
    public GameObject GrassyPlatform;
    public GameObject RubberPlatform;

    void Awake()
    {
        CleanSlate();
    }
    void Start()
    {
        if (transform.position.x != 0)
        {

            Vector3[,] possiblePositions = new Vector3[5, 3];

            float yposition = -2f;
            float xposition = -3.6f;

            int MaxRows = 5;
            int MaxColumns = 3;

            for (int i = 0; i < MaxRows; i++)
            {
                for (int n = 0; n < MaxColumns; n++)
                {
                    possiblePositions[i, n] = new Vector3(transform.position.x + xposition, yposition, 1);
                    xposition += (xposition == 3.6f) ? -7.2f : 3.6f;
                }
                yposition += 1.5f;
            }

            //Platform Array Initializer
            GameObject[] randomPlatforms = new GameObject[3] { StoneyPlatform, GrassyPlatform, RubberPlatform };

            int PatternOrRandom = Random.Range(1, 4);

            if (PatternOrRandom < 3)
            {
                CreatePatterned(possiblePositions, randomPlatforms);
            }
            else
            {
                CreateChaotic(possiblePositions, randomPlatforms);
            }
        }
    }

   private void CreateChaotic(Vector3[,] possiblePositions, GameObject[] randomPlatforms)
    {
        int percenChance = 75;

        foreach(Vector3 actualPosition in possiblePositions)
        {
            int diceRoll = Random.Range(1, 100); 

            if(diceRoll < percenChance)
            {
                GameObject createdPlatform = (GameObject)GameObject.Instantiate(randomPlatforms[Random.Range(0, 3)], actualPosition, transform.rotation);
                createdPlatform.transform.parent = this.gameObject.transform;
                percenChance -= 5;
            }
            percenChance -= 5;
        }
    }

    private void CreatePatterned(Vector3[,] possiblePositions, GameObject[] randomPlatforms)
    {
        int patternCounter = 0;
        int evenOrOdd = Random.Range(0, 0);

        foreach(Vector3 actualPosition in possiblePositions)
        {
            if(patternCounter % 2 == evenOrOdd && patternCounter < Random.Range(5, 15))
            {
                GameObject createdPlatform = (GameObject)GameObject.Instantiate(randomPlatforms[Random.Range(0, 3)], actualPosition, transform.rotation);
                createdPlatform.transform.parent = this.gameObject.transform;
            }
            patternCounter++;
        }
    }

    private void CleanSlate()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    
}
