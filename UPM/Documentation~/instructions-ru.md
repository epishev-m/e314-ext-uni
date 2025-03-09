# E314.ExtUni

## Описание

Модуль `E314.ExtUni` предоставляет расширения для Unity, предоставляющий дополнительные инструменты для улучшения работы с типами данных и другой вспомогательный функционал.

## Содержание

- [E314.ExtUni](#e314extuni)
  - [Описание](#описание)
  - [Содержание](#содержание)
  - [Bootstrap](#bootstrap)
  - [Типы данных](#типы-данных)
    - [SerializableType](#serializabletype)

## Bootstrap

Предоставляет базовую функциональность для загрузки и инициализации системных компонентов.
Bootstrap является абстрактным классом и наследует ScriptableObject.
Для использования необходимо создать свой класс и унаследовать его от Bootstrap.
В момент создания, полученный ассет автоматически добавится в Предзагружаемые ассеты (Project Settings.. -> Player -> Optimization -> Preloaded Assets).

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

## Типы данных

### SerializableType

Позволяет сериализовать System.Type для Unity инспектора. В инспекторе Unity отображается как выпадающий список.
Список содержит перечисление типов унаследованных от заданного базового типа, при этом из списка будет исключен текущий файл.

``` csharp
class MyCommponent : MonoBehaviour
{
  [SerializeField] SerializableType _type = new(typeof(MonoBehaviour));
}
```