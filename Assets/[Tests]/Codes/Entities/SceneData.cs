using System;
using UnityEngine;

public class SceneData : MonoBehaviour
{
	private readonly ConditionalEventsCollection _validator = new ConditionalEventsCollection();

	private readonly CachedCollection<Player> _players = new CachedCollection<Player>();

	public ICachedCollection<Player> Players => _players;

	void Start()
	{
		Guaranteed<Account>.Instance.IsLogged.Synchronize( _validator.Validated<bool>( OnConnectionState ) );
	}

	void OnDestroy()
	{
		_validator.Void();
	}

	void OnConnectionState( bool isLogged )
	{

	}

	public void NotifyPlayerInstance( Player player )
	{
		_players.Add( player );
	}
}
