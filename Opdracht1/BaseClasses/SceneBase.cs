namespace J3P2_Csharp_Expert.Opdracht1.BaseClasses;

/// <summary>
/// An abstract base class for defining scenes in the game.
/// Classes which derive from this class must implement the Update and Draw functions.
/// </summary>
public abstract class SceneBase
{
    #region Public Voids
    /// <summary>
    /// Updates the scene Logic. Derived classes must implement the Update void.
    /// </summary>
    /// <param name="pGameTime">The current game time.</param>
    public abstract void Update(GameTime pGameTime);

    /// <summary>
    /// Draws the scene to the screen. Derived classes must implement the Draw void.
    /// </summary>
    /// <param name="pSpriteBatch">The SpriteBatch used for drawing.</param>
    public abstract void Draw(SpriteBatch pSpriteBatch);
    #endregion
}
