using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
	public GameObject CongratsText;
	public GameObject[] Deactivateable;
	
	void Start()
	{
		CongratsText.SetActive(false);
	}
	
	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "Player")
		{
			Debug.Log("Finished");
			CongratsText.SetActive(true);
			Invoke	("LoadMenu", 3.5f);
			for (int i = 0; i < Deactivateable.Length; i++) 
			{
				Deactivateable[i].SetActive(false);
			}
		}
	}
	
	void LoadMenu()
	{
		SceneManager.LoadScene(0);
	}
}
