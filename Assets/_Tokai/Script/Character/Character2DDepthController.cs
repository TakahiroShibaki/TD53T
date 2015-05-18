//
//	20150412 created by Kiryu & QRM(Takahiro Shibaki)
//
//	This is Super class.
//
using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Animator ), typeof( Rigidbody ), typeof( BoxCollider ) )]
public class Character2DDepthController : MonoBehaviour
{
	// character speed
	private float _speed = 0.2f;
	private float _jumpPower = 1000f;

	// character position
	private Vector3 _temp_pos;

	// Unity's
	private Animator	_animator;
	private Rigidbody	_rigidbody;

	// wall & Ground
	private const float _raycast_length = 1.7f;
	protected bool _is_ground = false;
	private float _wall_z = 0.0f;
	private float _wall_z_depth = 5.0f;

	// move force
	protected int _move_x = 0;
	protected int _move_z = 0;
	protected const float _gravity = -50.0f;

	// Animator's param
	private float _face = -1.0f;

	// Animetion of Action
	private ActionState _actionstate = ActionState.Normal;
	enum ActionState
	{
		Normal,
		Damaged,
		Invincible,
	}

	//---------------------------------------------------------------------
	// Unity's Function
	//---------------------------------------------------------------------
	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_rigidbody = GetComponent<Rigidbody>();

		Physics.gravity = new Vector3( 0, _gravity, 0 );
	}
	
	private void Update()
	{
		BaseUpdate();
	}

	protected void BaseUpdate()
	{
		_is_ground = Physics.Raycast( transform.position, transform.TransformDirection( Vector3.down ), _raycast_length );
		if( _actionstate != ActionState.Damaged )
		{
			Move();
		}
	}

	IEnumerator INTERNAL_OnDamage()
	{
		_animator.Play( _is_ground ? "Damage" : "AirDamage" );
		_animator.Play( "Idle" );

		SendMessage( "OnDamage", SendMessageOptions.DontRequireReceiver );
		yield return new WaitForSeconds( .2f );
		while( _is_ground == false )
		{
			yield return new WaitForFixedUpdate();
		}
		_animator.SetTrigger( "Invincible Mode" );
		_actionstate = ActionState.Invincible;
	}
	
	void OnFinishedInvincibleMode()
	{
		_actionstate = ActionState.Normal;
	}

	protected void Move()
	{
		// move X Z
		_move_x = 0;
		_move_z = 0;
		if( KeyInput.Instance.UP_KEEP != false ){ _move_z += 1; }
		if( KeyInput.Instance.DOWN_KEEP != false ){ _move_z -= 1; }
		if( KeyInput.Instance.LEFT_KEEP != false ){ _move_x -= 1;}
		if( KeyInput.Instance.RIGHT_KEEP != false ){ _move_x += 1; }

		// Speed up
		if( KeyInput.Instance.L_SHIFT_KEEP != false )
		{
			_move_x += _move_x;
			_move_z += _move_z;
			_animator.speed = 2.0f;
		}
		else
		{
			_animator.speed = 1.0f;
		}

		_face = _move_x > 0 ? -1 : ( _move_x < 0 ? 1 : _face );
		transform.rotation = Quaternion.Euler( 0, ( _face + 1 ) * 90, transform.rotation.z );

		_temp_pos = transform.position;
		_temp_pos.x = _temp_pos.x + _move_x * _speed;
		_temp_pos.z = _temp_pos.z + _move_z * _speed;
		if( _temp_pos.z > _wall_z_depth )
		{
			_temp_pos.z = _wall_z_depth;
		}
		else if( _temp_pos.z < _wall_z )
		{
			_temp_pos.z = _wall_z;
		}
		transform.position = _temp_pos;

		// Set Animation
		_animator.SetFloat( "Horizontal", _move_x != 0 ? _move_x : ( _move_z != 0 ? _face : 0) );
		_animator.SetFloat( "Vertical", _rigidbody.velocity.y );
		_animator.SetBool ( "isGround", _is_ground );

		// Jump
		if( _is_ground != false && KeyInput.Instance.S )
		{
			_animator.SetTrigger( "Jump" );
			_rigidbody.AddForce( Vector3.up * _jumpPower );
			_is_ground = false;
		}
	}

	public Vector3 GetPosition()
	{
		return transform.position;
	}
}
