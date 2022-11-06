namespace Game.ECSComponents
{
    /// <summary>
    /// Команда спавна стены по краям сцены.
    /// </summary>
    public struct WallSpawnCmd
    {
        public float x, y;
    }

    /// <summary>
    /// Событие удаления стены.
    /// </summary>
    public struct WallDestroyedEvent {};

    /// <summary>
    /// Тег стены.
    /// Помогает пересоздавать объект этого типа при удалении старого.
    /// </summary>
    public struct WallTag {}
}