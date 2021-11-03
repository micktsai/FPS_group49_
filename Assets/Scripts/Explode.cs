using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Explode : MonoBehaviour
{

    public float time;
    public float deltaTime;
    public float range;
    public Rigidbody rb;
    public GameObject ps;
    void Update()
    {
        
        time -= Time.deltaTime * deltaTime;

        if (time <= 0)
        {
            GOT_Explode();
            //rb.AddExplosionForce(200f, this.transform.position, 200f);
            GameObject ps_o = Instantiate(ps, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(ps_o, 3f);
        }
            


    }

    void GOT_Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach(Collider c in colliders)
        {
            if(c.tag == "Enemy")
            {
                Damage(c.transform);
            }
        }
    }
    void Damage(Transform transform)
    {
        // TODO
    }



}