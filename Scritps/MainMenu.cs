using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {


	public string playgamelevel;

	public void Playgame()

	{
		Application.LoadLevel (playgamelevel);//ไปยังซีนที่กำหนด

	}


}
