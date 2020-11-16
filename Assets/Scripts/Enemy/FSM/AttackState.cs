using UnityEngine;

/// <summary>
/// 攻击状态的类
/// </summary>
public class AttackState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        enemy.animState = 2;
        // 先把当前目标换到检测列表中的第一个变量
        enemy.targetPonit = enemy.attackList[0];
    }

    public override void OnUpdate(Enemy enemy)
    {
        if (enemy.hasBomb)
            return;
        
        // 没有对象可以进行攻击，转换为巡逻状态
        if (enemy.attackList.Count == 0)
            enemy.TransitionToState(enemy.patrolState);
        else if (enemy.attackList.Count > 1)
        {
            for (int i = 0; i < enemy.attackList.Count; i++)
            {
                // 修改距离最近的点作为目标点
                if (Mathf.Abs(enemy.transform.position.x - enemy.attackList[i].position.x) <
                    Mathf.Abs(enemy.transform.position.x - enemy.targetPonit.position.x))
                    enemy.targetPonit = enemy.attackList[i];
            }
        }
        else if (enemy.attackList.Count == 1)
            enemy.targetPonit = enemy.attackList[0];


        // 根据标签类型选择攻击方式 在移动之前
        if (enemy.targetPonit.CompareTag("Player"))
            enemy.AttackAction();
        if (enemy.targetPonit.CompareTag("Bomb"))
            enemy.SkillAction();

        enemy.MoveToTarget();
    }
}