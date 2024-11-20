using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RealAbilityEditor : EditorWindow
{
    private List<AbilityData> _allItems = new();
    private VisualElement _rightPane;
    private AbilityData _selectedItem;

    [MenuItem("Tools/RealAbilityEditor")]
    public static void ShowWindow()
    {
        var wnd = GetWindow<RealAbilityEditor>();
        wnd.titleContent = new GUIContent("RealAbilityEditor");
        wnd.minSize = new Vector2(450, 300);
    }

    [Obsolete("Obsolete")]
    public void CreateGUI()
    {
        LoadAllItems();

        var splitView = new TwoPaneSplitView(0, 200, TwoPaneSplitViewOrientation.Horizontal);
        rootVisualElement.Add(splitView);

        var leftPane = new ListView(_allItems, 20, () => new Label(), (element, index) =>
        {
            ((Label)element).text = _allItems[index].itemName;
        });
        splitView.Add(leftPane);

        _rightPane = new VisualElement();
        splitView.Add(_rightPane);

        leftPane.onSelectionChange += OnItemSelected;
    }

    private void LoadAllItems()
    {
        _allItems = AssetDatabase.FindAssets("t:AbilityData")
            .Select(guid => AssetDatabase.LoadAssetAtPath<AbilityData>(AssetDatabase.GUIDToAssetPath(guid)))
            .Where(item => item != null)
            .ToList();
    }

    private void OnItemSelected(IEnumerable<object> selectedItems)
    {
        _selectedItem = selectedItems.FirstOrDefault() as AbilityData;
        _rightPane.Clear();

        if (_selectedItem == null) return;

        AddField("Name", _selectedItem.itemName, value => _selectedItem.itemName = value);
        AddField("AttackPower", _selectedItem.attack, value => _selectedItem.attack = value);
        AddField("Hp", _selectedItem.hp, value => _selectedItem.hp = value);
        AddField("Speed",_selectedItem.speed, value => _selectedItem.speed = value);
        AddField("EvasionRate",_selectedItem.dodge, value => _selectedItem.dodge = value);
        AddField("Accuracy",_selectedItem.accuracy, value => _selectedItem.accuracy = value);
        AddField("EscapeRate",_selectedItem.escape, value => _selectedItem.escape = value);
        AddField("CriticalStrikeRate",_selectedItem.critical, value => _selectedItem.critical = value);
    }

    private void AddField<T>(string label, T initialValue, System.Action<T> onValueChanged)
    {
        VisualElement field;

        if (typeof(T) == typeof(int))
        {
            var intField = new IntegerField(label) { value = (int)(object)initialValue };
            intField.RegisterValueChangedCallback(evt =>
            {
                onValueChanged((T)(object)evt.newValue);
                EditorUtility.SetDirty(_selectedItem);
            });
            field = intField;
        }
        else if (typeof(T) == typeof(string))
        {
            var textField = new TextField(label) { value = (string)(object)initialValue };
            textField.RegisterValueChangedCallback(evt =>
            {
                onValueChanged((T)(object)evt.newValue);
                EditorUtility.SetDirty(_selectedItem);
            });
            field = textField;
        }
        else if (typeof(T) == typeof(float))
        {
            var floatField = new FloatField(label) { value = (float)(object)initialValue };
            floatField.RegisterValueChangedCallback(evt =>
            {
                onValueChanged((T)(object)evt.newValue);
                EditorUtility.SetDirty(_selectedItem);
            });
            field = floatField;
        }
        else if (typeof(T) == typeof(bool))
        {
            var toggleField = new Toggle(label) { value = (bool)(object)initialValue };
            toggleField.RegisterValueChangedCallback(evt =>
            {
                onValueChanged((T)(object)evt.newValue);
                EditorUtility.SetDirty(_selectedItem);
            });
            field = toggleField;
        }
        else
        {
            Debug.LogWarning($"Unsupported field type: {typeof(T).Name}");
            return;
        }

        _rightPane.Add(field);
    }
}