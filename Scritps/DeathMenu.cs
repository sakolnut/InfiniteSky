using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;

	public void RestartGame()

	{

		FindObjectOfType<GameManager> ().Reset ();
	}// เรียกหาฟังชั่น Reset จาก GameManager 

	public void QuitToMain()

	{

		Application.LoadLevel (mainMenuLevel);
	}// ไปซีนที่กำหนดไว้
}
