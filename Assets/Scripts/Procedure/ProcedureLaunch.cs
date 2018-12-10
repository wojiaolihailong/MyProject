
/***
 *  启动软件时加载登录界面
 *   
 */


using System.Collections;
using System.Collections.Generic;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

public class ProcedureLaunch : ProcedureBase 
{
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        UIComponent UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();
        UI.OpenUIForm("Assets/Prefab/UI/Loading.prefab", "UIFirst");//注意路径要写清楚
    }
}
