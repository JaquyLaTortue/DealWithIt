using UnityEngine;
using UnityEngine.InputSystem;


public class Sneak : MonoBehaviour
{
    public bool Crouch { get; private set; }

    public float SneakHeight = 0.5f;

    public float SneakSpeed;

    [SerializeField] Move MoveScript;

    public void OnSneak(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {

            //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - sneak, gameObject.transform.position.z);
            gameObject.transform.localScale = new Vector3(1, SneakHeight, 1);
            MoveScript.SetSneakSpeed(SneakSpeed);

        }
        else if (ctx.canceled)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            MoveScript.SetSneakSpeed(MoveScript.InitialSpeed);
        }
        
    }
}
