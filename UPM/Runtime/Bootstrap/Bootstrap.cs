using System;
using System.Linq;
using UnityEngine;

namespace E314.GameKit.Uni
{

public abstract class Bootstrap : ScriptableObject
{
	internal static Bootstrap Instance { get; private set; }

#if UNITY_EDITOR
	internal void ExecuteAwake()
	{
		Awake();
	}
#endif

	internal void Initialize(RuntimeInitializeLoadType type)
	{
		switch (type)
		{
			case RuntimeInitializeLoadType.SubsystemRegistration:
				OnSubsystemRegistration();
				break;
			case RuntimeInitializeLoadType.AfterSceneLoad:
				OnAfterAssembliesLoaded();
				break;
			case RuntimeInitializeLoadType.BeforeSceneLoad:
				OnBeforeSplashScreen();
				break;
			case RuntimeInitializeLoadType.AfterAssembliesLoaded:
				OnBeforeSceneLoad();
				break;
			case RuntimeInitializeLoadType.BeforeSplashScreen:
				OnAfterSceneLoad();
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(type), type, null);
		}
	}

	protected abstract void OnSubsystemRegistration();

	protected abstract void OnAfterAssembliesLoaded();

	protected abstract void OnBeforeSplashScreen();

	protected abstract void OnBeforeSceneLoad();

	protected abstract void OnAfterSceneLoad();

	private void Awake()
	{
#if UNITY_EDITOR
		if (!Application.isPlaying)
		{
			var preloadedAssets = UnityEditor.PlayerSettings.GetPreloadedAssets().ToList();
			preloadedAssets.RemoveAll(x => x is Bootstrap);
			preloadedAssets.Add(this);
			UnityEditor.PlayerSettings.SetPreloadedAssets(preloadedAssets.ToArray());
			return;
		}
#endif
		Instance = this;
		Debug.LogError("Awake");
	}
}

}