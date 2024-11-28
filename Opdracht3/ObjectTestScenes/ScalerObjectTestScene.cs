using J3P2_Csharp_Expert.Opdracht3.BaseClasses;
using J3P2_Csharp_Expert.Opdracht3.GameObjects;

namespace J3P2_Csharp_Expert.Opdracht3.ObjectTestScenes;
public class ScalerObjectTestScene : SceneBase
{
    private GameObject _gameObject;
    public ScalerObjectTestScene(Texture2D pTexture, SpriteFont pFont)
    {
        _gameObject = InitializeGameObject(pTexture, new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2), 1f, new Vector2(-2.5f, -3f), new Vector2(2.5f, 3f));
        _gameObject.AddTextRenderer(new TextRenderer(pFont, $"{_gameObject.Transform.Scale:F0}", new Vector2(50, -50), Color.White));
    }

    public override void Update(GameTime pGameTime)
    {
        _gameObject.Update(pGameTime);
        _gameObject.TextRenderers.ForEach(j => j.UpdateText($"{_gameObject.Transform.Scale:F0}"));
    }

    public override void Draw(SpriteBatch pSpriteBatch)
    {
        _gameObject.Draw(pSpriteBatch);
    }

    private GameObject InitializeGameObject(Texture2D pTexture, Vector2 pPosition, float pScalingSpeed, Vector2? pMinScale = null, Vector2? pMaxScale = null)
    {
        return new ScalerObject(pTexture, pPosition, pScalingSpeed, pMinScale, pMaxScale);
    }
}
