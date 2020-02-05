using DG.Tweening;
using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Enemy enemy;
    public Transform startPos;
    public Transform endPos;
    public bool killed = false;
    bool moving = false;

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
        enemy.ResetEnemy();
        transform.position = startPos.position;
        moving = true;
        transform.DOMove(endPos.position, 1f).SetEase(Ease.InOutCubic);
        yield return new WaitForSeconds(1f);
        moving = false;
        killed = false;
    }
}
