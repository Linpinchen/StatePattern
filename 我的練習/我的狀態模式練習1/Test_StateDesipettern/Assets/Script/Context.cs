using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 控制狀態變化
/// </summary>
public class Context 
{


    IState state = null;

    /// <summary>
    /// 呼叫 當前狀態的狀態行為
    /// </summary>
    /// <param name="value"></param>
    public void Request(int value)
    {

        state.Handel(value);

    }

    /// <summary>
    /// 設置當前狀態
    /// </summary>
    /// <param name="TheState"></param>
    public void SetState(IState TheState )
    {


        Debug.Log($"Context.SetState() : {TheState}");

        state = TheState;



    }


    
}
