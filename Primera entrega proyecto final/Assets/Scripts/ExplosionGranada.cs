using UnityEngine;

public class ExplosionGranada : MonoBehaviour
{
    float radio = 5f;
    public float fuerzaExplosion = 5f;
    public float delay = 4f;
    public GameObject efectoExplosion;
    void Start()
    {
        Invoke("ExplotarGranada", delay);
    }

    void ExplotarGranada()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radio);
        
        foreach(Collider near in colliders)
        {
            Rigidbody rb = near.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(fuerzaExplosion, transform.position, radio, 1f, ForceMode.Impulse);
            Instantiate(efectoExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
