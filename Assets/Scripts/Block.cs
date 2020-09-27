using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    Level level;
    [SerializeField] GameObject blockSparklesVFX;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.UpdateBlockCollision();
        // particle effect
        GameObject sparkle = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkle, 1f);

    }
    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
