using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoATKState : IState
{

    public Context context { get; set; }


    public NoATKState(Context context)
    {

        this.context = context;

    }


    public void ATK()
    {

        Debug.Log("NoATK");

    }



    public void Move()
    {

        context.skill.Move();

    }

    /// <summary>
    /// 狀態更新
    /// </summary>
    /// <param name="value"></param>
    /// <param name="skill"></param>
    public void StateUpdate(int value,ISkill skill)
    {
        if (value >=50)
        {
            context.SetState(new NoMoveState(context));
        }
        
    }
}
