using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform platformgenerator;
	private Vector3 platformstartpoint;

	public PlayerController Player;
	private Vector3 Playerstartpoint;

	private PlatformDestroy[] platformlist;

	private ScoreManager theScoreManager;

	public DeathMenu thedeathscreen;
	public PauseMenu unpause;

	void Start () {
		platformstartpoint = platformgenerator.position;
		Playerstartpoint = Player.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager> ();
	}//ประกาศเเละเซทตัวเเปรต่างๆให้พร้อมใช้งาน
	

	public void RestartGame()
	{

		theScoreManager.scoreincrese = false;
		Player.gameObject.SetActive (false);

		thedeathscreen.gameObject.SetActive (true);
		unpause.gameObject.SetActive (false);
	
	}//ทำให้คะเเนนหยุดเดินเเละเเสดงเมนูที่กำหนดเเละทำให้เมนูอันอื่นหายไป

	public void Reset() // ทำให้ค่าหลายอย่างรีเซทเเละดึงตัวละครมาจุดเริ่มต้นเพื่อเริ่มเล่นใหม่
	{
		thedeathscreen.gameObject.SetActive (false);
		unpause.gameObject.SetActive (true);
		platformlist = FindObjectsOfType<PlatformDestroy> ();
		for (int i = 0; i < platformlist.Length; i++) {

			platformlist [i].gameObject.SetActive (false);

		}
		Player.transform.position = Playerstartpoint; //ทำให้กลับไปอยู่ตำเเหน่งเริ่มต้น

		platformgenerator.position = platformstartpoint; // ทำให้จุด spawn กลับไปอยู่จุดเริ่มต้น
		Player.gameObject.SetActive (true);

		theScoreManager.scorecount = 0;
		theScoreManager.scoreincrese = true;

	}


}
