namespace SwApiNet.Wrappers.Models.Enums;

public enum CallbackType
{
    ValidateAuthTicketResponse = 143, // not initialized at InitCb
    GetAuthSessionTicketResponse = 163,
    GameLobbyJoinRequested = 333,
    LobbyEnter = 504, //RFG uses this with CCallResult and CCallback
    LobbyDataUpdate = 505,
    LobbyChatUpdate = 506,
    LobbyMatchList = 510, //RFG only uses this with CCallResult. not initialized at InitCb
    LobbyCreated = 513, //RFG only uses this with CCallResult. not initialized at InitCb
    SteamUserStatsReceived = 1101, // InitCb gets called twice for this
    SteamUserStatsStored = 1102, // InitCb gets called twice for this
    SteamUserAchievementStored = 1103,
    P2PSessionRequest = 1202,
}

/*
    //Base class for callbacks and call results. Used by the DLL to communicate events/data to the game asynchronously.
    //Callbacks can send data to multiple listeners
    //Call results only send them to one listener
    [CRepr, ReflectAll]
    public struct CCallbackBase
    {
        public CCallbackBase.VTable* Vfptr;

        //So far I've only seen these two fields use with CCallResult<>
        public u8 CallbackFlags;
        public CallbackType CallResultType;

        [CRepr]
        public struct VTable
        {
            public function void(CCallbackBase* this, void* param, u8 param1, u64 param2) Run;
            public function void(CCallbackBase* this, void* param) Run2;
            public function i32(CCallbackBase* this) GetCallbackSizeBytes;
        }
    }

    [CRepr, ReflectAll]
    public struct CCallResult<T, U> : CCallbackBase
    {
        public SteamAPICall ApiCall; //Unique handle for an API call. The vanilla DLL mimics the steamworks API so that's why we use the SteamAPICall type
        public T* Obj;
        public function void(T* this, U* data, bool bIOFailure) Func;
    }

    [CRepr, ReflectAll]
    public struct CCallback<T, U, V> : CCallbackBase where V : const int
    {
        public T* Obj;
        public function void(T* this, U* data) Func;
    }

    public struct LobbyEnter
    {
        public u64 SteamIDLobby; //TODO: Should this be a CSteamID?
        public u32 ChatPermissions;
        public bool Blocked; //TODO: Is this really a bool, or a u8? Naming scheme in rfg.exe indicates its a bool, but the debugger shows it being set to some strange values like 13 (would've expected 255 for true and 0 for false)
        public u32 ChatRoomEnterResponse; //Likely an enum
    }

    public struct LobbyDataUpdate
    {
        public u64 SteamIDLobby;
        public u64 SteamIDMember;
        public bool Success;
    }

    struct CallbackLogger<T> : CCallbackBase where T : struct
    {
        public CallbackType CallbackType;
        public CCallbackBase* Original;
        private CCallbackBase.VTable* _originalVtable = null;
        private CCallbackBase.VTable _loggedVtable = .();

        public this(CCallbackBase* original, CallbackType callbackType)
        {
            CallbackType = callbackType;
            Original = original;

            //Point the struct to a new vtable that logs any calls then passes them onto the real vtable
            _originalVtable = Original.Vfptr;
            _loggedVtable.Run = => Run;
            _loggedVtable.Run2 = => Run2;
            _loggedVtable.GetCallbackSizeBytes = => GetCallbackSizeBytes;

            base.Vfptr = &_loggedVtable;
            base.CallResultType = original.CallResultType;
            base.CallbackFlags = original.CallbackFlags;

            Original.Vfptr = &_loggedVtable;
        }

        public void Cleanup()
        {
            Original.Vfptr = _originalVtable;
        }

        public void Run(void* param, u8 param1, u64 param2)
        {
            //Convert param and its fields to string and log it
            String dataFields = scope .();
            gBonEnv.serializeFlags |= .Verbose;
            Bon.Serialize<T>(*(T*)param, dataFields);

            String logString = scope $"[CALLBACK] {CallbackType.ToString(.. scope .())}.Run({typeof(T).GetName(.. scope .())}* param:\n{dataFields},\nuint8 param1: {param1}, uint64 param2: {param2})";
            logString.Replace("{", "{{"); //Have to escape these so StreamWriter doesn't think they're formatting parameters
            logString.Replace("}", "}}");
            Logger.WriteLine(logString);

            //Call original vtable func
            _originalVtable.Run(Original, param, param1, param2);
        }

        public void Run2(void* param)
        {
            //Convert param and its fields to string and log it
            String dataFields = scope .();
            gBonEnv.serializeFlags |= .Verbose;
            Bon.Serialize<T>(*(T*)param, dataFields);

            String logString = scope $"[CALLBACK] {CallbackType.ToString(.. scope .())}.Run2({typeof(T).GetName(.. scope .())}* param:\n{dataFields})";
            logString.Replace("{", "{{");
            logString.Replace("}", "}}");
            Logger.WriteLine(logString);

            //Call original vtable func
            _originalVtable.Run2(Original, param);
        }

        public i32 GetCallbackSizeBytes()
        {
            i32 result = _originalVtable.GetCallbackSizeBytes(Original);
            Logger.WriteLine(scope $"[CALLBACK] {CallbackType.ToString(.. scope .())}.GetCallbackSizeBytes() -> {result}");
            return result;
        }
    }
    ==================================================================================
    ==================================================================================
    ==================================================================================
    ==================================================================================
struct CallResultLogger <T> : CCallbackBase where T : struct
    {
        public u32 APICallLower;
        public u32 APICallUpper;
        public CCallbackBase* Original;
        private CCallbackBase.VTable* _originalVtable = null;
        private CCallbackBase.VTable _loggedVtable = .();

        public this(CCallbackBase* original, u32 apiCallLower, u32 apiCallUpper)
        {
            APICallLower = apiCallLower;
            APICallUpper = apiCallUpper;
            Original = original;

            //Point the struct to a new vtable that logs any calls then passes them onto the real vtable
            _originalVtable = Original.Vfptr;
            _loggedVtable.Run = => Run;
            _loggedVtable.Run2 = => Run2;
            _loggedVtable.GetCallbackSizeBytes = => GetCallbackSizeBytes;

            base.Vfptr = &_loggedVtable;
            base.CallResultType = original.CallResultType;
            base.CallbackFlags = original.CallbackFlags;

            Original.Vfptr = &_loggedVtable;
        }

        public void Cleanup()
        {
            Original.Vfptr = _originalVtable;
        }

        public void Run(void* param, u8 param1, u64 param2)
        {
            //Convert param and its fields to string and log it
            String dataFields = scope .();
            gBonEnv.serializeFlags |= .Verbose;
            Bon.Serialize<T>(*(T*)param, dataFields);

            String logString = scope $"[CALL_RESULT] {CallResultType.ToString(.. scope .())}.Run({typeof(T).GetName(.. scope .())}* param:\n{dataFields},\nuint8 param1: {param1}, uint64 param2: {param2})";
            logString.Replace("{", "{{"); //Have to escape these so StreamWriter doesn't think they're formatting parameters
            logString.Replace("}", "}}");
            Logger.WriteLine(logString);

            //Call original vtable func
            _originalVtable.Run(Original, param, param1, param2);
        }

        public void Run2(void* param)
        {
            //Convert param and its fields to string and log it
            String dataFields = scope .();
            gBonEnv.serializeFlags |= .Verbose;
            Bon.Serialize<T>(*(T*)param, dataFields);

            String logString = scope $"[CALL_RESULT] {CallResultType.ToString(.. scope .())}.Run2({typeof(T).GetName(.. scope .())}* param:\n{dataFields})";
            logString.Replace("{", "{{");
            logString.Replace("}", "}}");
            Logger.WriteLine(logString);

            //Call original vtable func
            _originalVtable.Run2(Original, param);
        }

        public i32 GetCallbackSizeBytes()
        {
            i32 result = _originalVtable.GetCallbackSizeBytes(Original);
            Logger.WriteLine(scope $"[CALL_RESULT] {base.CallResultType.ToString(.. scope .())}.GetCallbackSizeBytes() -> {result}");
            return result;
        }
    }
*/
