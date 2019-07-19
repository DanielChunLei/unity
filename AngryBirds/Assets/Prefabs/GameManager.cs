using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public List<Birds> birds;
	public List<Pig> pig;
	public static GameManager _instance;
	private Vector3 originPos;
	private void Awake()
	{
		_instance = this;
		if (birds.Count > 0)
		{
			originPos = birds[0].transform.position;
		}
	}
	private void Start()
	{
		Intialized();
	}

	/// <summary>
	/// 初始化小鸟
	/// </summary>
	private void Intialized()
	{
		for (int i = 0; i < birds.Count; i++)
		{
			if (i == 0)///第一只小鸟
			{
				birds[0].gameObject.transform .position= originPos;
				birds[i].enabled = true;
				birds[i].sp.enabled = true;
			}
			else
			{
				birds[i].enabled = false;
				birds[i].sp.enabled = false;

			}
		}

	}
      public void NextBird()
	{
		if (pig.Count > 0)
		{

			if (birds.Count > 0)
			{
				Intialized();//下一只飞
			}
			else
			{
				//输了
			}

		}
		else
		{
			//胜利
		}
    }
}
