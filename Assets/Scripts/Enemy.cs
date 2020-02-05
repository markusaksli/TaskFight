using UnityEngine;

public class Enemy : MonoBehaviour
{
    Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Collider2D touchCollider = Physics2D.OverlapPoint(touchPos);
            if (touchCollider.Equals(col))
            {
                //Destroy(this.gameObject);
            }
        }
    }
}
