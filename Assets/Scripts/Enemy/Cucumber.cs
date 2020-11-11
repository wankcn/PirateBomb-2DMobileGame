using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucumber : Enemy
{
    /// 事件方法执行在吹灭动画里
    public void SetOff()
    {
        targetPonit.GetComponent<Bomb>().TurnOff();
    }
}