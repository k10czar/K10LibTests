using System.Collections;
using UnityEngine;

public class InstantiateAction : SceneAction
{
	[SerializeField] int _instances = 1;
	[SerializeField] GameObject _prefab;
	[SerializeField] Vector3 _position;
	[SerializeField] Vector3 _rotation;
	[SerializeField] bool _dontDestroyOnLoad;

	public override IEnumerator Execute()
	{
		if( _prefab != null )
		{
			for( int i = 0; i < _instances; i++ )
			{
				var go = GameObject.Instantiate( _prefab, _position, Quaternion.Euler( _rotation ) );
				if( _dontDestroyOnLoad ) GameObject.DontDestroyOnLoad(go);
			}
		}
		else
		{
			Debug.LogError( "Cannot instantiate null prefab" );
		}
		if( false ) yield return null;
	}
}