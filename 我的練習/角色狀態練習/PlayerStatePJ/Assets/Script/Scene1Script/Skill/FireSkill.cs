using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : ISkill
{
    public void Move()
    {
        Debug.Log("火焰移動");
    }

    public void Skill()
    {
        Debug.Log(" 火焰攻擊");
    }
}
