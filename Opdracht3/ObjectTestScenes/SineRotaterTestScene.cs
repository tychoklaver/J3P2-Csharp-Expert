using J3P2_Csharp_Expert.Opdracht3.BaseClasses;
using J3P2_Csharp_Expert.Opdracht3.GameObjects;

namespace J3P2_Csharp_Expert.Opdracht3.ObjectTestScenes;
public class SineRotaterTestScene : SceneBase
{
    private GameObject _gameObject;
    private GameObject _textObject;
    public SineRotaterTestScene(Texture2D pTexture, SpriteFont pFont)
    {
        _gameObject = InitializeGameObject(pTexture, new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2), 1f, -30f, 180f);
        _gameObject.AddTextRenderer(new TextRenderer(pFont, $"{_gameObject.Transform.Position:F1}", new Vector2(50, -50), Color.White));
    }

    public override void Update(GameTime pGameTime)
    {
        _gameObject.Update(pGameTime);
        _gameObject.TextRenderers.ForEach(j => j.UpdateText($"X: {_gameObject.Transform.Position.X:F0} | Y: {_gameObject.Transform.Position.Y:F0}"));
    }

    public override void Draw(SpriteBatch pSpriteBatch)
    {
        _gameObject.Draw(pSpriteBatch);
    }

    private GameObject InitializeGameObject(Texture2D pTexture, Vector2 pPosition, float pRotatingSpeed, float pMinRotation, float pMaxRotation)
    {
        return new SineRotaterObject(pTexture, pPosition, pRotatingSpeed, pMinRotation, pMaxRotation);
    }

}
