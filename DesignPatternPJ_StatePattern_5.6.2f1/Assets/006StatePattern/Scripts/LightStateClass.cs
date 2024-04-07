using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStateClass : MonoBehaviour
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
    作者对switch case下的状态机理解并不深刻，一般情况下，状态机需要两个switch case，一个用于处理状态变化，另一个用来处理状态行为
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
    交通灯 : 通行(綠燈亮) -> 切燈警示(綠準備轉黃)(綠燈閃爍) -> 警示(黃燈亮) -> 停止(紅燈亮) 循環~
    */

    public GameObject GreenLightObj;
    public GameObject YellowLightObj;
    public GameObject RedLightObj;

    private Material GreenLight;
    private Material YellowLight;
    private Material RedLight;

    /// <summary>
    /// 交通燈狀態
    /// </summary>
    private TrafficState TrafficLight;

    void Start()
    {
        GreenLight = GreenLightObj.GetComponent<Renderer>().material;
        YellowLight = YellowLightObj.GetComponent<Renderer>().material;
        RedLight = RedLightObj.GetComponent<Renderer>().material;
        SetState(new Pass());

    }

    void Update()
    {
        TrafficLight.ContinousStateBehaviour(this, GreenLight, YellowLight, RedLight);

    }

    public void SetState(TrafficState state)
    {
        TrafficLight = state;
        TrafficLight.StateStart(GreenLight, YellowLight, RedLight);
    }
}

/// <summary>
/// 抽象-交通燈狀態
/// </summary>
public abstract class TrafficState
{
    /// <summary>
    /// 持續時間
    /// </summary>
    public float Duration;

    /// <summary>
    /// 計時器
    /// </summary>
    public float Timer;

    /// <summary>
    /// 狀態開始
    /// </summary>
    /// <param name="GreenLight"></param>
    /// <param name="YellowLight"></param>
    /// <param name="RedLight"></param>
    public virtual void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        Timer = Time.time;
    }

    /// <summary>
    /// 切換狀態行為
    /// </summary>
    /// <param name="mLSC"></param>
    /// <param name="GreenLight"></param>
    /// <param name="YellowLight"></param>
    /// <param name="RedLight"></param>
    public abstract void ContinousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight);
}

/// <summary>
/// 通行(綠燈亮)
/// </summary>
public class Pass : TrafficState
{
    public Pass()
    {
        Duration = 2;
    }

    public override void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        base.StateStart(GreenLight, YellowLight, RedLight);
        GreenLight.SetColor("_EmissionColor", Color.green);
        YellowLight.SetColor("_EmissionColor", Color.black);
        RedLight.SetColor("_EmissionColor", Color.black);
    }
    public override void ContinousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight)
    {
        //實際時間 > 指定時間(上次結束時記錄的時間+本次需要的持續時間)
        if (Time.time > Timer + Duration)
        {
            mLSC.SetState(new PassBlink());
        }
    }
}

/// <summary>
/// 切燈警示(綠準備轉黃)(綠燈閃爍)
/// </summary>
public class PassBlink : TrafficState
{
    private bool On = true;
    /// <summary>
    /// 閃爍計時器
    /// </summary>
    private float BlinkTimer = 0;

    public PassBlink()
    {
        Duration = 1;
    }

    public override void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        base.StateStart(GreenLight, YellowLight, RedLight);
    }

    private static void SwitchGreen(Material GreenLight, bool open)
    {
        Color color = open ? Color.green : Color.black;
        GreenLight.SetColor("_EmissionColor", color);
    }

    public override void ContinousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight)
    {
        if (Time.time > Timer + Duration)
        {
            mLSC.SetState(new Wait());
        }
        if (Time.time > BlinkTimer + 0.2f)
        {
            On = !On;
            BlinkTimer = Time.time;
            SwitchGreen(GreenLight,On);
        }
    }
}

/// <summary>
/// 警示(黃燈亮)
/// </summary>
public class Wait : TrafficState
{
    public Wait()
    {
        Duration = 1;
    }

    public override void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        base.StateStart(GreenLight, YellowLight, RedLight);
        GreenLight.SetColor("_EmissionColor", Color.black);
        YellowLight.SetColor("_EmissionColor", Color.yellow);
        RedLight.SetColor("_EmissionColor", Color.black);
    }
    public override void ContinousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight)
    {
        if (Time.time > Timer + Duration)
        {
            mLSC.SetState(new Stop());
        }
    }
}

/// <summary>
/// 停止(紅燈亮)
/// </summary>
public class Stop : TrafficState
{
    public Stop()
    {
        Duration = 1;
    }

    public override void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        base.StateStart(GreenLight, YellowLight, RedLight);
        GreenLight.SetColor("_EmissionColor", Color.black);
        YellowLight.SetColor("_EmissionColor", Color.black);
        RedLight.SetColor("_EmissionColor", Color.red);
    }
    public override void ContinousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight)
    {
        if (Time.time > Timer + Duration)
        {
            mLSC.SetState(new Pass());
        }
    }
}
