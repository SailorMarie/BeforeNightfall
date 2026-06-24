using UnityEngine;
using UnityEngine.InputSystem;

public abstract class LevelController : MonoBehaviour
{
    public abstract void SetDependencies(GameController gameController);

    public abstract void Init();

    public abstract void ClosePopUp(InputAction.CallbackContext context);
    
}
