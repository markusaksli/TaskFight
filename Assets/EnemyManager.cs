using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Transform> enemies = new List<Transform>();
    Collider2D col;
    public Transform startPos;
    public Transform endPos;
    public bool killed = false;
    public float lerpTime;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = endPos.position;
        col = GetComponent<Collider2D>();
        Transform[] enemyArray = GetComponentsInChildren<Transform>();
        foreach (Transform t in enemyArray)
        {
            enemies.Add(t);
        }
        enemies.Remove(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !killed)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Collider2D touchCollider = Physics2D.OverlapPoint(touchPos);
            if (touchCollider.Equals(col))
            {
                StartCoroutine(MoveEnemies());
            }
        }
        if (!killed)
        {
            StartCoroutine(MoveEnemies());
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(MoveEnemies());
        }
    }

    IEnumerator MoveEnemies()
    {
        killed = true;
        transform.position = startPos.position;
        transform.DOMove(endPos.position, 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        killed = false;
    }
}
