using System.Collections;
using UnityEngine;

public abstract class SceneAction : ScriptableObject
{
	public abstract IEnumerator Execute();
}
