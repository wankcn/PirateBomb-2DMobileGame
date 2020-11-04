using UnityEngine;

/// <summary>
/// 攻击状态的类
/// </summary>
public class AttackState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        Debug.Log("发现敌人！！！");
        // TODO 刚进入攻击状态
    }

    public override void OnUpdate(Enemy enemy)
    {
        // 如果攻击列表内有物体，敌人就进行攻击
        if (enemy.attackList.Count <= 0)
            enemy.TransitionToState(enemy.patrolState);
    }
}