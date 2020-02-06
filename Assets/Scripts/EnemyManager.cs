using Assets.SimpleAndroidNotifications;
using DG.Tweening;
using Doozy.Engine.UI;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Enemy enemy;
    public Transform startPos;
    public Transform endPos;
    public UIPopup winPopup;
    public bool killed = false;

    public TMP_Text enemyLabel;
    public TMP_Text dummyLabel;
    public TMP_Text popupLabel;
    public int currentName = 0;
    public string[] names;

    void Start()
    {
        enemyLabel.text = names[currentName];
        dummyLabel.text = names[currentName + 1];
        DOTween.SetTweensCapacity(500, 50);
        transform.position = endPos.position;
        enemy = GetComponentInChildren<Enemy>();
    }

    public void MoveEnemies()
    {
        if (currentName == 1)
        {
            NotificationManager.Send(TimeSpan.FromSeconds(5), "Your friend just levelled up!", "Markus Aksli just reached level 52!", Color.white);
        }
        else
        {
            NotificationManager.Send(TimeSpan.FromSeconds(5), "Your friend just completed a task!", "Markus Aksli just completed " + names[currentName] + "!", Color.white);
        }
        StartCoroutine(MoveRoutine());
    }

    public void EditName(string newName)
    {
        names[currentName] = newName;
    }

    IEnumerator MoveRoutine()
    {
        killed = true;
        popupLabel.text = names[currentName];
        yield return new WaitForSeconds(1f);
        winPopup.Show();
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => winPopup.IsHidden);
        enemy.ResetEnemy();
        currentName += 1;
        enemyLabel.text = names[currentName];
        dummyLabel.text = names[currentName + 1];
        transform.position = startPos.position;
        transform.DOMove(endPos.position, 1f).SetEase(Ease.InOutCubic);
        yield return new WaitForSeconds(1f);
        killed = false;
    }
}
