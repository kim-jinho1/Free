using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [Header("SO")]
    [SerializeField] private EnemySO enemySO;

    private int _hp;
    private float _attackDamage;
    private float _attackSpeed;

    public int Hp
    {
        get
        {
            return _hp;
        }
        set
        {
            if (value >= 0)
            {
                _hp = value;
            }
            else
            {
                _hp = 0;
            }
        }
    }
}
