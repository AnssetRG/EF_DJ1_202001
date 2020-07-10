using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    protected Sprite[] colourSprites;
    protected SpriteRenderer renderer;
    protected Rigidbody2D myRB;
    protected BoxCollider2D collider2D;
    protected bool CanDie = false;
    protected int points;

    protected void SetUp(float y_multiplier, bool x_random)
    {
        renderer = GetComponent<SpriteRenderer>();
        myRB = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();

        transform.position = RandomPos(y_multiplier, x_random);
        myRB.velocity = RandomVelocity(y_multiplier, x_random);
        renderer.sprite = colourSprites[(int)Random.Range(0, colourSprites.Length - 1)];
    }

    private void OnBecameVisible()
    {
        CanDie = true;
    }

    private void OnBecameInvisible()
    {
        if (CanDie)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 10)
        {
            if (other.tag == this.tag)
            {
                Destroy(other.gameObject);
                GameController.instance.GainPoints(points);
                Destroy(this.gameObject);
            }
            Destroy(other.gameObject);
        }
        else if (other.tag == "Player")
        {
            GameController.instance.RestLife();
            Destroy(this.gameObject);
        }
    }

    public virtual int GetPoints()
    {
        return points;
    }

    protected Vector3 RandomPos(float y_multiplier, bool x_random)
    {
        float x = 0;
        float width = Camera.main.orthographicSize * Screen.width / Screen.height;
        if (x_random)
        {
            x = RandomFloat(width) * 0.9f;
        }
        else
        {
            x = RandomFloat(10) <= 0 ? -width : width;
        }
        return new Vector3(x, Camera.main.orthographicSize * y_multiplier, 0);
    }

    protected Vector2 RandomVelocity(float y_multiplier, bool x_random)
    {
        float y_speed = 0;
        float x_speed = 0;
        if (x_random)
        {
            y_speed = 5 * (-y_multiplier);
        }
        else
        {
            x_speed = transform.position.x > 0 ? -5 : 5;
        }
        return new Vector2(x_speed, y_speed);
    }

    protected float RandomFloat(float value)
    {

        return Random.Range(-value, value);
    }
}