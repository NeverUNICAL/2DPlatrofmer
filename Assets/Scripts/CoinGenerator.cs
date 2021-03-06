using System;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private Coin _template;
    private CoinSpawn[] _spawnPoints;

    private void Awake()
    {
      _spawnPoints = GetComponentsInChildren<CoinSpawn>();
    }

    void Start()
    {
        Generate();
    }

    private void Generate()
    {
        foreach (var point in _spawnPoints)
        {
            Instantiate(_template, point.transform.position, Quaternion.identity);
        }
    }
    
}
