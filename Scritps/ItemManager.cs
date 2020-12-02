using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {//สคริปนี้จะทำให้เราสามารถเก็บเหรียญเพื่อรับคะเเนนเพิ่มเติมได้


	public int scoretogive;
	private ScoreManager thescoremanager;

	private AudioSource coinsound;

	void Start () {
		thescoremanager = FindObjectOfType <ScoreManager> ();
		coinsound = GameObject.Find ("Coin").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") //หากชนกับ object ที่ชื่อว่า Player จะทำให้ ตัวเองหายไปเเละเกิดเสียงที่กำหนดพร้อมให้คะเเนน
		{
		
			thescoremanager.Addscore (scoretogive);
			gameObject.SetActive (false);
			if (coinsound.isPlaying) {

				coinsound.Stop ();
				coinsound.Play ();
			} 

			else
			{
				coinsound.Play ();
			}

		}
	}
}
