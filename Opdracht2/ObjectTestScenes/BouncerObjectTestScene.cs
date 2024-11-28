using J3P2_Csharp_Expert.Opdracht2.BaseClasses;
using J3P2_Csharp_Expert.Opdracht2.GameObjects;
using Microsoft.Xna.Framework;

namespace J3P2_Csharp_Expert.Opdracht2.ObjectTestScenes;
public class BouncerObjectTestScene : SceneBase
{
    private GameObject _gameObject;
    private GameObject _gameObject2;
    private GameObject _gameObject3;
    private GameObject _gameObject4;
    private GameObject _textObject;
    public BouncerObjectTestScene(Texture2D pTexture, SpriteFont pFont)
    {
        _gameObject = InitializeGameObject(pTexture, new Vector2(Game1.ScreenWidth * 0.5f, Game1.ScreenHeight * 0.1f), 0.1f, 540f, new Vector2(1f, 0f));
        _gameObject2 = InitializeGameObject(pTexture, new Vector2(Game1.ScreenWidth * 0.5f, Game1.ScreenHeight * 0.3f), 0.2f, 580f, new Vector2(1f, 0f));
        _gameObject3 = InitializeGameObject(pTexture, new Vector2(Game1.ScreenWidth * 0.5f, Game1.ScreenHeight * 0.6f), 0.4f, 560f, new Vector2(1f, 0f));
        _gameObject4 = InitializeGameObject(pTexture, new Vector2(Game1.ScreenWidth * 0.5f, Game1.ScreenHeight * 0.9f), 0.8f, 520f, new Vector2(1f, 0f));

        _gameObject.AddTextRenderer(new TextRenderer(pFont, $"{_gameObject.Transform.Position:F1}", new Vector2(50, -50), Color.White));
    }

    public override void Update(GameTime pGameTime)
    { 
        _gameObject.Update(pGameTime);
        _gameObject2.Update(pGameTime);
        _gameObject3.Update(pGameTime);
        _gameObject4.Update(pGameTime);
        _gameObject.TextRenderers.ForEach(j => j.UpdateText($"X: {_gameObject.Transform.Position.X:F0} | Y: {_gameObject.Transform.Position.Y:F0}"));
    }

    public override void Draw(SpriteBatch pSpriteBatch)
    {
        _gameObject.Draw(pSpriteBatch);
        _gameObject2.Draw(pSpriteBatch);
        _gameObject3.Draw(pSpriteBatch);
        _gameObject4.Draw(pSpriteBatch);
    }

    private GameObject InitializeGameObject(Texture2D pTexture, Vector2 pPosition, float pBouncingSpeed, float pAmplitude, Vector2 pBounceDirection)
    {
        return new BouncerObject(pTexture, pPosition, pBouncingSpeed, pAmplitude, pBounceDirection);
    }

}
