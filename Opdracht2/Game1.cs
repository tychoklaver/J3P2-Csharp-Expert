#region Global Usings
using J3P2_Csharp_Expert.Opdracht2.ObjectTestScenes;
using J3P2_Csharp_Expert.Opdracht2.TestScenes;
#endregion

namespace J3P2_Csharp_Expert.Opdracht2;

/// <summary>
/// Game1 Class.
/// </summary>
public class Game1 : Game
{
    #region Fields
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private RotaterObjectTestScene _rotaterObjectTestScene;
    private BouncerObjectTestScene _bouncerObjectTestScene;
    private ScalerObjectTestScene _scalerObjectTestScene;
    private SineRotaterTestScene _sineRotationTestScene;
    private Texture2D _texture;
    private SceneManager _sceneManager;
    #endregion

    #region Properties
    public static int ScreenWidth { get; private set; }
    public static int ScreenHeight { get; private set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Creates a new instance of the Game1 class.
    /// </summary>
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    #endregion

    #region Protected Voids  
    /// <summary>
    /// Initializes the Game.
    /// </summary>
    protected override void Initialize()
    {
        ScreenWidth = _graphics.PreferredBackBufferWidth;
        ScreenHeight = _graphics.PreferredBackBufferHeight;

        base.Initialize();
    }

    /// <summary>
    /// Loads the content which features in the Game.
    /// </summary>
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _texture = Content.Load<Texture2D>("Textures/LittleStar");

        _sceneManager = new SceneManager();
        _rotaterObjectTestScene = new RotaterObjectTestScene(_texture, Content.Load<SpriteFont>("Fonts/Font"));
        _bouncerObjectTestScene = new BouncerObjectTestScene(_texture, Content.Load<SpriteFont>("Fonts/Font"));
        _sineRotationTestScene = new SineRotaterTestScene(_texture, Content.Load<SpriteFont>("Fonts/Font"));
        _scalerObjectTestScene = new ScalerObjectTestScene(_texture, Content.Load<SpriteFont>("Fonts/Font"));

        _sceneManager.AddScene(1, _rotaterObjectTestScene);
        _sceneManager.AddScene(2, _bouncerObjectTestScene);
        _sceneManager.AddScene(3, _sineRotationTestScene);
        _sceneManager.AddScene(4, _scalerObjectTestScene);

        _sceneManager.SetCurrentScene(1);
    }

    /// <summary>
    /// Updates the Game loop.
    /// </summary>
    /// <param name="gameTime">The current game time.</param>
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _sceneManager.Update(gameTime);

        base.Update(gameTime);
    }

    /// <summary>
    /// Draws the content in the Game.
    /// </summary>
    /// <param name="gameTime">The current game time.</param>
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(SpriteSortMode.FrontToBack);
        _sceneManager.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
    #endregion
}
