using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

	public float maxSpeed = 10;
	public float minSpeed = 5;
	private SpriteRenderer render;
	public Sprite hurt;
	public GameObject boom;
	public GameObject Score;

	public bool isPig;

	private void Awake()
  
	{
		render = GetComponent<SpriteRenderer>();
	}
	private void OnCollisionEnter2D(Collision2D collision)
		
	{
		Debug.Log(collision.relativeVelocity.magnitude);
		if(collision.relativeVelocity.magnitude>maxSpeed)
		{
			Dead();
		}
		else if(collision.relativeVelocity.magnitude>minSpeed&& collision.relativeVelocity.magnitude<maxSpeed)
		{
			render.sprite = hurt;
		}
	}
	void Dead()
	{   
		if(isPig)
		{
			GameManager._instance.pig.Remove(this);
		}
		Destroy(gameObject);
		Instantiate(boom, transform.position, Quaternion.identity);
		Instantiate(Score, transform.position+new Vector3(0,0.7f,0), Quaternion.identity);
	}

}
