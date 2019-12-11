using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    private float timer;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((timer += Time.deltaTime) >= time)
        {
            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], transform);
            enemy.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            timer = 0f;
        }
    }
}