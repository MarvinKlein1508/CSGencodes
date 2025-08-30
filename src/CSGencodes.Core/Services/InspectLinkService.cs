using CSGencodes.Core.Models;
using CSGencodes.Core.Utilities;
using Google.Protobuf;
using System.Text;

namespace CSGencodes.Core.Services;

public class InspectLinkService
{
    private readonly Crc32 _crc = new();

    public (string url, bool commandMode) GenerateInspectLink(Weapon weapon, decimal @float, int pattern, string customName, List<AppliedSticker> stickers)
    {
        CEconItemPreviewDataBlock proto = new CEconItemPreviewDataBlock();

        proto.Rarity = (uint)weapon.RarityId;
        proto.Defindex = (uint)weapon.WeaponId;
        proto.Paintindex = (uint)weapon.PaintKitId;
        proto.Paintseed = (uint)pattern;

        if (!string.IsNullOrWhiteSpace(customName))
        {
            proto.Customname = customName;
        }


        byte[] paintWearBytes = BitConverter.GetBytes((float)@float);
        //Array.Reverse(paintWearBytes); // Convert to big-endian
        proto.Paintwear = BitConverter.ToUInt32(paintWearBytes, 0);

        if (stickers.Count != 0)
        {

            foreach (AppliedSticker sticker in stickers.OrderBy(x => x.PosId))
            {
                CEconItemPreviewDataBlock.Types.Sticker proto_sticker = new()
                {
                    Slot = (uint)sticker.PosId,
                    StickerId = (uint)sticker.StickerId
                };

                if (sticker.OffsetX != 0)
                {
                    proto_sticker.OffsetX = sticker.OffsetX;
                }

                if (sticker.OffsetY != 0)
                {
                    proto_sticker.OffsetY = sticker.OffsetY;
                }

                if (sticker.Scratched != 0)
                {
                    proto_sticker.Wear = (float)sticker.Scratched;
                }

                if (sticker.Rotation != 0)
                {
                    proto_sticker.Rotation = (float)sticker.Rotation;
                }

                proto.Stickers.Add(proto_sticker);
            }

        }

        string baseUrl = "steam://rungame/730/76561202255233023/+csgo_econ_action_preview%20";
        string inspect = GenerateInspect(proto);

        // 300 is the max size which steam will open, otherwise console is needed for preview
        if (inspect.Length + baseUrl.Length > 300)
        {
            return ($"csgo_econ_action_preview {inspect}", true);
        }

        return ($"{baseUrl}{inspect}", false);
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
