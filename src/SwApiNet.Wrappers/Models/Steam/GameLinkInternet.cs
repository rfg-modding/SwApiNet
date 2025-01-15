using SwApiNet.Wrappers.Models.Enums;

namespace SwApiNet.Wrappers.Models.Steam;

partial struct GameLinkInternet
{
    partial struct Fields
    {
        public GameLinkState State;
        public GameLinkError Error;
        public int PlatformErrorCode;
        public int GameplayRunning;
        public double VoicechatVolume;
    }
}