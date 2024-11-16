namespace J3P2_Csharp_Expert.Opdracht1.BaseClasses;

/// <summary>
/// Represents the transformation properties of an object, mainly used for it's position.
/// </summary>
public class Transform
{
    #region Properties
    /// <summary>
    /// Gets or sets the position of the object.
    /// </summary>
    public Vector2 Position { get; set; }

    /// <summary>
    /// Gets or sets the rotation of the object.
    /// </summary>
    public float Rotation { get; set; }

    /// <summary>
    /// Gets or sets the scale of the object.
    /// </summary>
    public Vector2 Scale { get; set; }

    /// <summary>
    /// Gets or sets the origin point of the object (dynamically, relative to its size).
    /// </summary>
    public Vector2 Origin { get; set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the Transform, with default values.
    /// </summary>
    public Transform()
    {
        Position = Vector2.Zero;
        Rotation = 0f;
        Scale = Vector2.One;
        Origin = new Vector2(0.5f, 0.5f); // Sets Origin to half the size of the Texture. Further logic handled in SpriteRenderer.
    }
    #endregion
}
