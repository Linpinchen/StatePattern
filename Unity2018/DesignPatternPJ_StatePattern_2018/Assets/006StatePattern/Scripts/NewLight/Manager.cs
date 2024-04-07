using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewTest;

public class Manager : MonoBehaviour
{

    
    public StateControl _STCon;
    public TrafficState2 _TrafficState;
    public GameObject GreenLightObj;
    public GameObject YellowLightObj;
    public GameObject RedLightObj;
    private Material GreenLight;
    private Material YellowLight;
    private Material RedLight;
    
    // Start is called before the first frame update
    void Start()
    {
        GreenLight = GreenLightObj.GetComponent<Renderer>().material;
        YellowLight = YellowLightObj.GetComponent<Renderer>().material;
        RedLight = RedLightObj.GetComponent<Renderer>().material;
        _STCon = new StateControl();
        _TrafficState = new NewTest.Pass();
        _STCon.StateStart();
        _STCon.IsOK = true;
        _TrafficState.ContinousStateBehaviour(ref _STCon.IsOK, GreenLight, YellowLight, RedLight);
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time>_STCon.Timer+_TrafficState.Duration)
        {
            _TrafficState=_STCon.StatsChange(_TrafficState);
            
        }
        _TrafficState.ContinousStateBehaviour(ref _STCon.IsOK, GreenLight, YellowLight, RedLight);
    }
}

public enum LightType
{
    Pass,
    PassBlink,
    Wait,
    Stop,



}
