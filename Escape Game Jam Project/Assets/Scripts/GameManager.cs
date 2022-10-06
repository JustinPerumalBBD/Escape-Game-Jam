using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] Targets;
    
    [SerializeField]
    private GameObject CurrentTarget;
    private GameObject NewMonster;

    private int RandomTargetSelection;

    public Sprite TargetSprite;
    public Image TargetImage;

    [Header("Timer Controls")]
    [SerializeField]
    private float CountDownTimer; 
    public GameObject CountDownText;  

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
        if(CountDownTimer > 0)
        {
            CountDownTimer -= Time.deltaTime;
            CountDownText.GetComponent<TextMeshProUGUI>().text = CountDownTimer.ToString("F0");
        }

        if(CountDownTimer <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
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
