namespace Data
{
    // ------------------------------------------------------------------------
    public class GameData
    {
        public string CurrentScene = "Sandbox";

        public void SetScene(string sceneName)
        {
            CurrentScene = sceneName;
        }
    }

    // ------------------------------------------------------------------------
    public static class Game
    {
        private static GameData _currentData;

        public static GameData GetData()
        {
            return _currentData ?? (_currentData = new GameData());
        }
    }
}