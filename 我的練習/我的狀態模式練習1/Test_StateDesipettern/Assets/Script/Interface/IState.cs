using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 狀態（ˋ抽象類）
/// </summary>
public abstract class IState
{

    protected Context m_COntext = null;

    public IState(Context m_COntext)
    {

        this.m_COntext = m_COntext;

    }

    //狀態行為
    public abstract void Handel(int Value);


}
