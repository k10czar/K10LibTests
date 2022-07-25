using UnityEngine;

public class TestingSceneChangeLeaks : MonoBehaviour
{
	[SerializeField,InlineProperties] K10.Automation.Operation _benchmark;
	// private Coroutine _coroutine;


	void Start()
    {
		_benchmark.Execute();
	}
}
