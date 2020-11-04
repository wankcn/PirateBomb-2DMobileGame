using UnityEngine;

public class PatrolState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        // 一进入游戏数值为0，表示从idle动画状态开始
        enemy.animState = 0;
        // 一进入状态找到巡逻的目标点
        enemy.SwitchPoint();
    }

    public override void OnUpdate(Enemy enemy)
    {
        // !如果正在播放的动画 (动画的层级).IsName("状态的名称")
        if (!enemy.anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            enemy.animState = 1;
            enemy.MoveToTarget();
        }

        // 每一帧把不断的循环 无限趋近于目标点 当前敌人的坐标以及当前敌人的目标点
        if (Mathf.Abs(enemy.transform.position.x - enemy.targetPonit.position.x) < 0.01f)
        {
            // 切换点以外，也同时切换回idle的状态
            // (这里的逻辑是，一切换到巡逻的状态先运行进入状态EnterState方法，进入anim初始化为0，再次执行idle的动画状态)
            enemy.TransitionToState(enemy.patrolState);
        }

        // 如果攻击列表内有物体，敌人就进行攻击
        if (enemy.attackList.Count > 0)
            enemy.TransitionToState(enemy.attackState);
    }
}