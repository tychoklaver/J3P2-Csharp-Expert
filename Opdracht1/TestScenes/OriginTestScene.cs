namespace J3P2_Csharp_Expert.Opdracht1.TestScenes;

/// <summary>
/// A scene in which the object's origin gets tested using rotation. Derives from SceneBase.
/// </summary>
public class OriginTestScene : SceneBase
{
    #region Fields
    private readonly GameObject _centerOriginObject;
    private readonly GameObject _topleftOriginObject;
    private readonly GameObject _bottomRightOriginObject;
    private readonly Texture2D _originMarkerTexture;

    private readonly GameObject _textObject;

    private float _startRotation = 0f;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the Origin Test Scene.
    /// </summary>
    /// <param name="pTexture">The texture for the Game Objects.</param>
    /// <param name="pMarkerTexture">The texture for the Origin Marker</param>
    /// <param name="pFont">The font for the text.</param>
    public OriginTestScene(Texture2D pTexture, Texture2D pMarkerTexture,SpriteFont pFont)
    {
        _originMarkerTexture = pMarkerTexture;

        // Initialize Game Objects.
        _centerOriginObject = InitializeGameObject(pTexture, new Vector2(200, 200), new Vector2(0.5f, 0.5f), pFont, 0.8f);
        _topleftOriginObject = InitializeGameObject(pTexture, new Vector2(400, 200), new Vector2(0, 0), pFont);
        _bottomRightOriginObject = InitializeGameObject(pTexture, new Vector2(600, 200), new Vector2(1, 1), pFont);

        // Initialize Text Object.
        _textObject = new GameObject()
        {
            Transform = { Position = new Vector2(Game1.ScreenWidth / 2, 29) }
        };
        _textObject.AddTextRenderer(new TextRenderer(pFont, "Origin Scene", Vector2.Zero, Color.White));
        _textObject.AddTextRenderer(new TextRenderer(pFont, "Use Numbers 1-5 to switch between scenes", new Vector2(0, 20), Color.White));
    }
    #endregion

    #region Public Voids
    /// <summary>
    /// Override of the SceneBase Update.
    /// </summary>
    /// <param name="pGameTime">The current game time.</param>
    public override void Update(GameTime pGameTime)
    {
        _startRotation += 1f;

        // Updates rotation of the objects.
        _centerOriginObject.Transform.UpdateRotation(_startRotation);
        _topleftOriginObject.Transform.UpdateRotation(_startRotation);
        _bottomRightOriginObject.Transform.UpdateRotation(_startRotation);
    }

    /// <summary>
    /// Override of the SceneBase Draw.
    /// </summary>
    /// <param name="pSpriteBatch">The SpriteBatch used for drawing.</param>
    public override void Draw(SpriteBatch pSpriteBatch)
    {
        DrawOriginMarker(pSpriteBatch, _centerOriginObject);
        DrawOriginMarker(pSpriteBatch, _topleftOriginObject);
        DrawOriginMarker(pSpriteBatch, _bottomRightOriginObject);

        _centerOriginObject.Draw(pSpriteBatch);
        _topleftOriginObject.Draw(pSpriteBatch);
        _bottomRightOriginObject.Draw(pSpriteBatch);

        _textObject.Draw(pSpriteBatch);
    }
    #endregion

    #region Private Voids
    private GameObject InitializeGameObject(Texture2D pTexture, Vector2 pPosition, Vector2 pOrigin, SpriteFont pFont, float pLayerDepth = 0f)
    {
        GameObject gameObject = new GameObject(pTexture, pLayerDepth);
        gameObject.Transform.Position = pPosition;
        gameObject.Transform.UpdateOrigin(pOrigin);
        gameObject.AddTextRenderer(new TextRenderer(pFont, $"{gameObject.Transform.Origin}", new Vector2(50, -50), Color.White));
        return gameObject;
    }

    private void DrawOriginMarker(SpriteBatch pSpriteBatch, GameObject pObject)
    {
        Vector2 markerPosition = pObject.Transform.Position;

        Vector2 markerOrigin = new Vector2(_originMarkerTexture.Width / 2, _originMarkerTexture.Height / 2);
        pSpriteBatch.Draw(
            _originMarkerTexture,
            markerPosition,
            null,
            Color.Red,
            0f,
            markerOrigin,
            1f,
            SpriteEffects.None,
            1f);
    }
    #endregion
}
