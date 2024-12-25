using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SJ_BattleUI : MonoSingleton<SJ_BattleUI>
{
    private EnemySO enemySO;
    [SerializeField] private List<TextMeshProUGUI> percentList;
    [SerializeField] private List<TextMeshProUGUI> damageList;
    [SerializeField] private List<Image> _images;
    [SerializeField] private GameObject pannel;

    private List<float> _enemypercents;
    private List<float> _attacks;
    private Sprite[] _enemySprites;

    public void Awake()
    {
        for (int i = 0; i < _enemypercents.Count; i++)
        {
            percentList[i].text = _enemypercents[i].ToString();
            damageList[i].text = _attacks[i].ToString();
        }
    }

    public void SetEnemy(Enemy en)
    {
        enemySO = en.enemyData.enemySO;
        _enemypercents[0] = 1;
        _attacks[0] = 1;
        _enemySprites = en.enemyData.GetHitPointSprites();

        for (int i = 0; i < _enemySprites.Length; i++)
        {
            _images[i].sprite = _enemySprites[i];
        }
    }

    public void Attack(int ListNum)
    {
        int per = Random.Range(0, 101);
        if (per >= 50)
        {
            Debug.Log("공격");
        }
        else
        {
            Debug.Log("개모태");
        }
        pannel.SetActive(false);
        pannel.transform.DOMoveX(1200, 1f);
    }
}
