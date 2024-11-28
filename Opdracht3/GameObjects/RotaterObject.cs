using J3P2_Csharp_Expert.Opdracht3.BaseClasses;

namespace J3P2_Csharp_Expert.Opdracht3.GameObjects;

/// <summary>
/// Represents a rotation object in a 2D space.
/// </summary>
public class RotaterObject : GameObject
{
    private readonly float _rotationSpeed;
    private readonly bool _isClockwise;

    /// <summary>
    /// Initializes a new instance of the <see cref="RotaterObject"/> class.
    /// </summary>
    /// <param name="pTexture">The Texture used for drawing this object.</param>
    /// <param name="pPosition">The initial position of this object.</param>
    /// <param name="pRotationSpeed">The rotation speed in revolutons per second.</param>
    /// <param name="pIsClockwise">Returns true if object rotates clockwise; otherwise, false.</param>
    public RotaterObject(Texture2D pTexture, Vector2 pPosition, float pRotationSpeed, bool pIsClockwise) : base(pTexture, pPosition)
    {
        _rotationSpeed = pRotationSpeed;
        _isClockwise = pIsClockwise;
    }

    /// <summary>
    /// Updates the rotation of the object.
    /// </summary>
    /// <param name="pGameTime">The current game time.</param>
    public override void Update(GameTime pGameTime)
    {
        float deltaSeconds = (float)pGameTime.ElapsedGameTime.TotalSeconds;

        Transform.IncrementRotation(ReturnRotationDelta(deltaSeconds)); 
    }

    /// <summary>
    /// Calculates change in rotation, based on the elapsed time and rotation speed.
    /// </summary>
    /// <param name="pDeltaSeconds">The time elapsed in seconds.</param>
    /// <returns>The change of rotatonal value in degrees. A positive value indicates clockwise rotation, while negative a negaive value indicates counterclockwise rotation.</returns>
    private float ReturnRotationDelta(float pDeltaSeconds)
    {
        float rotationDelta = _rotationSpeed * pDeltaSeconds * 360f; // Calculates rotation delta by RPS.
        return rotationDelta *= _isClockwise ? 1 : -1; // Applies clockwise/counterclockwise rotation based on calculated delta.
    }

}
