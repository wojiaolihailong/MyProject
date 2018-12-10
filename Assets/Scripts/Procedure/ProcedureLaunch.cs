
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

        SceneComponent scene = GameEntry.GetComponent<SceneComponent>();




        //跳转场景
        scene.LoadScene("Assets/Scenes/Loading.unity", this);
        // 切换流程
       ChangeState<ProcedureLoading>(procedureOwner);
    }
}
