using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	private readonly ConditionalEventsCollection _validator = new ConditionalEventsCollection();
	private readonly ConditionalEventsCollection _runValidator = new ConditionalEventsCollection();

	private readonly EventSlot _onSpawn = new EventSlot();
	private readonly EventSlot _onDeath = new EventSlot();

	public IEventRegister OnSpawn => _onSpawn;
	public IEventRegister OnDeath => _onDeath;

	int _skinId = 0;

	SceneData sceneData;

	void Start()
	{
		sceneData = Guaranteed<SceneData>.Instance;
		Guaranteed<SceneData>.Instance.NotifyPlayerInstance( this );
		Guaranteed<Account>.Instance.SelectedSkin.Synchronize( _validator.Validated<int>( OnSelectedSkinChange ) );

		_onSpawn.Trigger();
	}

	private void OnSelectedSkinChange( int skin )
	{
		_skinId = skin;
	}

	void OnDestroy()
	{
		_onDeath.Trigger();
		_validator.Void();
	}
}
