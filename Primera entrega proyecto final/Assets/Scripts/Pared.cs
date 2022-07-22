using UnityEngine;

public class Pared : MonoBehaviour
{
    public GameObject Jugador;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(message: $"el Jugador choca con la {gameObject}");
        }
    }
}
