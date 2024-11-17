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
    public Vector2 Position { get; private set; }

    /// <summary>
    /// Gets or sets the rotation of the object.
    /// </summary>
    public float Rotation { get; private set; }

    /// <summary>
    /// Gets or sets the scale of the object.
    /// </summary>
    public Vector2 Scale { get; private set; }

    /// <summary>
    /// Gets or sets the origin point of the object (dynamically, relative to its size).
    /// </summary>
    public Vector2 Origin { get; private set; }
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

    public Transform(Vector2 pPosition)
    {
        Position = pPosition;
        Rotation = 0f;
        Scale = Vector2.One;
        Origin = new Vector2(0.5f, 0.5f);
    }
    #endregion

    #region Public Voids
    /// <summary>
    /// Updates the position of the GameObject.
    /// </summary>
    /// <param name="pPosition">The new position.</param>
    public void UpdatePosition(Vector2 pPosition) => Position = pPosition;

    /// <summary>
    /// Updates the rotation of the GameObject.
    /// </summary>
    /// <param name="pRotation">The new rotation.</param>
    public void UpdateRotation(float pRotation) => Rotation = pRotation;

    /// <summary>
    /// Updates the scale of the GameObject.
    /// </summary>
    /// <param name="pScale">The new scale.</param>
    public void UpdateScale(Vector2 pScale) => Scale = pScale;

    /// <summary>
    /// Updates the origin of the GameObject.
    /// </summary>
    /// <param name="pOrigin">The new origin.</param>
    public void UpdateOrigin(Vector2 pOrigin) => Origin = pOrigin;

    /// <summary>
    /// Converts the rotation float to degrees.
    /// </summary>
    public float RotationToDegrees() => MathHelper.ToDegrees(Rotation);

    /// <summary>
    /// Converts the rotation float to radians.
    /// </summary>
    public float RotationToRadians() => MathHelper.ToRadians(Rotation);
    #endregion
}
