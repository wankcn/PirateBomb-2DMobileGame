using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFX : MonoBehaviour
{
    // 播放完之后关闭动画显示
    public void Finish()
    {
        gameObject.SetActive(false);
    }
}