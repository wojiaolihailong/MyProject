
/***
 *  启动软件,跳转到登录场景 *   
 */


using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class ProcedureLaunch : ProcedureBase 
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        GameFrameworkLog.Info("开始");  

        SceneComponent scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();

        // 切换场景
        procedureOwner.SetData<VarString>("NextSceneName", "Loading"); 
        // 切换流程
        ChangeState<ProcedureLoading>(procedureOwner);
    }
}
