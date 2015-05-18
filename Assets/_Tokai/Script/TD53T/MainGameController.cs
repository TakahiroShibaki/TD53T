//
//	20150323 created by Kiryu & QRM(Takahiro Shibaki)
//
//
using UnityEngine;

public class MainGameController : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		SoundEffect.Instance.PlayBGM( SoundEffect.Instance.HisWorld );
	}
	
	// Update is called once per frame
	void Update()
	{
	}
}
