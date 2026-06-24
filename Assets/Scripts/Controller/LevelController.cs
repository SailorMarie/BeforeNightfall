using UnityEngine;

public abstract class LevelController : MonoBehaviour
{
    public abstract void SetDependencies(GameController gameController);

    public abstract void Init();
    
}
