
using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    class SettingsSaveObject
    {
        public float Volume { get; set; } = 0.1f;
        public int FrameLimit { get; set; } = -1;
        public int VSync { get; set; } = 1;
        public SettingsSaveObject()
        {

        }
        public SettingsSaveObject WithVolume(float volume)
        {
            Volume = volume;
            return this;
        }
        public SettingsSaveObject WithFrameLimit(int frameLimit)
        {
            FrameLimit = frameLimit;
            return this;
        }
        public SettingsSaveObject WithVSync(int vsync)
        {
            VSync = vsync;
            return this;
        }
    }
}
