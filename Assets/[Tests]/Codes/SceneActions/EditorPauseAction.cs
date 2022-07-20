using System.Collections;

public class EditorPauseAction : SceneAction
{
	public override IEnumerator Execute()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPaused = true;
#endif //UNITY_EDITOR
		if( false ) yield return null;
	}
}
