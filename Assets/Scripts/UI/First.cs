
/***
 * 测试脚本，创建出UI  
 */


using System.Collections;
using System.Collections.Generic;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

public class First : ProcedureBase 
{
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        UIComponent UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();
        UI.OpenUIForm("Assets/Prefab/Image.prefab", "UIFirst"); 
    }
}
