//
//	20150414 reated by Kiryu & QRM(Takahiro Shibaki)
//
//	referenced
//	http://www.xxxxx13.com/unity_draque_CSV.html
//
using UnityEngine;
using System;
using System.Collections;

public class EnemyGenerator : MonoBehaviour
{
	private const string RESOURCE_SUB_DIR = "MapData/";
	public string[] _array_data;

	void Awake()
	{
		ReadMap( RESOURCE_SUB_DIR + "SampleCsv" );
	}

	void Update()
	{
	}

	public void GenerateEnemy( float x )
	{
	}

	public IEnumerator ReadMap( string target )
	{
		// Load File
		TextAsset asset = (TextAsset)Instantiate( Resources.Load( target ) );
		yield return null;

		_array_data = asset.text.Split( new string[]{ ",", "\n" }, StringSplitOptions.RemoveEmptyEntries );
		foreach( string str in _array_data )
		{
			Debug.Log( str );
		}
	}
}