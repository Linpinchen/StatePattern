using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{


    //講一下個腳本之間的關係


    /*
     
        IState 是 狀態的模板(抽象類) ： 會設定一個建構子 用來取得  Context

        Context 是狀態的控制腳本 負責 設定當前狀態 以及調用 當前狀態的行為
     
        然後我們有三個 實際的狀態腳本  分別有各自的行為 , 並且一樣在建構子 基於基底腳本 導入 Context  方便使用 Context的設定狀態

        三個腳本 分別 的行為為 ： Ａ： value >10 調用 Context的 SetState 並將狀態更換為 B , B： value >20 調用 Context的 SetState 並將狀態更換為 C 
     
                               C： value >30 調用 Context的 SetState 並將狀態更換為 A 
     
     
     
     -----------------------------------------------------------------------------------------------------------------------------------


     
     
     */





    Context context;

    // Start is called before the first frame update
    void Start()
    {
        context = new Context();

        context.SetState(new StateA(context));

        context.Request(5);
        context.Request(15);
        context.Request(25);
        context.Request(35);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
