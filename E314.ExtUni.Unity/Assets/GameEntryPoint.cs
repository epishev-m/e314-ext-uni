using E314.ExtUni;
using UnityEngine;

[CreateAssetMenu(fileName = "GameBootstrap", menuName = "Game/GameBootstrap")]
public sealed class GameBootstrap : Bootstrap
{
	protected override void OnSubsystemRegistration()
	{
		Debug.Log(nameof(OnSubsystemRegistration));
	}

	protected override void OnAfterAssembliesLoaded()
	{
		Debug.Log(nameof(OnAfterAssembliesLoaded));
	}

	protected override void OnBeforeSplashScreen()
	{
		Debug.Log(nameof(OnBeforeSplashScreen));
	}

	protected override void OnBeforeSceneLoad()
	{
		Debug.Log(nameof(OnBeforeSceneLoad));
	}

	protected override void OnAfterSceneLoad()
	{
		Debug.Log(nameof(OnAfterSceneLoad));
	}
}
