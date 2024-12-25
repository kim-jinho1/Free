using UnityEngine;

public class Map : MonoSingleton<Map>
{
    [SerializeField] public Transform _centerEnemyPos;
    [SerializeField] public Transform _leftEnemypos;
    [SerializeField] public Transform _rightEnemypos;
    [SerializeField] public Transform _floor;

    [SerializeField] public GameObject[] _enemies;

    public GameObject CreateEnemy()
    {
        // 랜덤 적 선택
        int enemyIndex = UnityEngine.Random.Range(0, _enemies.Length);
        GameObject en = Instantiate(_enemies[enemyIndex], MapManager.Instance._enemyPool.transform);

        // 랜덤 위치 선택
        Transform[] spawnPositions = { _centerEnemyPos, _leftEnemypos, _rightEnemypos };
        int positionIndex = UnityEngine.Random.Range(0, spawnPositions.Length);

        // 적 배치
        Transform selectedPosition = spawnPositions[positionIndex];
        en.transform.position = selectedPosition.position;
        en.transform.GetChild(0).GetChild(0).Rotate(0, 180, 0);

        en.SetActive(false);

        // 위치에 따른 방 스크립트에 적 설정
        AssignEnemyToRoom(selectedPosition, en);

        return en;
    }

    private void AssignEnemyToRoom(Transform position, GameObject enemy)
    {
        // 해당 위치에 연결된 스크립트를 가져오기
        IMap roomScript = position.GetComponent<IMap>();
        if (roomScript != null)
        {
            roomScript.SettingRoom(0, enemy); // 방 번호를 0으로 설정 (필요 시 수정 가능)
        }
        else
        {
            Debug.LogWarning($"No IMap script attached to object: {position.name}");
        }
    }
}