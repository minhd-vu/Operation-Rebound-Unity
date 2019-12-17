using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps;
    public float spawnTime = 0.5f;
    public Tilemap tileMap;
    public Tilemap collisionTileMap;
    private List<Vector3> availablePlaces;
    private bool spawning;

    private void Start()
    {
        availablePlaces = new List<Vector3>();

        for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++)
        {
            for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++)
            {
                Vector3Int localPlace = new Vector3Int(n, p, (int)tileMap.transform.position.y);
                Vector3 place = tileMap.CellToWorld(localPlace);
                if (tileMap.HasTile(localPlace))
                {
                    availablePlaces.Add(place);
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
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], availablePlaces[Random.Range(0, availablePlaces.Count)], Quaternion.identity);
        }
    }
}
