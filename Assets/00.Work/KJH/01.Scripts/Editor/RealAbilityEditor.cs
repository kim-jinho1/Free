using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
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
        AddField("AttackPower", _selectedItem.attackPower, value => _selectedItem.attackPower = value);
        AddField("Hp", _selectedItem.hp, value => _selectedItem.hp = value);
        AddField("Speed",_selectedItem.speed, value => _selectedItem.speed = value);
        AddField("EvasionRate",_selectedItem.evasionRate, value => _selectedItem.evasionRate = value);
        AddField("Accuracy",_selectedItem.accuracy, value => _selectedItem.accuracy = value);
        AddField("EscapeRate",_selectedItem.escapeRate, value => _selectedItem.escapeRate = value);
        AddField("CriticalStrikeRate",_selectedItem.criticalStrikeRate, value => _selectedItem.criticalStrikeRate = value);
        
        
        AddImageField("AttackPowerImage", _selectedItem.attackPowerImage, value => _selectedItem.attackPowerImage = value);
        AddImagePreview(_selectedItem.attackPowerImage); 
        AddImageField("HpImage", _selectedItem.hpImage, value => _selectedItem.hpImage = value);
        AddImagePreview(_selectedItem.hpImage);
        AddImageField("SpeedImage", _selectedItem.speedImage, value => _selectedItem.speedImage = value);
        AddImagePreview(_selectedItem.speedImage);
        AddImageField("EvasionRateImage", _selectedItem.evasionRateImage, value => _selectedItem.evasionRateImage = value);
        AddImagePreview(_selectedItem.evasionRateImage);
        AddImageField("AccuracyImage", _selectedItem.accuracyImage, value => _selectedItem.accuracyImage = value);
        AddImagePreview(_selectedItem.accuracyImage);
        AddImageField("EscapeRateRateImage", _selectedItem.escapeRateRateImage, value => _selectedItem.escapeRateRateImage = value);
        AddImagePreview(_selectedItem.escapeRateRateImage);
        AddImageField("CriticalStrikeRateImage", _selectedItem.criticalStrikeRateImage, value => _selectedItem.criticalStrikeRateImage = value);
        AddImagePreview(_selectedItem.criticalStrikeRateImage);
        
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
        else
        {
            return;
        }

        _rightPane.Add(field);
    }

    private void AddImageField(string label, Sprite initialImage, System.Action<Sprite> onValueChanged)
    {
        var imageField = new ObjectField(label)
        {
            objectType = typeof(Sprite),
            value = initialImage
        };
        imageField.RegisterValueChangedCallback(evt =>
        {
            onValueChanged(evt.newValue as Sprite);
            EditorUtility.SetDirty(_selectedItem);
        });
        _rightPane.Add(imageField);
    }

    private void AddImagePreview(Sprite sprite)
    {
        if (sprite == null) return;

        var spriteImage = new Image { image = sprite.texture };
        _rightPane.Add(spriteImage);
    }
}