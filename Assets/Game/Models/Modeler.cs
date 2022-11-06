namespace Game.Models
{
    public static class Modeler
    {
        public static ModelGame ModelGame { get; } = new ModelGame();
        public static ModelWorld ModelWorld { get; } = new ModelWorld();
        public static ModelBall ModelBall { get; } = new ModelBall();
        public static ModelPrefs ModelPrefs { get; } = new ModelPrefs();
        
        public static void Init()
        {
            ModelWorld.Init();
            ModelPrefs.Init();
        }
    }
}