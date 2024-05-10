using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject loader;
    // Start is called before the first frame update
    public void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthManager.health--;
            loader.gameObject.SetActive(true);
            Debug.Log("bomb hit");
            StartCoroutine(wait());


        }
    }
    IEnumerator wait()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);
        loader.gameObject.SetActive(false);
    }
}