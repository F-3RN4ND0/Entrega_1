using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform posJugador;
    public float enemySpeed =0 ;
    private int enemyRotationSpeed = 3;
    public GameObject Jugador;
    public Animator animacionEnemigo;
    enum TipoEnemigo
    {
        observar,
        perseguir,
    };
    [SerializeField] TipoEnemigo tiposDeEnemigo;

    
    void Start()
    {
        
    }

    void Update()
    {
        QueHaceElEnemigo();
    }

    void QueHaceElEnemigo()
    {
        switch (tiposDeEnemigo)
        {
            case TipoEnemigo.observar:
                VerAlJugador();
                break;

            case TipoEnemigo.perseguir:
                SeguirAlJugador();
                break;
        }
    }
    void VerAlJugador()
    {
        Quaternion newRotation = Quaternion.LookRotation((posJugador.position - transform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation , newRotation ,enemyRotationSpeed * Time.deltaTime);
        
    }

    void SeguirAlJugador()
    {
        transform.position = Vector3.MoveTowards(transform.position, posJugador.position, enemySpeed * Time.deltaTime);
        float dist = Vector3.Distance(transform.position, posJugador.position);
        transform.LookAt(posJugador);
        if (dist <= 0)
        {
            enemySpeed = 0;

        }
        else
        {
            enemySpeed = 0.5f;
        }
        if (transform.position == Vector3.zero)
        {
            animacionEnemigo.SetBool("estaCaminando", false);
        }
        else animacionEnemigo.SetBool("estaCaminando", true);
    }
    public void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log(message: $"el Jugador toco al {gameObject}");
        }
    }
}
        
