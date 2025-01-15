using SwApiNet.Codegen;
using SwApiNet.Wrappers.Models.Enums;
using SwApiNet.Wrappers.Models.Structs;

namespace SwApiNet.Wrappers.Models.Steam;

[StaticVTableProxy]
public unsafe interface ISteamNetworkingVTable
{
    int SendP2PPacket(SteamNetworking* thisPtr, CSteamID steamIDRemote, void* pubData, uint cubData, P2PSend eP2PSendType, int nChannel);
    int IsP2PPacketAvailable(SteamNetworking* thisPtr, uint* pcubMsgSize, int nChannel);
    int ReadP2PPacket(SteamNetworking* thisPtr, void* pubDest, uint cubDest, uint* pcubMsgSize, CSteamID* psteamIDRemote, int nChannel);
    int AcceptP2PSessionWithUser(SteamNetworking* thisPtr, CSteamID steamIDRemote);
    int CloseP2PSessionWithUser(SteamNetworking* thisPtr, CSteamID steamIDRemote);
    int CloseP2PChannelWithUser(SteamNetworking* thisPtr, CSteamID steamIDRemote, int nChannel);
    int GetP2PSessionState(SteamNetworking* thisPtr, CSteamID steamIDRemote, P2PSessionState* pConnectionState);
    int AllowP2PPacketRelay(SteamNetworking* thisPtr, int bAllow);
    SNetListenSocket CreateListenSocket(SteamNetworking* thisPtr, int nVirtualP2PPort, uint nIP, ushort nPort, int bAllowUseOfPacketRelay);
    SNetSocket CreateP2PConnectionSocket(SteamNetworking* thisPtr, CSteamID steamIDTarget, int nVirtualPort, int nTimeoutSec, int bAllowUseOfPacketRelay);
    SNetSocket CreateConnectionSocket(SteamNetworking* thisPtr, uint nIP, ushort nPort, int nTimeoutSec);
    int DestroySocket(SteamNetworking* thisPtr, SNetSocket hSocket, int bNotifyRemoteEnd);
    int DestroyListenSocket(SteamNetworking* thisPtr, SNetListenSocket hSocket, int bNotifyRemoteEnd);
    int SendDataOnSocket(SteamNetworking* thisPtr, SNetSocket hSocket, void* pubData, uint cubData, int bReliable);
    int IsDataAvailableOnSocket(SteamNetworking* thisPtr, SNetSocket hSocket, uint* pcubMsgSize);
    int RetrieveDataFromSocket(SteamNetworking* thisPtr, SNetSocket hSocket, void* pubDest, uint cubDest, uint* pcubMsgSize);
    int IsDataAvailable(SteamNetworking* thisPtr, SNetListenSocket hListenSocket, uint* pcubMsgSize, SNetSocket* phSocket);
    int RetrieveData(SteamNetworking* thisPtr, SNetListenSocket hListenSocket, void* pubDest, uint cubDest, uint* pcubMsgSize, SNetSocket* phSocket);
    int GetSocketInfo(SteamNetworking* thisPtr, SNetSocket hSocket, CSteamID* pSteamIDRemote, int* peSocketStatus, uint* punIPRemote, ushort* punPortRemote);
    int GetListenSocketInfo(SteamNetworking* thisPtr, SNetListenSocket hListenSocket, uint* pnIP, ushort* pnPort);
    SNetSocketConnectionType GetSocketConnectionType(SteamNetworking* thisPtr, SNetSocket hSocket);
    int GetMaxPacketSize(SteamNetworking* thisPtr, SNetSocket hSocket);
}
