using J3P2_Csharp_Expert.Opdracht3.BaseClasses;

namespace J3P2_Csharp_Expert.Opdracht3.GameObjects;

/// <summary>
/// Represents a object rotating using Sin formula, in a 2D space.
/// </summary>
public class SineRotaterObject : GameObject
{
    private float _time;
    private readonly float _speed;
    private readonly float _minRotation;
    private readonly float _maxRotation;

    /// <summary>
    /// Initializes a new instance of the <see cref="SineRotaterObject"/> class.
    /// </summary>
    /// <param name="pTexture">The texture used to draw this object.</param>
    /// <param name="pPosition">The initial position of the object.</param>
    /// <param name="pSpeed">The speed of which the object rotates and back.</param>
    /// <param name="pMinRotation">The minimum rotation the object goes, where the default is -180f.</param>
    /// <param name="pMaxRotation">The maximum rotation the object goes, where the edfault is 180f</param>
    public SineRotaterObject(Texture2D pTexture, Vector2 pPosition, float pSpeed, float pMinRotation = -180f, float pMaxRotation = 180f) : base(pTexture, pPosition)
    {
        _speed = pSpeed;
        _minRotation = pMinRotation;
        _maxRotation = pMaxRotation;
    }

    /// <summary>
    /// Updates the object's rotation.
    /// </summary>
    /// <param name="pGameTime">The current game time.</param>
    public override void Update(GameTime pGameTime)
    {
        _time += (float)pGameTime.ElapsedGameTime.TotalSeconds;

        float sineValue = MathF.Sin(_time * _speed * MathF.Tau);

        Transform.UpdateRotation(ReturnNewRotation(sineValue));
    }

    /// <summary>
    /// Calculates the rotation of the object, based on the calculated sine value.
    /// </summary>
    /// <param name="pSineValue">The calculated sine value.</param>
    /// <returns>The object's new rotation.</returns>
    private float ReturnNewRotation(float pSineValue)
    {
        // Calculates the rotation of the object, based on the calculated sine value.
        float rotationRange = (_maxRotation - _minRotation);
        float midPoint = _minRotation + (rotationRange / 2);
        return midPoint + (rotationRange / 2) * pSineValue;
    }
}
