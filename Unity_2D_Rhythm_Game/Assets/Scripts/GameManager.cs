using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글 톤 처리
    public static GameManager instance { get; set; }
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    public float noteSpeed;
    // Start is called before the first frame update
    /**/
    public enum judges { NONE = 0, BAD, GOOD, PERFECT, MISS}; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
