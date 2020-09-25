using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthUnit=16f;
    [SerializeField] float minX=2f;
    [SerializeField] float maxX=14f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosXInUnits = Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthUnit, minX, maxX);
        transform.position = new Vector2(mousePosXInUnits, transform.position.y);
    }
}
