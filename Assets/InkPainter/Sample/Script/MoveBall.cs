﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveBall : MonoBehaviour {

	float currentTime = 0;
	float currentTimeFall = 0;
	public float timeLimit = 2;
	public float timeLimitFall = 0.4f;
	public GameObject objectFall;

	int move = 1;

	// Use this for initialization
	void Start () {
		timeLimitFall = Random.Range(.9f, 2f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentTime += Time.deltaTime;
		currentTimeFall+= Time.deltaTime;

		if (currentTime >= timeLimit)
		{
			move *= -1;
			currentTime = 0;
		}

		transform.Translate(Vector3.left * Time.deltaTime * move);

		if (currentTimeFall >= timeLimitFall)
		{
			currentTimeFall = 0;
			if (!ManagerBall.instance.listBalls.Any())
			{
				GameObject objectClone = Instantiate(objectFall, this.transform);
			}
			else
			{
				ManagerBall.instance.listBalls[0].transform.position = this.transform.position;
				ManagerBall.instance.listBalls[0].GetComponent<Rigidbody>().useGravity = true;
				ManagerBall.instance.listBalls[0].SetActive(true);
			}
		}


		////////////////////////////////////////////////////////////

		// if (currentTime >= timeChange && !m_FacingRight)
		// 	{
        //         // Reset Time
        //         currentTime = 0;
        //         move = -move;
		// 		// ... flip the player.
		// 		Flip();
		// 	}
		// 	// Otherwise if the input is moving the player left and the player is facing right...
		// 	else if (currentTime >= timeChange && m_FacingRight)
		// 	{
        //         // Reset Time
        //         currentTime = 0;
        //         move = move * -1;

		// 		// ... flip the player.
		// 		Flip();
		// 	}
	}
}
