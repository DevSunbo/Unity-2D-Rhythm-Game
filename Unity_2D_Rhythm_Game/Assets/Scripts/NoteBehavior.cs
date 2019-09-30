using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    public int noteType; // 몇 번 노트인지
    private GameManager.judges judge;
    private KeyCode keyCode;
    void Start()
    {
        if (noteType == 1) keyCode = KeyCode.D;
        if (noteType == 2) keyCode = KeyCode.F;
        if (noteType == 3) keyCode = KeyCode.J;
        if (noteType == 4) keyCode = KeyCode.K;
    }

    void Update()
    {
        transform.Translate(Vector3.down * GameManager.instance.noteSpeed);
        if (Input.GetKey(keyCode))
        {
            Debug.Log(judge);
            if (judge != GameManager.judges.NONE) Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bad Line")
        {
            judge = GameManager.judges.BAD;
        }
        if (other.gameObject.tag == "Good Line")
        {
            judge = GameManager.judges.GOOD;
        }
        if (other.gameObject.tag == "Perfect Line")
        {
            judge = GameManager.judges.PERFECT;
        }
        if (other.gameObject.tag == "Miss")
        {
            judge = GameManager.judges.MISS;
            Destroy(gameObject);
        }
       
    }
}
