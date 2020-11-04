using UnityEngine;

public class PatrolState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        // 一进入状态切换巡逻的目标点
        enemy.SwitchPoint();
    }

    public override void OnUpdate(Enemy enemy)
    {
        // 每一帧把不断的循环 无限趋近于目标点 当前敌人的坐标以及当前敌人的目标点
        if (Mathf.Abs(enemy.transform.position.x - enemy.targetPonit.position.x) < 0.01f)
            enemy.SwitchPoint();
        enemy.MoveToTarget();
    }
}