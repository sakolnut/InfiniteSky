using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour {//ถ้าจุดทำลายที่กำหนดผ่านobject ใดๆที่มีสคริปนี้จะถูกทำลายทันที

	public GameObject Destroyer;
	void Start () {
		Destroyer = GameObject.Find ("PlatformDestroynaja");
	}
	

	void Update () {

		if(transform.position.x < Destroyer.transform.position.x) 
		{
			Destroy (gameObject);
		
		}
	}
}
