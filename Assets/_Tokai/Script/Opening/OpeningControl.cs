//
//	20150406 created by Kiryu & QRM(Takahiro Shibaki)
//
//
using UnityEngine;
using System.Collections;

public class OpeningControl : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		SoundEffect.Instance.PlayBGM( SoundEffect.Instance.Kamui );
	}
	
	// Update is called once per frame
	void Update()
	{
		if( KeyInput.Instance.SPACE != false )
		{
			SceneChanger.Instance.Change( 3 );
		}
	}
}
