using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 3;
    public float runSpeed = 6;
    public float rotationSpeed = 0.5f;
    public Vector3 rotationInput = Vector3.zero;
    public Animator animacion;
    public Rigidbody _rigidb;

    public float sensibilidadMouse = 500;
    public float xRotacion;
    public float yRotacion;
    public Transform cam;

    public GameObject Zombie;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        MovimientoJugador();
    }
    void Update()
    {
        MouseLook();
    }
    void MovimientoJugador()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(hor, 0, ver);
        movementDirection.Normalize();
        movementDirection = Vector3.ClampMagnitude(movementDirection, 1f);
        _rigidb.MovePosition (_rigidb.position + (transform.TransformDirection(movementDirection) * speed* Time.fixedDeltaTime));

        if (movementDirection == Vector3.zero)
        {
            animacion.SetBool("estaCaminando", false);
        }
        else animacion.SetBool("estaCaminando", true);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _rigidb.MovePosition(_rigidb.position + (transform.TransformDirection(movementDirection) * runSpeed * Time.fixedDeltaTime));
            animacion.SetBool("estaCorriendo", true);
            animacion.SetBool("estaCaminando", false);
        }
        else
        {
            animacion.SetBool("estaCorriendo", false);
        }
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
        xRotacion -= mouseY;
        xRotacion = Mathf.Clamp(xRotacion, -20, 20);

        yRotacion += mouseX;
        cam.localRotation = Quaternion.Euler(xRotacion, yRotacion, 0);
        yRotacion = Mathf.Clamp(xRotacion, -80, 80);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Debug.Log(message: $"el Zombie toco al {gameObject}");
        }
    }
}
