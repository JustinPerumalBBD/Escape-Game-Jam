 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public GameObject Spotlight;

    private Vector3 mousePos;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed = 1000f;

    [SerializeField]
    private bool playerControlled;

    [SerializeField]
    private int ExtraSpotlights;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        float x = Random.Range(0, 2) == 0 ? -1 : 1; 
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.AddForce(new Vector2(10*Time.deltaTime*moveSpeed, 10*Time.deltaTime*moveSpeed));  
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControlled)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y);
        }
        else
        {
            MoveSpotlight();
        }
    }

    void MoveSpotlight()
    {

    }
}
