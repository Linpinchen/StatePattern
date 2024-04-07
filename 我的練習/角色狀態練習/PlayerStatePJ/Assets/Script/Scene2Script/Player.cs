using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{

    public Context2 context2;

    public int AllHP;
    public int Atk;
    public int Speed;

    public int NowHP;

    public Player()
    {

        context2 = new Context2();
        Rest();
        NowHP = AllHP;

    }




    public void ATK()
    {
        context2.state2.Atk();
    }

    public void Move()
    {
        context2.state2.Move();

    }


    public void Request()
    {

        context2.ChangeAnimal(NowHP);

    }

    public void Rest()
    {
        AllHP = 100;
        Atk = 500;
        Speed = 150;

    }

}
