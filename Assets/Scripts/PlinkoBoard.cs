using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoBoard : MonoBehaviour
{
    [SerializeField] GameObject pegPrefab;
    [SerializeField] Vector2 boardSize = new Vector2(4, 12);

    float rowOffset;

    void Start()
    {
        for (int y = 0; y < boardSize.y; y++)
        {
            if (y % 2 == 0) { rowOffset = .5f; }
            else { rowOffset = 0; }
            for (int x = 0; x < boardSize.x; x++)
            {

                Vector2 spawnPosition = new Vector2(transform.position.x - rowOffset + x, transform.position.y - y);
                Instantiate(pegPrefab, spawnPosition, Quaternion.identity);
                print(spawnPosition);
            }
        }
    }
}
