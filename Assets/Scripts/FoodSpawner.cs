using UnityEngine;
using System.Collections.Generic;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> foodTypes = new List<GameObject>();
    [SerializeField] private float minXPosition = -5f;
    [SerializeField] private float maxXPosition = 5f;
    public bool isActive = false;

    private void Start()
    {
        // Start spawning food periodically
        InvokeRepeating("SpawnFood", 3f, Random.Range(3f, 8f));
    }

    private void SpawnFood()
    {
        if (isActive)
        {
            // Randomly select one of the food types from the list
            GameObject selectedFood = GetRandomFoodType();

            if (selectedFood != null)
            {
                // Random X position within the specified range
                float randomX = Random.Range(minXPosition, maxXPosition);

                // Spawn the selected food at the random position
                Instantiate(selectedFood, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
            }
        }
    }

    private GameObject GetRandomFoodType()
    {
        // Check if the list is not empty
        if (foodTypes.Count > 0)
        {
            // Randomly select one of the food types from the list
            int randomIndex = Random.Range(0, foodTypes.Count);
            return foodTypes[randomIndex];
        }

        return null;
    }
}