using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 movePos;
    public float moveSpeed; 
    private Scene CurrentScene;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1f;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        movePos = new Vector2(Random.Range(-12,12), Random.Range(-7,7));

        CurrentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos, moveSpeed*Time.deltaTime);

        if(Vector2.Distance(transform.position, movePos) < 0.2f)
        {
            movePos = new Vector2(Random.Range(-12,12), Random.Range(-7,7));     
        }   
    }

    private void OnMouseDown() 
    {
        if(gameObject.tag == "Target")
        {
            Debug.Log("Click target");
            Destroy(this.gameObject);
            if(CurrentScene.name == "Level 1")
            {
                SceneManager.LoadScene("Pre-Level 2");
            }

            if(CurrentScene.name == "Level 2")
            {
                SceneManager.LoadScene("Pre-Level 3");
            }

            if(CurrentScene.name == "Level 3")
            {
                SceneManager.LoadScene("End Game");
            }
        }    
        else{
            SceneManager.LoadScene("Game Over");
        }
    }
}
