using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JustDestoryByTime: MonoBehaviour
{
	public float lifeTime;

	void Start()
	{
		Destroy(gameObject, lifeTime);
	}
}
	


