using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 不同狀態類型的狀態B
/// </summary>
public class StateB :IState
{
    public StateB(Context context) : base(context)
    {

    }

    public override void Handel(int Value)
    {

        Debug.Log("StateB.Handel");

        if (Value > 20)
        {


            m_COntext.SetState(new StateC(m_COntext));

        }


    }
}
