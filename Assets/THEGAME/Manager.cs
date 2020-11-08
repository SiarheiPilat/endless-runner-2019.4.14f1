using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
	
	public GameObject[] Deactivatables;
	
	[Header("Set manually: 1 for tiger, 0 for elephant")]
	public bool AssignIndex;
	public int AnimalIndex;
	
	void Awake()
	{
		//Screen.fullScreen = !Screen.fullScreen;
		Screen.SetResolution(562, 1218, false);
	}
	
	void Start()
	{
		if(AssignIndex)
			PlayerPrefs.SetInt("animal", AnimalIndex);
		
		Debug.Log("current animal:" + PlayerPrefs.GetInt("animal").ToString());
	}
	
	public void Pause()
	{
		Time.timeScale = 0.0f;
		for (int i = 0; i < Deactivatables.Length; i++) {
			Deactivatables[i].SetActive(false);
		}
	}
	public void Resume()
	{
		Time.timeScale = 1.0f;
		for (int i = 0; i < Deactivatables.Length; i++) {
			Deactivatables[i].SetActive(true);
		}
	}
	public void LoadLevel(string name)
	{
		SceneManager.LoadScene(name);
	}
	
	public GameObject Tiger, Elephant;
	
	public void NextPlayer()
	{
		if(Tiger.activeSelf)
		{
			Tiger.SetActive(false);
			Elephant.SetActive(true);
		}else
		{
			Tiger.SetActive(true);
			Elephant.SetActive(false);
		}
	}
	
	public void PlayLevel()
	{
		if(Tiger.activeSelf)
		{
			PlayerPrefs.SetInt("animal", 1); // tiger
			LoadLevel("1-game-tiger");
		}else
		{
			PlayerPrefs.SetInt("animal", 0); // elephant
			LoadLevel("1-game-elephant");
		}
	}
	
	public void PlayLevelAgain()
	{
		if(PlayerPrefs.GetInt("animal") == 1)
		{
			// tiger
			LoadLevel("1-game-tiger");
		}
		if(PlayerPrefs.GetInt("animal") == 0)
		{
			// elephant
			LoadLevel("1-game-elephant");
		}
	}
}
