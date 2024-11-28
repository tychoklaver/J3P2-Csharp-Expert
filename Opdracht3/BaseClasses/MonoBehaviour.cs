namespace J3P2_Csharp_Expert.Opdracht3.BaseClasses;

public class MonoBehaviour
{
    public GameObject Owner {  get; private set; }

    public virtual void Awake() { }
    public virtual void Start() { }
    public virtual void Update(GameTime pGameTime) { }
    public virtual void Draw(SpriteBatch pSpriteBatch) { }

    public T GetComponent<T>() where T : MonoBehaviour
    {
        return Owner.GetComponent<T>();
    }
}
