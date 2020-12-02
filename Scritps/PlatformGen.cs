using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour {//สคริปนี้จะทำให้เกิดการspawn object ที่ใส่ไว้ใน array ในรูปเเบบการสุ่มเเละความห่างกับความสูงของเเต่ละ object ที่Spawn นั้นเรากำหนดได้


	public Transform Gen;
	public float distancebetween;
	private float platformwidth;

	public float diswidthmin;
	public float diswidthmax;

	private int platfromselector;
	public GameObject[] theplatforms;
	private float[] platformwidths;



	private float minheight;
	public Transform maxheightpoint;
	private float maxheight;
	public float maxheightchange;
	private float heightchange;





	void Start () {
		

		platformwidths = new float[theplatforms.Length];
		for(int i = 0;i < theplatforms.Length;i++)
		{
			platformwidths[i] = theplatforms[i].GetComponent<BoxCollider2D> ().size.x;
		}
		minheight = transform.position.y;
		maxheight = maxheightpoint.position.y; 

	}
	

	void Update () {
		if(transform.position.x < Gen.position.x)
		{

			distancebetween = Random.Range (diswidthmin,diswidthmax);// สุ่มความห่างใกล้สุดเเละไกลสุดตามที่เรากำหนด
			platfromselector = Random.Range (0, theplatforms.Length);//สุ่มลำดับ object ที่อยู่ใน array

			heightchange = transform.position.y + Random.Range (maxheightchange, -maxheightchange);//สุ่มความสูงต่ำของ object

			if (heightchange > maxheight) 
			{
			
				heightchange = maxheight;
			}
			else if (heightchange < minheight)

			{
				heightchange = minheight;
			}

			transform.position = new Vector3 (transform.position.x + platformwidths[platfromselector] + distancebetween, heightchange, transform.position.z);


		
			Instantiate (theplatforms[platfromselector], transform.position, transform.rotation);//สปอนด์ object ที่สุ่มออกมาตามตำเเหน่ง

		}
	}
}
