using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject half_fruit_left, half_fruit_right;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (this.GetComponent<MeshRenderer>().enabled == true)
        {
            Instantiate(half_fruit_right, col.gameObject.transform.position, Quaternion.identity);
            Instantiate(half_fruit_left, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
    }
}
