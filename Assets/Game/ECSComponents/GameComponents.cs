namespace Game.ECSComponents
{
    /// <summary>
    /// Событие начала игры.
    /// </summary>
    public struct GameStartEvent {}
    
    /// <summary>
    ///  Команда запуска уровня.
    /// </summary>
    public struct GameStartCmd {}
    
    /// <summary>
    /// Команда запуска отсчета перед запуском уровня.
    /// </summary>
    public struct GameStartCountDownCmd {}
    
    /// <summary>
    /// Тег запущеной игры, для проверки состояния.
    /// </summary>
    public struct GamePlayingTag {}
}