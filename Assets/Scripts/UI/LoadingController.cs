
/***
 * 登录界面控制脚本
 */

using GameFramework.Fsm;

using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Event;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

#region 修改的数据
public class Form
{
    public string Name { set; get; }
    public int Age { set; get; }

    public Form(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}


#endregion



public class LoadingController : UguiForm
{

    public InputField _NameInp;
    public InputField _PasswordInp;
    public Button _OkButton;
    public Button _setting;

    private void Awake()
    {
        UIComponent UI = GameEntry.GetComponent<UIComponent>();


        _OkButton.onClick.AddListener(() =>
        {
            Get();//请求服务器认证
        });

        _setting.onClick.AddListener(() =>
        {
            UI.OpenUIForm("","");
        });


    }

    #region 填用户名密码请求认证

    protected void Get()
    {
        EventComponent EventComment = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
        WebRequestComponent webRequest = UnityGameFramework.Runtime.GameEntry.GetComponent<WebRequestComponent>();
        EventComment.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);//成功返回数据
        EventComment.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestFailure);//失败返回数据  

        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("username", _NameInp.text);
        wwwForm.AddField("password", _PasswordInp.text);
        string uri = "http://117.78.60.124:8081/security/login";//请求数据地址
        webRequest.AddWebRequest(uri, wwwForm);
    }

    #endregion

    #region 请求后返回事件

    /// <summary>
    /// 请求成功后返回的数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnWebRequestSuccess(object sender, GameEventArgs e)
    {
        WebRequestSuccessEventArgs ne = (WebRequestSuccessEventArgs)e;
        // 获取回应的数据
        string responseJson = Utility.Converter.GetString(ne.GetWebResponseBytes());

        Log.Debug("responseJson：" + responseJson);

        EnterMain();
    }

    /// <summary>
    /// 请求失败返回的数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnWebRequestFailure(object sender, GameEventArgs e)
    {
        Log.Warning("请求失败");
    }
    #endregion

    #region 跳转场景 
    /// <summary>
    /// 跳转场景到主场景
    /// </summary>
    protected void EnterMain()
    {
        // 获取框架场景组件
        SceneComponent scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();
        // 卸载所有场景
        string[] loadedSceneAssetNames = scene.GetLoadedSceneAssetNames();
        for (int i = 0; i < loadedSceneAssetNames.Length; i++)
        {
            scene.UnloadScene(loadedSceneAssetNames[i]);
        }
        // 加载游戏场景
        scene.LoadScene("Assets/Scenes/Main.unity", this);
    }
    #endregion

}
