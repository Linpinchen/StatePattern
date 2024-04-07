using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 狀態控制腳本
/// </summary>
public class Context 
{

    public IState state;

    public ISkill skill;



    public Context(ISkill skill)
    {
        this.skill = skill;
        state = new NoMoveState(this);
    }

    /// <summary>
    /// 設定當前狀態
    /// </summary>
    /// <param name="state"></param>
    public void SetState( IState state )
    {

        this.state = state;
       
    }


    /// <summary>
    /// 狀態更新方法
    /// </summary>
    /// <param name="value"></param>
    public void Request(int value)
    {

        state.StateUpdate(value,skill);

    }

}
