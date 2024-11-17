namespace J3P2_Csharp_Expert.Opdracht1.TestScenes;

/// <summary>
/// A scene in which the object's rotation gets tested. Derives from SceneBase.
/// </summary>
public class RotationTestScene : SceneBase
{
    #region Fields
    private readonly GameObject[] _gameObjects; 
    private readonly GameObject _textObject;
    private int _currentObjectIndex;
    private KeyboardState _previousKeyboardState;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the Rotation Test Scene.
    /// </summary>
    /// <param name="pTexture">The texture of the GameObject.</param>
    /// <param name="pFont">The font for the text.</param>
    public RotationTestScene(Texture2D pTexture, SpriteFont pFont)
    {
        _gameObjects = new GameObject[4];
        InitializeGameObject(pTexture, 0f, pFont, 0);
        InitializeGameObject(pTexture, 90f, pFont, 1);
        InitializeGameObject(pTexture, 180f, pFont, 2);
        InitializeGameObject(pTexture, 270f, pFont, 3);

        _textObject = new GameObject()
        {
            Transform = { Position = new Vector2(Game1.ScreenWidth / 2, 20) }
        };

        List<TextRenderer> renderers = new List<TextRenderer>()
        {
            new TextRenderer(pFont, "Rotation Scene", Vector2.Zero, Color.White),
            new TextRenderer(pFont, "Use Numbers 1-5 to switch between scenes!", new Vector2(0, 20), Color.White),
            new TextRenderer(pFont, "Use the Arrow Keys to switch between object!", new Vector2(0, 40), Color.White)
        };

        _textObject.AddTextRenderer(renderers);

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
        HandleInput();
    }

    /// <summary>
    /// Override of the SceneBase Draw.
    /// </summary>
    /// <param name="pSpriteBatch">The SpriteBatch used for drawing.</param>
    public override void Draw(SpriteBatch pSpriteBatch)
    {
        _gameObjects[_currentObjectIndex].Draw(pSpriteBatch);
        _textObject.Draw(pSpriteBatch);
    }
    #endregion

    #region Private Voids
    private void InitializeGameObject(Texture2D pTexture, float pRotation, SpriteFont pFont, int pIndex)
    {
        _gameObjects[pIndex] = new GameObject(pTexture);
        _gameObjects[pIndex].Transform.Position = new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2);
        _gameObjects[pIndex].Transform.UpdateRotation(pRotation);
        _gameObjects[pIndex].AddTextRenderer(new TextRenderer(pFont, $"{_gameObjects[pIndex].Transform.Rotation}", new Vector2(50, -50), Color.White));
    }

    private void HandleInput()
    {
        KeyboardState keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.Left) && !_previousKeyboardState.IsKeyDown(Keys.Left))
            _currentObjectIndex = (_currentObjectIndex - 1 + _gameObjects.Length) % _gameObjects.Length;
        else if (keyboardState.IsKeyDown(Keys.Right) && !_previousKeyboardState.IsKeyDown(Keys.Right))
            _currentObjectIndex = (_currentObjectIndex + 1) % _gameObjects.Length;

        _previousKeyboardState = keyboardState;
    }
    #endregion
}
