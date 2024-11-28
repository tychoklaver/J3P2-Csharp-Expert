using J3P2_Csharp_Expert.Opdracht3.BaseClasses;

namespace J3P2_Csharp_Expert.Opdracht3.GameObjects;

/// <summary>
/// Represents a bouncing object in a 2D space.
/// </summary>
public class BouncerObject : GameObject
{
    private Vector2 _startPosition;
    private float _time;
    private readonly float _bounceSpeed;
    private readonly float _amplitude;
    private Vector2 _bounceDirection;


    /// <summary>
    /// Initializes a new object of the <see cref="BouncerObject"/> class
    /// </summary>
    /// <param name="pTexture">The texture to render for this object.</param>
    /// <param name="pPosition">The initial position of the object.</param>
    /// <param name="pBounceSpeedInSeconds">The speed of the bounce, in cycles per second.</param>
    /// <param name="pAmplitude">The ampliude of the bounce.</param>
    /// <param name="pBounceDirection">The direction of the bounce as a <see cref="Vector2"/></param>
    public BouncerObject(Texture2D pTexture, Vector2 pPosition, float pBounceSpeedInSeconds, float pAmplitude, Vector2 pBounceDirection) : base(pTexture, pPosition)
    {
        _startPosition = pPosition;
        _bounceSpeed = pBounceSpeedInSeconds;
        _amplitude = pAmplitude;
        _bounceDirection = Vector2.Normalize(pBounceDirection); // Normalizes the direction, so it's equal along diagonals.
        _time = 0f;
    }

    /// <summary>
    /// Updates the position of the object based on elapsed time and the bounce pattern.
    /// </summary>
    /// <param name="pGameTime">The current game time.</param>
    public override void Update(GameTime pGameTime)
    {
        _time += (float)pGameTime.ElapsedGameTime.TotalSeconds;

        float offset = CalculateBounceOffset();

        UpdatePosition(offset);
    }

    /// <summary>
    /// Calculates the offset from the startin position based on the bounce pattern.
    /// </summary>
    /// <returns>The offset distance along the bounce direction.</returns>
    private float CalculateBounceOffset()
    {
        float sineValue = MathF.Sin(_time * _bounceSpeed * MathF.Tau);
        return sineValue * _amplitude;
    }

    /// <summary>
    /// Updates the position of the object, based on the calculated offset.
    /// </summary>
    /// <param name="pOffset">The calculated bounce offset.</param>
    private void UpdatePosition(float pOffset)
    {
        Vector2 newPosition = _startPosition + _bounceDirection * pOffset;
        Transform.UpdatePosition(newPosition);
    }
}
