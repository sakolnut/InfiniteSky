using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class PauseMenu : MonoBehaviour {

	public string scenename;
	string GooglePlay_ID = "3921647";
	bool GameMode = true;
	public GameObject pausemenu;

    void Start()
    {
		Advertisement.Initialize(GooglePlay_ID,GameMode); 
    }
    public void Pausegame()
	{
		Time.timeScale = 0f;
		pausemenu.SetActive (true);
		Advertisement.Show();

	}//หยุดเวลาเเละทำให้เมนูปรากฏ


	public void Resumegame()
	{
		Time.timeScale = 1f;
		pausemenu.SetActive (false);

	}//ทำให้เวลาเดินเหมือนเดิมเเละทำให้เมนูหายไป

	public void RestartGame()

	{
		Time.timeScale = 1f;
		FindObjectOfType<GameManager> ().Reset ();
		pausemenu.SetActive (false);
	}//ทำให้เวลาเดินเหมือนเดิมเเละทำให้เมนูหายไปเเละเริ่มเกมใหม่

	public void QuitToMain()

	{
		Time.timeScale = 1f;
		Application.LoadLevel (scenename);
	}//ไปยังซีนที่กำหนด
}
