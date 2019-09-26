using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    public int noteType; // 몇 번 노트인지
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down * GameManager.instance.noteSpeed);
    }
}
