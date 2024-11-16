namespace J3P2_Csharp_Expert.Opdracht1.TestScenes;

/// <summary>
/// Scene which tests the object's layer depth. Derives from SceneBase.
/// </summary>
public class LayerDepthTestScene : SceneBase
{
    #region Fields
    private readonly List<GameObject> _gameObjects;
    private readonly GameObject _textObject;

    private int _currentObjectIndex;
    private KeyboardState _previousKeyboardState;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the Layer Depth Test Scene.
    /// </summary>
    /// <param name="pTexture">The texture of the GameObject.</param>
    /// <param name="pFont">The font for the text.</param>
    public LayerDepthTestScene(Texture2D pTexture, SpriteFont pFont)
    {
        _gameObjects = new List<GameObject>()
        {
            new GameObject(pTexture, 0.9f)
            {
                Transform = { Position = new Vector2(300, 300) }
            },

            new GameObject(pTexture, 0.3f)
            {
                Transform = { Position = new Vector2(350, 350) }
            },

            new GameObject(pTexture, 0.5f)
            {
                Transform = { Position = new Vector2(400, 400) }
            }
        };

        foreach (GameObject obj in  _gameObjects)
        {
            obj.AddTextRenderer(new TextRenderer(pFont, $"Layer Depth: {obj.SpriteRenderer.LayerDepth}", new Vector2(20, -40), Color.White));
        }

        _textObject = new GameObject(null)
        {
            Transform = { Position = new Vector2(Game1.ScreenWidth / 2, 20) }
        };
        _textObject.AddTextRenderer(new TextRenderer(pFont, "Layer Depth Scene", Vector2.Zero, Color.White));
        _textObject.AddTextRenderer(new TextRenderer(pFont, "Use Numbers 1-5 to switch between scenes!", new Vector2(0, 20), Color.White));
        _textObject.AddTextRenderer(new TextRenderer(pFont, "Use Up/Down keys to change layer depth of selected object!", new Vector2(0, 40), Color.White));
        _textObject.AddTextRenderer(new TextRenderer(pFont, "Use Left/Right to switch objects!", new Vector2(0, 60), Color.White));

        _currentObjectIndex = 0;
        _previousKeyboardState = Keyboard.GetState();
    }
    #endregion

    #region Public Voids
    /// <summary>
    /// Override of the SceneBase Update.
    /// </summary>
    /// <param name="pGameTime">The current game time.</param>
    public override void Update(GameTime pGameTime)
    {
        KeyboardState currentKeyboardState = Keyboard.GetState();

        HandleObjectSelection(currentKeyboardState);
        AdjustLayerDepth(currentKeyboardState);
        UpdateTextRenderers();

        _previousKeyboardState = currentKeyboardState;
    }

    /// <summary>
    /// Override of the SceneBase Draw.
    /// </summary>
    /// <param name="pSpriteBatch">The SpriteBatch used for drawing.</param>
    public override void Draw(SpriteBatch pSpriteBatch)
    {
        foreach (GameObject obj in _gameObjects.OrderBy(o => o.SpriteRenderer.LayerDepth))
        {
            obj.Draw(pSpriteBatch);
            if (_gameObjects.IndexOf(obj) == _currentObjectIndex)
                DrawSelectedOverlay(pSpriteBatch, obj);
        }
        _textObject.Draw(pSpriteBatch);
    }
    #endregion

    #region Private Voids
    private void HandleObjectSelection(KeyboardState pCurrentKeyboardState)
    {
        if (pCurrentKeyboardState.IsKeyDown(Keys.Left) && !_previousKeyboardState.IsKeyDown(Keys.Left))
            _currentObjectIndex = (_currentObjectIndex - 1 + _gameObjects.Count) % _gameObjects.Count;
        else if (pCurrentKeyboardState.IsKeyDown(Keys.Right) && !_previousKeyboardState.IsKeyDown(Keys.Right))
            _currentObjectIndex = (_currentObjectIndex + 1) % _gameObjects.Count;
    }

    private void AdjustLayerDepth(KeyboardState pCurrentKeyboardState)
    {
        if (pCurrentKeyboardState.IsKeyDown(Keys.Up) && !_previousKeyboardState.IsKeyDown(Keys.Up))
        {
            GameObject obj = _gameObjects[_currentObjectIndex];
            obj.SpriteRenderer.LayerDepth = MathHelper.Clamp(obj.SpriteRenderer.LayerDepth + 0.1f, 0f, 1f);
        }

        else if(pCurrentKeyboardState.IsKeyDown(Keys.Down) && !_previousKeyboardState.IsKeyDown(Keys.Down))
        {
            GameObject obj = _gameObjects[_currentObjectIndex];
            obj.SpriteRenderer.LayerDepth = MathHelper.Clamp(obj.SpriteRenderer.LayerDepth - 0.1f, 0f, 1f);
        }

    }

    private void UpdateTextRenderers()
    {
        foreach (GameObject gameObject in _gameObjects)
        {
            gameObject.TextRenderers[0].UpdateText($"Layer Depth: {gameObject.SpriteRenderer.LayerDepth:F1}");
        }
    }

    private void DrawSelectedOverlay(SpriteBatch pSpriteBatch, GameObject pSelectedObject)
    {
        if (pSelectedObject.SpriteRenderer.Texture == null) return;

        Vector2 overlayPosition = pSelectedObject.Transform.Position;
        Vector2 overlayOrigin = new Vector2(pSelectedObject.SpriteRenderer.Texture.Width / 2, pSelectedObject.SpriteRenderer.Texture.Height / 2);

        pSpriteBatch.Draw(
            pSelectedObject.SpriteRenderer.Texture,
            overlayPosition,
            null,
            Color.Gray * 0.5f,
            MathHelper.ToRadians(pSelectedObject.Transform.Rotation),
            overlayOrigin,
            pSelectedObject.Transform.Scale,
            SpriteEffects.None,
            pSelectedObject.SpriteRenderer.LayerDepth + 0.01f
        );

    }
    #endregion
}
