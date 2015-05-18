//
//	20150323 created by Kiryu & QRM(Takahiro Shibaki)
//
//	referenced
//	http://naichilab.blogspot.jp/2013/11/unityaudiomanager.html
//
//
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

// Please Use of Singleton
public class SoundEffect : Singleton<SoundEffect>
{
	//-------------------------------------------------------------
	// Member variable
	//-------------------------------------------------------------
	// error message
	private const string _SOUND_ERROR = "SoundEffectError -> ";
	private const string _MUSIC_NOT_FOUND = "music not found : ";

	// BGM&SE key/title
	public string HisWorld;
	public string Kamui;
	public string title_BGM;
	public string title_001;

	// Audio Component
	private AudioSource _audio_source_bgm;
	private AudioSource _audio_source_se;
	private Dictionary< string, AudioClip > _audio_clips = new Dictionary< string, AudioClip >();
	
	//-------------------------------------------------------------
	// Unity's Function
	//-------------------------------------------------------------
	// Awake for Initialization
	public void Awake()
	{
		if( this != Instance )
		{
			Destroy( this );
			return;
		}

		_audio_source_bgm = gameObject.AddComponent<AudioSource>();
		_audio_source_bgm.loop = true;

		_audio_source_se = gameObject.AddComponent<AudioSource>();

		try
		{
			_audio_clips.Add( HisWorld = "bgm/HisWorld",		( AudioClip )Resources.Load( HisWorld ) );
			_audio_clips.Add( Kamui = "bgm/Kamui",				( AudioClip )Resources.Load( Kamui ) );
			_audio_clips.Add( title_BGM = "",					( AudioClip )Resources.Load( title_BGM ) );
			_audio_clips.Add( title_001 = "se/meka_ka_type02",	( AudioClip )Resources.Load( title_001 ) );
		}
		catch( ArgumentException e )
		{
			// May already exists same key
			Debug.Log( _SOUND_ERROR + e.Message );
		}
		catch( Exception e )
		{
			Debug.Log( _SOUND_ERROR + e.Message );
		}
	}

	//-------------------------------------------------------------
	// Function to SoundEffect Control
	//-------------------------------------------------------------
	// bgm loop play
	public void PlayBGM( string key )
	{
		if( _audio_clips[ key ] != null )
		{
			_audio_source_bgm.clip = _audio_clips[ key ];
			_audio_source_bgm.Play();
		}
		else
		{
			Debug.Log( _SOUND_ERROR + _MUSIC_NOT_FOUND + key );
		}
	}

	// SE oneshot play
	public void PlaySE( string key )
	{
		if( _audio_clips[ key ] != null )
		{
			_audio_source_se.PlayOneShot( _audio_clips[ key ] );
		}
		else
		{
			Debug.Log( _SOUND_ERROR + _MUSIC_NOT_FOUND + key );
		}
	}

	public void StopBGM()
	{
		_audio_source_bgm.Stop();
	}

	public void StopSE()
	{
		_audio_source_se.Stop();
	}
}
