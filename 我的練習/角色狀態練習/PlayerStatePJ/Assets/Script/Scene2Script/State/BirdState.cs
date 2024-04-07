using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdState : IState2
{
    
    ISkill2 skill2;

    public BirdState( ISkill2 skill2)
    {

        this.skill2 = skill2;
    }


    public void Atk()
    {
        skill2.AtkSkill();
    }

    public void Move()
    {
        skill2.MoveSkill();
    }

    public void ValueUP()
    {

        skill2.Natural();

    }

}
