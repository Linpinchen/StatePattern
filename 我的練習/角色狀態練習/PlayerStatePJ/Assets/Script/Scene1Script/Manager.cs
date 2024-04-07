using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    // 場景一 腳本示範的是   技能都是同樣的 角色狀態改變 改的是各個狀態下技能的表現 

    /*
     
     腳本之間 關係說明 ：

        Manager  總控制端 這裡統一由 Manager 決定誰跟誰耦合


        Boss : 角色腳本  內部有 移動方法 跟 攻擊方法 （ 提供給Maanger呼叫 這裡腳本內容一樣不會更動 , 需要啥都由Manager給予 ）
               以及一個 狀態控制器 （ 控制目前角色狀態 ）


        Context : 狀態控制腳本  內部會有狀態屬性 紀錄當前狀態 以及 設定當前狀態的方法 跟 呼叫 狀態更新的方法


        IState : 狀態介面 負責定義 各狀態類需要哪些方法 的模板 , 還有一個方法是 狀態的更新機制

        NoATKState : 繼承了 IState 介面實作內容 

        noMoveState : 繼承了 IState 介面實作內容 
        

        ISkill : 技能的模板

        FireSkill : 繼承了 ISkill 介面實作內容 
        
        IceSkill :  繼承了 ISkill 介面實作內容 
     
     

        

     
     */




    public int HP;
    public Propoty propoty;

    Boss Boss;

    ISkill skill;


    // Start is called before the first frame update
    void Start()
    {

        if (propoty == Propoty.冰)
        {
            skill = new IceSkill();
            
        }
        else
        {
            skill = new FireSkill();
        }
        Boss = new Boss(skill);

        Boss.HP = HP;

        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Boss.ATK();

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Boss.Move();

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {

            Boss.HP = HP;
            Debug.Log(Boss.HP);
            Boss.Change();
            



        }



    }




}


public enum Propoty
{
    冰,
    火

}
