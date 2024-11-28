using J3P2_Csharp_Expert.Opdracht2.BaseClasses;

namespace J3P2_Csharp_Expert.Opdracht2.GameObjects;

/// <summary>
/// Represents a scaling object in a 2D space.
/// </summary>
public class ScalerObject : GameObject
{
    private float _time;
    private readonly float _speed;
    private Vector2 _minScale;
    private Vector2 _maxScale;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScalerObject"/> class.
    /// </summary>
    /// <param name="pTexture">The texture used for drawing this object.</param>
    /// <param name="pPosition">The initial position of this object.</param>
    /// <param name="pSpeed">The speed of which the object scales.</param>
    /// <param name="minScale">The minimum scale, in <see cref="Vector2"/>. Default is null.</param>
    /// <param name="maxScale">The maximum scale, in <see cref="Vector2"/>. Default is null.</param>
    public ScalerObject(Texture2D pTexture, Vector2 pPosition, float pSpeed, Vector2? pMinScale = null, Vector2? pMaxScale = null) : base(pTexture, pPosition)
    {
        _speed = pSpeed;
        _minScale = pMinScale ?? Vector2.Zero;
        _maxScale = pMaxScale ?? new Vector2(1f, 1f);
    }

    /// <summary>
    /// Updates the scaling of the object.
    /// </summary>
    /// <param name="pGameTime">The current game time.</param>
    public override void Update(GameTime pGameTime)
    {
        _time += (float)pGameTime.ElapsedGameTime.TotalSeconds;

        // Calculates sine value for the scaling, normalized after initial sin formula.
        float sineValue = MathF.Sin(_time * _speed * MathF.Tau); 
        float normalizedSine = (sineValue + 1f) / 2f; 

        Transform.UpdateScale(ReturnNewScale(normalizedSine));
    }

    /// <summary>
    /// Calculates the new scale for the object, based on sine value.
    /// </summary>
    /// <param name="pNormalizedSineValue">The calculated sine value.</param>
    /// <returns>The new scaling of the object.</returns>
    private Vector2 ReturnNewScale(float pNormalizedSineValue)
    {
        Vector2 scaleRange = _maxScale - _minScale;
        return _minScale + scaleRange * pNormalizedSineValue;
    }
}
