using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnerList = new List<Transform>();
    [SerializeField] private List<GameObject> itemsToSpawn = new List<GameObject>();
    [SerializeField] private float time;

    private float timer;

    private void Update()
    {
        if(timer >= time)
        {
            SpawnNewProp();
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void SpawnNewProp()
    {
        int rand1 = Random.Range(0, itemsToSpawn.Count);
        int rand2 = Random.Range(0, spawnerList.Count);
        Instantiate(itemsToSpawn[rand1], spawnerList[rand2]);
    }
}
