using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoBoard : MonoBehaviour
{
    [Header("Board Specs")]
    [SerializeField] Vector2 boardSize = new Vector2(4, 12);
    [SerializeField] float evenRowOffset = .5f;
    [SerializeField] float pegOffsetX = 1;
    [SerializeField] float pegOffsetY = 1;

    [Header("References")]
    [SerializeField] GameObject pegPrefab;
    [SerializeField] Transform pegs;

    List<GameObject> pegList;



    private float rowOffset;


    void Start()
    {
        pegList = new List<GameObject>();
        for (int y = 0; y < boardSize.y; y++)
        {
            if (y % 2 != 0) { rowOffset = evenRowOffset; }
            else { rowOffset = 0; }

            for (int x = 0; x < boardSize.x; x++)
            {

                Vector2 spawnPosition = new Vector2(pegs.position.x + (x * pegOffsetX) - rowOffset, pegs.position.y - (pegOffsetY * y));
                GameObject peg = Instantiate(pegPrefab, spawnPosition, Quaternion.identity);
                peg.transform.parent = pegs;
                pegList.Add(peg);
            }
        }
    }
}
