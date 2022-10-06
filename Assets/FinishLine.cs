using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // ysha8al o8nya

            // Debug.Log("HORAY");
            // yen2el lel level el b3do
            // StartCoroutine(TimeDelay());
        }
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(0.85f);      // waits for 1.5 seconds abl ma yen2el el level
                                                    // dh 3lshan 5ater nel7a2 nesma3 el o8nya
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)%3);       // gets the next level
        // bs msh htb2a %3 b2a, h8ayar el rakam 3la asas 3adad el levels
    }
}
