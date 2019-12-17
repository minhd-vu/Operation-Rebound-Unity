using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerUps;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private Tilemap tileMap;
    private List<Vector3> spawnLocations;
    private bool spawning;

    private void Start()
    {
        spawnLocations = new List<Vector3>();

        for (int i = tileMap.cellBounds.xMin; i < tileMap.cellBounds.xMax; i++)
        {
            for (int j = tileMap.cellBounds.yMin; j < tileMap.cellBounds.yMax; j++)
            {
                Vector3Int localPlace = new Vector3Int(i, j, 0);
                Vector3 place = tileMap.CellToWorld(localPlace);
                if (!tileMap.HasTile(localPlace))
                {
                    spawnLocations.Add(new Vector3(place.x + tileMap.cellSize.x / 2, place.y + tileMap.cellSize.y / 2, place.z));
                }
            }
        }

        spawning = true;
        StartCoroutine("SpawnPowerUp");
    }

    IEnumerator SpawnPowerUp()
    {
        while (spawning)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], spawnLocations[Random.Range(0, spawnLocations.Count)], Quaternion.identity);
        }
    }
}
