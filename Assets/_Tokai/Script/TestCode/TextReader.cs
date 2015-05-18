// it is code of test to read txt. 

using UnityEngine;

public class TextReader : MonoBehaviour
{
	private const string RESOURCE_SUB_DIR = "TextFile/";
	private string _target_map = string.Empty;
	private TextAsset _text_asset;
	
	// Use this for initialization
	void Awake()
	{
	}
	
	void Start()
	{
		if( string.IsNullOrEmpty( _target_map ) != false )
		{
			_target_map = "Sample";
		}
		_text_asset = Resources.Load( RESOURCE_SUB_DIR + _target_map ) as TextAsset;
		Debug.Log( _text_asset.text );
	}
	
	// Update is called once per frame
	void Update()
	{
	}
	
	public void SetTarget( string target )
	{
		_target_map = target;
	}
}
