using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SJ_TempTurn : MonoBehaviour
{
    [SerializeField] private GameObject tempPan;
    [SerializeField] private GameObject[] _enemyImage;

    public void ChangeTurn()
    {
        tempPan.SetActive(true);
        tempPan.transform.DOMove(new Vector3(960,540), 1f).SetEase(Ease.OutExpo);
        StartCoroutine(ShowImage());
    }  
    
    public IEnumerator ShowImage()
    {
        for(int i = 0; i < _enemyImage.Length; i++)
        {
            _enemyImage[i].SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
