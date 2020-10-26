using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //Para animaciones y fisicas
    private Rigidbody2D rb2d;
    private Animator myanimator;

    private bool FacingRight = true;

    //variables
    public float speed = 2.0f;
    public float horizMovement;//= 1[OR]-1[OR]0

    private void Start()
    {
        //Define los objetos del juego encontrados en el jugador 
        rb2d = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
    }

    //Maneja la entrada de las fisicas
    private void Update()
    {
        //Revisa la direccion dada por el jugador
        horizMovement = Input.GetAxisRaw("Horizontal");
    }
    //revisa las fisicas
    private void FixedUpdate()
    {
        //mueve el personaje de derecha a iquierda
        rb2d.velocity = new Vector2(horizMovement * speed, rb2d.velocity.y);
        myanimator.SetFloat("speed", Mathf.Abs(horizMovement));
        Flip(horizMovement);
    }

    //Funcion de giro
    private void Flip (float horiznontal)
    {
        if (horiznontal < 0 && FacingRight || horiznontal > 0 && !FacingRight)
        {
            FacingRight = !FacingRight;
            Vector3 thescale = transform. localScale;
            thescale.x *= -1;
            transform.localScale = thescale;
        }
    }
}