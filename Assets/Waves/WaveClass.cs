using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Wave", order = 1)]
public class WaveClass : ScriptableObject
{

    [SerializeField] public List<GameObject> enemies;
    [SerializeField] public List<int> number;
    [SerializeField] public int spawnDelay;
}
