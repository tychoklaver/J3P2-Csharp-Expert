﻿using J3P2_Csharp_Expert.Opdracht2.BaseClasses;

namespace J3P2_Csharp_Expert.Opdracht2.TestScenes;

/// <summary>
/// A scene in which the object's positioning gets tested. Derives from SceneBase.
/// </summary>
public class PositionTestScene : SceneBase
{
    #region Fields
    private readonly GameObject[] _gameObjects;
    private readonly GameObject _textObject;
    private int _currentObjectIndex;
    private KeyboardState _previousKeyboardState;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the Position Test Scene.
    /// </summary>
    /// <param name="pTexture">The texture of the GameObject.</param>
    /// <param name="pFont">The font for the text.</param>
    public PositionTestScene(Texture2D pTexture, SpriteFont pFont)
    {
        _gameObjects = new GameObject[5];
        InitializeGameObject(pTexture, new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2), pFont, 0);
        InitializeGameObject(pTexture, new Vector2(300, 100), pFont, 1);
        InitializeGameObject(pTexture, new Vector2(600, 300), pFont, 2);
        InitializeGameObject(pTexture, new Vector2(400, 400), pFont, 3);
        InitializeGameObject(pTexture, new Vector2(80, 310), pFont, 4);

        _textObject = new GameObject(new Vector2(Game1.ScreenWidth / 2, 20));

        List<TextRenderer> renderers = new List<TextRenderer>()
        {
            new TextRenderer(pFont, "Position Scene", Vector2.Zero, Color.White),
            new TextRenderer(pFont, "Use Numbers 1-5 to switch between scenes!", new Vector2(0, 20), Color.White),
            new TextRenderer(pFont, "Use the Arrow Keys to switch between object!", new Vector2(0, 40), Color.White)
        };

        _textObject.AddTextRenderer(renderers.ToArray());

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
    private void InitializeGameObject(Texture2D pTexture, Vector2 pPosition, SpriteFont pFont, int pIndex)
    {
        _gameObjects[pIndex] = new GameObject(pTexture, pPosition);
        _gameObjects[pIndex].AddTextRenderer(new TextRenderer(pFont, $"{_gameObjects[pIndex].Transform.Position}", new Vector2(50, -50), Color.White));
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
