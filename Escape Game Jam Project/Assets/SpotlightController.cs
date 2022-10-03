 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public GameObject Spotlight;

    private Vector3 mousePos;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed = 10f;

    [SerializeField]
    private bool playerControlled;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControlled)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y);
        }
    }
}
