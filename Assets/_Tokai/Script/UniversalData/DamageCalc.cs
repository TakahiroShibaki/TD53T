//
//	20150406 created by Kiryu & QRM(Takahiro Shibaki)
//
//
using UnityEngine;
using System.Collections;

// Please Use of Singleton
public class DamageCalc : Singleton<DamageCalc>
{
	// error message
	private const string _DAMAGE_ERROR = "DamageCalcError -> ";

	// 
	private const int _SUPER_CRITICAL_POWER = 2;
	private const double _DEFENCER_POWER_DOWN = 0.8;

	// Use this for initialization
	public void Start(){}
	
	// Update is called once per frame
	public void Update(){}

	// 
	public void Awake()
	{
		if( this != Instance )
		{
			Destroy( this );
			return;
		}
	}

	public int Calc( int ATK, int DEF )
	{
		return ( int )( ATK - DEF * _DEFENCER_POWER_DOWN );
	}
}
