using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {//สคริปนี้จะทำให้กล้องเเพลนไปตามผู้เล่นเเละรีกลับมาหากผู้เล่นตายหรือกดเริ่มใหม่
	public PlayerController Player;
	private Vector3 Playerlastpos; 
	private float distancemove;

	void Start () {
		Player = FindObjectOfType <PlayerController> ();
		Playerlastpos = Player.transform.position;
	}
	

	void Update () {
		distancemove = Player.transform.position.x - Playerlastpos.x;
		transform.position = new Vector3 (transform.position.x + distancemove, transform.position.y, transform.position.z);
		Playerlastpos = Player.transform.position;
	}
}
