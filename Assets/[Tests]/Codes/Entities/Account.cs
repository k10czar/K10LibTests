using UnityEngine;

public class Account : MonoBehaviour
{
	private readonly BoolState _isLogged = new BoolState( true );
	private readonly IntState _id = new IntState( 10 );
	private readonly IntState _selectedSkin = new IntState( 99 );

	public IValueState<bool> IsLogged => _isLogged;
	public IValueState<int> ID => _id;
	public IValueState<int> SelectedSkin => _selectedSkin;
}