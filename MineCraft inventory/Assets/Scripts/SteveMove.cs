using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SteveMove : MonoBehaviour
{
    private PlayerInput input = null;
    private Vector3 Mov = Vector2.zero;
    public float movspeed = 8f;
    public Vector3 VelC;


    // Start is called before the first frame update
    void Awake()
    {
        input = new PlayerInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        VelC = Mov * movspeed;
        transform.position += VelC * Time.fixedDeltaTime;
    }
    private void MovM(InputAction.CallbackContext value)
    {
        Mov = value.ReadValue<Vector2>();
        Mov = new Vector3(Mov.x, 0, Mov.y);

    }
    private void MovC(InputAction.CallbackContext value)
    {
        Mov = Vector2.zero;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Move.performed -= MovM;
        input.Player.Move.canceled -= MovC;
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += MovM;
        input.Player.Move.canceled += MovC;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
}
