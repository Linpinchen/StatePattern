using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss 
{

    Context context;

    ISkill skill;


    public int HP;

    public Boss(ISkill skill)
    {
        this.skill = skill;
        context = new Context(this.skill);

    }


    public void ATK()
    {
        context.state.ATK();
    }


    public void Move()
    {

        context.state.Move();

    }


    public void Change()
    {

        context.Request(HP);
    }


}
