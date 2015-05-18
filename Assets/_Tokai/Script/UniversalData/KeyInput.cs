//
//	20150406 created by Kiryu & QRM(Takahiro Shibaki)
//
//
using UnityEngine;

public class KeyInput : Singleton<KeyInput>
{
	//------------------------------------------------
	// Unity's Function
	//------------------------------------------------
	// Use this for initialization
	void Awake()
	{
		if( this != Instance )
		{
			Destroy( this );
			return;
		}
	}
	
	// Update is called once per frame
	void Update(){}


	//------------------------------------------------
	// Universal Data Update
	//------------------------------------------------
	public void UpdateFromUniversal()
	{
		UP = Input.GetKeyDown( KeyCode.UpArrow );
		DOWN = Input.GetKeyDown( KeyCode.DownArrow );
		LEFT = Input.GetKeyDown( KeyCode.LeftArrow );
		RIGHT = Input.GetKeyDown( KeyCode.RightArrow );

		Z = Input.GetKeyDown( KeyCode.Z );
		X = Input.GetKeyDown( KeyCode.X );
		S = Input.GetKeyDown( KeyCode.S );
		D = Input.GetKeyDown( KeyCode.D );
		W = Input.GetKeyDown( KeyCode.W );
		A = Input.GetKeyDown( KeyCode.A );
		R = Input.GetKeyDown( KeyCode.R );
		E = Input.GetKeyDown( KeyCode.E );
		Q = Input.GetKeyDown( KeyCode.Q );

		ESC = Input.GetKeyDown( KeyCode.Escape );
		RETURN = Input.GetKeyDown( KeyCode.Return );
		SPACE = Input.GetKeyDown( KeyCode.Space );

		L_SHIFT = Input.GetKeyDown( KeyCode.LeftShift );
		R_SHIFT = Input.GetKeyDown( KeyCode.RightShift );


		UP_KEEP = Input.GetKey( KeyCode.UpArrow );
		DOWN_KEEP = Input.GetKey( KeyCode.DownArrow );
		LEFT_KEEP = Input.GetKey( KeyCode.LeftArrow );
		RIGHT_KEEP = Input.GetKey( KeyCode.RightArrow );

		L_SHIFT_KEEP = Input.GetKey( KeyCode.LeftShift );
	}

	//------------------------------------------------
	// KEY VALUE
	//------------------------------------------------
	public bool UP;
	public bool DOWN;
	public bool LEFT;
	public bool RIGHT;
	public bool X;
	public bool Z;
	public bool A;
	public bool S;
	public bool W;
	public bool D;
	public bool Q;
	public bool E;
	public bool R;
	public bool SPACE;
	public bool RETURN;
	public bool ESC;
	public bool L_SHIFT;
	public bool R_SHIFT;

	public bool UP_KEEP;
	public bool DOWN_KEEP;
	public bool LEFT_KEEP;
	public bool RIGHT_KEEP;

	public bool L_SHIFT_KEEP;
}
