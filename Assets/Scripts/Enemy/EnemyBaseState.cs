public abstract class EnemyBaseState
{
    /// 进入状态
    public abstract void EnterState(Enemy enemy);

    /// 保持在当前状态下 持续不断运行的函数的方法
    public abstract void OnUpdate(Enemy enemy);
}