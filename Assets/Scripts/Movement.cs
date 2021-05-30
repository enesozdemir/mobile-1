using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Controler playerInput;
    
    private CharacterController controller;
        
    [SerializeField]
    private float playerSpeed = 2.0f;
    

    private void Awake()
    {
        playerInput = new Controler();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        
    }

    void Update()
    {

        Vector2 movementInput = playerInput.Player.Move.ReadValue<Vector2>();

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

    }
}

