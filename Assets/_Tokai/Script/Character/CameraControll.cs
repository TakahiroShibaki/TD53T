//
//	20150413 created by Kiryu & QRM(Takahiro Shibaki)
//
//
using UnityEngine;

public class CameraControll : MonoBehaviour
{
	private const string ERROR_MESSAGE = "[CameraControll] -> ";
	
	private Character2DDepthController _character;
	private Vector3 _temp_pos;
	private string _target = string.Empty;

	// Use this for initialization
	void Awake()
	{
		// TODO : Get targt object name!
		if( string.IsNullOrEmpty( _target ) != false )
		{
			Debug.Log( ERROR_MESSAGE + "Target is null or empty. Load default asset." ); 
			_target = "UnityChan2D_For3D";
		}
		_character = GameObject.Find( _target ).GetComponent<Character2DDepthController>();

		transform.rotation = Quaternion.Euler( 20, 0, 0 );
	}

	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		_temp_pos.x = _character.GetPosition().x;
		_temp_pos.y = _character.GetPosition().y + 5;
		_temp_pos.z = _character.GetPosition().z - 10;

		if( _temp_pos.y < 5 )
		{
			_temp_pos.y = 5;
		}

		transform.position = _temp_pos;
	}
}
