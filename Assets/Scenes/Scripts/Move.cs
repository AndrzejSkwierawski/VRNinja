using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Blade blade;
    private Vector3 finalPoint;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        finalPoint = new Vector3(Random.Range(-1f, 1f), 1.5f,-2f);
        moveSpeed = 0.5f;

    }



    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -1000)
        {
            moveSpeed = 0;
        }
        Vector3 direction = finalPoint - transform.position;
        transform.Translate(moveSpeed * direction[0] * Time.deltaTime, 
            moveSpeed * direction[1] * Time.deltaTime, moveSpeed * direction[2] * Time.deltaTime);
        if (transform.position.z < -1 && transform.position.z > -100)
        {
            blade.Lives--;
            Destroy(gameObject);

        }
    }
}
