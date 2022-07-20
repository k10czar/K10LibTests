using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneBenchmark", menuName = "ScriptableObjects/SceneBenchmark", order = 1)]
public class SceneBenchmark : ScriptableObject
{
	[SerializeField] SceneExecution _startAction;
	[SerializeField] int _repetions;
	[SerializeField] List<SceneExecution> _sequence;
	[SerializeField] SceneExecution _lastAction;

	public IEnumerator ExecuteBenchmark()
	{
		yield return _startAction.Execute();

		var pendingRepetions = _repetions;

		for (int i = 0; i < _sequence.Count; i++)
		{
			var exec = _sequence[i];
			yield return exec.Execute();

			if (pendingRepetions != 0 && (i == (_sequence.Count - 1)))
			{
				i = -1;
				pendingRepetions--;
			}
		}

		yield return _lastAction.Execute();
	}

	[System.Serializable]
	public struct SceneExecution
	{
		[SerializeField] bool _changeScene;
		[SerializeField,Scene,EnableIf(nameof(_changeScene))] string _scene;
		[SerializeField,InlineProperties] List<SceneAction> _actions;

		public IEnumerator Execute()
		{
			if( _changeScene )
			{
				var op = SceneManager.LoadSceneAsync( _scene );
				while( !op.isDone ) yield return null;
			}

			for (int i = 0; i < _actions.Count; i++)
			{
				var exec = _actions[i];
				yield return exec.Execute();
			}
		}
	}
}
