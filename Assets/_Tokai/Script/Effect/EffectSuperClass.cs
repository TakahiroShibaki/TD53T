//
//	20150421 created by Kiryu & QRM(Takahiro Shibaki)
//	
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EffectSuperClass : MonoBehaviour
{
	void OnAnimationFinish()
	{
		Destroy( gameObject );
	}
}

