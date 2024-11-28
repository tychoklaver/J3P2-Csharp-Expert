using J3P2_Csharp_Expert.Opdracht2.BaseClasses;
using J3P2_Csharp_Expert.Opdracht2.GameObjects;

namespace J3P2_Csharp_Expert.Opdracht2.ObjectTestScenes;
internal class RotaterObjectTestScene : SceneBase
{
    private GameObject _gameObject;
    public RotaterObjectTestScene(Texture2D pTexture, SpriteFont pFont)
    {
        _gameObject = InitializeGameObject(pTexture, new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2), 2f, true);
        _gameObject.AddTextRenderer(new TextRenderer(pFont, $"{_gameObject.Transform.Rotation:F1}", new Vector2(50, -50), Color.White));
    }

    public override void Update(GameTime pGameTime)
    {
        float deltaSeconds = (float)pGameTime.ElapsedGameTime.TotalSeconds;
        float previousRotation = _gameObject.Transform.Rotation;
        _gameObject.Update(pGameTime);
        float currentRotation = _gameObject.Transform.Rotation;
        float rotationDelta = currentRotation - previousRotation;

        int displayedRotation = ((int)currentRotation % 360 + 360) % 360;

        float rotationsPerSecond = Math.Abs(rotationDelta / 360f) / deltaSeconds;
        _gameObject.TextRenderers.ForEach(j => j.UpdateText($"{displayedRotation} | RPS: {rotationsPerSecond:F2}"));
    }

    public override void Draw(SpriteBatch pSpriteBatch)
    {
        _gameObject.Draw(pSpriteBatch);
    }

    private GameObject InitializeGameObject(Texture2D pTexture, Vector2 pPosition, float pRotationSpeed, bool pIsClockwise)
    {
        return new RotaterObject(pTexture, pPosition, pRotationSpeed, pIsClockwise);
    }

}
