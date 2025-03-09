using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine.UIElements;

namespace E314.ExtUni.Editor
{

[CustomPropertyDrawer(typeof(SerializableType))]
public sealed class SerializableTypeDrawer : PropertyDrawer
{
	private List<string> _names;
	private SerializedProperty _typeNameProperty;

	public override VisualElement CreatePropertyGUI(SerializedProperty property)
	{
		var container = new VisualElement();
		if (_names == null) FillNames(property);
		_typeNameProperty = property.FindPropertyRelative("_typeName");
		var index = GetIndex(_typeNameProperty.stringValue);
		var popup = new PopupField<string>(property.displayName, _names, index);
		popup.RegisterValueChangedCallback(OnValueChanged);
		container.Add(popup);
		return container;
	}

	private void FillNames(SerializedProperty property)
	{
		var serializableType = GetSerializableType(property);
		var baseType = serializableType.BaseType;
		var allTypes = GetAllTypeNames(baseType);
		var type = property.serializedObject.targetObject.GetType();
		_names = type.IsSubclassOf(baseType)
			? allTypes.Where(name => name != type.FullName).ToList()
			: allTypes.ToList();
	}

	private SerializableType GetSerializableType(SerializedProperty property)
	{
		object targetObject = property.serializedObject.targetObject;
		return (SerializableType)fieldInfo.GetValue(targetObject);
	}

	private static IEnumerable<string> GetAllTypeNames(Type baseType)
	{
		return new List<string> { "None" }
			.Concat(TypeCache.GetTypesDerivedFrom(baseType)
				.Select(type => type.FullName))
			.ToArray();
	}

	private int GetIndex(string value)
	{
		var index = _names?.IndexOf(value) ?? 0;
		if (index < 0) index = 0;
		return index;
	}

	private void OnValueChanged(ChangeEvent<string> evt)
	{
		if (_typeNameProperty == null) return;
		var index = GetIndex(evt.newValue);
		_typeNameProperty.stringValue = index > 0 ? evt.newValue : string.Empty;
		_typeNameProperty.serializedObject.ApplyModifiedProperties();
	}
}

}