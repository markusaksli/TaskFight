
using Doozy.Engine.Progress;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Progressor healthBar;
    Collider2D col;
    EnemyManager EM;
    Animator anim;
    public int hp = 3;
    public Animator playerAnim;


    public ParticleSystem particle;
    public ParticleSystem deathParticle;

    void Start()
    {
        healthBar = GetComponent<Progressor>();
        anim = GetComponent<Animator>();
        EM = GetComponentInParent<EnemyManager>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && !EM.killed)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                Collider2D touchCollider = Physics2D.OverlapPoint(touchPos);
                if (touchCollider.Equals(col))
                {
                    TapAction();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && !EM.killed)
        {
            TapAction();
        }
    }

    public void ResetEnemy()
    {
        anim.Play("Walk");
        healthBar.SetValue(3);
        hp = 3;
    }

    void TapAction()
    {
        playerAnim.Play("PlayerSlash");
        hp -= 1;
        StartCoroutine(ValueWait());
        healthBar.SetValue(hp);
        anim.Play("Hurt");
        particle.Play();
        if (hp == 0)
        {
            deathParticle.Play();
            anim.Play("Death");
            EM.MoveEnemies();
        }
    }

    IEnumerator ValueWait()
    {
        int oldHp = hp;
        yield return new WaitForSeconds(1f);
        if (hp == oldHp)
        {
            hp = 3;
            healthBar.SetValue(3);
        }
    }
}
