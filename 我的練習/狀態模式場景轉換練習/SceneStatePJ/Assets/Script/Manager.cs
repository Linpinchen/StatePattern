using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    /*
     * 
     * 
     * 我們遊戲當中 只會在一個場景中運行 
     * 
     * 所以我們可以讓每個場景 都由一個場景類別來做維護
     * 
     * 如果將場景類別 用 “ 狀態 ” 來比喻的話 , 那麼就可以用狀態模式的狀態轉換原理 , 來完成場景轉換的功能
     * 
     * 由於每個場景所負責的功能不同 , 透過狀態模式 的狀態轉移 , 除了可以達成遊戲內部功能的轉換外 
     * 
     * 對於客戶端來說 , 也不必根據不同的遊戲狀態撰寫不同的程式碼 , 同時 “ 減少 外界對於不同遊戲狀態 的相依性 ”
     * 
     * 
     * 
     * 
     * 
     * 各腳本 說明 ：
     * 
     * 場經先預設分成三個 來做練習  , 分別是 開始場景 , 主畫面場景  , 戰鬥場景
     * 
     * 
     * ISceneState :  
     * 
     *              場景類別的介面 , 定義 場景轉換 以及 執行時需要呼叫的方法
     * 
     * 
     * StartState , MainMenuState ,  BattleState :
     * 
     *              分別對應 開始場景 主畫面場景 戰鬥場景  , 作為這些場景執行時的操作類別
     * 
     * 
     * 
     * SceneStateController : 
     * 
     *              場景狀態的擁有者 , 保有目前遊戲狀態 , 並作為 與 Manager 互動的介面 , 也是執行狀態轉換的地方
     * 
     * 
     * 
     * Manager : 
     *              負責調用 SceneStateController 內部方法
     * 
     * 
     * 
     * ＵMＬ 圖 ：
     * 
     *              
     *                  Manager
     *            (- SceneStateControl)
     *            
     *                     ^
     *                     v
     *                     |
     *                     |
     *                     |
     *              SceneStateController
     *               (- ISceneState )
     *                 (+ SetState )     <>------------  ISceneState
     *                (+ StateUpdete)                   (+ StateBegin )
     *                                                   (+ StateEnd)
     *                                                  (+ StateUpdate )
     *                                                         
     *                                                          ^
     *                                                          |
     *                                                  ________|_________
     *                                                  |       |       |
     *                                                  |       |       |
     *                                         _________|       |       |_________
     *                                         |                |                |
     *                                         |                |                |
     *                                         |                |                |
     *                               StartState           MainMenuState        BattleState
     *                             (+ StateBegin)        (+ StateBegin)       (+ StateBegin)
     *                              (+ StateEnd)          (+ StateEnd)         (+ StateEnd)
     *                             (+ StateUPddate)      (+ StateUpdate)      (+ StateUpdate)
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * ----------------------------------------------------------------------------------------------------------------
     * 
     */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
