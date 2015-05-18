//
//	20150402 created by Kiryu & QRM(Takahiro Shibaki)
//
//
using UnityEngine;
using System;
using System.Collections.Generic;

public struct ScoreAndTime
{
	public int		_score;
	public double	_time;
}

public class ScoreData : Singleton<ScoreData>
{
	//-------------------------------------------------------------
	// Member variable
	//-------------------------------------------------------------

	// error message
	private const string ERROR_OF_SCORE = "[Error of Score]";

	// const stage number
	private const int TOTAL = 0;

	// start stop
	private bool _started;

	// present result
	private ScoreAndTime _present_data;
	private Dictionary< int, ScoreAndTime > _result = new Dictionary<int, ScoreAndTime>();

	//-------------------------------------------------------------
	// Unity's Function
	//-------------------------------------------------------------
	void Awake()
	{
		if( this != Instance )
		{
			Destroy( this );
			return;
		}

		ResetScore();
	}

	void Start(){}

	void Update(){}

	//-------------------------------------------------------------
	// Universal Data Update
	//-------------------------------------------------------------
	public void UpdateFromUniversal()
	{
		if( _started != false )
		{
			_present_data._time += Time.deltaTime;
		}
	}

	//-------------------------------------------------------------
	// Function to control result
	//-------------------------------------------------------------

	private void AddStageResult( int stage )
	{
		AddStageResult( stage, 0, 0.0 );
	}
	private void AddStageResult( int stage, int score, double time )
	{
		try
		{
			ScoreAndTime temp;
			temp._score = score;
			temp._time = time;
			_result.Add( stage, temp );
		}
		catch( Exception e )
		{
			Debug.Log( ERROR_OF_SCORE + e.Message + "[AddStageResult]" );
		}
	}

	public void ResetScore()
	{
		_started = false;

		// reset temp result
		_result.Clear();
		AddStageResult( TOTAL );
	}

	// Call me at the same time of stage finish.
	public void ClosingResult( int stage )
	{
		_started = false;

		// stage
		AddStageResult( stage, _present_data._score, _present_data._time );
		
		// calc total
		ScoreAndTime temp = _result[TOTAL];
		temp._score += _present_data._score;
		temp._time += _present_data._time;
		_result[TOTAL] = temp;
	}

	// 
	public void StartMeasureResult()
	{
		_present_data._score = 0;
		_present_data._time = 0;

		// TODO : timer init

		_started = true;
	}

	// 
	public void AddScore( int val )
	{
		_present_data._score += val;
		if( _present_data._score < 0 )
		{
			_present_data._score = 0;
		}
	}

	// 
	public string GetPresentScore()
	{
		return _present_data._score.ToString();
	}

	// 
	public string GetPresentTime()
	{
		return _present_data._time.ToString();
	}


	//-------------------------------------------------------------
	// Function to control save data
	//-------------------------------------------------------------

	// Output File
	public void SaveScore()
	{
		// TODO : Save tha Savedata
	}

	// ScoreRanking
	public void LoadScoreList( int stage_number )
	{
		// TODO : Load the SaveData
	}
}
