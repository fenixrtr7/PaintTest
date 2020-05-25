using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBall : MonoBehaviour {

	public static ManagerBall instance;

	public List<GameObject> listBalls = new List<GameObject>();


	// Use this for initialization
	void Start () {
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
