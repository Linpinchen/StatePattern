using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMoveState : IState
{

    public Context context { get; set; }



    public NoMoveState(Context context)
    {

        this.context = context;

    }


    public void ATK()
    {

        context.skill.Skill();

    }

    public void Move()
    {

        Debug.Log("NoMove");

    }

    /// <summary>
    /// 狀態更新
    /// </summary>
    /// <param name="value"></param>
    /// <param name="skill"></param>
    public void StateUpdate(int value, ISkill skill)
    {
        if (value < 50)
        {
            context.SetState(new NoATKState(context));
        }

    }
}
