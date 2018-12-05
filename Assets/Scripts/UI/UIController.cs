using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

public class UIController : MonoBehaviour {

	 
	void Start ()
    {
		this.GetComponent<Button>().onClick.AddListener(() =>
		{
		    UIComponent UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();

		    UI.OpenUIForm("Assets/Prefab/UI_Menu 1.prefab", "UIFirst");
		     
		});
	}
	
	 
}
