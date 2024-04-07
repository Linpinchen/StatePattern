using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context2 
{

    public IState2 state2;

    Animal animal;

    Dictionary<Animal, IState2> Status;


    public Context2()
    {
        Status = new Dictionary<Animal, IState2>();

    }


    /// <summary>
    /// 添加狀態
    /// </summary>
    /// <param name="animal"></param>
    /// <param name="state2"></param>
    public void AddStatus(Animal animal , IState2 state2 )
    {
        
        Status.Add(animal, state2);

        if (Status.Keys.Count<=1)
        {
            this.animal = animal;
            this.state2 = state2;
            state2.ValueUP();
        }


    }

    /// <summary>
    /// 狀態設置條件
    /// </summary>
    /// <param name="value"></param>
    public void ChangeAnimal(int value)
    {

        if (value >=150 && animal!= Animal.Bear)
        {
            animal = Animal.Bear;
            Request();
            
        }
        else if(value <150 && animal != Animal.Bird)
        {
            animal = Animal.Bird;
            Request();
        }




    }




    /// <summary>
    /// 要設置哪個狀態
    /// </summary>
    void Request()
    {

        this.state2 = Status[animal];
        state2.ValueUP();
    }


}

public enum Animal
{
    Bear,
    Bird


}
