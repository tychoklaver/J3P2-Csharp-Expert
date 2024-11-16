global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using Microsoft.Xna.Framework.Input;
global using J3P2_Csharp_Expert.Opdracht1.TestScenes;
global using J3P2_Csharp_Expert.Opdracht1.BaseClasses;
global using System;
global using System.Collections.Generic;
global using System.Linq;

namespace J3P2_Csharp_Expert.Opdracht1;

/// <summary>
/// Game1 Class.
/// </summary>
public class Game1 : Game
{
    #region Fields
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private RotationTestScene _rotationTestScene;
    private PositionTestScene _positionTestScene;
    private ScaleTestScene _scaleTestScene;
    private OriginTestScene _originTestScene;
    private LayerDepthTestScene _layerDepthScene;
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
        _rotationTestScene = new RotationTestScene(_texture, Content.Load<SpriteFont>("Fonts/Font"));
        _positionTestScene = new PositionTestScene(_texture, Content.Load<SpriteFont>("Fonts/Font"));
        _scaleTestScene = new ScaleTestScene(_texture, Content.Load<SpriteFont>("Fonts/Font"));
        _originTestScene = new OriginTestScene(_texture, Content.Load<Texture2D>("Textures/DebugTexture"), Content.Load<SpriteFont>("Fonts/Font"));
        _layerDepthScene = new LayerDepthTestScene(_texture, Content.Load<SpriteFont>("Fonts/Font"));

        _sceneManager.AddScene(1, _rotationTestScene);
        _sceneManager.AddScene(2, _positionTestScene);
        _sceneManager.AddScene(3, _originTestScene);
        _sceneManager.AddScene(4, _scaleTestScene);
        _sceneManager.AddScene(5, _layerDepthScene);

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
