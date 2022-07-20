using System.Collections;

public class WaitForEndOfFrameSceneAction : SceneAction
{
	public override IEnumerator Execute() { yield return new WaitForEndOfFrameSceneAction(); }
}
