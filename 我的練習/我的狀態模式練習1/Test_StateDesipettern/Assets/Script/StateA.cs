using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 不同狀態類型的狀態Ａ
/// </summary>
public class StateA :IState
{
    public StateA(Context context) : base(context)
    {

    }

    public override void Handel(int Value)
    {

        Debug.Log("StateA.Handel");

        if (Value > 10)
        {


            m_COntext.SetState(new StateB(m_COntext));

        }


    }
}
