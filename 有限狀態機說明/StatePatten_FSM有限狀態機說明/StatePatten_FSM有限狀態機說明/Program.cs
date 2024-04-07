using System;

namespace StatePatten_FSM有限狀態機說明
{

    /*
     * 有限狀態機說明 ：
     * 
     * 
     *              有限狀態機 與 狀態模式是不同的
     *              
     *              有限狀態機 其實可以說是一種數學邏輯 是種概念 他有很多方式可以實現 不一定要用狀態模式（雖然大部分狀況都是用狀態模式來寫有限狀態機比較好的）
     *              
     *              狀態模式 是 設計模式的一種 ： 狀態模式只是 有限狀態機 在物件導向概念下 的一種實現方式
     *              狀態模式---> 透過不同狀態得切換 , 讓類別展現不同的行為 
     *              主要就兩個點 ： 分離不同的行為模式 , 整合（切換）不同的行為狀態 
     *              
     * 
     *              有限狀態機 通常用來說明系統在幾個狀態之間切換 
     *              
     *              
     *              有限狀態機 最簡單的實作方式 就是透過  Switch Case 搭配 Enum 來實作 ,
     *              
     *              但是這又個缺點 , 負責處理 轉換判斷的腳本 會因為 龐大的判別式 而難以擴增 , 每次新增狀態 也代表 判斷是要多加一個判斷  , 也需要多增加一個Enum
     *              
     *              雖然 可以將各狀態的腳本解耦（每個狀態不認識其他狀態） , 但是容易因為龐大的判斷是而造成閱讀上的困難
     *              
     *              
     *              所以 會比較推薦 將狀態的轉換方式 寫在各自的狀態內 （這樣 要新增新的狀態 , 只需將前一個狀態 要更新的腳本修改狀態更改對象 並新增新的狀態實例腳本就好）
     *
     *              
     *              參考文章 : https://featherchung.wordpress.com/2020/06/13/為遊戲開發者所寫的有限狀態機-finite-state-machine-fsm-for-game-developers/
     *
     *              參考文章2:https://medium.com/pm的生產力工具箱/如何有邏輯的釐清事物的狀態-f9fb59b15054
     *
     *              參考文章3:https://douduck08.wordpress.com/2017/01/18/prepare-a-state-pattern-for-unity/
     *
     */


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
