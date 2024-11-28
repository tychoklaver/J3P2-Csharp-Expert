namespace J3P2_Csharp_Expert.Opdracht2.BaseClasses;

/// <summary>
/// Represents a game object, encapsulating logic and rendering components.
/// </summary>
public class GameObject
{
    #region Properties
    /// <summary>
    /// Transform Component to handle the object's positioning.
    /// </summary>
    public Transform Transform { get; private set; }

    /// <summary>
    /// SpriteRenderer Component to handle the object's drawing.
    /// </summary>
    public SpriteRenderer SpriteRenderer { get; private set; }

    /// <summary>
    /// The list of TextRenderers added on to the Object.
    /// </summary>
    public List<TextRenderer> TextRenderers { get; private set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new default GameObject instance.
    /// </summary>
    /// <param name="pTexture">The texture to render.</param>
    /// <param name="pPosition">The position of the object.</param>
    /// <param name="pLayerDepth">The layer depth of the GameObject, where the default is 0.</param>
    public GameObject(Texture2D pTexture, Vector2 pPosition, float pLayerDepth = 0f)
    {
        Transform = new Transform(pPosition);
        SpriteRenderer = new SpriteRenderer(pTexture, pLayerDepth);
        TextRenderers = new List<TextRenderer>();
    }

    /// <summary>
    /// Initializes a new GameObject instance without a SpriteRenderer instance.
    /// </summary>
    /// <param name="pPosition">The position of the object.</param>
    public GameObject(Vector2 pPosition)
    {
        Transform = new Transform(pPosition);
        SpriteRenderer = null;
        TextRenderers = new List<TextRenderer>();
    }
    #endregion

    #region Public Voids
    /// <summary>
    /// Updates the GameObject. Override this to provide custom behavior.
    /// </summary>
    /// <param name="pGameTime">The current GameTime</param>
    public virtual void Update(GameTime pGameTime) { }

    /// <summary>
    /// Draws the GameObject to the screen, along with the Text added on to it (if any).
    /// </summary>
    /// <param name="pSpriteBatch">The SpriteBatch used to draw the textures.</param>
    public virtual void Draw(SpriteBatch pSpriteBatch)
    {
        SpriteRenderer?.Draw(pSpriteBatch, Transform);

        foreach (TextRenderer textRenderer in TextRenderers)
        {
            textRenderer.DrawText(pSpriteBatch);
        }
    }

    /// <summary>
    /// Adds a TextRenderer to the List in the GameObject.
    /// </summary>
    /// <param name="pTextRenderer">The TextRenderer to add to the list.</param>
    public void AddTextRenderer(TextRenderer pTextRenderer)
    {
        if (pTextRenderer == null) throw new ArgumentNullException(nameof(pTextRenderer));
        pTextRenderer.Parent = this;
        TextRenderers.Add(pTextRenderer);
    }

    /// <summary>
    /// Allows multiple text renderers to be added at once, instead of only one.
    /// </summary>
    /// <param name="pTextRenderers">The list of Renderers to add.</param>
    public void AddTextRenderer(params TextRenderer[] pTextRenderers)
    {
        if (pTextRenderers == null) throw new ArgumentNullException(nameof(pTextRenderers));

        foreach (TextRenderer renderer in pTextRenderers)
        {
            renderer.Parent = this;
            TextRenderers.Add(renderer);
        }
    }

    /// <summary>
    /// Removes the TextRenderer from the List.
    /// </summary>
    /// <param name="pTextRenderer">The TextRenderer to remove.</param>
    public void RemoveTextRenderer(TextRenderer pTextRenderer)
    {
        if (pTextRenderer == null) throw new ArgumentNullException(nameof(pTextRenderer));

        if (!TextRenderers.Contains(pTextRenderer))
            return;

        pTextRenderer.Parent = null;
        TextRenderers.Remove(pTextRenderer);
    }
    #endregion
}
