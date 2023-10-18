using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Player player;
    private GunBase gunBase;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        gunBase = FindObjectOfType<GunBase>();
    }

    public void OnMove(InputAction.CallbackContext ctxt)
    {
        if (ctxt.started) player.Move(ctxt.ReadValue<Vector2>().x);
        else if(ctxt.canceled) player.Move(0);
    }

    public void OnJump(InputAction.CallbackContext ctxt)
    {
        if (ctxt.started) player.Jump();
    }

    public void OnRun(InputAction.CallbackContext ctxt)
    {
        if (ctxt.started) player.Run();
    }

    public void OnFire(InputAction.CallbackContext ctxt)
    {
        if (ctxt.started) gunBase.Shoot();
    }
}
