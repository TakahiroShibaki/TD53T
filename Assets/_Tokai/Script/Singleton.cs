//
//	20150323 created by Kiryu & QRM(Takahiro Shibaki)
//
//	referenced
//	http://naichilab.blogspot.jp/2013/11/unityaudiomanager.html
//
//
using UnityEngine;

// Transrate into Singleton Pattern Class
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	public static T Instance
	{
		get
		{
			if( _instance == null )
			{
				_instance = ( T )FindObjectOfType( typeof( T ) );
			}
			return _instance;
		}
	}
}
