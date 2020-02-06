using DG.Tweening;
using Doozy.Engine.UI;
using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Enemy enemy;
    public Transform startPos;
    public Transform endPos;
    public UIPopup winPopup;
    public bool killed = false;

    void Start()
    {
        DOTween.SetTweensCapacity(500, 50);
        transform.position = endPos.position;
        enemy = GetComponentInChildren<Enemy>();
    }

    public void MoveEnemies()
    {
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        killed = true;
        yield return new WaitForSeconds(1f);
        winPopup.Show();
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => winPopup.IsHidden);
        enemy.ResetEnemy();
        transform.position = startPos.position;
        transform.DOMove(endPos.position, 1f).SetEase(Ease.InOutCubic);
        yield return new WaitForSeconds(1f);
        killed = false;
    }
}
