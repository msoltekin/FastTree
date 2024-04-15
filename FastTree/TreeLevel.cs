namespace FastTree
{
    public class TreeLevel
    {
        private readonly short[] levelMapIndex;
        private byte currentMapIndex;
        private const short mapLength = 256;

        public TreeLevel()
        {
            levelMapIndex = new short[mapLength];
            PopulateLevelMap();
        }

        private void PopulateLevelMap()
        {
            for (int i = 0; i < mapLength; i++)
                levelMapIndex[i] = -1;
        }

        public short this[short key]
        {
            get => levelMapIndex[key];
            set => levelMapIndex[key] = value;
        }

        public short InsertItemToMap(byte item)
        {
            if (levelMapIndex[item] > -1) // if character already stored
                return levelMapIndex[item];

            levelMapIndex[item] = currentMapIndex;
            short tmpCurrentMapIndex = currentMapIndex;
            currentMapIndex++;
            return tmpCurrentMapIndex;
        }
    }
}
