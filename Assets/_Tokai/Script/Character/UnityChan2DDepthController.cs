//
//	20150430 created by Kiryu & QRM(Takahiro Shibaki)
//
//
using UnityEngine;

[RequireComponent( typeof( Animator ), typeof( Rigidbody ), typeof( BoxCollider ) )]
public class UnityChan2DDepthController : Character2DDepthController
{
	private void Update()
	{
		BaseUpdate();
	}
}
