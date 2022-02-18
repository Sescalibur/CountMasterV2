using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public int heal = 2;
    public int damage = 1;
    private Rigidbody my_rigidbody;
    void Start()
    {
        my_rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 my_axis = new Vector3(0, transform.rotation.y, 0);
        //my_rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
