namespace J3P2_Csharp_Expert.Opdracht1.BaseClasses;

/// <summary>
/// Handles the drawing of a Texture to the screen.
/// </summary>
public class SpriteRenderer
{
    #region Fields
    private readonly Vector2 _textureSize;
    #endregion

    #region Properties
    /// <summary>
    /// The texture to draw.
    /// </summary>
    public Texture2D Texture { get; private set; }

    /// <summary>
    /// The Layer Depth of the object to be drawn to the screen.
    /// </summary>
    public float LayerDepth { get; set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the SpriteRenderer with a texture and layer depth.
    /// </summary>
    /// <param name="pTexture">The texture to draw.</param>
    /// <param name="pLayerDepth">The layer depth for drawing.</param>
    public SpriteRenderer(Texture2D pTexture, float pLayerDepth)
    {
        if (pTexture == null)
            return;

        Texture = pTexture;
        LayerDepth = pLayerDepth;
        _textureSize = Texture.Bounds.Size.ToVector2(); // Get the full size of the used Texture.
    }
    #endregion

    #region Public Voids
    /// <summary>
    /// Draws the provided texture to the screen.
    /// </summary>
    /// <param name="pSpriteBatch">The SpriteBatch used for rendering.</param>
    /// <param name="pTransform">The Transform used for the positioning, origin, rotating and scaling of the texture.</param>
    public void Draw(SpriteBatch pSpriteBatch, Transform pTransform)
    {
        if (Texture == null) return;
        pSpriteBatch.Draw(
            Texture,
            pTransform.Position,
            null,
            Color.White,
            pTransform.RotationToRadians(), // Translates the Degrees to Radians, for correct rotation.
            pTransform.Origin * _textureSize, // Sets the Origin of the object to the centre of the sprite.
            pTransform.Scale,
            SpriteEffects.None,
            LayerDepth);
    }
    #endregion
}
