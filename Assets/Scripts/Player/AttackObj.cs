using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObj : MonoBehaviour
{
    public float delayDestroy;
    public float speed;
    private void OnEnable() 
    {
        Destroy(gameObject, delayDestroy);
    }

    private void Update() 
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
