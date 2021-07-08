using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed;
    public Transform movePoint;

    public GameObject objeto1, objeto2, objeto1a, objeto2a;

    public LayerMask whatStopsMovement;

    Vector2 movement;

    public Animator animator;

    private Pociones powerUp;
    private Pociones2 powerUp2;

    void Start()
    {
        if (AudioTroughScenes.instance != null) //Pongo pausa a la cancion inicializada en el menu y utilizo un if para corregir el singletone
        {
            AudioTroughScenes.Pause();
        }

        movePoint.parent = null;
        Time.timeScale = 1f; //arreglar la pausa

        powerUp = FindObjectOfType<Pociones>();
        powerUp2 = FindObjectOfType<Pociones2>();


        if (Pociones.instance!=null && Pociones2.instance2 != null) //if para corregir el singletone y activar dentro las fotos en el inventario
        {
            if (powerUp.havePowerUp == 0 && powerUp2.havePowerUp2 == 2)
            {
                objeto2a.SetActive(true);

            }

            else if (powerUp.havePowerUp == 1 && powerUp2.havePowerUp2 == 0)
            {
                objeto1a.SetActive(true);

            }
            else if (powerUp.havePowerUp == 1 && powerUp2.havePowerUp2 == 2)
            {
                objeto2a.SetActive(true);
                objeto1a.SetActive(true);
            }
        }
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //Utilizo las variables del movimiento para poder utilizar las animaciones
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .3f, whatStopsMovement)) //Me muevo si no hay ninguna capa que me trabe el movimiento
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .3f, whatStopsMovement)) // Me muevo si no hay ninguna capa que me trabe el movimiento
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) //Si compro esto, oculto las fotos de las pociones, tanto la que compre como la otra
    {
        if (collider.gameObject.tag.Equals("Objeto1"))
        {
            objeto1.SetActive(false);
            objeto2.SetActive(false);
        }
        else if (collider.gameObject.tag.Equals("Objeto2"))
        {
            objeto1.SetActive(false);
            objeto2.SetActive(false);
        }
    }

}
