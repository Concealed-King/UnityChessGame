using UnityEngine;
using System.Collections;

public class MakeHugoHappy : MonoBehaviour 
{
	public GameObject winScreen;

	void OnTriggerEnter(Collider other)
	{
		winScreen.SetActive(true);
	}
}
