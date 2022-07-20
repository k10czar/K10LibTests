using System.Collections;
using UnityEngine;

public class WaitForSecondsSceneAction : SceneAction
{
	[SerializeField] float _seconds;

	public override IEnumerator Execute() { yield return new WaitForSeconds( _seconds ); }
}
