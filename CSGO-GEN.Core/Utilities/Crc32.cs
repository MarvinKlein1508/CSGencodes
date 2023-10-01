using System.Security.Cryptography;

namespace CSGO_GEN.Core.Utilities
{
    /// <summary>
    /// Crc32 class for calculating the CRC32 checksum 
    /// </summary>
    public class Crc32 : HashAlgorithm
    {
        private uint _crc32;

        public Crc32()
        {
            HashSizeValue = 32;
            Initialize();
        }

        public override void Initialize()
        {
            _crc32 = 0xFFFFFFFF;
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            for (int i = ibStart; i < ibStart + cbSize; i++)
            {
                _crc32 ^= array[i];
                for (int j = 0; j < 8; j++)
                {
                    _crc32 = (_crc32 & 1) != 0 ? (_crc32 >> 1) ^ 0xEDB88320 : _crc32 >> 1;
                }
            }
        }

        protected override byte[] HashFinal()
        {
            _crc32 ^= 0xFFFFFFFF;
            return BitConverter.GetBytes(_crc32);
        }
    }
}
