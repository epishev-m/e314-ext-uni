using E314.GameKit.Uni;
using UnityEngine;

[CreateAssetMenu(fileName = "EntryPoint", menuName = "Game/EntryPoint")]
public sealed class GameEntryPoint : Bootstrap
{
	protected override void OnSubsystemRegistration()
	{
		Debug.LogError(nameof(OnSubsystemRegistration));
	}

	protected override void OnAfterAssembliesLoaded()
	{
		Debug.LogError(nameof(OnAfterAssembliesLoaded));
	}

	protected override void OnBeforeSplashScreen()
	{
		Debug.LogError(nameof(OnBeforeSplashScreen));
	}

	protected override void OnBeforeSceneLoad()
	{
		Debug.LogError(nameof(OnBeforeSceneLoad));
	}

	protected override void OnAfterSceneLoad()
	{
		Debug.LogError(nameof(OnAfterSceneLoad));
	}
}
