using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSkill : ISkill2
{
    Player player;


    public BearSkill(Player player)
    {

        this.player = player;
    }

    public void AtkSkill()
    {

        Debug.Log("熊掌攻擊");

    }

    public void MoveSkill()
    {

        Debug.Log("衝刺");

    }

    public void Natural()
    {
        player.Rest();

        if (player.AllHP == player.NowHP)
        {
            player.AllHP *= 3;
            player.NowHP = player.AllHP;
        }
        else
        {
            player.AllHP *= 3;
        }

        player.Atk *= 2;
        player.Speed -= 60;
        
    }



}
