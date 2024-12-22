
public interface IAttackAble
{
    public void AttackEnemy(EnemyData enemy, ItemData item);
}

public interface IDebuffAble
{
    public void DebuffEnemy();
}

public interface IDebuffEnAble
{
    public void CancelDebuff(EnemyData enemy, ItemData item);
}
