namespace Game.Models
{
    public static class Modeler
    {
        public static ModelGame ModelGame { get; private set; }

        public static void Init()
        {
            ModelGame = new ModelGame();
        }
    }
}