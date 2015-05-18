//
//	20150412 created by Kiryu & QRM(Takahiro Shibaki)
//
//	Set Unity's camera aspect.
//	But it is not completed code.
//
using UnityEngine;
using System.Collections;

public class FixedAspectRatio : MonoBehaviour
{
	private const int _width = 1024;
	private const int _height = 768;
	public float _aspect = 0.0f;

	// Use this for initialization
	void Start()
	{
		_aspect = _width / _height;
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
