﻿using System;

namespace 狀態模式說明
{

    /*
     
     
        狀態模式的定義  ：


                        讓一個物件的行為 , 隨著內部狀態的改變而變化 , 而該物件也像是換了類別一樣


                        如果以遊戲來說 ：

                                        狀態模式給人的感覺會像是這樣

                                        當德魯伊 由人行變化成獸型狀態（內部狀態改變時） 他所施展的技能（物件的行為）也會有所改變 , 這時玩家就像是在操作另一個不同的角色（像是換了類別）


                        所以 當某個物件狀態改變時 , 雖然他的 “ 表現行為 ” 改變了 , 但是對於客戶端來說 , 並不會因為這樣蓻的變化 , 而改變對他的 " 操作方式" , 或 “訊息溝通方式”
                        也就是說 這個物件與外界的對應方式 不會發生任何改變

                        但是 ！！ 物件內部 確實是會透過 “更換狀態類別物件” , 的方式進行狀態的轉換 , 表現出他在這個狀態下應該有的行為表現
                        ！！！ 但是這個狀態的轉換只會發生在物件的內部 , 對客戶端來說 , 完全不需要了解這些狀態的轉換過程 以及 對應的方式


                懶人包 ： 我們對物件啜出了狀態的改變 這個改變 是物件內部去處理的 , 對於 外部操作角色移動 放技能啥的 完全不會改變


    ---------------------------------------------------------------------------------------------------------------------------------------

                            這裡會是固定的                           ｜                這裡會是變動的


                                                                              |-----------------------------------|  
                   ｜----------------------｜                                  |                                   ｜
                   ｜     操作角色移動       ｜----------------|                 |   角色狀態 1. 人型   攻擊方式 拳頭攻擊｜
                   ｜----------------------|                 |                |                                   ｜
                                                            |-----------------|-----------------------------------｜
                                                            |                 |                                   ｜
                   ｜----------------------｜                |                 |  角色狀態 2. 獸型   攻擊方式 熊掌攻擊  ｜
                   ｜     操作角色攻擊       ｜----------------|                 |-----------------------------------｜
                   ｜----------------------|                                                                                                                                       


    ---------------------------------------------------------------------------------------------------------------------------------------



        狀態模式 的結構如下 ：

                            Context  <>----------------->   State
                          (+Request)                      (+Handle)   <----------------------------------------|
                                                                                                               |
                              ^                                 ^   ^                                          |
                              |                                 |   |                                          |
                              |                                 |   |____________________                      |
                              |                                 |                        |                     |
                              |                                 |                        |                     |
                              |                                 |                        |                     |
                              |                                 |                        |                     |
                      function Request()                        |                        |                     |
                       { state.Handel }                  concreteState A          concreteState B       concreteState C 
                                                         (    +Handle   )         (    +Handle   )       (    +Handle   )
     




     Context : (狀態擁有者)

                1. 是一個具有 “ 狀態 ” , 屬性的類別 , 可以制定相關的介面 , 讓外界能夠得知 “ 狀態的改變 ” , 或 “ 通過操作來讓狀態改變 ”

                2. 有狀態屬性得類別 ：  例如 角色憯行的狀態 , 角色攻擊的狀態 , 角色施法的狀態

                   會有一個ConcreteStata [X] 子類別的物件為其成員用來代表當前狀態 （其實不一定要用陣列 , 也可以用Enum 他只是要用來代表 當前是指哪個狀態而已）
        




     State : (狀態介面類別)

                制定狀態的介面 , 負責規範 Context（狀態擁有者） 在特定狀態下要表現的行為

     




    ConcreteState : (具體狀態類別) 

                    1. 繼承自 State(狀態介面類別)

                    2. 實作 Context （狀態擁有者）在特定狀態下該有的行為
                       例如 ： 實作角色在淺型狀態下的行動變緩 , 或 模型變半透明 等  






     懶人包 ：  我會有很多不同狀態的Class 什麼 人型態  狼型態 熊型態  , 他們都繼承了   State 這個介面 並實作介面的內容

               而State 裡面可能會有 移動方式的方法 ,  攻擊方式的方法等    我的  人型態  狼型態 熊型態 腳本會去個別實現它

               而 Context 腳本 就是 負責處理  變化當前狀態 跟 回傳當前狀態的腳本 （這可以寫一個介面 , 然後 寫一個狀態變化的方法 讓繼承的腳本 去做不同的實例化內容） 




        以老虎機來說 , 我可以 寫一個贏錢狀態的介面 , 那贏錢狀態有 普通贏錢 , Bonus 贏錢 , 最終展示贏錢

        Manager 透過 調用  Context 內部更改狀態的方法  回傳一個 符合當前狀態的 贏錢表演  來讓 Manager 做 調用 
        （或是 呼叫 更改狀態的方法 改變 Context當前的狀態 然後 Manager 始終都是呼叫  Context 的表演方法 ）


     ---------------------------------------------------------------------------------------------------------------------------------------


     
     */


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
