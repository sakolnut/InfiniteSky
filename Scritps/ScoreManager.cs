using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {//สคริปนี้จะทำให้สามารถเก็บคะเเนนระหว่างเล่นได้เเละเซฟคะเเนนสูงสุดได้อีกด้วย

	public Text scoretext;
	public Text highscoretext;

	public float scorecount;
	public float highscorecount;

	public float pointspersecond;

	public bool scoreincrese;


	void Start () {

		if (PlayerPrefs.HasKey("HighScore")) {

			highscorecount = PlayerPrefs.GetFloat ("HighScore");
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (scoreincrese) {

			scorecount += pointspersecond * Time.deltaTime;
		
		}//ทำให้คะเเนนเพิ่มขึ้นเรื่อยๆระหว่างเล่นเกม



		if (scorecount > highscorecount) {
		
			highscorecount = scorecount;
			PlayerPrefs.SetFloat ("HighScore", highscorecount);
		}

		scoretext.text = "Score: " + Mathf.Round(scorecount); //เเสดงผลคะเเนนไปที่ text ที่กำหนด
		highscoretext.text = "High Score: " + Mathf.Round(highscorecount);//เเสดงผลคะเเนนสูงสุดไปที่ text ที่กำหนด
	

	}

	public void Addscore(int pointstoadd)

	{

		scorecount += pointstoadd;
	}//ได้รับคะเเนนจากการเก็บเหรียญ
}
