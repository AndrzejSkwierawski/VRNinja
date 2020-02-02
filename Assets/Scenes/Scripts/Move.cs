using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 finalPoint;
    public float MoveSpeed;
    private Blade blade;
    // Start is called before the first frame update
    void Start()
    {
        finalPoint = new Vector3(Random.Range(-1f, 1f), 1.5f,-2f);
        blade = (Blade)GameObject.FindObjectOfType(typeof(Blade));
        MoveSpeed = blade.level / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -1000)
        {
            MoveSpeed = 0;
        }
        Vector3 direction = finalPoint - transform.position;
        transform.Translate(MoveSpeed * direction[0] * Time.deltaTime, 
            MoveSpeed * direction[1] * Time.deltaTime, MoveSpeed * direction[2] * Time.deltaTime);
        if (transform.position.z < -1 && transform.position.z > -100)
        {
            blade.Lives--;
            Destroy(gameObject);
        }
    }
}
