using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {

	public float movespeed;
	private float movespeedstore;
	public float speedmulti;
	private float speedmilestore;
	public float speedincrease;
	private float speedmilecount;
	public float jump;
	public float drag;
	private float speedincresestore;
	public float jumptime;
	private float jumptimecount;
	private Rigidbody2D rigibodynaja;
	private bool doublejump;
	private bool takehit;

	private Animator myanimator;

	public GameManager thegamemanager;

	public AudioSource jumpsound;
	public AudioSource deathsound;
	public AudioSource healsound;
	private int Healthnaja = 100;


	public Text Health;



	void Start () {
		rigibodynaja = GetComponent<Rigidbody2D> ();
		myanimator = GetComponent<Animator> ();
		jumptimecount = jumptime;
		speedmilecount = speedincrease;
		movespeedstore = movespeed;
		speedmilestore = speedmilecount;
		speedincresestore = speedincrease;
		}//เซทตัวเเปรต่างๆให้พร้อมใช้งาน
	

	void Update () {


	

		if (transform.position.x > speedmilecount) 
		{
			speedmilecount += speedincrease;

			speedincrease = speedincrease * speedmulti;
			movespeed = movespeed * speedmulti;
			
		}//ทำให้ความเร็วเพิ่มขึ้นเรื่อยตามค่าที่เรากำหนด

		rigibodynaja.velocity = new Vector2 (movespeed, rigibodynaja.velocity.y);//ทำให้ตัวละครเคลื่อนที่ไปตามเเนวเเกน x ด้วยความเร็วที่กำหนดไว้

		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) {//ทำให้สามารถกด Space หรือ คลิ๊กเมาท์ซ้าย เพื่อบังคับได้
			
			rigibodynaja.velocity = new Vector2 (rigibodynaja.velocity.x, jump);
			rigibodynaja.AddForce (transform.up * jump);
			rigibodynaja.drag = drag;
			doublejump = true;

			jumpsound.Play ();
		} 
		else if (!Input.GetKey  (KeyCode.Space) || Input.GetMouseButton  (0)) 
		{
			doublejump = false;
		}
		if (Healthnaja <= 0)//ถ้าเลือดเหลือ0หรือน้อยกว่า
		{
			Healthnaja = 100;

			thegamemanager.RestartGame ();
			movespeed = movespeedstore;
			speedmilecount = speedmilestore;
			speedincrease = speedincresestore;
			deathsound.Play ();
			}//ให้เซตเลือดกลับไปเป็น 100 เเละเริ่มด่านใหม่อีกครั้งพร้อมเปิดเสียงที่กำหนดไว้
		if(Healthnaja > 100)//ถ้าเลือดมากกว่า 100
		{

			Healthnaja = 100;

		}//เซ็ตเลือดให้เป็น100


		myanimator.SetFloat ("Speed", rigibodynaja.velocity.x);//เชื่อมกับอนิเมเตอร์
		myanimator.SetBool ("TakeHit",takehit);
		myanimator.SetBool ("Doublejump", doublejump);//เชื่อมกับอนิเมเตอร
		Health.text = " HP: " + Mathf.Round(Healthnaja)+ "%"; //เเสดงผลไปยัง text ที่กำหนด
		if(takehit == true)
		{
			takehit = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other)//ฟังชั่นการชนต่อวัตถุต่างๆ
	{
		
		 if (other.gameObject.tag == "Monster") { //ถ้าชนกับวัตถุใดๆที่มี tag Monster
			Healthnaja = Healthnaja - 10;
			takehit = true;
			deathsound.Play ();
			Destroy (other.gameObject);
		}//เลือดลด 10 หน่วย เเละทำลายออปเจ็คนั้นทิ้งเเละเล่นเสียงที่กำหนด

		else if (other.gameObject.tag == "Monster2") { //ถ้าชนกับวัตถุใดๆที่มี tag Monster2
			Healthnaja = Healthnaja - 5;
			deathsound.Play ();
			Destroy (other.gameObject);
		}//เลือดลด 5 หน่วย เเละทำลายออปเจ็คนั้นทิ้งเเละเล่นเสียงที่กำหนด
	
		else if (other.gameObject.tag == "heal") 
		{ //ถ้าชนกับวัตถุใดๆที่มี tag heal
			Healthnaja = Healthnaja + 10;
			healsound.Play ();
			Destroy (other.gameObject);		
		}//เลือดเพิ่ม 10 หน่วย เเละทำลายออปเจ็คนั้นทิ้งเเละเล่นเสียงที่กำหนด
	}

}


