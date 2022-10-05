using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ExtraSpotlights;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<ExtraSpotlights.Length; i++)
        {
            Instantiate(ExtraSpotlights[i], new Vector3(0,0,0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
