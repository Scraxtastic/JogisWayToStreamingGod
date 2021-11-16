
namespace Assets.Scripts
{
    [System.Serializable]
    class SettingsSaveObject
    {
        public float Volume { get; set; } = 0.1f;
        public SettingsSaveObject()
        {

        }
        public SettingsSaveObject withVolume(float volume)
        {
            Volume = volume;
            return this;
        }
    }
}
