namespace Game.Models
{
    public static class Modeler
    {
        public static ModelGame ModelGame { get; } = new ModelGame();
        public static ModelWorld ModelWorld { get; } = new ModelWorld();
        public static ModelBall ModelBall { get; } = new ModelBall();
        
        public static void Init()
        {
            ModelWorld.Init();
        }
    }
}