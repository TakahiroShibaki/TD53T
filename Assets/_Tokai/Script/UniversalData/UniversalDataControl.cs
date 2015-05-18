//
//	20150402 created by Kiryu & QRM(Takahiro Shibaki)
//	
//	CAUTION! : Do not call Universal Scene twice. 
//	CAUTION! : Do not use Awake() in Universal Scene.
//	CAUTION! : Please call this class's Update() before any other.
//
using UnityEngine;

public class UniversalDataControl : MonoBehaviour
{
	//------------------------------------------------
	// Unity's Function
	//------------------------------------------------
	// Use this for initialization
	void Awake()
	{
		Application.targetFrameRate = 60;
	}

	void Start()
	{
		DontDestroyOnLoad( this );
		SceneChanger.Instance.LockToChange( 0 );
		SceneChanger.Instance.Change( 1 );
	}

	// Update is called once per frame
	void Update()
	{
		KeyInput.Instance.UpdateFromUniversal();
		ScoreData.Instance.UpdateFromUniversal();
		if( KeyInput.Instance.ESC != false )
		{
			Debug.Log( "GameEnd" );
			Application.Quit();
		}
	}
}
