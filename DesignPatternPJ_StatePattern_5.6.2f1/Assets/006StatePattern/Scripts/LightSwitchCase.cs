using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchCase : MonoBehaviour 
{
    /*
    ---- 狀態模式 StatePattern
    https://github.com/TYJia/GameDesignPattern_U3D_Version/tree/master/Assets/006StatePattern

    ★项目说明
    这个场景内有两个状态机：

    一个是Light Switch Case实现的冷暖光，运行后点击“Switch”按键即可观察
    一个是Light State Class实现的交通灯，运行后会自动变换
    
    ★笔记
    - 是什么（个人理解）
    现在状态和条件决定对象的新状态，状态决定行为（Unity内AnimationController就是状态机）

    - 为什么
    使流程清晰化、结构化
    简化判断逻辑，比如嘴的状态是洗牙，那就不应该做出咀嚼的行为；必须是在憋气，那就不应该做出呼吸的行为
    注解
    状态机（自动机）是我最喜欢的一种设计模式，因为这样设计的程序逻辑清晰，稳定性也很强
    作者对switch case下的状态机理解并不深刻，一般情况下，状态机需要两个switch case，"一个用于处理状态变化"，"另一个用来处理状态行为"
    相比状态类，个人更喜欢switch case的方法，虽然状态类有其有点，但缺点也非常明显——当状态量较大时，代码量激增，可读性也很差，状态变化和状态行为都需要大量的信息传递，十分不便
    怎么做
    这次我实现了两个版本：

    - LightSwitchCase版本
    用按键控制一盏灯，关灯状态下，
    按一次打开暖光，
    再按切换为白光，
    再按变为暖白光，
    再按关闭。

    - Light State Class状态类版本
    交通灯 : 停止、通行、闪烁、等待的切换 
    */

    public LightState CurrentState = LightState.Off;

    private Light mLight;
    private Material mMat;

    /// <summary>
    /// 燈的狀態
    /// </summary>
    public enum LightState
    {
        Off,
        Warm,//暖光
        White,//白光
        WarmWhite//暖白光
    }

    private void Awake()
    {
        mLight = GetComponent<Light>();
        mMat = GetComponentInChildren<Renderer>().material;
    }

    /// <summary>
    /// 切換狀態
    /// </summary>
    public void OnChangeState()
    {
        //状态转换
        switch (CurrentState)
        {
            case LightState.Off:
                CurrentState = LightState.Warm;
                break;
            case LightState.Warm:
                CurrentState = LightState.White;
                break;
            case LightState.White:
                CurrentState = LightState.WarmWhite;
                break;
            case LightState.WarmWhite:
                CurrentState = LightState.Off;
                break;
            default:
                CurrentState = LightState.Off;
                break;
        }
        //状态行为
        /*
        unity material.SetColor
         https://docs.unity3d.com/ScriptReference/Material.SetColor.html
         http://www.manew.com/youxizz/1753.html
         */
        switch (CurrentState)
        {
            case LightState.Off:
                mLight.color = Color.black;
                mMat.SetColor("_EmissionColor", mLight.color);
                break;
            case LightState.Warm:
                mLight.color = new Color(0.8f, 0.5f, 0);
                mMat.SetColor("_EmissionColor", mLight.color);
                break;
            case LightState.White:
                mLight.color = new Color(0.8f, 0.8f, 0.8f);
                mMat.SetColor("_EmissionColor", mLight.color);
                break;
            case LightState.WarmWhite:
                mLight.color = new Color(1, 0.85f, 0.6f);
                mMat.SetColor("_EmissionColor", mLight.color);
                break;
            default:
                mLight.color = Color.black;
                mMat.SetColor("_EmissionColor", mLight.color);
                break;
        }
    }
}
