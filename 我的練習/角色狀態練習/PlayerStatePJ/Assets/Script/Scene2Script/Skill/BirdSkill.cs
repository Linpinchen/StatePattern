using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSkill : ISkill2
{

    Player player;

    public BirdSkill(Player player)
    {

        this.player = player;        

    }

    public void AtkSkill()
    {

        Debug.Log("翅膀攻擊");

    }

    public void MoveSkill()
    {

        Debug.Log("飛天");

    }

    public void Natural()
    {
        player.Rest();

        if (player.AllHP == player.NowHP)
        {
            player.AllHP *= 2;
            player.NowHP = player.AllHP;
        }
        else
        {
            player.AllHP *= 2;
        }

        player.Atk += 100;

        player.Speed *=2;

    }


}
