
/***
 * 登录界面控制脚本
 */


using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;


public class Form
{
    public string Name { set; get; }
    public int Age { set; get; }

    public Form(string name,int age)
    {
        this.Name = name;
        this.Age = age;
    }
}


public class LoadingController : UguiForm 
{ 
    private void Awake()
    {  

    } 
    protected internal override void OnOpen(object userData)
    {
        base.OnOpen(userData);

        EventComponent EventComment = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
        WebRequestComponent webRequest = UnityGameFramework.Runtime.GameEntry.GetComponent<WebRequestComponent>();

        EventComment.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);//成功返回数据
        EventComment.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestFailure);//失败返回数据 


        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("username", "haoxuan");
        wwwForm.AddField("password", "123"); 

        string uri = "http://117.78.60.124:8081/security/login";//请求数据地址

        webRequest.AddWebRequest(uri, wwwForm); 
    }

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
     

        GameFrameworkLog.Debug("responseJson：" + responseJson);
    }

    /// <summary>
    /// 请求失败返回的数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnWebRequestFailure(object sender, GameEventArgs e)
    {
        GameFrameworkLog.Warning("请求失败");
    }
}
