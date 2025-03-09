using System.Linq;
using UnityEngine;

namespace E314.GameKit.Uni
{

internal static class BootstrapRuntime
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void RuntimeInitialize_SubsystemRegistration()
	{
#if UNITY_EDITOR
		var preloadAsset = UnityEditor.PlayerSettings.GetPreloadedAssets().FirstOrDefault(x => x is Bootstrap);
		if (preloadAsset is Bootstrap instance) instance.ExecuteAwake();
#endif

			Bootstrap.Instance.Initialize(RuntimeInitializeLoadType.SubsystemRegistration);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	private static void RuntimeInitialize_AfterAssembliesLoaded()
	{
		Bootstrap.Instance.Initialize(RuntimeInitializeLoadType.AfterAssembliesLoaded);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
	private static void RuntimeInitialize_BeforeSplashScreen()
	{
		Bootstrap.Instance.Initialize(RuntimeInitializeLoadType.BeforeSplashScreen);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void RuntimeInitialize_BeforeSceneLoad()
	{
		Bootstrap.Instance.Initialize(RuntimeInitializeLoadType.BeforeSceneLoad);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void RuntimeInitialize_AfterSceneLoad()
	{
		Bootstrap.Instance.Initialize(RuntimeInitializeLoadType.AfterSceneLoad);
	}
}

}