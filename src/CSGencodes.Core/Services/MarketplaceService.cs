using CSGencodes.Core.Models;
using System.Text;
using System.Web;

namespace CSGencodes.Core.Services;

public class MarketplaceService
{
    /// <summary>
    /// Generates a Steam Community Market URL which searchs for all skins with the selected stickers.
    /// </summary>
    /// <returns></returns>
    public string GetSteamMarketUrl(List<AppliedSticker> appliedStickers)
    {
        if (appliedStickers.Count == 0)
        {
            return string.Empty;
        }

        StringBuilder sb = new();
        sb.Append("https://steamcommunity.com/market/search?q=");

        string query = HttpUtility.UrlEncode($"\"{string.Join(",", appliedStickers.Select(x => x.Name))}\"");

        sb.Append(query);
        sb.Append("&descriptions=1&category_730_ItemSet%5B%5D=any&category_730_Weapon%5B%5D=any&category_730_Quality%5B%5D=#p1_price_asc");

        string url = sb.ToString();

        return url;
    }
    public string GetSkinbidUrl(List<AppliedSticker> appliedStickers)
    {
        if (appliedStickers.Count == 0)
        {
            return string.Empty;
        }

        StringBuilder sb = new();
        sb.Append("https://skinbid.com/market?Stickers=");

        string query = $"{string.Join(",", appliedStickers.Select(x => x.StickerId))}";

        sb.Append(query);

        string url = sb.ToString();

        return url;
    }
    public string? GetBuff163Url(List<AppliedSticker> appliedStickers)
    {
        // TODO: Reimplement this method later
        return null;
        // Example: https://buff.163.com/market/csgo#tab=selling&page_num=1&extra_tag_ids=16226,16226,16226,16226  
        //List<int> searchIds = [];
        //if (appliedStickers.Count != 0)
        //{
        //    foreach (var sticker in appliedStickers)
        //    {
        //        if (sticker.BuffStickerId is not null)
        //        {
        //            searchIds.Add((int)sticker.BuffStickerId);
        //        }
        //    }
        //}

        //if (searchIds.Count == 0)
        //{
        //    return null;
        //}

        //return $"https://buff.163.com/market/csgo#tab=selling&page_num=1&extra_tag_ids={String.Join(",", searchIds)}";
    }
    public string GetSkinportUrl(List<AppliedSticker> appliedStickers)
    {
        if (appliedStickers.Count == 0)
        {
            return string.Empty;
        }

        StringBuilder sb = new();
        sb.Append("https://skinport.com/market?sticker=");

        string query = $"{string.Join("%2C", appliedStickers.Where(x => x.SkinportSearchId is not null).Select(x => x.SkinportSearchId))}";

        sb.Append(query);

        sb.Append("&r=erdbeerchen02");


        string url = sb.ToString();

        return url;
    }
    public string GetCsfloatDatabaseUrl(Weapon? selectedWeapon, List<AppliedSticker> appliedStickers)
    {
        // Example: https://csfloat.com/db?defIndex=7&paintIndex=282&min=0.1&max=0.7&stickers=%5B%7B%22i%22:%225015%22%7D,%7B%22i%22:%225015%22%7D,%7B%22i%22:%225015%22%7D,%7B%22i%22:%225015%22%7D%5D
        StringBuilder sb = new();
        sb.Append("https://csfloat.com/db?");

        List<string> parameters = new();

        if (selectedWeapon is not null)
        {
            parameters.Add($"defIndex={selectedWeapon.weapon_id}");
            parameters.Add($"paintIndex={selectedWeapon.gen_id}");
        }

        if (appliedStickers.Count != 0)
        {
            // Example: [{"i":"5015"},{"i":"5015"},{"i":"5015"},{"i":"5015"}]
            var stickers = appliedStickers.Take(4);
            List<string> sticker_values = new();
            foreach (var sticker in stickers)
            {
                sticker_values.Add($"{{\"i\":\"{sticker.StickerId}\"}}");
            }


            parameters.Add($"stickers=[{string.Join(",", sticker_values)}]");
        }


        if (parameters.Count == 0)
        {
            return string.Empty;
        }

        sb.Append(string.Join("&", parameters));

        return sb.ToString();
    }
    public string GetCsfloatUrl(List<AppliedSticker> appliedStickers)
    {
        StringBuilder sb = new();
        sb.Append("https://csfloat.com/search?");

        List<string> parameters = new();

        if (appliedStickers.Count != 0)
        {
            // Example: [{"i":"5015"},{"i":"5015"},{"i":"5015"},{"i":"5015"}]
            var stickers = appliedStickers.Take(4);
            List<string> sticker_values = new();
            foreach (var sticker in stickers)
            {
                sticker_values.Add($"{{\"i\":\"{sticker.StickerId}\"}}");
            }


            parameters.Add($"stickers=[{string.Join(",", sticker_values)}]");
        }


        if (parameters.Count == 0)
        {
            return string.Empty;
        }

        sb.Append(string.Join("&", parameters));

        return sb.ToString();
    }
}
