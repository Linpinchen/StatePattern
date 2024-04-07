using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    /// <summary>
    /// 抽象-交通燈狀態
    /// </summary>
    public abstract class TrafficState2
    {
        /// <summary>
        /// 持續時間
        /// </summary>
        public float Duration;

        public LightType _LightType;
       
        /// <summary>
        /// 切換狀態行為
        /// </summary>
        /// <param name="mLSC"></param>
        /// <param name="GreenLight"></param>
        /// <param name="YellowLight"></param>
        /// <param name="RedLight"></param>
        public abstract void ContinousStateBehaviour( ref bool isOK, Material GreenLight, Material YellowLight, Material RedLight);
    }


