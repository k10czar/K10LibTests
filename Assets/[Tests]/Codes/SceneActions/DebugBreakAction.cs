using System.Collections;
using UnityEngine;

public class DebugBreakAction : SceneAction
{
	public override IEnumerator Execute()
	{
		Debug.Break();
		if( false ) yield return null;
	}
}