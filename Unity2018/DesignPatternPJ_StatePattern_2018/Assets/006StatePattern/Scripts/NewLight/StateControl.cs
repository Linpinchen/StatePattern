using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateControl 
{
    
    public float Timer;

    public bool IsOK;

    public void StateStart()
    {

        Timer = Time.time;

    }

    public TrafficState2 StatsChange(TrafficState2 _LightClass)
    {

            TrafficState2 retTra;
            IsOK = true;
            StateStart();
            Debug.Log("Timer :"+Timer);

            switch (_LightClass._LightType)
            {


                case LightType.Pass:
                   
                    Debug.Log(LightType.Pass);

                    retTra = new NewTest.PassBlink();
                    Debug.Log("Pass :ChangeType-TO-PassBlink");
                  
                    break;

                case LightType.PassBlink:
                   
                    Debug.Log(LightType.PassBlink);

                    retTra = new NewTest.Wait();
                        Debug.Log("PassBlink :ChangeType-TO-Wait");
                   
                    break;

                case LightType.Wait:
                   
                    Debug.Log(LightType.Wait);

                    retTra = new NewTest.Stop();
                    Debug.Log("Wait :ChangeType-TO-Stop");
                   
                    break;

                case LightType.Stop:
                   
                    Debug.Log(LightType.Stop);

                    retTra = new NewTest.Pass();
                    Debug.Log("Stop :ChangeType-TO-Pass");
                    
                    break;

                default:
                    retTra = new NewTest.Pass();
                    break;
            }

        return retTra;
        
       
    }

}
