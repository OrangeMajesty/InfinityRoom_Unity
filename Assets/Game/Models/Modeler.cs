namespace Game.Models
{
    /// <summary>
    /// Класс хранит и управляет runtime даннными.
    /// </summary>
    public static class Modeler
    {
        public static ModelGame ModelGame { get; } = new ModelGame();
        public static ModelWorld ModelWorld { get; } = new ModelWorld();
        public static ModelPrefs ModelPrefs { get; } = new ModelPrefs();
        
        public static void Init()
        {
            ModelWorld.Init();
            ModelPrefs.Init();
        }
    }
}