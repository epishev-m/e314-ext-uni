# E314.ExtUni

## Description

The `E314.ExtUni` module provides extensions for Unity, offering additional tools to enhance work with data types and other auxiliary functionality.

## Content

- [E314.ExtUni](#e314extuni)
  - [Description](#description)
  - [Content](#content)
  - [Bootstrap](#bootstrap)
  - [Data Types](#data-types)
    - [SerializableType](#serializabletype)

## Bootstrap

Provides basic functionality for loading and initializing system components.
Bootstrap is an abstract class that inherits from ScriptableObject.
To use it, you need to create your own class and inherit it from Bootstrap.
Upon creation, the resulting asset will automatically be added to Preloaded Assets (Project Settings.. -> Player -> Optimization -> Preloaded Assets).

``` csharp
[CreateAssetMenu(fileName = "Bootstrap", menuName = "Game/Bootstrap")]
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
```

## Data Types

### SerializableType

Allows serialization of System.Type for the Unity inspector. It appears as a dropdown list in the Unity inspector.
The list contains an enumeration of types inherited from the specified base type, while excluding the current file from the list.

``` csharp
class MyCommponent : MonoBehaviour
{
  [SerializeField] SerializableType _type = new(typeof(MonoBehaviour));
}
```
