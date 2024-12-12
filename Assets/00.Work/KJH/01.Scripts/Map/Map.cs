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
    private void Start()
    {
        
    }

    public void CreateEnemy(Transform pos)
    {
        GameObject en = Instantiate(_enemies[0], _floor);
        en.transform.Rotate(0, 180, 0);
        en.transform.position = _rightEnemypos.position;
        _enemy = en;
        en.SetActive(false);
    }
}