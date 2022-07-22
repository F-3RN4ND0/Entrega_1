using UnityEngine;

public class LanzarLaGranada : MonoBehaviour
{
    public GameObject granada;
    public Transform spawnpoint;
    public float range = 10f;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            LanzarGranada();
        }
    }

    void LanzarGranada()
    {
        GameObject copiaGranada = Instantiate(granada, spawnpoint.position, spawnpoint.rotation);
        copiaGranada.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * range, ForceMode.Impulse);
    }
}
