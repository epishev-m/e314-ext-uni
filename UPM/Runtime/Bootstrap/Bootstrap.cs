using System;
using System.Linq;
using UnityEngine;

namespace E314.ExtUni
{

/// <summary>
/// Abstract class for managing application initialization.
/// Provides basic functionality for loading and initializing system components.
/// </summary>
public abstract class Bootstrap : ScriptableObject
{
	/// <summary>
	/// Gets the singleton instance of Bootstrap.
	/// </summary>
	internal static Bootstrap Instance { get; private set; }

#if UNITY_EDITOR
	internal void ExecuteAwake()
	{
		Awake();
	}
#endif

	/// <summary>
	/// Initializes components depending on the loading stage.
	/// </summary>
	/// <param name="type">Type of initialization stage.</param>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when initialization type is unknown.</exception>
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

	/// <summary>
	/// Called during subsystem registration.
	/// </summary>
	protected abstract void OnSubsystemRegistration();

	/// <summary>
	/// Called after all assemblies are loaded.
	/// </summary>
	protected abstract void OnAfterAssembliesLoaded();

	/// <summary>
	/// Called before the splash screen is displayed.
	/// </summary>
	protected abstract void OnBeforeSplashScreen();

	/// <summary>
	/// Called before scene loading.
	/// </summary>
	protected abstract void OnBeforeSceneLoad();

	/// <summary>
	/// Called after scene loading.
	/// </summary>
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