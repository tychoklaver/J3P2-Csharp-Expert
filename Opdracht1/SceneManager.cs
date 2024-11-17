namespace J3P2_Csharp_Expert.Opdracht1;

/// <summary>
/// The SceneManager class, which stores all game scenes and allows switching between them.
/// </summary>
public class SceneManager
{
    #region Fields
    private readonly Dictionary<int, SceneBase> _scenes;
    private SceneBase _currentScene;
    private KeyboardState _previousKeyboardState;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the SceneManager.
    /// </summary>
    public SceneManager()
    {
        _scenes = new Dictionary<int, SceneBase>();
        _currentScene = null;
        _previousKeyboardState = Keyboard.GetState();
    }
    #endregion

    #region Public Voids
    /// <summary>
    /// Updates the current active scene and ensures switching between scenes is possible.
    /// </summary>
    /// <param name="pGameTime">The current game time.</param>
    public void Update(GameTime pGameTime)
    {
        KeyboardState currentKeyboardState = Keyboard.GetState();

        for (int i = 0; i <= _scenes.Count; i++)
        {
            Keys key = (Keys)((int)Keys.D1 + i);
            if (currentKeyboardState.IsKeyDown(key) && !_previousKeyboardState.IsKeyDown(key))
                SetCurrentScene(i + 1); // Starts indexing at 1.
        }

        _previousKeyboardState = currentKeyboardState;

        _currentScene?.Update(pGameTime);
    }

    /// <summary>
    /// Draws the current scene.
    /// </summary>
    /// <param name="pSpriteBatch">The SpriteBatch used for drawing.</param>
    public void Draw(SpriteBatch pSpriteBatch) => _currentScene?.Draw(pSpriteBatch);

    /// <summary>
    /// Adds a new scene to the Scenes list, should the scene key not already exist in the list.
    /// </summary>
    /// <param name="pKey">The key (int) associated with the added scene.</param>
    /// <param name="pScene">The scene to add.</param>
    public void AddScene(int pKey, SceneBase pScene)
    {
        if (!_scenes.ContainsKey(pKey))
            _scenes[pKey] = pScene;
    }

    /// <summary>
    /// Sets the active scene, based on the provided key.
    /// </summary>
    /// <param name="pKey">The key of the scene to set as active.</param>
    public void SetCurrentScene(int pKey)
    {
        if (_scenes.ContainsKey(pKey))
            _currentScene = _scenes[pKey];
    }
    #endregion
}
