using UnityEngine;

public class TestingSceneChangeLeaks : MonoBehaviour
{
	[SerializeField,InlineProperties] SceneBenchmark _benchmark;
	private Coroutine _coroutine;


	void Start()
    {
		DontDestroyOnLoad(gameObject);
		if( _benchmark != null ) _coroutine = StartCoroutine( _benchmark.ExecuteBenchmark() );
	}
}
