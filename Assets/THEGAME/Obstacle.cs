using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "Player")
		{
			Debug.Log("collided");
			SceneManager.LoadScene("2-game-over");
		}
	}
}
