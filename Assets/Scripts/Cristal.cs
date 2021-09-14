using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal : MonoBehaviour
{
    public GameObject particleCollected;
    public AudioClip fxCollected;

    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            Instantiate(particleCollected, gameObject.transform.position, gameObject.transform.rotation);
            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();
            Destroy(gameObject);
            AudioManager.instance.PlaySound(fxCollected);
            
}
    }
}
