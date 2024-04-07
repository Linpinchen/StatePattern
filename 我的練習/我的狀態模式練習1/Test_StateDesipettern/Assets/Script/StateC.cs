using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 不同狀態類型的狀態C
/// </summary>
public class StateC :IState
{

    //建構子 後面 : base(context) 是引用到基底腳本的建構子
    public StateC(Context context) : base(context)
    {

    }


    /// <summary>
    /// 設置狀態行為
    /// </summary>
    /// <param name="Value"></param>
    public override void Handel(int Value)
    {

        Debug.Log("StateC.Handel");

        if (Value>30)
        {


            m_COntext.SetState(new StateA(m_COntext));

        }


    }


}
