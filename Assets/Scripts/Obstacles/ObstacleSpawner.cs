using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> horizontalObstacles;
    [SerializeField] private List<GameObject> verticalObstacles;
    [SerializeField] private List<Transform> horizontalSpots;
    [SerializeField] private List<Transform> verticalSpots;

    [SerializeField] private float time;

    private float timer;

    private void Update()
    {
        if(timer < time)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        int rand1 = Random.Range(0, 2);
        SpawnObstacle(rand1);
    }

    private void SpawnObstacle(int rand)
    {
        if (rand == 0)
        {
            int rand2 = Random.Range(0, horizontalSpots.Count);
            int rand3 = Random.Range(0, horizontalObstacles.Count);
            GameObject newObstacle = Instantiate(horizontalObstacles[rand3], horizontalSpots[rand2].position, Quaternion.identity);
        }
        else
        {
            int rand2 = Random.Range(0, verticalSpots.Count);
            int rand3 = Random.Range(0, verticalObstacles.Count);
            GameObject newObstacle = Instantiate(verticalObstacles[rand3], verticalSpots[rand2].position, Quaternion.identity);
        }
    }
}
