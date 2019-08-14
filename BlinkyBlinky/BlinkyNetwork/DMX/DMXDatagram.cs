namespace BlinkyNetwork
{
    public class DMXDatagram
    {
        public byte[] Buffer = new byte[512];
        public short UniverseNo;
        public string NetworkName { get; private set; }
        
        public DMXDatagram(byte[] _buffer, short _universeNo, string _networkName)
        {
            Buffer = _buffer;
            UniverseNo = _universeNo;
            NetworkName = _networkName;
        }
    }
}