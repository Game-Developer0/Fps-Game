using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ReactToHit()
    {
        Enemy enemy = GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.isAlive = false;
        }
        enemy.animator.SetBool("Death", true);
        StartCoroutine(Die());
    }
    IEnumerator Die()
    {

        yield return new WaitForSeconds(6);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
