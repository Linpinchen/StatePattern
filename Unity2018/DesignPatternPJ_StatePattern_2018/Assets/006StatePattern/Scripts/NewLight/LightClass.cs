using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NewTest
{
    /// <summary>
    /// 通行(綠燈亮)
    /// </summary>
    public class Pass :TrafficState2
    {
        public Pass()
        {
            Duration = 2;
            _LightType = LightType.Pass;
        }

        public override void ContinousStateBehaviour(ref bool isOK,Material GreenLight, Material YellowLight, Material RedLight)
        {
            if (isOK)
            {
                isOK = false;
                //實際時間 > 指定時間(上次結束時記錄的時間+本次需要的持續時間)
                GreenLight.SetColor("_EmissionColor", Color.green);
                YellowLight.SetColor("_EmissionColor", Color.black);
                RedLight.SetColor("_EmissionColor", Color.black);
            }
           
        }
    }


    /// <summary>
    /// 切燈警示(綠準備轉黃)(綠燈閃爍)
    /// </summary>
    public class PassBlink : TrafficState2
    {
        private bool On = true;
        /// <summary>
        /// 閃爍計時器
        /// </summary>
        private float BlinkTimer = 0;

        public PassBlink()
        {
            Duration = 1;
            _LightType = LightType.PassBlink;
        }

       
        private static void SwitchGreen(Material GreenLight, bool open)
        {
            Color color = open ? Color.green : Color.black;
            GreenLight.SetColor("_EmissionColor", color);
        }

        public override void ContinousStateBehaviour(ref bool isOK, Material GreenLight, Material YellowLight, Material RedLight)
        {
            if (isOK)
            {
                isOK = false;
                //實際時間 > 指定時間(上次結束時記錄的時間+本次需要的持續時間)
                GreenLight.SetColor("_EmissionColor", Color.green);
                YellowLight.SetColor("_EmissionColor", Color.black);
                RedLight.SetColor("_EmissionColor", Color.black);
            }
            if (Time.time > BlinkTimer + 0.2f)
            {
                On = !On;
                BlinkTimer = Time.time;
                SwitchGreen(GreenLight, On);
            }
        }
    }


    /// <summary>
    /// 警示(黃燈亮)
    /// </summary>
    public class Wait : TrafficState2
    {
        public Wait()
        {
            Duration = 1;
            _LightType = LightType.Wait;
        }

        public override void ContinousStateBehaviour(ref bool isOK, Material GreenLight, Material YellowLight, Material RedLight)
        {

            if (isOK)
            {
                isOK = false;
                //實際時間 > 指定時間(上次結束時記錄的時間+本次需要的持續時間)
                GreenLight.SetColor("_EmissionColor", Color.black);
                YellowLight.SetColor("_EmissionColor", Color.yellow);
                RedLight.SetColor("_EmissionColor", Color.black);
            }

        }
    }



    /// <summary>
    /// 停止(紅燈亮)
    /// </summary>
    public class Stop : TrafficState2
    {
        public Stop()
        {
            Duration = 1;
            _LightType = LightType.Stop;
        }

        
        public override void ContinousStateBehaviour(ref bool isOK, Material GreenLight, Material YellowLight, Material RedLight)
        {

            if (isOK)
            {
                isOK = false;
                //實際時間 > 指定時間(上次結束時記錄的時間+本次需要的持續時間)
                GreenLight.SetColor("_EmissionColor", Color.black);
                YellowLight.SetColor("_EmissionColor", Color.black);
                RedLight.SetColor("_EmissionColor", Color.red);
            }

        }
    }


}

