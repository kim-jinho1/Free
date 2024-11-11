using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class RealAbilityEditor : EditorWindow
{
    private Ability playerStats;

    [MenuItem("Tools/Player Stats Editor")]
    public static void ShowWindow()
    {
        var wnd = GetWindow<RealAbilityEditor>();
        wnd.titleContent = new GUIContent("Player Stats Editor");
        wnd.minSize = new Vector2(300, 300);
    }

    public void CreateGUI()
    {
        // 게임 오브젝트 필드 생성
        var objectField = new ObjectField("Player GameObject")
        {
            objectType = typeof(GameObject),
            allowSceneObjects = true
        };
        objectField.RegisterValueChangedCallback(evt =>
        {
            // 선택된 GameObject에서 PlayerStats 컴포넌트를 찾음
            var selectedObject = evt.newValue as GameObject;
            playerStats = selectedObject?.GetComponent<Ability>();
            RefreshStatsFields();
        });
        rootVisualElement.Add(objectField);
    }

    private void RefreshStatsFields()
    {
        // 기존 필드를 모두 제거
        rootVisualElement.Clear();

        // PlayerStats 컴포넌트가 없으면 메시지 표시
        if (playerStats == null)
        {
            rootVisualElement.Add(new Label("PlayerStats 컴포넌트를 가진 오브젝트를 선택하세요."));
            return;
        }

        // 각 능력치 필드를 생성하고, 값이 변경될 때마다 반영
        AddIntegerField("Attack Power", playerStats.attackPower, value => playerStats.attackPower = value);
        AddIntegerField("Health", playerStats.health, value => playerStats.health = value);
        AddFloatField("Speed", playerStats.speed, value => playerStats.speed = value);
        AddFloatField("Dodge Chance", playerStats.dodgeChance, value => playerStats.dodgeChance = value);
        AddFloatField("Accuracy", playerStats.accuracy, value => playerStats.accuracy = value);
        AddFloatField("Escape Rate", playerStats.escapeRate, value => playerStats.escapeRate = value);
        AddFloatField("Critical Chance", playerStats.criticalChance, value => playerStats.criticalChance = value);

        // 변경 사항 저장 버튼
        var saveButton = new Button(() =>
        {
            EditorUtility.SetDirty(playerStats);
        })
        { text = "Save Changes" };
        rootVisualElement.Add(saveButton);
    }

    private void AddIntegerField(string label, int initialValue, System.Action<int> onValueChanged)
    {
        var field = new IntegerField(label) { value = initialValue };
        field.RegisterValueChangedCallback(evt => onValueChanged(evt.newValue));
        rootVisualElement.Add(field);
    }

    private void AddFloatField(string label, float initialValue, System.Action<float> onValueChanged)
    {
        var field = new FloatField(label) { value = initialValue };
        field.RegisterValueChangedCallback(evt => onValueChanged(evt.newValue));
        rootVisualElement.Add(field);
    }
}
