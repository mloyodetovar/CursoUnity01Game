using System.Collections;
using UnityEngine;

public class BreakFloor : MonoBehaviour
{
    public float time;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            StartCoroutine(DestroyFloor(other));    
        } 
    }

    IEnumerator DestroyFloor(Collider2D other) 
    {
        yield return new WaitForSeconds(time);

        if (other) 
        {
            Destroy(gameObject);
        }
    }
}
