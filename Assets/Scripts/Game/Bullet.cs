using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Sprite[] bullet_sprites;
    public void SetUp(Vector2 force, string tag)
    {
        GetComponent<Rigidbody2D>().velocity = force;
        this.tag = tag;
        switch (tag)
        {
            case "Red":
                GetComponent<SpriteRenderer>().sprite = bullet_sprites[0];
                break;
            case "Yellow":
                GetComponent<SpriteRenderer>().sprite = bullet_sprites[1];
                break;
            case "Fly":
                GetComponent<SpriteRenderer>().sprite = bullet_sprites[2];
                break;
            case "Brown":
                GetComponent<SpriteRenderer>().sprite = bullet_sprites[3];
                break;
            case "Cream":
                GetComponent<SpriteRenderer>().sprite = bullet_sprites[4];
                break;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}