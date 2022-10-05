 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public GameObject Spotlight;

    private Vector3 mousePos;
    private Rigidbody2D rb;
    private Vector2 direction;

    [SerializeField]
    private bool playerControlled;

    [Header("AI Spotlights")]
    public Transform[] SpotlightPositions;
    public int CurrentPos = 0;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 2.25f;
        CurrentPos = Random.Range(0,SpotlightPositions.Length-1); 
        GetPositions();
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
        transform.position = Vector2.MoveTowards(transform.position, SpotlightPositions[CurrentPos].position, moveSpeed*Time.deltaTime);

        if(Vector2.Distance(transform.position, SpotlightPositions[CurrentPos].position) < 0.2f)
        {
            CurrentPos = Random.Range(0, SpotlightPositions.Length-1);
        }   
    }

    void GetPositions()
    {
        for (int i = 0; i < SpotlightPositions.Length; i++)
        {
            SpotlightPositions[i] = GameObject.Find("Pos" +(i+1).ToString()).transform;
        }
    }
}
