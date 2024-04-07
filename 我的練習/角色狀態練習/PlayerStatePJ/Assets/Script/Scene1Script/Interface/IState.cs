using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState 
{

    Context context { get; set; }

    void ATK();

    void Move();


    void StateUpdate(int value, ISkill skill);


}
