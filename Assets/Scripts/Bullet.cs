
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    GameObject bulletImpactSpawnLocation;

    public float speed = 70f;
    public GameObject impactEffect;

    void Start()
    {
        bulletImpactSpawnLocation = GameObject.Find("BulletImpactSpawnHere");
    }

    public void Chase (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);


    }

    void HitTarget()
    {
        GameObject effectIns =(GameObject)Instantiate(impactEffect, transform.position, transform.rotation, bulletImpactSpawnLocation.transform);
        Destroy(effectIns, 2f);

        Destroy(gameObject);
    }
}
