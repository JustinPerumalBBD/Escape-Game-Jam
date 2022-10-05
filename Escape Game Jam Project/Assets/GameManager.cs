using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] Targets;
    
    [SerializeField]
    private GameObject CurrentTarget;
    private GameObject NewMonster;

    private int RandomTargetSelection;

    public Sprite TargetSprite;
    public Image TargetImage;

    void Awake()
    {
        RandomTargetSelection = Random.Range(0, Targets.Length-1);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetTargetPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Randomly places targets across level
    private void SetTargetPositions() 
    {
        for(int i=0; i<Targets.Length; i++)
        {
            NewMonster = Instantiate(Targets[i], new Vector3(Random.Range(-10,10), Random.Range(-8,8),0), Quaternion.identity);

            if(i==RandomTargetSelection)
            {
                NewMonster.tag = "Target";
                CurrentTarget = Targets[i];
            }
        }

        SetCurrentTarget();
    }

    private void SetCurrentTarget()
    {
       TargetSprite = CurrentTarget.GetComponent<SpriteRenderer>().sprite;
       TargetImage.sprite = TargetSprite;
    }
}
