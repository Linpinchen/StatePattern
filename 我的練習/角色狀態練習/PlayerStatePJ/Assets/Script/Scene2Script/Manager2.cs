using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager2 : MonoBehaviour
{
    Player player;

    bool b;

    // Start is called before the first frame update
    void Start()
    {
        b = true;
       
        player = new Player();

        player.context2.AddStatus(Animal.Bear,new BearState(new BearSkill(player)));

        player.context2.AddStatus(Animal.Bird, new  BirdState(new BirdSkill(player)));




    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {

            player.ATK();
            Debug.Log($"Player.ATK:{player.Atk}");

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            player.Move();
            Debug.Log($"Player.Speed :{player.Speed}");
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (b)
            {
                player.NowHP -= 10;
                if (player.NowHP <= 0)
                {
                    b = !b;
                }
            }
            else
            {
                player.NowHP += 10;
                if (player.NowHP >= player.AllHP)
                {
                    b = !b;
                }
            }
            
            Debug.Log($" Player.總HP : {player.AllHP} , 當前ＨＰ：{player.NowHP}");
            player.Request();

        }


    }
}
