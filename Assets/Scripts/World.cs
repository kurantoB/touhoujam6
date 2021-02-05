using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    // 20 x 20 grid, each square is a bucket representing all the objects in that location
    // value increases left to right, top to bottom
    // player starts at location 10, 10
    public List<GameObject>[,] map = new List<GameObject>[20, 20];

    public GameObject player;

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
}
