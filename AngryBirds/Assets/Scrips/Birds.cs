using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour {

	bool isClick = false;
	public Transform rightPos;
	public Transform leftPos;
	public float maxDis = 3;
	[HideInInspector]
	public SpringJoint2D sp;
	Rigidbody2D rp;
	public LineRenderer right;
	public LineRenderer left;

	public GameObject boom;
	private TestMyTrail myTrail;
	private void Awake()

	{
		sp = GetComponent<SpringJoint2D>();
		rp = GetComponent<Rigidbody2D>();
		myTrail = GetComponent<TestMyTrail>();
	}
	private void OnMouseDown()
	{
		isClick = true;
		rp.isKinematic = true;
		
	}
	private void OnMouseUp()
	{
		isClick = false;
		
		rp.isKinematic = false;
		Invoke("Fly", 0.15f);
		right.enabled = false;
		left.enabled = false;
		
	}
	private void Update()
	{
		if (isClick)
		{
			transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);

			if (Vector3.Distance(transform.position, rightPos.position) > maxDis)
			{
				Vector3 Pos = (transform.position - rightPos.position).normalized;
				Pos *= maxDis;
				transform.position = Pos + rightPos.position;
			}
			Line();
		}
	}
	void Fly()
	{
		sp.enabled = false;
		Invoke("Next", 5);
		myTrail.TailStart();
	}
	void Line()
	{
		right.enabled = true;
		left.enabled = true;

		right.SetPosition(0, rightPos.position);
		right.SetPosition(1, transform.position);

		left.SetPosition(0, leftPos.position);
		left.SetPosition(1, transform.position);
	}
	void Next()
	{
		GameManager._instance.birds.Remove(this);
		Destroy(gameObject);
		Instantiate(boom, transform.position, Quaternion.identity);
		GameManager._instance.NextBird();
	}
	private void OnCollisionEnter(Collision collision)
	{
		myTrail.ClearTrail();
	}
}
