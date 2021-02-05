using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    // 20 x 20 grid, each square is a bucket representing all the objects in that location
    // value increases left to right, top to bottom
    // player starts at location 10, 10
    public List<GameObject>[,] map = new List<GameObject>[20, 20];

    public GameObject player;
    public Enemy enemy;

    private float timeElapsed;
    private List<Enemy> enemies = new List<Enemy>();

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                map[i, j] = new List<GameObject>();
            }
        }
        map[10, 10].Add(player);
    }

    private bool spawned = false;
    private void Update()
    {
        timeElapsed += Time.deltaTime;

        // TESTING PURPOSES: spawn an enemy at the 3 second mark at (13, 13) on the grid;
        if (!spawned && timeElapsed > 3f)
        {
            Enemy enemyInstance = Instantiate(enemy);
            enemyInstance.GetComponent<Enemy>().SpawnAt(this, 13, 13);
            enemies.Add(enemyInstance);
            spawned = true;
        }
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }
}
