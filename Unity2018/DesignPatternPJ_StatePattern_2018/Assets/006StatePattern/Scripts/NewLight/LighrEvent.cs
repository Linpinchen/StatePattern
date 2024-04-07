using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighrEvent 
{

    bool isOn;
    float BlinkTimer = 0;

    public void TOShiny(Material GreenLight, Material YellowLight, Material RedLight)
    {
        GreenLight.SetColor("_EmissionColor", Color.green);
        YellowLight.SetColor("_EmissionColor", Color.black);
        RedLight.SetColor("_EmissionColor", Color.black);
    }


    public void TOYellow(Material GreenLight, Material YellowLight, Material RedLight)
    {

    }


    public void TORed(Material GreenLight, Material YellowLight, Material RedLight)
    {

        GreenLight.SetColor("_EmissionColor", Color.black);
        YellowLight.SetColor("_EmissionColor", Color.yellow);
        RedLight.SetColor("_EmissionColor", Color.black);
    }

    public void TOGreen(Material GreenLight, Material YellowLight, Material RedLight)
    {

        GreenLight.SetColor("_EmissionColor", Color.black);
        YellowLight.SetColor("_EmissionColor", Color.black);
        RedLight.SetColor("_EmissionColor", Color.red);

    }


}
