
/***
 * 
 
 *   
 */


using System.Collections;
using System.Collections.Generic;
using GameFramework;
using UnityEngine;


public class Show
{
    public string Name;
    public int Age { set; get; } 
    public Show(string name, int age)
    {
        Name = name;
        Age = age;
    }
}



public class Test : MonoBehaviour 
{

	
	void Start ()
	{
		Show s1=new Show("lhl",1);
       
	} 
}
