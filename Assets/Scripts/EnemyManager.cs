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
    public UIPopup taskPopup;

    public bool killed = false;
    public UIDrawer notificationDrawer;

    public TMP_Text enemyLabel;
    public TMP_Text dummyLabel;
    public TMP_Text popupLabel;
    public TMP_Text taskNameLabel;
    public TMP_Text taskCustomLabel;
    public TMP_Text taskTimeLabel;


    public int currentName = 0;
    public string[] names;

    void Start()
    {
        taskNameLabel.text = names[currentName];
        popupLabel.text = names[currentName];
        taskCustomLabel.text = names[currentName];
        enemyLabel.text = names[currentName];
        dummyLabel.text = names[currentName + 1];
        DOTween.SetTweensCapacity(500, 50);
        transform.position = endPos.position;
        enemy = GetComponentInChildren<Enemy>();
        DisableInput();
    }

    public void UpdateNames()
    {
        names[currentName] = taskCustomLabel.text;
        taskNameLabel.text = names[currentName];
        popupLabel.text = names[currentName];
        taskCustomLabel.text = names[currentName];
        enemyLabel.text = names[currentName];
    }

    public void MoveEnemies()
    {
        NotificationManager.Send(TimeSpan.FromSeconds(5), "Your friend just completed a task!", "Markus Aksli just completed " + names[currentName] + "!", Color.white);
        StartCoroutine(MoveRoutine());
    }

    public void EditName(string newName)
    {
        names[currentName] = newName;
    }

    public void DisableInput()
    {
        killed = true;
    }
    public void EnableInput()
    {
        killed = false;
    }

    IEnumerator MoveRoutine()
    {
        killed = true;
        popupLabel.text = names[currentName];
        if (currentName == 0)
        {
            taskTimeLabel.text = "Task duration 27:36";
        }
        else
        {
            taskTimeLabel.text = "Task duration 00:31";
        }
        yield return new WaitForSeconds(1f);
        winPopup.Show();
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => winPopup.IsHidden);
        enemy.ResetEnemy();
        currentName += 1;
        taskNameLabel.text = names[currentName];
        popupLabel.text = names[currentName];
        taskCustomLabel.text = names[currentName];
        enemyLabel.text = names[currentName];
        dummyLabel.text = names[currentName + 1];
        transform.position = startPos.position;
        transform.DOMove(endPos.position, 1f).SetEase(Ease.InOutCubic);
        yield return new WaitForSeconds(1f);
        killed = false;
        if (currentName == 2)
        {
            notificationDrawer.Open();
            yield return new WaitForSeconds(5f);
            notificationDrawer.Close();
        }
    }
}
