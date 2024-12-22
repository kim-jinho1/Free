using System;
using UnityEngine;

public class Map : MonoSingleton<Map>
{
    [SerializeField] public Transform _centerEnemyPos;
    [SerializeField] public Transform _leftEnemypos;
    [SerializeField] public Transform _rightEnemypos;
    [SerializeField] public Transform _floor;
    
    [SerializeField] public GameObject[] _enemies;
    
    public GameObject _enemy;

    public GameObject CreateEnemy()
    {
        GameObject en = Instantiate(_enemies[0], MapManager.Instance._enemyPool.transform);
        en.transform.position = _rightEnemypos.position;
        en.transform.Rotate(0, 180, 0);
        en.transform.position = _rightEnemypos.position;
        _enemy = en;
        en.SetActive(false);
        return en;
    }
}