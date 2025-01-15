using SwApiNet.Wrappers.Models.Enums;

namespace SwApiNet.Wrappers.Models.Steam;

public partial struct Callback
{
    public partial struct Fields
    {
        public CallbackFlags CallbackFlags;
        public CallbackType CallbackType;
    }
}