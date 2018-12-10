
/***
 * 测试脚本，创建出UI  ,场景
 */

 
using GameFramework.Fsm;
using GameFramework.Procedure; 
using UnityGameFramework.Runtime;

public class First : ProcedureBase 
{
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        //UIComponent UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();
        //UI.OpenUIForm("Assets/Prefab/UI_Menu.prefab", "UIFirst"); 

        SceneComponent scene = GameEntry.GetComponent<SceneComponent>();
        // 加载游戏场景
        scene.LoadScene("Main", this);
    }
}
