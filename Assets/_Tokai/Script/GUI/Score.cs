//
//	20150406 created by Kiryu & QRM(Takahiro Shibaki)
//
//
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
	private GameObject _canvas_UI;

	// GUI
	private Text _timeGUIText;
	private Text _scoreGUIText;

	//-------------------------------------------------------------
	// Unity's Function
	//-------------------------------------------------------------
	// Use this for initialization
	void Awake()
	{
		_canvas_UI = GameObject.Find( "Canvas_UI" );
		_canvas_UI.GetComponent<Canvas>().enabled = true;
		
		if( _timeGUIText == null )
		{
			GameObject gui = GameObject.Find( "TimeText" );
			_timeGUIText = gui.GetComponent<Text>();
		}
		
		if( _scoreGUIText == null )
		{
			GameObject gui = GameObject.Find( "ScoreText" );
			_scoreGUIText = gui.GetComponent<Text>();
		}
	}

	void Start()
	{
		ScoreData.Instance.StartMeasureResult();
	}

	// Update is called once per frame
	void Update()
	{
		_timeGUIText.text = "経過時間 : " + ScoreData.Instance.GetPresentTime();
		_scoreGUIText.text = "獲得点数 : " + ScoreData.Instance.GetPresentScore();
	}
}
