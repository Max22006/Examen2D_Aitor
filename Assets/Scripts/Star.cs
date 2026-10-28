using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Star : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    private SpriteRenderer _spriteRender;
    
    void Awake()
    {
         _boxCollider2D = GetComponent<BoxCollider2D>();
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Victoria");
        }
    }
}
