using System;
using UnityEngine;

public class Map : MonoSingleton<Map>
{
    [SerializeField] public Transform _centerEnemyPos;
    [SerializeField] public Transform _leftEnemypos;
    [SerializeField] public Transform _rightEnemypos;
    
    [SerializeField] public GameObject[] _enemies;

    public GameObject _enemy;
    private void Start()
    {
        GameObject en = Instantiate(_enemies[0], _rightEnemypos);
        en.transform.Rotate(0, 180, 0);
        _enemy = en;
        en.SetActive(false);
    }
}