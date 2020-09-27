using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    Level level;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] sprites; // indicate different states of the block
    [SerializeField] int hitTimes=0; // serialize for debugging
    [SerializeField] int point = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (tag == "breakable")
        {
            hitTimes++;
            if (hitTimes == sprites.Length+1)
            {
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                level.UpdateBlockCollision(point);
                Destroy(gameObject);
                // particle effect
                GameObject sparkle = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
                Destroy(sparkle, 1f);
            } else
            {
                GetComponent<SpriteRenderer>().sprite = sprites[hitTimes-1];
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
