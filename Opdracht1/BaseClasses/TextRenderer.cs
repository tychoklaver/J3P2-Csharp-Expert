namespace J3P2_Csharp_Expert.Opdracht1.BaseClasses;

/// <summary>
/// Used to render text to the screen.
/// </summary>
public class TextRenderer
{
    #region Fields
    private readonly SpriteFont _font;
    private string _text;
    private readonly Vector2 _offset;
    private readonly Color _color;
    #endregion

    #region Properties
    /// <summary>
    /// The GameObject the renderer is attached to.
    /// </summary>
    public GameObject Parent { private get; set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the TextRenderer.
    /// </summary>
    /// <param name="pFont">The font which the text uses.</param>
    /// <param name="pText">The text to render.</param>
    /// <param name="pOffset">The offset to position the text, relative to the position of the Parent.</param>
    /// <param name="pColor">The color of the text.</param>
    public TextRenderer(SpriteFont pFont, string pText, Vector2 pOffset, Color pColor)
    {
        _font = pFont ?? throw new ArgumentNullException(nameof(pFont));
        _text = pText ?? throw new ArgumentNullException(nameof(pText));
        _offset = pOffset;
        _color = pColor;
    }
    #endregion

    #region Public Voids
    /// <summary>
    /// Used to draw the text on the screen.
    /// </summary>
    /// <param name="pSpriteBatch">The SpriteBatch used for drawing.</param>
    public void DrawText(SpriteBatch pSpriteBatch)
    {
        if (Parent == null || _font == null || string.IsNullOrEmpty(_text)) 
            return;

        Vector2 textSize = _font.MeasureString(_text);
        Vector2 drawPosition = new(
            Parent.Transform.Position.X + _offset.X - (textSize.X / 2),
            Parent.Transform.Position.Y + _offset.Y - (textSize.Y / 2)
        );

        pSpriteBatch.DrawString(
            _font,
            _text,
            drawPosition,
            _color);
    }

    public void UpdateText(string pText) => _text = pText;
    #endregion
}
