using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private float timer;
    [SerializeField]
    private float maxTime;
    [SerializeField]
    private float minTime;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        time = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if ((timer += Time.deltaTime) >= time)
        {
            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], transform);
            enemy.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            timer = 0f;
            time = Random.Range(minTime, maxTime);
        }
    }
}