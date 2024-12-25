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
        // ���� �� ����
        int enemyIndex = UnityEngine.Random.Range(0, _enemies.Length);
        GameObject en = Instantiate(_enemies[enemyIndex], MapManager.Instance._enemyPool.transform);

        // ���� ��ġ ����
        Transform[] spawnPositions = { _centerEnemyPos, _leftEnemypos, _rightEnemypos };
        int positionIndex = UnityEngine.Random.Range(0, spawnPositions.Length);

        // �� ��ġ
        Transform selectedPosition = spawnPositions[positionIndex];
        en.transform.position = selectedPosition.position;
        en.transform.GetChild(0).GetChild(0).Rotate(0, 180, 0);

        en.SetActive(false);

        // ��ġ�� ���� �� ��ũ��Ʈ�� �� ����
        AssignEnemyToRoom(selectedPosition, en);

        return en;
    }

    private void AssignEnemyToRoom(Transform position, GameObject enemy)
    {
        // �ش� ��ġ�� ����� ��ũ��Ʈ�� ��������
        IMap roomScript = position.GetComponent<IMap>();
        if (roomScript != null)
        {
            roomScript.SettingRoom(0, enemy); // �� ��ȣ�� 0���� ���� (�ʿ� �� ���� ����)
        }
        else
        {
            Debug.LogWarning($"No IMap script attached to object: {position.name}");
        }
    }
}