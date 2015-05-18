//
//	20150402 created by Kiryu & QRM(Takahiro Shibaki)
//
//
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SceneChanger : Singleton<SceneChanger>
{
	//-------------------------------------------------------------
	// Member variable
	//-------------------------------------------------------------
	// error message
	private const string _SCENE_CHANGE_ERROR = "SceneChanger Error -> ";

	private Dictionary<int, string> _scene = new Dictionary<int, string>();
	private List<int> _lock = new List<int>();

	// texture for fadeout
	private const float _CHANGE_INTERVAL = 1.0f;
	private Texture2D _black;
	private float _fade_alpha = 0.0f;
	private bool _is_fade = false;


	//-------------------------------------------------------------
	// Unity's Function
	//-------------------------------------------------------------
	// Use this for initialization
	void Awake()
	{
		if( this != Instance )
		{
			Destroy( this );
			return;
		}

		// create scene list
		_scene.Add( 0, "UniversalData" );
		_scene.Add( 1, "Opening" );
		_scene.Add( 2, "Setting" );
		_scene.Add( 3, "TokaiDo53Tugi" );

		// create fadeout texture
		_black = new Texture2D( 32, 32, TextureFormat.RGB24, false );
		_black.ReadPixels( new Rect( 0, 0, 32, 32 ), 0, 0, false );
		_black.SetPixel( 0, 0, Color.white );
		_black.Apply();
	}

	void Start(){}
	
	// Update is called once per frame
	void Update(){}

	void OnGUI()
	{
		if( _is_fade != false )
		{
			GUI.color = new Color( 0, 0, 0, _fade_alpha );
			GUI.DrawTexture( new Rect ( 0, 0, Screen.width, Screen.height ), _black );
		}
	}

	//-------------------------------------------------------------
	// Function to SceneChanger
	//-------------------------------------------------------------
	// SceneChange
	public void Change( int target )
	{
		if( _is_fade == false )
		{
			_is_fade = true;
			StartCoroutine( TranseScene( target ) );
		}
	}

	private IEnumerator TranseScene( int target )
	{
		float time = 0.0f;
		while( time <= _CHANGE_INTERVAL )
		{
			_fade_alpha = Mathf.Lerp( 0f, 1f, time / _CHANGE_INTERVAL );
			time += Time.deltaTime;
			yield return 0;
		}

		try
		{
			if( _lock.Contains( target ) == false )	// Check the target locked
			{
				Application.LoadLevel( _scene[target] );
			}
			else
			{
				Debug.Log( _SCENE_CHANGE_ERROR + "access to locked scene : " + _scene[target] );
			}
		}
		catch( Exception e )
		{
			Debug.Log( _SCENE_CHANGE_ERROR + e.Message );
		}

		time = 0;
		while( time <= _CHANGE_INTERVAL )
		{
			_fade_alpha = Mathf.Lerp( 1f, 0f, time / _CHANGE_INTERVAL );
			time += Time.deltaTime;
			yield return 0;
		}

		_is_fade = false;
	}

	// Lock SeceneChange
	public void LockToChange( int target )
	{
		_lock.Add( target );
	}
}
