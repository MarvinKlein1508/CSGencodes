using CSGO_GEN.Core.Models;
using CSGO_GEN.Core.Utilities;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CEconItemPreviewDataBlock.Types;

namespace CSGO_GEN.Core.Services
{
    public class InspectLinkService
    {
        private Crc32 _crc = new();


        public string GenerateInspectLink(Weapon weapon, decimal @float, int pattern, List<AppliedSticker> stickers)
        {
            CEconItemPreviewDataBlock proto = new CEconItemPreviewDataBlock();

            proto.Rarity = (uint)weapon.RarityId;
            proto.Defindex = (uint)weapon.weapon_id;
            proto.Paintindex = (uint)weapon.gen_id;
            proto.Paintseed = (uint)pattern;
            byte[] paintWearBytes = BitConverter.GetBytes((float)@float);
            Array.Reverse(paintWearBytes); // Convert to big-endian
            proto.Paintwear = BitConverter.ToUInt32(paintWearBytes, 0);

            if (stickers.Any())
            {
                int slot = 0;
                foreach (AppliedSticker sticker in stickers.OrderBy(x => x.PosId))
                {
                    CEconItemPreviewDataBlock.Types.Sticker proto_sticker = new()
                    {
                        Slot = (uint)slot++,
                        StickerId = (uint)sticker.gen_id,
                        Wear = (float)sticker.Scratched,
                    };
                    proto.Stickers.Add(proto_sticker);
                }

            }

            return $"steam://rungame/730/76561202255233023/+csgo_econ_action_preview%20{GenerateInspect(proto)}";
        }

        private string GenerateInspect(CEconItemPreviewDataBlock proto)
        {
            // Serialize the protobuf message to a byte array
            byte[] protoBytes = proto.ToByteArray();

            // Prefix with a null byte
            byte[] buffer = new byte[protoBytes.Length + 1];
            buffer[0] = 0;
            Array.Copy(protoBytes, 0, buffer, 1, protoBytes.Length);

            // Calculate the checksum

            var crc = _crc.ComputeHash(buffer);

            // XOR the CRC with the product of protoByteSize and the original CRC
            uint normalCrc = BitConverter.ToUInt32(crc);
            uint protoSize = (uint)proto.CalculateSize();
            uint xoredCrc = unchecked((ushort)normalCrc) ^ (protoSize * normalCrc);


            // Append the CRC to the buffer
            byte[] crcBytes = BitConverter.GetBytes(xoredCrc);
            Array.Reverse(crcBytes); // Convert to big-endian
            buffer = buffer.Concat(crcBytes).ToArray();


            // Convert the byte array to a hex string (uppercase)
            StringBuilder hexBuilder = new StringBuilder(buffer.Length * 2);
            foreach (byte b in buffer)
            {
                hexBuilder.AppendFormat("{0:X2}", b);
            }

            return hexBuilder.ToString().ToUpper();
        }
    }
}
