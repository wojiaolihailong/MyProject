
/***
 * 不删除界面流程转换到跳转到登录流程
  *   
 */


using System.Collections;
using System.Collections.Generic;
 
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

public class ProcedureLoading : ProcedureBase 
{
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        //UIComponent UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();
        //UI.OpenUIForm("Assets/Prefab/UI/Loading.prefab", "UIFirst");//注意路径要写清楚 
    }  
}
