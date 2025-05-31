using CSGencodes.Core.Models;
using ItemsGameParser;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

internal class Program
{
    private static string _translations;
    private static string _items_game;
    private static Regex _tournamentRegex = new Regex("(?<=\\|).*");
    private static List<ItemSet> _itemSets = new();
    static Program()
    {
        string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "csgo_english.txt");
        _translations = File.ReadAllText(filename);
        filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "items_game.txt");
        _items_game = File.ReadAllText(filename);

        var collections = Regex.Matches(_items_game, @"""item_sets""\s*\{([\s\S]*?)\n\s*\}", RegexOptions.Multiline);

        foreach (Match item in collections)
        {
            var itemSet = ParseItemSet(item.Value);
            _itemSets.Add(itemSet);
        }

        ClientLootList.ParseClientLootLists(_items_game);

    }
    static async Task Main(string[] args)
    {
        //await CreateCollections();
        await CreateStickers();
    }



    private static async Task CreateCollections()
    {
        string input =
            """
            "1181"
            {
            	"name"		"p2k_fractal"
            	"description_string"		"#PaintKit_p2k_fractal"
            	"description_tag"		"#PaintKit_p2k_fractal_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.900000"
            	"composite_material_path"		"weapons/paints/community/community_35/p2k_fractal.vcompmat"
            }
            "1182"
            {
            	"name"		"xm1014_mockingbird"
            	"description_string"		"#PaintKit_xm1014_mockingbird"
            	"description_tag"		"#PaintKit_xm1014_mockingbird_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_35/xm1014_mockingbird.vcompmat"
            }
            "1183"
            {
            	"name"		"zeus_tosai"
            	"description_string"		"#PaintKit_zeus_tosai"
            	"description_tag"		"#PaintKit_zeus_tosai_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/community/community_35/zeus_tosai.vcompmat"
            }
            "1184"
            {
            	"name"		"famas_badtrip"
            	"description_string"		"#PaintKit_famas_badtrip"
            	"description_tag"		"#PaintKit_famas_badtrip_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_35/famas_badtrip.vcompmat"
            }
            "1185"
            {
            	"name"		"galil_control_strike"
            	"description_string"		"#PaintKit_galil_control_strike"
            	"description_tag"		"#PaintKit_galil_control_strike_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.798995"
            	"composite_material_path"		"weapons/paints/community/community_35/galil_control_strike.vcompmat"
            }
            "1186"
            {
            	"name"		"usps_bruteforce_green"
            	"description_string"		"#PaintKit_usps_bruteforce_green"
            	"description_tag"		"#PaintKit_usps_bruteforce_green_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.900000"
            	"composite_material_path"		"weapons/paints/community/community_35/usps_bruteforce_green.vcompmat"
            }
            "1187"
            {
            	"name"		"ssg08_brutalist"
            	"description_string"		"#PaintKit_ssg08_brutalist"
            	"description_tag"		"#PaintKit_ssg08_brutalist_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_35/ssg08_brutalist.vcompmat"
            }
            "1188"
            {
            	"name"		"mag7_ammo_box"
            	"description_string"		"#PaintKit_mag7_ammo_box"
            	"description_tag"		"#PaintKit_mag7_ammo_box_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_35/mag7_ammo_box.vcompmat"
            }
            "1189"
            {
            	"name"		"deagle_snake_pattern"
            	"description_string"		"#PaintKit_deagle_snake_pattern"
            	"description_tag"		"#PaintKit_deagle_snake_pattern_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.570000"
            	"composite_material_path"		"weapons/paints/community/community_35/deagle_snake_pattern.vcompmat"
            }
            "1190"
            {
            	"name"		"p90_boost_blue"
            	"description_string"		"#PaintKit_p90_boost_blue"
            	"description_tag"		"#PaintKit_p90_boost_blue_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.950549"
            	"composite_material_path"		"weapons/paints/community/community_35/p90_boost_blue.vcompmat"
            }
            "1192"
            {
            	"name"		"nova_rising_sun"
            	"description_string"		"#PaintKit_nova_rising_sun"
            	"description_tag"		"#PaintKit_nova_rising_sun_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_35/nova_rising_sun.vcompmat"
            }
            "1193"
            {
            	"name"		"mp9_nexus"
            	"description_string"		"#PaintKit_mp9_nexus"
            	"description_tag"		"#PaintKit_mp9_nexus_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_35/mp9_nexus.vcompmat"
            }
            "1194"
            {
            	"name"		"ump45_old_cartoon"
            	"description_string"		"#PaintKit_ump45_old_cartoon"
            	"description_tag"		"#PaintKit_ump45_old_cartoon_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_35/ump45_old_cartoon.vcompmat"
            }
            "1195"
            {
            	"name"		"am_carbon_fiber_cz75"
            	"description_string"		"#PaintKit_am_carbon_fiber_cz75"
            	"description_tag"		"#PaintKit_am_carbon_fiber_cz75_Tag"
            	"style"		"5"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.563291"
            	"composite_material_path"		"weapons/paints/set_train_2025/am_carbon_fiber_cz75.vcompmat"
            }
            "1198"
            {
            	"name"		"aug_cold_sentinel"
            	"description_string"		"#PaintKit_aug_cold_sentinel"
            	"description_tag"		"#PaintKit_aug_cold_sentinel_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_train_2025/aug_cold_sentinel.vcompmat"
            }
            "1199"
            {
            	"name"		"p90_steelcraft"
            	"description_string"		"#PaintKit_p90_steelcraft"
            	"description_tag"		"#PaintKit_p90_steelcraft_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_train_2025/p90_steelcraft.vcompmat"
            }
            "1200"
            {
            	"name"		"glock_train_green"
            	"description_string"		"#PaintKit_glock_train_green"
            	"description_tag"		"#PaintKit_glock_train_green_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_train_2025/glock_train_green.vcompmat"
            }
            "1201"
            {
            	"name"		"xm1014_freight"
            	"description_string"		"#PaintKit_xm1014_freight"
            	"description_tag"		"#PaintKit_xm1014_freight_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.746575"
            	"composite_material_path"		"weapons/paints/set_train_2025/xm1014_freight.vcompmat"
            }
            "1202"
            {
            	"name"		"gs_train_car_famas"
            	"description_string"		"#PaintKit_gs_train_car_famas"
            	"description_tag"		"#PaintKit_gs_train_car_famas_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.860000"
            	"composite_material_path"		"weapons/paints/set_train_2025/gs_train_car_famas.vcompmat"
            }
            "1203"
            {
            	"name"		"ump_transit"
            	"description_string"		"#PaintKit_ump_transit"
            	"description_tag"		"#PaintKit_ump_transit_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_train_2025/ump_transit.vcompmat"
            }
            "1204"
            {
            	"name"		"mac10_train_crash"
            	"description_string"		"#PaintKit_mac10_train_crash"
            	"description_tag"		"#PaintKit_mac10_train_crash_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/set_train_2025/mac10_train_crash.vcompmat"
            }
            "1205"
            {
            	"name"		"zeus_standard_issue"
            	"description_string"		"#PaintKit_zeus_standard_issue"
            	"description_tag"		"#PaintKit_zeus_standard_issue_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_train_2025/zeus_standard_issue.vcompmat"
            }
            "1206"
            {
            	"name"		"awp_printstream"
            	"description_string"		"#PaintKit_awp_printstream"
            	"description_tag"		"#PaintKit_cu_printstream_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_35/awp_printstream.vcompmat"
            }
            "1207"
            {
            	"name"		"ak47_explosive"
            	"description_string"		"#PaintKit_ak47_explosive"
            	"description_tag"		"#PaintKit_ak47_explosive_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_35/ak47_explosive.vcompmat"
            }
            "1208"
            {
            	"name"		"glock_shinobu"
            	"description_string"		"#PaintKit_glock_shinobu"
            	"description_tag"		"#PaintKit_glock_shinobu_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_35/glock_shinobu.vcompmat"
            }
            "1209"
            {
            	"name"		"cu_m4a4_train_hell"
            	"description_string"		"#PaintKit_cu_m4a4_train_hell"
            	"description_tag"		"#PaintKit_cu_m4a4_train_hell_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_train_2025/cu_m4a4_train_hell.vcompmat"
            }
            "1210"
            {
            	"name"		"m4a4_green_camo"
            	"description_string"		"#PaintKit_m4a4_green_camo"
            	"description_tag"		"#PaintKit_m4a4_green_camo_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_35/m4a4_green_camo.vcompmat"
            }
            "1211"
            {
            	"name"		"cu_mp9_latte"
            	"description_string"		"#PaintKit_cu_mp9_latte"
            	"description_tag"		"#PaintKit_cu_mp9_latte_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_train_2025/cu_mp9_latte.vcompmat"
            }
            "1212"
            {
            	"name"		"brutalist_architecture"
            	"description_string"		"#PaintKit_brutalist_architecture"
            	"description_tag"		"#PaintKit_brutalist_architecture_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.350000"
            	"composite_material_path"		"weapons/paints/set_train_2025/brutalist_architecture.vcompmat"
            }
            "1213"
            {
            	"name"		"awp_longdog"
            	"description_string"		"#PaintKit_awp_longdog"
            	"description_tag"		"#PaintKit_awp_longdog_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_train_2025/awp_longdog.vcompmat"
            }
            "1214"
            {
            	"name"		"so_whiteout_tec9"
            	"description_string"		"#PaintKit_so_whiteout"
            	"description_tag"		"#PaintKit_so_whiteout_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.060000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_train_2025/so_whiteout_tec9.vcompmat"
            }
            "1215"
            {
            	"name"		"soch_mountains_limited_time"
            	"description_string"		"#PaintKit_soch_mountains_xm1014"
            	"description_tag"		"#PaintKit_soch_mountains_xm1014_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/limited_time/soch_mountains_limited_time.vcompmat"
            }
            "1216"
            {
            	"name"		"cue_stratosphere"
            	"description_string"		"#PaintKit_cue_stratosphere"
            	"description_tag"		"#PaintKit_cue_stratosphere_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.800000"
            	"composite_material_path"		"weapons/paints/timed_drops/cue_stratosphere.vcompmat"
            }
            "1217"
            {
            	"name"		"soe_blue_and_gold"
            	"description_string"		"#PaintKit_soe_blue_and_gold"
            	"description_tag"		"#PaintKit_soe_blue_and_gold_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_blue_and_gold.vcompmat"
            }
            "1218"
            {
            	"name"		"soe_iridescent_purple"
            	"description_string"		"#PaintKit_soe_iridescent_purple"
            	"description_tag"		"#PaintKit_soe_iridescent_purple_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_iridescent_purple.vcompmat"
            }
            "1219"
            {
            	"name"		"soe_blue_famas"
            	"description_string"		"#PaintKit_soe_blue_famas"
            	"description_tag"		"#PaintKit_soe_blue_famas_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_blue_famas.vcompmat"
            }
            "1256"
            {
            	"name"		"hye_coral"
            	"description_string"		"#PaintKit_hye_coral"
            	"description_tag"		"#PaintKit_hye_coral_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_coral.vcompmat"
            }
            "1257"
            {
            	"name"		"ht_earth_fans"
            	"description_string"		"#PaintKit_ht_earth_fans"
            	"description_tag"		"#PaintKit_ht_earth_fans_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/ht_earth_fans.vcompmat"
            }
            "1258"
            {
            	"name"		"hye_blue_paisley"
            	"description_string"		"#PaintKit_hye_blue_paisley"
            	"description_tag"		"#PaintKit_hye_blue_paisley_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.650000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_blue_paisley.vcompmat"
            }
            "1259"
            {
            	"name"		"spe_scarf_print"
            	"description_string"		"#PaintKit_spe_scarf_print"
            	"description_tag"		"#PaintKit_spe_scarf_print_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/spe_scarf_print.vcompmat"
            }
            "1260"
            {
            	"name"		"soe_berry"
            	"description_string"		"#PaintKit_soe_berry"
            	"description_tag"		"#PaintKit_soe_berry_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.800000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_berry.vcompmat"
            }
            "1261"
            {
            	"name"		"soo_acrylic_flow_turquoise"
            	"description_string"		"#PaintKit_soo_acrylic_flow_turquoise"
            	"description_tag"		"#PaintKit_soo_acrylic_flow_turquoise_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.678431"
            	"composite_material_path"		"weapons/paints/timed_drops/soo_acrylic_flow_turquoise.vcompmat"
            }
            "1262"
            {
            	"name"		"soe_blue_and_chrome"
            	"description_string"		"#PaintKit_soe_blue_and_chrome"
            	"description_tag"		"#PaintKit_soe_blue_and_chrome_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_blue_and_chrome.vcompmat"
            }
            "1263"
            {
            	"name"		"soo_rose_gold"
            	"description_string"		"#PaintKit_soo_rose_gold"
            	"description_tag"		"#PaintKit_soo_rose_gold_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/timed_drops/soo_rose_gold.vcompmat"
            }
            "1264"
            {
            	"name"		"soe_robinsegg"
            	"description_string"		"#PaintKit_soe_robinsegg"
            	"description_tag"		"#PaintKit_soe_robinsegg_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_robinsegg.vcompmat"
            }
            "1265"
            {
            	"name"		"hye_topo"
            	"description_string"		"#PaintKit_hye_topo"
            	"description_tag"		"#PaintKit_hye_topo_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_topo.vcompmat"
            }
            "1266"
            {
            	"name"		"hye_blue_m4a4"
            	"description_string"		"#PaintKit_hye_blue_m4a4"
            	"description_tag"		"#PaintKit_hye_blue_m4a4_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_blue_m4a4.vcompmat"
            }
            "1267"
            {
            	"name"		"hye_drippy_camo"
            	"description_string"		"#PaintKit_hye_drippy_camo"
            	"description_tag"		"#PaintKit_hye_drippy_camo_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_drippy_camo.vcompmat"
            }
            "1268"
            {
            	"name"		"soe_electric_blue"
            	"description_string"		"#PaintKit_soe_electric_blue"
            	"description_tag"		"#PaintKit_soe_electric_blue_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_electric_blue.vcompmat"
            }
            "1269"
            {
            	"name"		"soo_mac10_blueberry"
            	"description_string"		"#PaintKit_soo_mac10_blueberry"
            	"description_tag"		"#PaintKit_soo_mac10_blueberry_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.637288"
            	"composite_material_path"		"weapons/paints/timed_drops/soo_mac10_blueberry.vcompmat"
            }
            "1270"
            {
            	"name"		"soo_blues"
            	"description_string"		"#PaintKit_soo_blues"
            	"description_tag"		"#PaintKit_soo_blues_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.795222"
            	"composite_material_path"		"weapons/paints/timed_drops/soo_blues.vcompmat"
            }
            "1271"
            {
            	"name"		"soch_blorb_bw"
            	"description_string"		"#PaintKit_soch_blorb_bw"
            	"description_tag"		"#PaintKit_soch_blorb_bw_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/soch_blorb_bw.vcompmat"
            }
            "1272"
            {
            	"name"		"gsch_ripple"
            	"description_string"		"#PaintKit_gsch_ripple"
            	"description_tag"		"#PaintKit_gsch_ripple_Tag"
            	"style"		"10"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.780822"
            	"composite_material_path"		"weapons/paints/timed_drops/gsch_ripple.vcompmat"
            }
            "1273"
            {
            	"name"		"sp_lace"
            	"description_string"		"#PaintKit_sp_lace"
            	"description_tag"		"#PaintKit_sp_lace_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/sp_lace.vcompmat"
            }
            "1274"
            {
            	"name"		"sp_lime_hex"
            	"description_string"		"#PaintKit_sp_lime_hex"
            	"description_tag"		"#PaintKit_sp_lime_hex_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.638225"
            	"composite_material_path"		"weapons/paints/timed_drops/sp_lime_hex.vcompmat"
            }
            "1275"
            {
            	"name"		"soch_blorb_bw_galilar"
            	"description_string"		"#PaintKit_soch_blorb_bw"
            	"description_tag"		"#PaintKit_soch_blorb_bw_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/soch_blorb_bw_galilar.vcompmat"
            }
            "1276"
            {
            	"name"		"soch_indigo_grips"
            	"description_string"		"#PaintKit_soch_indigo_grips"
            	"description_tag"		"#PaintKit_soch_indigo_grips_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.803390"
            	"composite_material_path"		"weapons/paints/timed_drops/soch_indigo_grips.vcompmat"
            }
            "1277"
            {
            	"name"		"hy_usaf_round"
            	"description_string"		"#PaintKit_hy_usaf_round"
            	"description_tag"		"#PaintKit_hy_usaf_round_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/hy_usaf_round.vcompmat"
            }
            "1278"
            {
            	"name"		"ht_blue_edges"
            	"description_string"		"#PaintKit_ht_blue_edges"
            	"description_tag"		"#PaintKit_ht_blue_edges_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/timed_drops/ht_blue_edges.vcompmat"
            }
            "1279"
            {
            	"name"		"so_teal"
            	"description_string"		"#PaintKit_so_teal"
            	"description_tag"		"#PaintKit_so_teal_Tag"
            	"style"		"4"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.800000"
            	"composite_material_path"		"weapons/paints/timed_drops/so_teal.vcompmat"
            }
            "1280"
            {
            	"name"		"cue_jump_line"
            	"description_string"		"#PaintKit_cue_jump_line"
            	"description_tag"		"#PaintKit_cue_jump_line_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/timed_drops/cue_jump_line.vcompmat"
            }
            "1281"
            {
            	"name"		"spe_lightning"
            	"description_string"		"#PaintKit_spe_lightning"
            	"description_tag"		"#PaintKit_spe_lightning_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/timed_drops/spe_lightning.vcompmat"
            }
            "1282"
            {
            	"name"		"spe_missile"
            	"description_string"		"#PaintKit_spe_missile"
            	"description_tag"		"#PaintKit_spe_missile_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.670000"
            	"composite_material_path"		"weapons/paints/timed_drops/spe_missile.vcompmat"
            }
            "1283"
            {
            	"name"		"soe_metallic_green_2"
            	"description_string"		"#PaintKit_soe_metallic_green"
            	"description_tag"		"#PaintKit_soe_metallic_green_Tag"
            	"style"		"5"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_metallic_green_2.vcompmat"
            }
            "1284"
            {
            	"name"		"soe_tropical"
            	"description_string"		"#PaintKit_soe_tropical"
            	"description_tag"		"#PaintKit_soe_tropical_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.550000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_tropical.vcompmat"
            }
            "1285"
            {
            	"name"		"hye_green_forest"
            	"description_string"		"#PaintKit_hye_green_forest"
            	"description_tag"		"#PaintKit_hye_green_forest_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.680000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_green_forest.vcompmat"
            }
            "1286"
            {
            	"name"		"soe_snakeskin"
            	"description_string"		"#PaintKit_soe_snakeskin"
            	"description_tag"		"#PaintKit_soe_snakeskin_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_snakeskin.vcompmat"
            }
            "1287"
            {
            	"name"		"ht_copper_edges"
            	"description_string"		"#PaintKit_ht_copper_edges"
            	"description_tag"		"#PaintKit_ht_copper_edges_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/ht_copper_edges.vcompmat"
            }
            "1288"
            {
            	"name"		"soe_varicamo"
            	"description_string"		"#PaintKit_soe_varicamo"
            	"description_tag"		"#PaintKit_soe_varicamo_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.671875"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_varicamo.vcompmat"
            }
            "1289"
            {
            	"name"		"hye_tiger2"
            	"description_string"		"#PaintKit_hye_tiger2"
            	"description_tag"		"#PaintKit_hye_tiger2_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.550000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_tiger2.vcompmat"
            }
            "1290"
            {
            	"name"		"soch_marble_grips"
            	"description_string"		"#PaintKit_soch_marble_grips"
            	"description_tag"		"#PaintKit_soch_marble_grips_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.800000"
            	"composite_material_path"		"weapons/paints/timed_drops/soch_marble_grips.vcompmat"
            }
            "1291"
            {
            	"name"		"hye_zoom"
            	"description_string"		"#PaintKit_hye_zoom"
            	"description_tag"		"#PaintKit_hye_zoom_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.630000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_zoom.vcompmat"
            }
            "1292"
            {
            	"name"		"soe_teal_glitter"
            	"description_string"		"#PaintKit_soe_teal_glitter"
            	"description_tag"		"#PaintKit_soe_teal_glitter_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_teal_glitter.vcompmat"
            }
            "1293"
            {
            	"name"		"aq_titanium_acid"
            	"description_string"		"#PaintKit_aq_titanium_acid"
            	"description_tag"		"#PaintKit_aq_titanium_acid_Tag"
            	"style"		"4"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.650980"
            	"composite_material_path"		"weapons/paints/timed_drops/aq_titanium_acid.vcompmat"
            }
            "1294"
            {
            	"name"		"hye_gold_camo"
            	"description_string"		"#PaintKit_hye_gold_camo"
            	"description_tag"		"#PaintKit_hye_gold_camo_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_gold_camo.vcompmat"
            }
            "1295"
            {
            	"name"		"hye_green_camo"
            	"description_string"		"#PaintKit_hye_green_camo"
            	"description_tag"		"#PaintKit_hye_green_camo_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.580000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_green_camo.vcompmat"
            }
            "1296"
            {
            	"name"		"hye_yellow_usaf"
            	"description_string"		"#PaintKit_hye_yellow_usaf"
            	"description_tag"		"#PaintKit_hye_yellow_usaf_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_yellow_usaf.vcompmat"
            }
            "1297"
            {
            	"name"		"hy_digicam_forest"
            	"description_string"		"#PaintKit_hy_digicam_forest"
            	"description_tag"		"#PaintKit_hy_digicam_forest_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/hy_digicam_forest.vcompmat"
            }
            "1298"
            {
            	"name"		"hyo_jungle_desat"
            	"description_string"		"#PaintKit_hyo_jungle_desat"
            	"description_tag"		"#PaintKit_hyo_jungle_desat_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/hyo_jungle_desat.vcompmat"
            }
            "1299"
            {
            	"name"		"so_ceramic"
            	"description_string"		"#PaintKit_so_ceramic"
            	"description_tag"		"#PaintKit_so_ceramic_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/timed_drops/so_ceramic.vcompmat"
            }
            "1300"
            {
            	"name"		"so_ceramic_negev"
            	"description_string"		"#PaintKit_so_ceramic"
            	"description_tag"		"#PaintKit_so_ceramic_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/timed_drops/so_ceramic_negev.vcompmat"
            }
            "1301"
            {
            	"name"		"soe_alpine_green"
            	"description_string"		"#PaintKit_soe_alpine_green"
            	"description_tag"		"#PaintKit_soe_alpine_green_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_alpine_green.vcompmat"
            }
            "1302"
            {
            	"name"		"spo_palm"
            	"description_string"		"#Paintkit_sp_palm"
            	"description_tag"		"#Paintkit_sp_palm_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/timed_drops/spo_palm.vcompmat"
            }
            "1303"
            {
            	"name"		"soch_hueshift_desat"
            	"description_string"		"#PaintKit_soch_hueshift_desat"
            	"description_tag"		"#PaintKit_soch_hueshift_desat_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/timed_drops/soch_hueshift_desat.vcompmat"
            }
            "1304"
            {
            	"name"		"so_ceramic_green_ssg08"
            	"description_string"		"#PaintKit_so_ceramic_green_ssg08"
            	"description_tag"		"#PaintKit_so_ceramic_green_ssg08_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/timed_drops/so_ceramic_green_ssg08.vcompmat"
            }
            "1305"
            {
            	"name"		"sp_khaki_camo"
            	"description_string"		"#PaintKit_sp_khaki_camo"
            	"description_tag"		"#PaintKit_sp_khaki_camo_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.650000"
            	"composite_material_path"		"weapons/paints/timed_drops/sp_khaki_camo.vcompmat"
            }
            "1306"
            {
            	"name"		"so_greyblue"
            	"description_string"		"#PaintKit_so_greyblue"
            	"description_tag"		"#PaintKit_so_greyblue_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.650000"
            	"composite_material_path"		"weapons/paints/timed_drops/so_greyblue.vcompmat"
            }
            "1307"
            {
            	"name"		"so_greyblue_p250"
            	"description_string"		"#PaintKit_so_greyblue"
            	"description_tag"		"#PaintKit_so_greyblue_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.650000"
            	"composite_material_path"		"weapons/paints/timed_drops/so_greyblue_p250.vcompmat"
            }
            "1308"
            {
            	"name"		"hy_flecktarn"
            	"description_string"		"#PaintKit_hy_flecktarn"
            	"description_tag"		"#PaintKit_hy_flecktarn_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.650000"
            	"composite_material_path"		"weapons/paints/timed_drops/hy_flecktarn.vcompmat"
            }
            "1309"
            {
            	"name"		"hye_ak47_nouveau"
            	"description_string"		"#PaintKit_hye_ak47_nouveau"
            	"description_tag"		"#PaintKit_hye_ak47_nouveau_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_ak47_nouveau.vcompmat"
            }
            "1310"
            {
            	"name"		"hye_pink_tiger"
            	"description_string"		"#PaintKit_hye_pink_tiger"
            	"description_tag"		"#PaintKit_hye_pink_tiger_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_pink_tiger.vcompmat"
            }
            "1311"
            {
            	"name"		"ht_abstract_wind"
            	"description_string"		"#PaintKit_ht_abstract_wind"
            	"description_tag"		"#PaintKit_ht_abstract_wind_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.670000"
            	"composite_material_path"		"weapons/paints/timed_drops/ht_abstract_wind.vcompmat"
            }
            "1312"
            {
            	"name"		"soe_roses"
            	"description_string"		"#PaintKit_soe_roses"
            	"description_tag"		"#PaintKit_soe_roses_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.752941"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_roses.vcompmat"
            }
            "1313"
            {
            	"name"		"ht_metal_edges"
            	"description_string"		"#PaintKit_ht_metal_edges"
            	"description_tag"		"#PaintKit_ht_metal_edges_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/timed_drops/ht_metal_edges.vcompmat"
            }
            "1314"
            {
            	"name"		"soe_orange_flick"
            	"description_string"		"#PaintKit_soe_orange_flick"
            	"description_tag"		"#PaintKit_soe_orange_flick_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_orange_flick.vcompmat"
            }
            "1315"
            {
            	"name"		"hye_pink_coral"
            	"description_string"		"#PaintKit_hye_pink_coral"
            	"description_tag"		"#PaintKit_hye_pink_coral_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/timed_drops/hye_pink_coral.vcompmat"
            }
            "1316"
            {
            	"name"		"soo_acrylic_flow_pink"
            	"description_string"		"#PaintKit_soo_acrylic_flow_pink"
            	"description_tag"		"#PaintKit_soo_acrylic_flow_pink_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.678431"
            	"composite_material_path"		"weapons/paints/timed_drops/soo_acrylic_flow_pink.vcompmat"
            }
            "1317"
            {
            	"name"		"soe_yellow_swirl"
            	"description_string"		"#PaintKit_soe_yellow_swirl"
            	"description_tag"		"#PaintKit_soe_yellow_swirl_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.680000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_yellow_swirl.vcompmat"
            }
            "1318"
            {
            	"name"		"soe_plum"
            	"description_string"		"#PaintKit_soe_plum"
            	"description_tag"		"#PaintKit_soe_plum_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_plum.vcompmat"
            }
            "1319"
            {
            	"name"		"hy_hexagon"
            	"description_string"		"#PaintKit_hy_hexagon"
            	"description_tag"		"#PaintKit_hy_hexagon_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.500000"
            	"composite_material_path"		"weapons/paints/timed_drops/hy_hexagon.vcompmat"
            }
            "1320"
            {
            	"name"		"ht_orange_basket"
            	"description_string"		"#PaintKit_ht_orange_basket"
            	"description_tag"		"#PaintKit_ht_orange_basket_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/ht_orange_basket.vcompmat"
            }
            "1321"
            {
            	"name"		"soo_famas_grey_ghost"
            	"description_string"		"#PaintKit_soo_famas_grey_ghost"
            	"description_tag"		"#PaintKit_soo_famas_grey_ghost_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.637288"
            	"composite_material_path"		"weapons/paints/timed_drops/soo_famas_grey_ghost.vcompmat"
            }
            "1322"
            {
            	"name"		"soo_paint_splats_yellow"
            	"description_string"		"#PaintKit_soo_paint_splats_yellow"
            	"description_tag"		"#PaintKit_soo_paint_splats_yellow_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/soo_paint_splats_yellow.vcompmat"
            }
            "1323"
            {
            	"name"		"ht_red_edges"
            	"description_string"		"#PaintKit_ht_red_edges"
            	"description_tag"		"#PaintKit_ht_red_edges_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/ht_red_edges.vcompmat"
            }
            "1324"
            {
            	"name"		"hy_varicamo_simple_yellow"
            	"description_string"		"#PaintKit_hy_varicamo_simple_yellow"
            	"description_tag"		"#PaintKit_hy_varicamo_simple_yellow_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.501961"
            	"composite_material_path"		"weapons/paints/timed_drops/hy_varicamo_simple_yellow.vcompmat"
            }
            "1325"
            {
            	"name"		"hy_wood_grain_camo_red"
            	"description_string"		"#PaintKit_hy_wood_grain_camo_red"
            	"description_tag"		"#PaintKit_hy_wood_grain_camo_red_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/hy_wood_grain_camo_red.vcompmat"
            }
            "1326"
            {
            	"name"		"so_mustard"
            	"description_string"		"#PaintKit_so_mustard"
            	"description_tag"		"#PaintKit_so_mustard_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.746575"
            	"composite_material_path"		"weapons/paints/timed_drops/so_mustard.vcompmat"
            }
            "1327"
            {
            	"name"		"so_mustard_scar20"
            	"description_string"		"#PaintKit_so_mustard"
            	"description_tag"		"#PaintKit_so_mustard_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.746575"
            	"composite_material_path"		"weapons/paints/timed_drops/so_mustard_scar20.vcompmat"
            }
            "1328"
            {
            	"name"		"soo_g3sg1_tomato"
            	"description_string"		"#PaintKit_soo_g3sg1_tomato"
            	"description_tag"		"#PaintKit_soo_g3sg1_tomato_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.637288"
            	"composite_material_path"		"weapons/paints/timed_drops/soo_g3sg1_tomato.vcompmat"
            }
            "1329"
            {
            	"name"		"soe_pink_pearl"
            	"description_string"		"#PaintKit_soe_pink_pearl"
            	"description_tag"		"#PaintKit_soe_pink_pearl_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/timed_drops/soe_pink_pearl.vcompmat"
            }
            "1330"
            {
            	"name"		"hy_mtp"
            	"description_string"		"#PaintKit_hy_mtp"
            	"description_tag"		"#PaintKit_hy_mtp_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/hy_mtp.vcompmat"
            }
            "1331"
            {
            	"name"		"soo_grass_photo_camo"
            	"description_string"		"#PaintKit_soo_grass_photo_camo"
            	"description_tag"		"#PaintKit_soo_grass_photo_camo_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.550000"
            	"composite_material_path"		"weapons/paints/timed_drops/soo_grass_photo_camo.vcompmat"
            }
            "1332"
            {
            	"name"		"ht_simple_camo"
            	"description_string"		"#PaintKit_ht_simple_camo"
            	"description_tag"		"#PaintKit_ht_simple_camo_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.650000"
            	"composite_material_path"		"weapons/paints/timed_drops/ht_simple_camo.vcompmat"
            }
            "1333"
            {
            	"name"		"hy_cloud_camo"
            	"description_string"		"#PaintKit_hy_cloud_camo"
            	"description_tag"		"#PaintKit_hy_cloud_camo_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/timed_drops/hy_cloud_camo.vcompmat"
            }
            "1334"
            {
            	"name"		"so_bronze_powder"
            	"description_string"		"#PaintKit_so_bronze_powder"
            	"description_tag"		"#PaintKit_so_bronze_powder_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.800000"
            	"composite_material_path"		"weapons/paints/timed_drops/so_bronze_powder.vcompmat"
            }
            "1335"
            {
            	"name"		"soch_acrylic_grips"
            	"description_string"		"#PaintKit_soch_acrylic_grips"
            	"description_tag"		"#PaintKit_soch_acrylic_grips_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.800000"
            	"composite_material_path"		"weapons/paints/timed_drops/soch_acrylic_grips.vcompmat"
            }
            "1336"
            {
            	"name"		"soo_branches"
            	"description_string"		"#PaintKit_soo_branches"
            	"description_tag"		"#PaintKit_soo_branches_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.636986"
            	"composite_material_path"		"weapons/paints/timed_drops/soo_branches.vcompmat"
            }
            "1337"
            {
            	"name"		"train_shapes_01"
            	"description_string"		"#PaintKit_train_shapes_01"
            	"description_tag"		"#PaintKit_train_shapes_01_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.350000"
            	"composite_material_path"		"weapons/paints/set_train_2025/train_shapes_01.vcompmat"
            }
            """;

        var result = ParseCollectionInput(input);

        // Printing the result

        List<Weapon> weapons = new List<Weapon>();

        foreach (var item in result)
        {
            var entry = item.Value;
            string name = GetWeaponName(entry);
            (string weapon_name, int weapon_id, string econ_name) = GetWeaponType(entry);

            ItemSet? itemSet = GetCollection(entry);

            if (itemSet is not null)
            {
                string collection_name = GetTranslation(itemSet.Name);
                string imageDirectory = collection_name.ToLower().Replace(' ', '_');
                string? rarity = ClientLootList.GetRarity(entry.name);


                weapons.Add(new Weapon
                {
                    gen_id = item.Key,
                    name = $"{weapon_name} | {name}",
                    min_wear = decimal.Parse(entry.wear_remap_min, CultureInfo.InvariantCulture),
                    max_wear = decimal.Parse(entry.wear_remap_max, CultureInfo.InvariantCulture),
                    trade_up = true,
                    weapon_id = weapon_id,
                    rarity = rarity,
                    collection = collection_name,
                    Image = $"/assets/img/items/weapons/{imageDirectory}/weapon_{econ_name}_{entry.name}_light_png.png"

                });
            }
            else
            {
                Console.WriteLine($"ItemSet for \"{entry.name}\" could not be found.");
            }

        }

        // Sort by collection
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };
        foreach (var item in weapons.GroupBy(x => x.collection))
        {
            List<Weapon> weaponList = item.ToList();
            string json = JsonSerializer.Serialize(weaponList, options);
            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{item.Key.ToLower().Replace(' ', '_')}.json");

            await File.WriteAllTextAsync(filename, json);
        }
    }

    private static ItemSet? GetCollection(WeaponEntry entry)
    {

        foreach (var set in _itemSets)
        {
            foreach (var item in set.Items)
            {
                if (item.Key.StartsWith($"[{entry.name}]"))
                {
                    return set;
                }
            }
        }


        return null;
    }
    private static (string name, int weapon_id, string econ_name) GetWeaponType(WeaponEntry entry)
    {
        string name = entry.name;
        string pattern = $@"\[{Regex.Escape(name)}\]([a-zA-Z0-9_]+)";
        var match = Regex.Match(_items_game, pattern);

        if (match.Success)
        {
            string weapon_type = match.Groups[1].Value;


            return weapon_type switch
            {
                "weapon_hkp2000" => ("P2000", 32, "hkp2000"),
                "weapon_xm1014" => ("XM1014", 25, "xm1014"),
                "weapon_taser" => ("Zeus", 31, "taser"),
                "weapon_famas" => ("FAMAS", 10, "famas"),
                "weapon_galilar" => ("Galil AR", 13, "galilar"),
                "weapon_usp_silencer" => ("USP-S", 61, "usp_silencer"),
                "weapon_ssg08" => ("SSG 08", 40, "ssg08"),
                "weapon_mag7" => ("MAG-7", 27, "mag7"),
                "weapon_deagle" => ("Desert Eagle", 1, "deagle"),
                "weapon_p90" => ("P90", 19, "p90"),
                "weapon_nova" => ("Nova", 35, "nova"),
                "weapon_mp9" => ("MP9", 34, "mp9"),
                "weapon_ump45" => ("UMP-45", 24, "ump45"),
                "weapon_cz75a" => ("CZ75-Auto", 63, "cz75a"),
                "weapon_aug" => ("AUG", 8, "aug"),
                "weapon_glock" => ("Glock-18", 4, "glock"),
                "weapon_mac10" => ("MAC-10", 17, "mac10"),
                "weapon_awp" => ("AWP", 9, "awp"),
                "weapon_ak47" => ("AK-47", 7, "ak47"),
                "weapon_m4a1" => ("M4A4", 16, "m4a1"),
                "weapon_p250" => ("P250", 36, "p250"),
                "weapon_tec9" => ("Tec-9", 30, "tec9"),
                "weapon_m4a1_silencer" => ("M4A1-S", 60, "m4a1_silencer"),
                "weapon_negev" => ("Negev", 28, "negev"),
                "weapon_fiveseven" => ("Five-SeveN", 3, "fiveseven"),
                "weapon_elite" => ("Dual Berettas", 2, "elite_gs"),
                "weapon_sg556" => ("SG 553", 39, "sg556"),
                "weapon_sawedoff" => ("Sawed-Off", 29, "sawedoff"),
                "weapon_mp5sd" => ("MP5-SD", 23, "mp5sd"),
                "weapon_revolver" => ("R8 Revolver", 64, "revolver"),
                "weapon_m249" => ("M249", 14, "m249"),
                "weapon_g3sg1" => ("G3SG1", 11, "g3sg1"),
                "weapon_bizon" => ("PP-Bizon", 26, "bizon"),
                "weapon_mp7" => ("MP7", 33, "mp7"),
                "weapon_scar20" => ("SCAR-20", 38, "scar20"),
                _ => throw new NotImplementedException($"Weapon {weapon_type} has not been implemented"),
            };
        }

        Console.WriteLine($"Weapon for \"{name}\" could not be found.");
        return (string.Empty, 0, string.Empty);
    }

    static ItemSet ParseItemSet(string block)
    {
        var set = new ItemSet();

        // ID aus erster Zeile
        var idMatch = Regex.Match(block, @"""([^""]+)""\s*\{");
        if (idMatch.Success)
            set.Id = idMatch.Groups[1].Value;

        // name
        set.Name = Regex.Match(block, @"""name""\s*""([^""]+)""").Groups[1].Value;

        // description
        set.Description = Regex.Match(block, @"""set_description""\s*""([^""]+)""").Groups[1].Value;

        // is_collection
        var isColl = Regex.Match(block, @"""is_collection""\s*""([^""]+)""").Groups[1].Value;
        set.IsCollection = isColl == "1";

        // items block extrahieren
        var itemsBlockMatch = Regex.Match(block, @"""items""\s*\{([\s\S]*?)\}", RegexOptions.Singleline);
        if (itemsBlockMatch.Success)
        {
            var itemLines = Regex.Matches(itemsBlockMatch.Groups[1].Value, @"""([^""]+)""\s*""([^""]+)""");
            foreach (Match match in itemLines)
            {
                string key = match.Groups[1].Value;
                string value = match.Groups[2].Value;
                set.Items[key] = value;
            }
        }

        return set;
    }
    private static async Task CreateStickers()
    {
        string input =
"""
"8554"
{
	"name"		"aus2025_team_vita"
	"item_name"		"#StickerKit_aus2025_team_vita"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/vita"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
}
"8555"
{
	"name"		"aus2025_team_vita_foil"
	"item_name"		"#StickerKit_aus2025_team_vita_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/vita_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
}
"8556"
{
	"name"		"aus2025_team_vita_holo"
	"item_name"		"#StickerKit_aus2025_team_vita_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/vita_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
}
"8557"
{
	"name"		"aus2025_team_vita_gold"
	"item_name"		"#StickerKit_aus2025_team_vita_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/vita_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
}
"8558"
{
	"name"		"aus2025_team_mouz"
	"item_name"		"#StickerKit_aus2025_team_mouz"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/mouz"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
}
"8559"
{
	"name"		"aus2025_team_mouz_foil"
	"item_name"		"#StickerKit_aus2025_team_mouz_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/mouz_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
}
"8560"
{
	"name"		"aus2025_team_mouz_holo"
	"item_name"		"#StickerKit_aus2025_team_mouz_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/mouz_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
}
"8561"
{
	"name"		"aus2025_team_mouz_gold"
	"item_name"		"#StickerKit_aus2025_team_mouz_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/mouz_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
}
"8562"
{
	"name"		"aus2025_team_spir"
	"item_name"		"#StickerKit_aus2025_team_spir"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/spir"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
}
"8563"
{
	"name"		"aus2025_team_spir_foil"
	"item_name"		"#StickerKit_aus2025_team_spir_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/spir_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
}
"8564"
{
	"name"		"aus2025_team_spir_holo"
	"item_name"		"#StickerKit_aus2025_team_spir_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/spir_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
}
"8565"
{
	"name"		"aus2025_team_spir_gold"
	"item_name"		"#StickerKit_aus2025_team_spir_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/spir_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
}
"8566"
{
	"name"		"aus2025_team_mngz"
	"item_name"		"#StickerKit_aus2025_team_mngz"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/mngz"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
}
"8567"
{
	"name"		"aus2025_team_mngz_foil"
	"item_name"		"#StickerKit_aus2025_team_mngz_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/mngz_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
}
"8568"
{
	"name"		"aus2025_team_mngz_holo"
	"item_name"		"#StickerKit_aus2025_team_mngz_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/mngz_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
}
"8569"
{
	"name"		"aus2025_team_mngz_gold"
	"item_name"		"#StickerKit_aus2025_team_mngz_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/mngz_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
}
"8570"
{
	"name"		"aus2025_team_aura"
	"item_name"		"#StickerKit_aus2025_team_aura"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/aura"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
}
"8571"
{
	"name"		"aus2025_team_aura_foil"
	"item_name"		"#StickerKit_aus2025_team_aura_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/aura_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
}
"8572"
{
	"name"		"aus2025_team_aura_holo"
	"item_name"		"#StickerKit_aus2025_team_aura_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/aura_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
}
"8573"
{
	"name"		"aus2025_team_aura_gold"
	"item_name"		"#StickerKit_aus2025_team_aura_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/aura_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
}
"8574"
{
	"name"		"aus2025_team_navi"
	"item_name"		"#StickerKit_aus2025_team_navi"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/navi"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
}
"8575"
{
	"name"		"aus2025_team_navi_foil"
	"item_name"		"#StickerKit_aus2025_team_navi_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/navi_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
}
"8576"
{
	"name"		"aus2025_team_navi_holo"
	"item_name"		"#StickerKit_aus2025_team_navi_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/navi_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
}
"8577"
{
	"name"		"aus2025_team_navi_gold"
	"item_name"		"#StickerKit_aus2025_team_navi_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/navi_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
}
"8578"
{
	"name"		"aus2025_team_g2"
	"item_name"		"#StickerKit_aus2025_team_g2"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/g2"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
}
"8579"
{
	"name"		"aus2025_team_g2_foil"
	"item_name"		"#StickerKit_aus2025_team_g2_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/g2_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
}
"8580"
{
	"name"		"aus2025_team_g2_holo"
	"item_name"		"#StickerKit_aus2025_team_g2_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/g2_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
}
"8581"
{
	"name"		"aus2025_team_g2_gold"
	"item_name"		"#StickerKit_aus2025_team_g2_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/g2_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
}
"8582"
{
	"name"		"aus2025_team_liq"
	"item_name"		"#StickerKit_aus2025_team_liq"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/liq"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
}
"8583"
{
	"name"		"aus2025_team_liq_foil"
	"item_name"		"#StickerKit_aus2025_team_liq_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/liq_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
}
"8584"
{
	"name"		"aus2025_team_liq_holo"
	"item_name"		"#StickerKit_aus2025_team_liq_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/liq_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
}
"8585"
{
	"name"		"aus2025_team_liq_gold"
	"item_name"		"#StickerKit_aus2025_team_liq_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/liq_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
}
"8586"
{
	"name"		"aus2025_team_fal"
	"item_name"		"#StickerKit_aus2025_team_fal"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/fal"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
}
"8587"
{
	"name"		"aus2025_team_fal_foil"
	"item_name"		"#StickerKit_aus2025_team_fal_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/fal_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
}
"8588"
{
	"name"		"aus2025_team_fal_holo"
	"item_name"		"#StickerKit_aus2025_team_fal_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/fal_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
}
"8589"
{
	"name"		"aus2025_team_fal_gold"
	"item_name"		"#StickerKit_aus2025_team_fal_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/fal_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
}
"8590"
{
	"name"		"aus2025_team_faze"
	"item_name"		"#StickerKit_aus2025_team_faze"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/faze"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
}
"8591"
{
	"name"		"aus2025_team_faze_foil"
	"item_name"		"#StickerKit_aus2025_team_faze_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/faze_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
}
"8592"
{
	"name"		"aus2025_team_faze_holo"
	"item_name"		"#StickerKit_aus2025_team_faze_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/faze_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
}
"8593"
{
	"name"		"aus2025_team_faze_gold"
	"item_name"		"#StickerKit_aus2025_team_faze_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/faze_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
}
"8594"
{
	"name"		"aus2025_team_3dm"
	"item_name"		"#StickerKit_aus2025_team_3dm"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/3dm"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
}
"8595"
{
	"name"		"aus2025_team_3dm_foil"
	"item_name"		"#StickerKit_aus2025_team_3dm_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/3dm_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
}
"8596"
{
	"name"		"aus2025_team_3dm_holo"
	"item_name"		"#StickerKit_aus2025_team_3dm_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/3dm_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
}
"8597"
{
	"name"		"aus2025_team_3dm_gold"
	"item_name"		"#StickerKit_aus2025_team_3dm_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/3dm_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
}
"8598"
{
	"name"		"aus2025_team_vp"
	"item_name"		"#StickerKit_aus2025_team_vp"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/vp"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
}
"8599"
{
	"name"		"aus2025_team_vp_foil"
	"item_name"		"#StickerKit_aus2025_team_vp_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/vp_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
}
"8600"
{
	"name"		"aus2025_team_vp_holo"
	"item_name"		"#StickerKit_aus2025_team_vp_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/vp_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
}
"8601"
{
	"name"		"aus2025_team_vp_gold"
	"item_name"		"#StickerKit_aus2025_team_vp_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/vp_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
}
"8602"
{
	"name"		"aus2025_team_pain"
	"item_name"		"#StickerKit_aus2025_team_pain"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/pain"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
}
"8603"
{
	"name"		"aus2025_team_pain_foil"
	"item_name"		"#StickerKit_aus2025_team_pain_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/pain_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
}
"8604"
{
	"name"		"aus2025_team_pain_holo"
	"item_name"		"#StickerKit_aus2025_team_pain_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/pain_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
}
"8605"
{
	"name"		"aus2025_team_pain_gold"
	"item_name"		"#StickerKit_aus2025_team_pain_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/pain_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
}
"8606"
{
	"name"		"aus2025_team_furi"
	"item_name"		"#StickerKit_aus2025_team_furi"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/furi"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
}
"8607"
{
	"name"		"aus2025_team_furi_foil"
	"item_name"		"#StickerKit_aus2025_team_furi_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/furi_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
}
"8608"
{
	"name"		"aus2025_team_furi_holo"
	"item_name"		"#StickerKit_aus2025_team_furi_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/furi_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
}
"8609"
{
	"name"		"aus2025_team_furi_gold"
	"item_name"		"#StickerKit_aus2025_team_furi_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/furi_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
}
"8610"
{
	"name"		"aus2025_team_mibr"
	"item_name"		"#StickerKit_aus2025_team_mibr"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/mibr"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
}
"8611"
{
	"name"		"aus2025_team_mibr_foil"
	"item_name"		"#StickerKit_aus2025_team_mibr_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/mibr_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
}
"8612"
{
	"name"		"aus2025_team_mibr_holo"
	"item_name"		"#StickerKit_aus2025_team_mibr_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/mibr_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
}
"8613"
{
	"name"		"aus2025_team_mibr_gold"
	"item_name"		"#StickerKit_aus2025_team_mibr_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/mibr_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
}
"8614"
{
	"name"		"aus2025_team_m80"
	"item_name"		"#StickerKit_aus2025_team_m80"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/m80"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
}
"8615"
{
	"name"		"aus2025_team_m80_foil"
	"item_name"		"#StickerKit_aus2025_team_m80_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/m80_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
}
"8616"
{
	"name"		"aus2025_team_m80_holo"
	"item_name"		"#StickerKit_aus2025_team_m80_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/m80_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
}
"8617"
{
	"name"		"aus2025_team_m80_gold"
	"item_name"		"#StickerKit_aus2025_team_m80_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/m80_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
}
"8618"
{
	"name"		"aus2025_team_cplx"
	"item_name"		"#StickerKit_aus2025_team_cplx"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/cplx"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
}
"8619"
{
	"name"		"aus2025_team_cplx_foil"
	"item_name"		"#StickerKit_aus2025_team_cplx_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/cplx_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
}
"8620"
{
	"name"		"aus2025_team_cplx_holo"
	"item_name"		"#StickerKit_aus2025_team_cplx_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/cplx_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
}
"8621"
{
	"name"		"aus2025_team_cplx_gold"
	"item_name"		"#StickerKit_aus2025_team_cplx_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/cplx_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
}
"8622"
{
	"name"		"aus2025_team_wcrd"
	"item_name"		"#StickerKit_aus2025_team_wcrd"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/wcrd"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
}
"8623"
{
	"name"		"aus2025_team_wcrd_foil"
	"item_name"		"#StickerKit_aus2025_team_wcrd_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/wcrd_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
}
"8624"
{
	"name"		"aus2025_team_wcrd_holo"
	"item_name"		"#StickerKit_aus2025_team_wcrd_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/wcrd_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
}
"8625"
{
	"name"		"aus2025_team_wcrd_gold"
	"item_name"		"#StickerKit_aus2025_team_wcrd_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/wcrd_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
}
"8626"
{
	"name"		"aus2025_team_hero"
	"item_name"		"#StickerKit_aus2025_team_hero"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/hero"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
}
"8627"
{
	"name"		"aus2025_team_hero_foil"
	"item_name"		"#StickerKit_aus2025_team_hero_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/hero_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
}
"8628"
{
	"name"		"aus2025_team_hero_holo"
	"item_name"		"#StickerKit_aus2025_team_hero_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/hero_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
}
"8629"
{
	"name"		"aus2025_team_hero_gold"
	"item_name"		"#StickerKit_aus2025_team_hero_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/hero_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
}
"8630"
{
	"name"		"aus2025_team_b8"
	"item_name"		"#StickerKit_aus2025_team_b8"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/b8"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
}
"8631"
{
	"name"		"aus2025_team_b8_foil"
	"item_name"		"#StickerKit_aus2025_team_b8_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/b8_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
}
"8632"
{
	"name"		"aus2025_team_b8_holo"
	"item_name"		"#StickerKit_aus2025_team_b8_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/b8_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
}
"8633"
{
	"name"		"aus2025_team_b8_gold"
	"item_name"		"#StickerKit_aus2025_team_b8_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/b8_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
}
"8634"
{
	"name"		"aus2025_team_og"
	"item_name"		"#StickerKit_aus2025_team_og"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/og"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
}
"8635"
{
	"name"		"aus2025_team_og_foil"
	"item_name"		"#StickerKit_aus2025_team_og_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/og_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
}
"8636"
{
	"name"		"aus2025_team_og_holo"
	"item_name"		"#StickerKit_aus2025_team_og_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/og_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
}
"8637"
{
	"name"		"aus2025_team_og_gold"
	"item_name"		"#StickerKit_aus2025_team_og_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/og_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
}
"8638"
{
	"name"		"aus2025_team_nemi"
	"item_name"		"#StickerKit_aus2025_team_nemi"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/nemi"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
}
"8639"
{
	"name"		"aus2025_team_nemi_foil"
	"item_name"		"#StickerKit_aus2025_team_nemi_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/nemi_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
}
"8640"
{
	"name"		"aus2025_team_nemi_holo"
	"item_name"		"#StickerKit_aus2025_team_nemi_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/nemi_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
}
"8641"
{
	"name"		"aus2025_team_nemi_gold"
	"item_name"		"#StickerKit_aus2025_team_nemi_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/nemi_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
}
"8642"
{
	"name"		"aus2025_team_bb"
	"item_name"		"#StickerKit_aus2025_team_bb"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/bb"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
}
"8643"
{
	"name"		"aus2025_team_bb_foil"
	"item_name"		"#StickerKit_aus2025_team_bb_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/bb_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
}
"8644"
{
	"name"		"aus2025_team_bb_holo"
	"item_name"		"#StickerKit_aus2025_team_bb_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/bb_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
}
"8645"
{
	"name"		"aus2025_team_bb_gold"
	"item_name"		"#StickerKit_aus2025_team_bb_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/bb_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
}
"8646"
{
	"name"		"aus2025_team_imp"
	"item_name"		"#StickerKit_aus2025_team_imp"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/imp"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
}
"8647"
{
	"name"		"aus2025_team_imp_foil"
	"item_name"		"#StickerKit_aus2025_team_imp_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/imp_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
}
"8648"
{
	"name"		"aus2025_team_imp_holo"
	"item_name"		"#StickerKit_aus2025_team_imp_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/imp_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
}
"8649"
{
	"name"		"aus2025_team_imp_gold"
	"item_name"		"#StickerKit_aus2025_team_imp_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/imp_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
}
"8650"
{
	"name"		"aus2025_team_nrg"
	"item_name"		"#StickerKit_aus2025_team_nrg"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/nrg"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
}
"8651"
{
	"name"		"aus2025_team_nrg_foil"
	"item_name"		"#StickerKit_aus2025_team_nrg_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/nrg_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
}
"8652"
{
	"name"		"aus2025_team_nrg_holo"
	"item_name"		"#StickerKit_aus2025_team_nrg_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/nrg_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
}
"8653"
{
	"name"		"aus2025_team_nrg_gold"
	"item_name"		"#StickerKit_aus2025_team_nrg_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/nrg_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
}
"8654"
{
	"name"		"aus2025_team_fq"
	"item_name"		"#StickerKit_aus2025_team_fq"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/fq"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
}
"8655"
{
	"name"		"aus2025_team_fq_foil"
	"item_name"		"#StickerKit_aus2025_team_fq_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/fq_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
}
"8656"
{
	"name"		"aus2025_team_fq_holo"
	"item_name"		"#StickerKit_aus2025_team_fq_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/fq_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
}
"8657"
{
	"name"		"aus2025_team_fq_gold"
	"item_name"		"#StickerKit_aus2025_team_fq_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/fq_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
}
"8658"
{
	"name"		"aus2025_team_meti"
	"item_name"		"#StickerKit_aus2025_team_meti"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/meti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
}
"8659"
{
	"name"		"aus2025_team_meti_foil"
	"item_name"		"#StickerKit_aus2025_team_meti_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/meti_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
}
"8660"
{
	"name"		"aus2025_team_meti_holo"
	"item_name"		"#StickerKit_aus2025_team_meti_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/meti_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
}
"8661"
{
	"name"		"aus2025_team_meti_gold"
	"item_name"		"#StickerKit_aus2025_team_meti_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/meti_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
}
"8662"
{
	"name"		"aus2025_team_tyl"
	"item_name"		"#StickerKit_aus2025_team_tyl"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/tyl"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
}
"8663"
{
	"name"		"aus2025_team_tyl_foil"
	"item_name"		"#StickerKit_aus2025_team_tyl_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/tyl_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
}
"8664"
{
	"name"		"aus2025_team_tyl_holo"
	"item_name"		"#StickerKit_aus2025_team_tyl_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/tyl_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
}
"8665"
{
	"name"		"aus2025_team_tyl_gold"
	"item_name"		"#StickerKit_aus2025_team_tyl_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/tyl_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
}
"8666"
{
	"name"		"aus2025_team_flux"
	"item_name"		"#StickerKit_aus2025_team_flux"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/flux"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
}
"8667"
{
	"name"		"aus2025_team_flux_foil"
	"item_name"		"#StickerKit_aus2025_team_flux_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/flux_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
}
"8668"
{
	"name"		"aus2025_team_flux_holo"
	"item_name"		"#StickerKit_aus2025_team_flux_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/flux_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
}
"8669"
{
	"name"		"aus2025_team_flux_gold"
	"item_name"		"#StickerKit_aus2025_team_flux_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/flux_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
}
"8670"
{
	"name"		"aus2025_team_chin"
	"item_name"		"#StickerKit_aus2025_team_chin"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/chin"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
}
"8671"
{
	"name"		"aus2025_team_chin_foil"
	"item_name"		"#StickerKit_aus2025_team_chin_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/chin_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
}
"8672"
{
	"name"		"aus2025_team_chin_holo"
	"item_name"		"#StickerKit_aus2025_team_chin_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/chin_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
}
"8673"
{
	"name"		"aus2025_team_chin_gold"
	"item_name"		"#StickerKit_aus2025_team_chin_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/chin_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
}
"8674"
{
	"name"		"aus2025_team_lynn"
	"item_name"		"#StickerKit_aus2025_team_lynn"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/lynn"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
}
"8675"
{
	"name"		"aus2025_team_lynn_foil"
	"item_name"		"#StickerKit_aus2025_team_lynn_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/lynn_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
}
"8676"
{
	"name"		"aus2025_team_lynn_holo"
	"item_name"		"#StickerKit_aus2025_team_lynn_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/lynn_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
}
"8677"
{
	"name"		"aus2025_team_lynn_gold"
	"item_name"		"#StickerKit_aus2025_team_lynn_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/lynn_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
}
"8678"
{
	"name"		"aus2025_team_lgcy"
	"item_name"		"#StickerKit_aus2025_team_lgcy"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/lgcy"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
}
"8679"
{
	"name"		"aus2025_team_lgcy_foil"
	"item_name"		"#StickerKit_aus2025_team_lgcy_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/lgcy_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
}
"8680"
{
	"name"		"aus2025_team_lgcy_holo"
	"item_name"		"#StickerKit_aus2025_team_lgcy_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/lgcy_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
}
"8681"
{
	"name"		"aus2025_team_lgcy_gold"
	"item_name"		"#StickerKit_aus2025_team_lgcy_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_team"
	"sticker_material"		"aus2025/lgcy_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
}
"8682"
{
	"name"		"aus2025_team_blst"
	"item_name"		"#StickerKit_aus2025_team_blst"
	"description_string"		"#EventItemDesc_aus2025_sticker_org"
	"sticker_material"		"aus2025/blst"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"0"
}
"8683"
{
	"name"		"aus2025_team_blst_foil"
	"item_name"		"#StickerKit_aus2025_team_blst_foil"
	"description_string"		"#EventItemDesc_aus2025_sticker_org"
	"sticker_material"		"aus2025/blst_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"0"
}
"8684"
{
	"name"		"aus2025_team_blst_holo"
	"item_name"		"#StickerKit_aus2025_team_blst_holo"
	"description_string"		"#EventItemDesc_aus2025_sticker_org"
	"sticker_material"		"aus2025/blst_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"0"
}
"8685"
{
	"name"		"aus2025_team_blst_gold"
	"item_name"		"#StickerKit_aus2025_team_blst_gold"
	"description_string"		"#EventItemDesc_aus2025_sticker_org"
	"sticker_material"		"aus2025/blst_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"0"
}
"8686"
{
	"name"		"aus2025_team_vita_graffiti"
	"item_name"		"#StickerKit_aus2025_team_vita"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/vita_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
}
"8687"
{
	"name"		"aus2025_team_mouz_graffiti"
	"item_name"		"#StickerKit_aus2025_team_mouz"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/mouz_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
}
"8688"
{
	"name"		"aus2025_team_spir_graffiti"
	"item_name"		"#StickerKit_aus2025_team_spir"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/spir_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
}
"8689"
{
	"name"		"aus2025_team_mngz_graffiti"
	"item_name"		"#StickerKit_aus2025_team_mngz"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/mngz_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
}
"8690"
{
	"name"		"aus2025_team_aura_graffiti"
	"item_name"		"#StickerKit_aus2025_team_aura"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/aura_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
}
"8691"
{
	"name"		"aus2025_team_navi_graffiti"
	"item_name"		"#StickerKit_aus2025_team_navi"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/navi_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
}
"8692"
{
	"name"		"aus2025_team_g2_graffiti"
	"item_name"		"#StickerKit_aus2025_team_g2"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/g2_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
}
"8693"
{
	"name"		"aus2025_team_liq_graffiti"
	"item_name"		"#StickerKit_aus2025_team_liq"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/liq_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
}
"8694"
{
	"name"		"aus2025_team_fal_graffiti"
	"item_name"		"#StickerKit_aus2025_team_fal"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/fal_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
}
"8695"
{
	"name"		"aus2025_team_faze_graffiti"
	"item_name"		"#StickerKit_aus2025_team_faze"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/faze_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
}
"8696"
{
	"name"		"aus2025_team_3dm_graffiti"
	"item_name"		"#StickerKit_aus2025_team_3dm"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/3dm_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
}
"8697"
{
	"name"		"aus2025_team_vp_graffiti"
	"item_name"		"#StickerKit_aus2025_team_vp"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/vp_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
}
"8698"
{
	"name"		"aus2025_team_pain_graffiti"
	"item_name"		"#StickerKit_aus2025_team_pain"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/pain_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
}
"8699"
{
	"name"		"aus2025_team_furi_graffiti"
	"item_name"		"#StickerKit_aus2025_team_furi"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/furi_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
}
"8700"
{
	"name"		"aus2025_team_mibr_graffiti"
	"item_name"		"#StickerKit_aus2025_team_mibr"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/mibr_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
}
"8701"
{
	"name"		"aus2025_team_m80_graffiti"
	"item_name"		"#StickerKit_aus2025_team_m80"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/m80_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
}
"8702"
{
	"name"		"aus2025_team_cplx_graffiti"
	"item_name"		"#StickerKit_aus2025_team_cplx"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/cplx_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
}
"8703"
{
	"name"		"aus2025_team_wcrd_graffiti"
	"item_name"		"#StickerKit_aus2025_team_wcrd"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/wcrd_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
}
"8704"
{
	"name"		"aus2025_team_hero_graffiti"
	"item_name"		"#StickerKit_aus2025_team_hero"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/hero_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
}
"8705"
{
	"name"		"aus2025_team_b8_graffiti"
	"item_name"		"#StickerKit_aus2025_team_b8"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/b8_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
}
"8706"
{
	"name"		"aus2025_team_og_graffiti"
	"item_name"		"#StickerKit_aus2025_team_og"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/og_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
}
"8707"
{
	"name"		"aus2025_team_nemi_graffiti"
	"item_name"		"#StickerKit_aus2025_team_nemi"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/nemi_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
}
"8708"
{
	"name"		"aus2025_team_bb_graffiti"
	"item_name"		"#StickerKit_aus2025_team_bb"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/bb_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
}
"8709"
{
	"name"		"aus2025_team_imp_graffiti"
	"item_name"		"#StickerKit_aus2025_team_imp"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/imp_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
}
"8710"
{
	"name"		"aus2025_team_nrg_graffiti"
	"item_name"		"#StickerKit_aus2025_team_nrg"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/nrg_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
}
"8711"
{
	"name"		"aus2025_team_fq_graffiti"
	"item_name"		"#StickerKit_aus2025_team_fq"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/fq_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
}
"8712"
{
	"name"		"aus2025_team_meti_graffiti"
	"item_name"		"#StickerKit_aus2025_team_meti"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/meti_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
}
"8713"
{
	"name"		"aus2025_team_tyl_graffiti"
	"item_name"		"#StickerKit_aus2025_team_tyl"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/tyl_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
}
"8714"
{
	"name"		"aus2025_team_flux_graffiti"
	"item_name"		"#StickerKit_aus2025_team_flux"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/flux_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
}
"8715"
{
	"name"		"aus2025_team_chin_graffiti"
	"item_name"		"#StickerKit_aus2025_team_chin"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/chin_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
}
"8716"
{
	"name"		"aus2025_team_lynn_graffiti"
	"item_name"		"#StickerKit_aus2025_team_lynn"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/lynn_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
}
"8717"
{
	"name"		"aus2025_team_lgcy_graffiti"
	"item_name"		"#StickerKit_aus2025_team_lgcy"
	"description_string"		"#EventItemDesc_aus2025_graffiti_team"
	"sticker_material"		"aus2025/lgcy_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
}
"8718"
{
	"name"		"aus2025_team_blst_graffiti"
	"item_name"		"#StickerKit_aus2025_team_blst"
	"description_string"		"#EventItemDesc_aus2025_graffiti_org"
	"sticker_material"		"aus2025/blst_graffiti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"0"
}
"8719"
{
	"name"		"aus2025_signature_apex_2"
	"item_name"		"#StickerKit_aus2025_signature_apex"
	"description_string"		"#StickerKit_desc_aus2025_signature_apex"
	"sticker_material"		"aus2025/sig_apex"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"29478439"
}
"8720"
{
	"name"		"aus2025_signature_apex_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_apex_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_apex_foil"
	"sticker_material"		"aus2025/sig_apex_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"29478439"
}
"8721"
{
	"name"		"aus2025_signature_apex_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_apex_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_apex_holo"
	"sticker_material"		"aus2025/sig_apex_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"29478439"
}
"8722"
{
	"name"		"aus2025_signature_apex_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_apex_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_apex_gold"
	"sticker_material"		"aus2025/sig_apex_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"29478439"
}
"8723"
{
	"name"		"aus2025_signature_zywoo_2"
	"item_name"		"#StickerKit_aus2025_signature_zywoo"
	"description_string"		"#StickerKit_desc_aus2025_signature_zywoo"
	"sticker_material"		"aus2025/sig_zywoo"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"153400465"
}
"8724"
{
	"name"		"aus2025_signature_zywoo_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_zywoo_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_zywoo_foil"
	"sticker_material"		"aus2025/sig_zywoo_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"153400465"
}
"8725"
{
	"name"		"aus2025_signature_zywoo_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_zywoo_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_zywoo_holo"
	"sticker_material"		"aus2025/sig_zywoo_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"153400465"
}
"8726"
{
	"name"		"aus2025_signature_zywoo_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_zywoo_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_zywoo_gold"
	"sticker_material"		"aus2025/sig_zywoo_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"153400465"
}
"8727"
{
	"name"		"aus2025_signature_flamez_2"
	"item_name"		"#StickerKit_aus2025_signature_flamez"
	"description_string"		"#StickerKit_desc_aus2025_signature_flamez"
	"sticker_material"		"aus2025/sig_flamez"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"18569432"
}
"8728"
{
	"name"		"aus2025_signature_flamez_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_flamez_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_flamez_foil"
	"sticker_material"		"aus2025/sig_flamez_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"18569432"
}
"8729"
{
	"name"		"aus2025_signature_flamez_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_flamez_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_flamez_holo"
	"sticker_material"		"aus2025/sig_flamez_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"18569432"
}
"8730"
{
	"name"		"aus2025_signature_flamez_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_flamez_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_flamez_gold"
	"sticker_material"		"aus2025/sig_flamez_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"18569432"
}
"8731"
{
	"name"		"aus2025_signature_mezii_2"
	"item_name"		"#StickerKit_aus2025_signature_mezii"
	"description_string"		"#StickerKit_desc_aus2025_signature_mezii"
	"sticker_material"		"aus2025/sig_mezii"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"12874964"
}
"8732"
{
	"name"		"aus2025_signature_mezii_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_mezii_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_mezii_foil"
	"sticker_material"		"aus2025/sig_mezii_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"12874964"
}
"8733"
{
	"name"		"aus2025_signature_mezii_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_mezii_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_mezii_holo"
	"sticker_material"		"aus2025/sig_mezii_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"12874964"
}
"8734"
{
	"name"		"aus2025_signature_mezii_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_mezii_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_mezii_gold"
	"sticker_material"		"aus2025/sig_mezii_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"12874964"
}
"8735"
{
	"name"		"aus2025_signature_ropz_2"
	"item_name"		"#StickerKit_aus2025_signature_ropz"
	"description_string"		"#StickerKit_desc_aus2025_signature_ropz"
	"sticker_material"		"aus2025/sig_ropz"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"31006590"
}
"8736"
{
	"name"		"aus2025_signature_ropz_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_ropz_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_ropz_foil"
	"sticker_material"		"aus2025/sig_ropz_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"31006590"
}
"8737"
{
	"name"		"aus2025_signature_ropz_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_ropz_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_ropz_holo"
	"sticker_material"		"aus2025/sig_ropz_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"31006590"
}
"8738"
{
	"name"		"aus2025_signature_ropz_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_ropz_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_ropz_gold"
	"sticker_material"		"aus2025/sig_ropz_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"89"
	"tournament_player_id"		"31006590"
}
"8739"
{
	"name"		"aus2025_signature_torzsi_2"
	"item_name"		"#StickerKit_aus2025_signature_torzsi"
	"description_string"		"#StickerKit_desc_aus2025_signature_torzsi"
	"sticker_material"		"aus2025/sig_torzsi"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"395473484"
}
"8740"
{
	"name"		"aus2025_signature_torzsi_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_torzsi_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_torzsi_foil"
	"sticker_material"		"aus2025/sig_torzsi_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"395473484"
}
"8741"
{
	"name"		"aus2025_signature_torzsi_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_torzsi_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_torzsi_holo"
	"sticker_material"		"aus2025/sig_torzsi_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"395473484"
}
"8742"
{
	"name"		"aus2025_signature_torzsi_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_torzsi_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_torzsi_gold"
	"sticker_material"		"aus2025/sig_torzsi_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"395473484"
}
"8743"
{
	"name"		"aus2025_signature_jimpphat_2"
	"item_name"		"#StickerKit_aus2025_signature_jimpphat"
	"description_string"		"#StickerKit_desc_aus2025_signature_jimpphat"
	"sticker_material"		"aus2025/sig_jimpphat"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"895109597"
}
"8744"
{
	"name"		"aus2025_signature_jimpphat_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_jimpphat_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_jimpphat_foil"
	"sticker_material"		"aus2025/sig_jimpphat_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"895109597"
}
"8745"
{
	"name"		"aus2025_signature_jimpphat_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_jimpphat_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_jimpphat_holo"
	"sticker_material"		"aus2025/sig_jimpphat_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"895109597"
}
"8746"
{
	"name"		"aus2025_signature_jimpphat_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_jimpphat_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_jimpphat_gold"
	"sticker_material"		"aus2025/sig_jimpphat_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"895109597"
}
"8747"
{
	"name"		"aus2025_signature_brollan_2"
	"item_name"		"#StickerKit_aus2025_signature_brollan"
	"description_string"		"#StickerKit_desc_aus2025_signature_brollan"
	"sticker_material"		"aus2025/sig_brollan"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"178562747"
}
"8748"
{
	"name"		"aus2025_signature_brollan_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_brollan_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_brollan_foil"
	"sticker_material"		"aus2025/sig_brollan_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"178562747"
}
"8749"
{
	"name"		"aus2025_signature_brollan_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_brollan_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_brollan_holo"
	"sticker_material"		"aus2025/sig_brollan_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"178562747"
}
"8750"
{
	"name"		"aus2025_signature_brollan_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_brollan_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_brollan_gold"
	"sticker_material"		"aus2025/sig_brollan_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"178562747"
}
"8751"
{
	"name"		"aus2025_signature_spinx_2"
	"item_name"		"#StickerKit_aus2025_signature_spinx"
	"description_string"		"#StickerKit_desc_aus2025_signature_spinx"
	"sticker_material"		"aus2025/sig_spinx"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"103070679"
}
"8752"
{
	"name"		"aus2025_signature_spinx_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_spinx_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_spinx_foil"
	"sticker_material"		"aus2025/sig_spinx_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"103070679"
}
"8753"
{
	"name"		"aus2025_signature_spinx_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_spinx_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_spinx_holo"
	"sticker_material"		"aus2025/sig_spinx_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"103070679"
}
"8754"
{
	"name"		"aus2025_signature_spinx_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_spinx_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_spinx_gold"
	"sticker_material"		"aus2025/sig_spinx_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"103070679"
}
"8755"
{
	"name"		"aus2025_signature_xertion_2"
	"item_name"		"#StickerKit_aus2025_signature_xertion"
	"description_string"		"#StickerKit_desc_aus2025_signature_xertion"
	"sticker_material"		"aus2025/sig_xertion"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"232908406"
}
"8756"
{
	"name"		"aus2025_signature_xertion_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_xertion_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_xertion_foil"
	"sticker_material"		"aus2025/sig_xertion_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"232908406"
}
"8757"
{
	"name"		"aus2025_signature_xertion_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_xertion_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_xertion_holo"
	"sticker_material"		"aus2025/sig_xertion_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"232908406"
}
"8758"
{
	"name"		"aus2025_signature_xertion_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_xertion_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_xertion_gold"
	"sticker_material"		"aus2025/sig_xertion_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"106"
	"tournament_player_id"		"232908406"
}
"8759"
{
	"name"		"aus2025_signature_chopper_2"
	"item_name"		"#StickerKit_aus2025_signature_chopper"
	"description_string"		"#StickerKit_desc_aus2025_signature_chopper"
	"sticker_material"		"aus2025/sig_chopper"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"85633136"
}
"8760"
{
	"name"		"aus2025_signature_chopper_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_chopper_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_chopper_foil"
	"sticker_material"		"aus2025/sig_chopper_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"85633136"
}
"8761"
{
	"name"		"aus2025_signature_chopper_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_chopper_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_chopper_holo"
	"sticker_material"		"aus2025/sig_chopper_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"85633136"
}
"8762"
{
	"name"		"aus2025_signature_chopper_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_chopper_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_chopper_gold"
	"sticker_material"		"aus2025/sig_chopper_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"85633136"
}
"8763"
{
	"name"		"aus2025_signature_magixx_2"
	"item_name"		"#StickerKit_aus2025_signature_magixx"
	"description_string"		"#StickerKit_desc_aus2025_signature_magixx"
	"sticker_material"		"aus2025/sig_magixx"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"868554"
}
"8764"
{
	"name"		"aus2025_signature_magixx_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_magixx_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_magixx_foil"
	"sticker_material"		"aus2025/sig_magixx_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"868554"
}
"8765"
{
	"name"		"aus2025_signature_magixx_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_magixx_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_magixx_holo"
	"sticker_material"		"aus2025/sig_magixx_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"868554"
}
"8766"
{
	"name"		"aus2025_signature_magixx_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_magixx_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_magixx_gold"
	"sticker_material"		"aus2025/sig_magixx_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"868554"
}
"8767"
{
	"name"		"aus2025_signature_donk_2"
	"item_name"		"#StickerKit_aus2025_signature_donk"
	"description_string"		"#StickerKit_desc_aus2025_signature_donk"
	"sticker_material"		"aus2025/sig_donk"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"425999755"
}
"8768"
{
	"name"		"aus2025_signature_donk_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_donk_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_donk_foil"
	"sticker_material"		"aus2025/sig_donk_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"425999755"
}
"8769"
{
	"name"		"aus2025_signature_donk_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_donk_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_donk_holo"
	"sticker_material"		"aus2025/sig_donk_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"425999755"
}
"8770"
{
	"name"		"aus2025_signature_donk_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_donk_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_donk_gold"
	"sticker_material"		"aus2025/sig_donk_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"425999755"
}
"8771"
{
	"name"		"aus2025_signature_sh1ro_2"
	"item_name"		"#StickerKit_aus2025_signature_sh1ro"
	"description_string"		"#StickerKit_desc_aus2025_signature_sh1ro"
	"sticker_material"		"aus2025/sig_sh1ro"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"121219047"
}
"8772"
{
	"name"		"aus2025_signature_sh1ro_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_sh1ro_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_sh1ro_foil"
	"sticker_material"		"aus2025/sig_sh1ro_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"121219047"
}
"8773"
{
	"name"		"aus2025_signature_sh1ro_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_sh1ro_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_sh1ro_holo"
	"sticker_material"		"aus2025/sig_sh1ro_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"121219047"
}
"8774"
{
	"name"		"aus2025_signature_sh1ro_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_sh1ro_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_sh1ro_gold"
	"sticker_material"		"aus2025/sig_sh1ro_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"121219047"
}
"8775"
{
	"name"		"aus2025_signature_zont1x_2"
	"item_name"		"#StickerKit_aus2025_signature_zont1x"
	"description_string"		"#StickerKit_desc_aus2025_signature_zont1x"
	"sticker_material"		"aus2025/sig_zont1x"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"1035615149"
}
"8776"
{
	"name"		"aus2025_signature_zont1x_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_zont1x_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_zont1x_foil"
	"sticker_material"		"aus2025/sig_zont1x_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"1035615149"
}
"8777"
{
	"name"		"aus2025_signature_zont1x_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_zont1x_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_zont1x_holo"
	"sticker_material"		"aus2025/sig_zont1x_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"1035615149"
}
"8778"
{
	"name"		"aus2025_signature_zont1x_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_zont1x_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_zont1x_gold"
	"sticker_material"		"aus2025/sig_zont1x_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"81"
	"tournament_player_id"		"1035615149"
}
"8779"
{
	"name"		"aus2025_signature_blitz_2"
	"item_name"		"#StickerKit_aus2025_signature_blitz"
	"description_string"		"#StickerKit_desc_aus2025_signature_blitz"
	"sticker_material"		"aus2025/sig_blitz"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"999558360"
}
"8780"
{
	"name"		"aus2025_signature_blitz_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_blitz_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_blitz_foil"
	"sticker_material"		"aus2025/sig_blitz_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"999558360"
}
"8781"
{
	"name"		"aus2025_signature_blitz_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_blitz_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_blitz_holo"
	"sticker_material"		"aus2025/sig_blitz_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"999558360"
}
"8782"
{
	"name"		"aus2025_signature_blitz_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_blitz_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_blitz_gold"
	"sticker_material"		"aus2025/sig_blitz_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"999558360"
}
"8783"
{
	"name"		"aus2025_signature_techno4k_2"
	"item_name"		"#StickerKit_aus2025_signature_techno4k"
	"description_string"		"#StickerKit_desc_aus2025_signature_techno4k"
	"sticker_material"		"aus2025/sig_techno4k"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"1006074432"
}
"8784"
{
	"name"		"aus2025_signature_techno4k_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_techno4k_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_techno4k_foil"
	"sticker_material"		"aus2025/sig_techno4k_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"1006074432"
}
"8785"
{
	"name"		"aus2025_signature_techno4k_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_techno4k_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_techno4k_holo"
	"sticker_material"		"aus2025/sig_techno4k_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"1006074432"
}
"8786"
{
	"name"		"aus2025_signature_techno4k_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_techno4k_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_techno4k_gold"
	"sticker_material"		"aus2025/sig_techno4k_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"1006074432"
}
"8787"
{
	"name"		"aus2025_signature_senzu_2"
	"item_name"		"#StickerKit_aus2025_signature_senzu"
	"description_string"		"#StickerKit_desc_aus2025_signature_senzu"
	"sticker_material"		"aus2025/sig_senzu"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"960454289"
}
"8788"
{
	"name"		"aus2025_signature_senzu_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_senzu_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_senzu_foil"
	"sticker_material"		"aus2025/sig_senzu_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"960454289"
}
"8789"
{
	"name"		"aus2025_signature_senzu_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_senzu_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_senzu_holo"
	"sticker_material"		"aus2025/sig_senzu_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"960454289"
}
"8790"
{
	"name"		"aus2025_signature_senzu_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_senzu_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_senzu_gold"
	"sticker_material"		"aus2025/sig_senzu_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"960454289"
}
"8791"
{
	"name"		"aus2025_signature_910_2"
	"item_name"		"#StickerKit_aus2025_signature_910"
	"description_string"		"#StickerKit_desc_aus2025_signature_910"
	"sticker_material"		"aus2025/sig_910"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"1243297617"
}
"8792"
{
	"name"		"aus2025_signature_910_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_910_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_910_foil"
	"sticker_material"		"aus2025/sig_910_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"1243297617"
}
"8793"
{
	"name"		"aus2025_signature_910_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_910_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_910_holo"
	"sticker_material"		"aus2025/sig_910_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"1243297617"
}
"8794"
{
	"name"		"aus2025_signature_910_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_910_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_910_gold"
	"sticker_material"		"aus2025/sig_910_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"1243297617"
}
"8795"
{
	"name"		"aus2025_signature_mzinho_2"
	"item_name"		"#StickerKit_aus2025_signature_mzinho"
	"description_string"		"#StickerKit_desc_aus2025_signature_mzinho"
	"sticker_material"		"aus2025/sig_mzinho"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"878556854"
}
"8796"
{
	"name"		"aus2025_signature_mzinho_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_mzinho_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_mzinho_foil"
	"sticker_material"		"aus2025/sig_mzinho_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"878556854"
}
"8797"
{
	"name"		"aus2025_signature_mzinho_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_mzinho_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_mzinho_holo"
	"sticker_material"		"aus2025/sig_mzinho_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"878556854"
}
"8798"
{
	"name"		"aus2025_signature_mzinho_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_mzinho_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_mzinho_gold"
	"sticker_material"		"aus2025/sig_mzinho_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"122"
	"tournament_player_id"		"878556854"
}
"8799"
{
	"name"		"aus2025_signature_maj3r_2"
	"item_name"		"#StickerKit_aus2025_signature_maj3r"
	"description_string"		"#StickerKit_desc_aus2025_signature_maj3r"
	"sticker_material"		"aus2025/sig_maj3r"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"7167161"
}
"8800"
{
	"name"		"aus2025_signature_maj3r_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_maj3r_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_maj3r_foil"
	"sticker_material"		"aus2025/sig_maj3r_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"7167161"
}
"8801"
{
	"name"		"aus2025_signature_maj3r_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_maj3r_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_maj3r_holo"
	"sticker_material"		"aus2025/sig_maj3r_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"7167161"
}
"8802"
{
	"name"		"aus2025_signature_maj3r_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_maj3r_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_maj3r_gold"
	"sticker_material"		"aus2025/sig_maj3r_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"7167161"
}
"8803"
{
	"name"		"aus2025_signature_xantares_2"
	"item_name"		"#StickerKit_aus2025_signature_xantares"
	"description_string"		"#StickerKit_desc_aus2025_signature_xantares"
	"sticker_material"		"aus2025/sig_xantares"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"83853068"
}
"8804"
{
	"name"		"aus2025_signature_xantares_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_xantares_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_xantares_foil"
	"sticker_material"		"aus2025/sig_xantares_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"83853068"
}
"8805"
{
	"name"		"aus2025_signature_xantares_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_xantares_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_xantares_holo"
	"sticker_material"		"aus2025/sig_xantares_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"83853068"
}
"8806"
{
	"name"		"aus2025_signature_xantares_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_xantares_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_xantares_gold"
	"sticker_material"		"aus2025/sig_xantares_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"83853068"
}
"8807"
{
	"name"		"aus2025_signature_jottaaa_2"
	"item_name"		"#StickerKit_aus2025_signature_jottaaa"
	"description_string"		"#StickerKit_desc_aus2025_signature_jottaaa"
	"sticker_material"		"aus2025/sig_jottaaa"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"450484535"
}
"8808"
{
	"name"		"aus2025_signature_jottaaa_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_jottaaa_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_jottaaa_foil"
	"sticker_material"		"aus2025/sig_jottaaa_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"450484535"
}
"8809"
{
	"name"		"aus2025_signature_jottaaa_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_jottaaa_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_jottaaa_holo"
	"sticker_material"		"aus2025/sig_jottaaa_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"450484535"
}
"8810"
{
	"name"		"aus2025_signature_jottaaa_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_jottaaa_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_jottaaa_gold"
	"sticker_material"		"aus2025/sig_jottaaa_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"450484535"
}
"8811"
{
	"name"		"aus2025_signature_wicadia_2"
	"item_name"		"#StickerKit_aus2025_signature_wicadia"
	"description_string"		"#StickerKit_desc_aus2025_signature_wicadia"
	"sticker_material"		"aus2025/sig_wicadia"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"852248195"
}
"8812"
{
	"name"		"aus2025_signature_wicadia_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_wicadia_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_wicadia_foil"
	"sticker_material"		"aus2025/sig_wicadia_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"852248195"
}
"8813"
{
	"name"		"aus2025_signature_wicadia_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_wicadia_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_wicadia_holo"
	"sticker_material"		"aus2025/sig_wicadia_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"852248195"
}
"8814"
{
	"name"		"aus2025_signature_wicadia_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_wicadia_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_wicadia_gold"
	"sticker_material"		"aus2025/sig_wicadia_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"852248195"
}
"8815"
{
	"name"		"aus2025_signature_woxic_2"
	"item_name"		"#StickerKit_aus2025_signature_woxic"
	"description_string"		"#StickerKit_desc_aus2025_signature_woxic"
	"sticker_material"		"aus2025/sig_woxic"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"123219778"
}
"8816"
{
	"name"		"aus2025_signature_woxic_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_woxic_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_woxic_foil"
	"sticker_material"		"aus2025/sig_woxic_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"123219778"
}
"8817"
{
	"name"		"aus2025_signature_woxic_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_woxic_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_woxic_holo"
	"sticker_material"		"aus2025/sig_woxic_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"123219778"
}
"8818"
{
	"name"		"aus2025_signature_woxic_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_woxic_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_woxic_gold"
	"sticker_material"		"aus2025/sig_woxic_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"134"
	"tournament_player_id"		"123219778"
}
"8819"
{
	"name"		"aus2025_signature_w0nderful_2"
	"item_name"		"#StickerKit_aus2025_signature_w0nderful"
	"description_string"		"#StickerKit_desc_aus2025_signature_w0nderful"
	"sticker_material"		"aus2025/sig_w0nderful"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"1102803112"
}
"8820"
{
	"name"		"aus2025_signature_w0nderful_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_w0nderful_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_w0nderful_foil"
	"sticker_material"		"aus2025/sig_w0nderful_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"1102803112"
}
"8821"
{
	"name"		"aus2025_signature_w0nderful_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_w0nderful_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_w0nderful_holo"
	"sticker_material"		"aus2025/sig_w0nderful_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"1102803112"
}
"8822"
{
	"name"		"aus2025_signature_w0nderful_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_w0nderful_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_w0nderful_gold"
	"sticker_material"		"aus2025/sig_w0nderful_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"1102803112"
}
"8823"
{
	"name"		"aus2025_signature_aleksib_2"
	"item_name"		"#StickerKit_aus2025_signature_aleksib"
	"description_string"		"#StickerKit_desc_aus2025_signature_aleksib"
	"sticker_material"		"aus2025/sig_aleksib"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"52977598"
}
"8824"
{
	"name"		"aus2025_signature_aleksib_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_aleksib_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_aleksib_foil"
	"sticker_material"		"aus2025/sig_aleksib_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"52977598"
}
"8825"
{
	"name"		"aus2025_signature_aleksib_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_aleksib_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_aleksib_holo"
	"sticker_material"		"aus2025/sig_aleksib_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"52977598"
}
"8826"
{
	"name"		"aus2025_signature_aleksib_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_aleksib_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_aleksib_gold"
	"sticker_material"		"aus2025/sig_aleksib_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"52977598"
}
"8827"
{
	"name"		"aus2025_signature_jl_2"
	"item_name"		"#StickerKit_aus2025_signature_jl"
	"description_string"		"#StickerKit_desc_aus2025_signature_jl"
	"sticker_material"		"aus2025/sig_jl"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"216612575"
}
"8828"
{
	"name"		"aus2025_signature_jl_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_jl_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_jl_foil"
	"sticker_material"		"aus2025/sig_jl_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"216612575"
}
"8829"
{
	"name"		"aus2025_signature_jl_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_jl_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_jl_holo"
	"sticker_material"		"aus2025/sig_jl_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"216612575"
}
"8830"
{
	"name"		"aus2025_signature_jl_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_jl_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_jl_gold"
	"sticker_material"		"aus2025/sig_jl_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"216612575"
}
"8831"
{
	"name"		"aus2025_signature_b1t_2"
	"item_name"		"#StickerKit_aus2025_signature_b1t"
	"description_string"		"#StickerKit_desc_aus2025_signature_b1t"
	"sticker_material"		"aus2025/sig_b1t"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"286341748"
}
"8832"
{
	"name"		"aus2025_signature_b1t_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_b1t_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_b1t_foil"
	"sticker_material"		"aus2025/sig_b1t_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"286341748"
}
"8833"
{
	"name"		"aus2025_signature_b1t_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_b1t_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_b1t_holo"
	"sticker_material"		"aus2025/sig_b1t_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"286341748"
}
"8834"
{
	"name"		"aus2025_signature_b1t_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_b1t_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_b1t_gold"
	"sticker_material"		"aus2025/sig_b1t_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"286341748"
}
"8835"
{
	"name"		"aus2025_signature_im_2"
	"item_name"		"#StickerKit_aus2025_signature_im"
	"description_string"		"#StickerKit_desc_aus2025_signature_im"
	"sticker_material"		"aus2025/sig_im"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"89984505"
}
"8836"
{
	"name"		"aus2025_signature_im_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_im_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_im_foil"
	"sticker_material"		"aus2025/sig_im_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"89984505"
}
"8837"
{
	"name"		"aus2025_signature_im_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_im_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_im_holo"
	"sticker_material"		"aus2025/sig_im_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"89984505"
}
"8838"
{
	"name"		"aus2025_signature_im_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_im_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_im_gold"
	"sticker_material"		"aus2025/sig_im_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"12"
	"tournament_player_id"		"89984505"
}
"8839"
{
	"name"		"aus2025_signature_snax_2"
	"item_name"		"#StickerKit_aus2025_signature_snax"
	"description_string"		"#StickerKit_desc_aus2025_signature_snax"
	"sticker_material"		"aus2025/sig_snax"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"21875845"
}
"8840"
{
	"name"		"aus2025_signature_snax_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_snax_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_snax_foil"
	"sticker_material"		"aus2025/sig_snax_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"21875845"
}
"8841"
{
	"name"		"aus2025_signature_snax_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_snax_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_snax_holo"
	"sticker_material"		"aus2025/sig_snax_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"21875845"
}
"8842"
{
	"name"		"aus2025_signature_snax_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_snax_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_snax_gold"
	"sticker_material"		"aus2025/sig_snax_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"21875845"
}
"8843"
{
	"name"		"aus2025_signature_hunter_2"
	"item_name"		"#StickerKit_aus2025_signature_hunter"
	"description_string"		"#StickerKit_desc_aus2025_signature_hunter"
	"sticker_material"		"aus2025/sig_hunter"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"52606325"
}
"8844"
{
	"name"		"aus2025_signature_hunter_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_hunter_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_hunter_foil"
	"sticker_material"		"aus2025/sig_hunter_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"52606325"
}
"8845"
{
	"name"		"aus2025_signature_hunter_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_hunter_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_hunter_holo"
	"sticker_material"		"aus2025/sig_hunter_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"52606325"
}
"8846"
{
	"name"		"aus2025_signature_hunter_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_hunter_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_hunter_gold"
	"sticker_material"		"aus2025/sig_hunter_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"52606325"
}
"8847"
{
	"name"		"aus2025_signature_malbsmd_2"
	"item_name"		"#StickerKit_aus2025_signature_malbsmd"
	"description_string"		"#StickerKit_desc_aus2025_signature_malbsmd"
	"sticker_material"		"aus2025/sig_malbsmd"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"120437415"
}
"8848"
{
	"name"		"aus2025_signature_malbsmd_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_malbsmd_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_malbsmd_foil"
	"sticker_material"		"aus2025/sig_malbsmd_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"120437415"
}
"8849"
{
	"name"		"aus2025_signature_malbsmd_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_malbsmd_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_malbsmd_holo"
	"sticker_material"		"aus2025/sig_malbsmd_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"120437415"
}
"8850"
{
	"name"		"aus2025_signature_malbsmd_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_malbsmd_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_malbsmd_gold"
	"sticker_material"		"aus2025/sig_malbsmd_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"120437415"
}
"8851"
{
	"name"		"aus2025_signature_heavygod_2"
	"item_name"		"#StickerKit_aus2025_signature_heavygod"
	"description_string"		"#StickerKit_desc_aus2025_signature_heavygod"
	"sticker_material"		"aus2025/sig_heavygod"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"107737265"
}
"8852"
{
	"name"		"aus2025_signature_heavygod_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_heavygod_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_heavygod_foil"
	"sticker_material"		"aus2025/sig_heavygod_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"107737265"
}
"8853"
{
	"name"		"aus2025_signature_heavygod_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_heavygod_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_heavygod_holo"
	"sticker_material"		"aus2025/sig_heavygod_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"107737265"
}
"8854"
{
	"name"		"aus2025_signature_heavygod_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_heavygod_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_heavygod_gold"
	"sticker_material"		"aus2025/sig_heavygod_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"107737265"
}
"8855"
{
	"name"		"aus2025_signature_hades_2"
	"item_name"		"#StickerKit_aus2025_signature_hades"
	"description_string"		"#StickerKit_desc_aus2025_signature_hades"
	"sticker_material"		"aus2025/sig_hades"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"90656280"
}
"8856"
{
	"name"		"aus2025_signature_hades_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_hades_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_hades_foil"
	"sticker_material"		"aus2025/sig_hades_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"90656280"
}
"8857"
{
	"name"		"aus2025_signature_hades_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_hades_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_hades_holo"
	"sticker_material"		"aus2025/sig_hades_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"90656280"
}
"8858"
{
	"name"		"aus2025_signature_hades_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_hades_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_hades_gold"
	"sticker_material"		"aus2025/sig_hades_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"59"
	"tournament_player_id"		"90656280"
}
"8859"
{
	"name"		"aus2025_signature_twistzz_2"
	"item_name"		"#StickerKit_aus2025_signature_twistzz"
	"description_string"		"#StickerKit_desc_aus2025_signature_twistzz"
	"sticker_material"		"aus2025/sig_twistzz"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"55989477"
}
"8860"
{
	"name"		"aus2025_signature_twistzz_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_twistzz_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_twistzz_foil"
	"sticker_material"		"aus2025/sig_twistzz_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"55989477"
}
"8861"
{
	"name"		"aus2025_signature_twistzz_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_twistzz_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_twistzz_holo"
	"sticker_material"		"aus2025/sig_twistzz_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"55989477"
}
"8862"
{
	"name"		"aus2025_signature_twistzz_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_twistzz_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_twistzz_gold"
	"sticker_material"		"aus2025/sig_twistzz_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"55989477"
}
"8863"
{
	"name"		"aus2025_signature_ultimate_2"
	"item_name"		"#StickerKit_aus2025_signature_ultimate"
	"description_string"		"#StickerKit_desc_aus2025_signature_ultimate"
	"sticker_material"		"aus2025/sig_ultimate"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"323723495"
}
"8864"
{
	"name"		"aus2025_signature_ultimate_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_ultimate_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_ultimate_foil"
	"sticker_material"		"aus2025/sig_ultimate_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"323723495"
}
"8865"
{
	"name"		"aus2025_signature_ultimate_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_ultimate_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_ultimate_holo"
	"sticker_material"		"aus2025/sig_ultimate_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"323723495"
}
"8866"
{
	"name"		"aus2025_signature_ultimate_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_ultimate_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_ultimate_gold"
	"sticker_material"		"aus2025/sig_ultimate_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"323723495"
}
"8867"
{
	"name"		"aus2025_signature_nertz_2"
	"item_name"		"#StickerKit_aus2025_signature_nertz"
	"description_string"		"#StickerKit_desc_aus2025_signature_nertz"
	"sticker_material"		"aus2025/sig_nertz"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"92860917"
}
"8868"
{
	"name"		"aus2025_signature_nertz_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_nertz_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_nertz_foil"
	"sticker_material"		"aus2025/sig_nertz_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"92860917"
}
"8869"
{
	"name"		"aus2025_signature_nertz_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_nertz_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_nertz_holo"
	"sticker_material"		"aus2025/sig_nertz_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"92860917"
}
"8870"
{
	"name"		"aus2025_signature_nertz_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_nertz_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_nertz_gold"
	"sticker_material"		"aus2025/sig_nertz_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"92860917"
}
"8871"
{
	"name"		"aus2025_signature_siuhy_2"
	"item_name"		"#StickerKit_aus2025_signature_siuhy"
	"description_string"		"#StickerKit_desc_aus2025_signature_siuhy"
	"sticker_material"		"aus2025/sig_siuhy"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"190407632"
}
"8872"
{
	"name"		"aus2025_signature_siuhy_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_siuhy_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_siuhy_foil"
	"sticker_material"		"aus2025/sig_siuhy_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"190407632"
}
"8873"
{
	"name"		"aus2025_signature_siuhy_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_siuhy_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_siuhy_holo"
	"sticker_material"		"aus2025/sig_siuhy_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"190407632"
}
"8874"
{
	"name"		"aus2025_signature_siuhy_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_siuhy_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_siuhy_gold"
	"sticker_material"		"aus2025/sig_siuhy_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"190407632"
}
"8875"
{
	"name"		"aus2025_signature_naf_2"
	"item_name"		"#StickerKit_aus2025_signature_naf"
	"description_string"		"#StickerKit_desc_aus2025_signature_naf"
	"sticker_material"		"aus2025/sig_naf"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"40885967"
}
"8876"
{
	"name"		"aus2025_signature_naf_2_foil"
	"item_name"		"#StickerKit_aus2025_signature_naf_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_naf_foil"
	"sticker_material"		"aus2025/sig_naf_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"40885967"
}
"8877"
{
	"name"		"aus2025_signature_naf_2_holo"
	"item_name"		"#StickerKit_aus2025_signature_naf_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_naf_holo"
	"sticker_material"		"aus2025/sig_naf_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"40885967"
}
"8878"
{
	"name"		"aus2025_signature_naf_2_gold"
	"item_name"		"#StickerKit_aus2025_signature_naf_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_naf_gold"
	"sticker_material"		"aus2025/sig_naf_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"48"
	"tournament_player_id"		"40885967"
}
"8879"
{
	"name"		"aus2025_signature_niko_1"
	"item_name"		"#StickerKit_aus2025_signature_niko"
	"description_string"		"#StickerKit_desc_aus2025_signature_niko"
	"sticker_material"		"aus2025/sig_niko"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"81417650"
}
"8880"
{
	"name"		"aus2025_signature_niko_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_niko_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_niko_foil"
	"sticker_material"		"aus2025/sig_niko_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"81417650"
}
"8881"
{
	"name"		"aus2025_signature_niko_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_niko_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_niko_holo"
	"sticker_material"		"aus2025/sig_niko_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"81417650"
}
"8882"
{
	"name"		"aus2025_signature_niko_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_niko_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_niko_gold"
	"sticker_material"		"aus2025/sig_niko_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"81417650"
}
"8883"
{
	"name"		"aus2025_signature_kyxsan_1"
	"item_name"		"#StickerKit_aus2025_signature_kyxsan"
	"description_string"		"#StickerKit_desc_aus2025_signature_kyxsan"
	"sticker_material"		"aus2025/sig_kyxsan"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"97016704"
}
"8884"
{
	"name"		"aus2025_signature_kyxsan_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_kyxsan_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_kyxsan_foil"
	"sticker_material"		"aus2025/sig_kyxsan_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"97016704"
}
"8885"
{
	"name"		"aus2025_signature_kyxsan_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_kyxsan_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_kyxsan_holo"
	"sticker_material"		"aus2025/sig_kyxsan_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"97016704"
}
"8886"
{
	"name"		"aus2025_signature_kyxsan_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_kyxsan_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_kyxsan_gold"
	"sticker_material"		"aus2025/sig_kyxsan_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"97016704"
}
"8887"
{
	"name"		"aus2025_signature_m0nesy_1"
	"item_name"		"#StickerKit_aus2025_signature_m0nesy"
	"description_string"		"#StickerKit_desc_aus2025_signature_m0nesy"
	"sticker_material"		"aus2025/sig_m0nesy"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"114497073"
}
"8888"
{
	"name"		"aus2025_signature_m0nesy_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_m0nesy_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_m0nesy_foil"
	"sticker_material"		"aus2025/sig_m0nesy_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"114497073"
}
"8889"
{
	"name"		"aus2025_signature_m0nesy_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_m0nesy_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_m0nesy_holo"
	"sticker_material"		"aus2025/sig_m0nesy_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"114497073"
}
"8890"
{
	"name"		"aus2025_signature_m0nesy_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_m0nesy_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_m0nesy_gold"
	"sticker_material"		"aus2025/sig_m0nesy_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"114497073"
}
"8891"
{
	"name"		"aus2025_signature_teses_1"
	"item_name"		"#StickerKit_aus2025_signature_teses"
	"description_string"		"#StickerKit_desc_aus2025_signature_teses"
	"sticker_material"		"aus2025/sig_teses"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"36412550"
}
"8892"
{
	"name"		"aus2025_signature_teses_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_teses_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_teses_foil"
	"sticker_material"		"aus2025/sig_teses_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"36412550"
}
"8893"
{
	"name"		"aus2025_signature_teses_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_teses_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_teses_holo"
	"sticker_material"		"aus2025/sig_teses_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"36412550"
}
"8894"
{
	"name"		"aus2025_signature_teses_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_teses_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_teses_gold"
	"sticker_material"		"aus2025/sig_teses_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"36412550"
}
"8895"
{
	"name"		"aus2025_signature_magisk_1"
	"item_name"		"#StickerKit_aus2025_signature_magisk"
	"description_string"		"#StickerKit_desc_aus2025_signature_magisk"
	"sticker_material"		"aus2025/sig_magisk"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"23690923"
}
"8896"
{
	"name"		"aus2025_signature_magisk_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_magisk_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_magisk_foil"
	"sticker_material"		"aus2025/sig_magisk_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"23690923"
}
"8897"
{
	"name"		"aus2025_signature_magisk_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_magisk_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_magisk_holo"
	"sticker_material"		"aus2025/sig_magisk_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"23690923"
}
"8898"
{
	"name"		"aus2025_signature_magisk_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_magisk_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_magisk_gold"
	"sticker_material"		"aus2025/sig_magisk_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"139"
	"tournament_player_id"		"23690923"
}
"8899"
{
	"name"		"aus2025_signature_karrigan_1"
	"item_name"		"#StickerKit_aus2025_signature_karrigan"
	"description_string"		"#StickerKit_desc_aus2025_signature_karrigan"
	"sticker_material"		"aus2025/sig_karrigan"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"29164525"
}
"8900"
{
	"name"		"aus2025_signature_karrigan_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_karrigan_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_karrigan_foil"
	"sticker_material"		"aus2025/sig_karrigan_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"29164525"
}
"8901"
{
	"name"		"aus2025_signature_karrigan_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_karrigan_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_karrigan_holo"
	"sticker_material"		"aus2025/sig_karrigan_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"29164525"
}
"8902"
{
	"name"		"aus2025_signature_karrigan_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_karrigan_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_karrigan_gold"
	"sticker_material"		"aus2025/sig_karrigan_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"29164525"
}
"8903"
{
	"name"		"aus2025_signature_broky_1"
	"item_name"		"#StickerKit_aus2025_signature_broky"
	"description_string"		"#StickerKit_desc_aus2025_signature_broky"
	"sticker_material"		"aus2025/sig_broky"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"241354762"
}
"8904"
{
	"name"		"aus2025_signature_broky_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_broky_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_broky_foil"
	"sticker_material"		"aus2025/sig_broky_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"241354762"
}
"8905"
{
	"name"		"aus2025_signature_broky_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_broky_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_broky_holo"
	"sticker_material"		"aus2025/sig_broky_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"241354762"
}
"8906"
{
	"name"		"aus2025_signature_broky_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_broky_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_broky_gold"
	"sticker_material"		"aus2025/sig_broky_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"241354762"
}
"8907"
{
	"name"		"aus2025_signature_elige_1"
	"item_name"		"#StickerKit_aus2025_signature_elige"
	"description_string"		"#StickerKit_desc_aus2025_signature_elige"
	"sticker_material"		"aus2025/sig_elige"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"106428011"
}
"8908"
{
	"name"		"aus2025_signature_elige_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_elige_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_elige_foil"
	"sticker_material"		"aus2025/sig_elige_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"106428011"
}
"8909"
{
	"name"		"aus2025_signature_elige_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_elige_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_elige_holo"
	"sticker_material"		"aus2025/sig_elige_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"106428011"
}
"8910"
{
	"name"		"aus2025_signature_elige_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_elige_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_elige_gold"
	"sticker_material"		"aus2025/sig_elige_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"106428011"
}
"8911"
{
	"name"		"aus2025_signature_frozen_1"
	"item_name"		"#StickerKit_aus2025_signature_frozen"
	"description_string"		"#StickerKit_desc_aus2025_signature_frozen"
	"sticker_material"		"aus2025/sig_frozen"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"108157034"
}
"8912"
{
	"name"		"aus2025_signature_frozen_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_frozen_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_frozen_foil"
	"sticker_material"		"aus2025/sig_frozen_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"108157034"
}
"8913"
{
	"name"		"aus2025_signature_frozen_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_frozen_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_frozen_holo"
	"sticker_material"		"aus2025/sig_frozen_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"108157034"
}
"8914"
{
	"name"		"aus2025_signature_frozen_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_frozen_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_frozen_gold"
	"sticker_material"		"aus2025/sig_frozen_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"108157034"
}
"8915"
{
	"name"		"aus2025_signature_rain_1"
	"item_name"		"#StickerKit_aus2025_signature_rain"
	"description_string"		"#StickerKit_desc_aus2025_signature_rain"
	"sticker_material"		"aus2025/sig_rain"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"37085479"
}
"8916"
{
	"name"		"aus2025_signature_rain_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_rain_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_rain_foil"
	"sticker_material"		"aus2025/sig_rain_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"37085479"
}
"8917"
{
	"name"		"aus2025_signature_rain_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_rain_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_rain_holo"
	"sticker_material"		"aus2025/sig_rain_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"37085479"
}
"8918"
{
	"name"		"aus2025_signature_rain_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_rain_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_rain_gold"
	"sticker_material"		"aus2025/sig_rain_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"61"
	"tournament_player_id"		"37085479"
}
"8919"
{
	"name"		"aus2025_signature_maka_1"
	"item_name"		"#StickerKit_aus2025_signature_maka"
	"description_string"		"#StickerKit_desc_aus2025_signature_maka"
	"sticker_material"		"aus2025/sig_maka"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"85474033"
}
"8920"
{
	"name"		"aus2025_signature_maka_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_maka_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_maka_foil"
	"sticker_material"		"aus2025/sig_maka_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"85474033"
}
"8921"
{
	"name"		"aus2025_signature_maka_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_maka_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_maka_holo"
	"sticker_material"		"aus2025/sig_maka_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"85474033"
}
"8922"
{
	"name"		"aus2025_signature_maka_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_maka_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_maka_gold"
	"sticker_material"		"aus2025/sig_maka_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"85474033"
}
"8923"
{
	"name"		"aus2025_signature_ex3rcice_1"
	"item_name"		"#StickerKit_aus2025_signature_ex3rcice"
	"description_string"		"#StickerKit_desc_aus2025_signature_ex3rcice"
	"sticker_material"		"aus2025/sig_ex3rcice"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"207932472"
}
"8924"
{
	"name"		"aus2025_signature_ex3rcice_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_ex3rcice_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_ex3rcice_foil"
	"sticker_material"		"aus2025/sig_ex3rcice_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"207932472"
}
"8925"
{
	"name"		"aus2025_signature_ex3rcice_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_ex3rcice_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_ex3rcice_holo"
	"sticker_material"		"aus2025/sig_ex3rcice_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"207932472"
}
"8926"
{
	"name"		"aus2025_signature_ex3rcice_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_ex3rcice_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_ex3rcice_gold"
	"sticker_material"		"aus2025/sig_ex3rcice_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"207932472"
}
"8927"
{
	"name"		"aus2025_signature_lucky_1"
	"item_name"		"#StickerKit_aus2025_signature_lucky"
	"description_string"		"#StickerKit_desc_aus2025_signature_lucky"
	"sticker_material"		"aus2025/sig_lucky"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"71624387"
}
"8928"
{
	"name"		"aus2025_signature_lucky_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_lucky_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_lucky_foil"
	"sticker_material"		"aus2025/sig_lucky_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"71624387"
}
"8929"
{
	"name"		"aus2025_signature_lucky_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_lucky_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_lucky_holo"
	"sticker_material"		"aus2025/sig_lucky_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"71624387"
}
"8930"
{
	"name"		"aus2025_signature_lucky_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_lucky_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_lucky_gold"
	"sticker_material"		"aus2025/sig_lucky_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"71624387"
}
"8931"
{
	"name"		"aus2025_signature_graviti_1"
	"item_name"		"#StickerKit_aus2025_signature_graviti"
	"description_string"		"#StickerKit_desc_aus2025_signature_graviti"
	"sticker_material"		"aus2025/sig_graviti"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"219272777"
}
"8932"
{
	"name"		"aus2025_signature_graviti_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_graviti_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_graviti_foil"
	"sticker_material"		"aus2025/sig_graviti_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"219272777"
}
"8933"
{
	"name"		"aus2025_signature_graviti_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_graviti_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_graviti_holo"
	"sticker_material"		"aus2025/sig_graviti_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"219272777"
}
"8934"
{
	"name"		"aus2025_signature_graviti_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_graviti_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_graviti_gold"
	"sticker_material"		"aus2025/sig_graviti_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"219272777"
}
"8935"
{
	"name"		"aus2025_signature_bodyy_1"
	"item_name"		"#StickerKit_aus2025_signature_bodyy"
	"description_string"		"#StickerKit_desc_aus2025_signature_bodyy"
	"sticker_material"		"aus2025/sig_bodyy"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"53029647"
}
"8936"
{
	"name"		"aus2025_signature_bodyy_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_bodyy_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_bodyy_foil"
	"sticker_material"		"aus2025/sig_bodyy_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"53029647"
}
"8937"
{
	"name"		"aus2025_signature_bodyy_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_bodyy_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_bodyy_holo"
	"sticker_material"		"aus2025/sig_bodyy_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"53029647"
}
"8938"
{
	"name"		"aus2025_signature_bodyy_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_bodyy_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_bodyy_gold"
	"sticker_material"		"aus2025/sig_bodyy_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"28"
	"tournament_player_id"		"53029647"
}
"8939"
{
	"name"		"aus2025_signature_fl1t_1"
	"item_name"		"#StickerKit_aus2025_signature_fl1t"
	"description_string"		"#StickerKit_desc_aus2025_signature_fl1t"
	"sticker_material"		"aus2025/sig_fl1t"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"35551773"
}
"8940"
{
	"name"		"aus2025_signature_fl1t_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_fl1t_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_fl1t_foil"
	"sticker_material"		"aus2025/sig_fl1t_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"35551773"
}
"8941"
{
	"name"		"aus2025_signature_fl1t_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_fl1t_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_fl1t_holo"
	"sticker_material"		"aus2025/sig_fl1t_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"35551773"
}
"8942"
{
	"name"		"aus2025_signature_fl1t_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_fl1t_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_fl1t_gold"
	"sticker_material"		"aus2025/sig_fl1t_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"35551773"
}
"8943"
{
	"name"		"aus2025_signature_fame_1"
	"item_name"		"#StickerKit_aus2025_signature_fame"
	"description_string"		"#StickerKit_desc_aus2025_signature_fame"
	"sticker_material"		"aus2025/sig_fame"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"119848818"
}
"8944"
{
	"name"		"aus2025_signature_fame_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_fame_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_fame_foil"
	"sticker_material"		"aus2025/sig_fame_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"119848818"
}
"8945"
{
	"name"		"aus2025_signature_fame_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_fame_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_fame_holo"
	"sticker_material"		"aus2025/sig_fame_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"119848818"
}
"8946"
{
	"name"		"aus2025_signature_fame_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_fame_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_fame_gold"
	"sticker_material"		"aus2025/sig_fame_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"119848818"
}
"8947"
{
	"name"		"aus2025_signature_electronic_1"
	"item_name"		"#StickerKit_aus2025_signature_electronic"
	"description_string"		"#StickerKit_desc_aus2025_signature_electronic"
	"sticker_material"		"aus2025/sig_electronic"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"83779379"
}
"8948"
{
	"name"		"aus2025_signature_electronic_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_electronic_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_electronic_foil"
	"sticker_material"		"aus2025/sig_electronic_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"83779379"
}
"8949"
{
	"name"		"aus2025_signature_electronic_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_electronic_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_electronic_holo"
	"sticker_material"		"aus2025/sig_electronic_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"83779379"
}
"8950"
{
	"name"		"aus2025_signature_electronic_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_electronic_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_electronic_gold"
	"sticker_material"		"aus2025/sig_electronic_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"83779379"
}
"8951"
{
	"name"		"aus2025_signature_fl4mus_1"
	"item_name"		"#StickerKit_aus2025_signature_fl4mus"
	"description_string"		"#StickerKit_desc_aus2025_signature_fl4mus"
	"sticker_material"		"aus2025/sig_fl4mus"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"53993406"
}
"8952"
{
	"name"		"aus2025_signature_fl4mus_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_fl4mus_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_fl4mus_foil"
	"sticker_material"		"aus2025/sig_fl4mus_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"53993406"
}
"8953"
{
	"name"		"aus2025_signature_fl4mus_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_fl4mus_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_fl4mus_holo"
	"sticker_material"		"aus2025/sig_fl4mus_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"53993406"
}
"8954"
{
	"name"		"aus2025_signature_fl4mus_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_fl4mus_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_fl4mus_gold"
	"sticker_material"		"aus2025/sig_fl4mus_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"53993406"
}
"8955"
{
	"name"		"aus2025_signature_icy_1"
	"item_name"		"#StickerKit_aus2025_signature_icy"
	"description_string"		"#StickerKit_desc_aus2025_signature_icy"
	"sticker_material"		"aus2025/sig_icy"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"94843300"
}
"8956"
{
	"name"		"aus2025_signature_icy_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_icy_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_icy_foil"
	"sticker_material"		"aus2025/sig_icy_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"94843300"
}
"8957"
{
	"name"		"aus2025_signature_icy_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_icy_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_icy_holo"
	"sticker_material"		"aus2025/sig_icy_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"94843300"
}
"8958"
{
	"name"		"aus2025_signature_icy_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_icy_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_icy_gold"
	"sticker_material"		"aus2025/sig_icy_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"31"
	"tournament_player_id"		"94843300"
}
"8959"
{
	"name"		"aus2025_signature_biguzera_1"
	"item_name"		"#StickerKit_aus2025_signature_biguzera"
	"description_string"		"#StickerKit_desc_aus2025_signature_biguzera"
	"sticker_material"		"aus2025/sig_biguzera"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"55043156"
}
"8960"
{
	"name"		"aus2025_signature_biguzera_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_biguzera_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_biguzera_foil"
	"sticker_material"		"aus2025/sig_biguzera_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"55043156"
}
"8961"
{
	"name"		"aus2025_signature_biguzera_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_biguzera_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_biguzera_holo"
	"sticker_material"		"aus2025/sig_biguzera_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"55043156"
}
"8962"
{
	"name"		"aus2025_signature_biguzera_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_biguzera_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_biguzera_gold"
	"sticker_material"		"aus2025/sig_biguzera_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"55043156"
}
"8963"
{
	"name"		"aus2025_signature_nqz_1"
	"item_name"		"#StickerKit_aus2025_signature_nqz"
	"description_string"		"#StickerKit_desc_aus2025_signature_nqz"
	"sticker_material"		"aus2025/sig_nqz"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"390076777"
}
"8964"
{
	"name"		"aus2025_signature_nqz_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_nqz_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_nqz_foil"
	"sticker_material"		"aus2025/sig_nqz_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"390076777"
}
"8965"
{
	"name"		"aus2025_signature_nqz_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_nqz_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_nqz_holo"
	"sticker_material"		"aus2025/sig_nqz_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"390076777"
}
"8966"
{
	"name"		"aus2025_signature_nqz_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_nqz_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_nqz_gold"
	"sticker_material"		"aus2025/sig_nqz_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"390076777"
}
"8967"
{
	"name"		"aus2025_signature_snow_1"
	"item_name"		"#StickerKit_aus2025_signature_snow"
	"description_string"		"#StickerKit_desc_aus2025_signature_snow"
	"sticker_material"		"aus2025/sig_snow"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"417070118"
}
"8968"
{
	"name"		"aus2025_signature_snow_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_snow_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_snow_foil"
	"sticker_material"		"aus2025/sig_snow_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"417070118"
}
"8969"
{
	"name"		"aus2025_signature_snow_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_snow_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_snow_holo"
	"sticker_material"		"aus2025/sig_snow_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"417070118"
}
"8970"
{
	"name"		"aus2025_signature_snow_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_snow_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_snow_gold"
	"sticker_material"		"aus2025/sig_snow_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"417070118"
}
"8971"
{
	"name"		"aus2025_signature_dav1deus_1"
	"item_name"		"#StickerKit_aus2025_signature_dav1deus"
	"description_string"		"#StickerKit_desc_aus2025_signature_dav1deus"
	"sticker_material"		"aus2025/sig_dav1deus"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"160225583"
}
"8972"
{
	"name"		"aus2025_signature_dav1deus_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_dav1deus_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_dav1deus_foil"
	"sticker_material"		"aus2025/sig_dav1deus_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"160225583"
}
"8973"
{
	"name"		"aus2025_signature_dav1deus_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_dav1deus_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_dav1deus_holo"
	"sticker_material"		"aus2025/sig_dav1deus_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"160225583"
}
"8974"
{
	"name"		"aus2025_signature_dav1deus_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_dav1deus_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_dav1deus_gold"
	"sticker_material"		"aus2025/sig_dav1deus_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"160225583"
}
"8975"
{
	"name"		"aus2025_signature_dgt_1"
	"item_name"		"#StickerKit_aus2025_signature_dgt"
	"description_string"		"#StickerKit_desc_aus2025_signature_dgt"
	"sticker_material"		"aus2025/sig_dgt"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"256625848"
}
"8976"
{
	"name"		"aus2025_signature_dgt_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_dgt_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_dgt_foil"
	"sticker_material"		"aus2025/sig_dgt_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"256625848"
}
"8977"
{
	"name"		"aus2025_signature_dgt_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_dgt_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_dgt_holo"
	"sticker_material"		"aus2025/sig_dgt_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"256625848"
}
"8978"
{
	"name"		"aus2025_signature_dgt_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_dgt_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_dgt_gold"
	"sticker_material"		"aus2025/sig_dgt_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"102"
	"tournament_player_id"		"256625848"
}
"8979"
{
	"name"		"aus2025_signature_fallen_1"
	"item_name"		"#StickerKit_aus2025_signature_fallen"
	"description_string"		"#StickerKit_desc_aus2025_signature_fallen"
	"sticker_material"		"aus2025/sig_fallen"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"424467"
}
"8980"
{
	"name"		"aus2025_signature_fallen_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_fallen_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_fallen_foil"
	"sticker_material"		"aus2025/sig_fallen_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"424467"
}
"8981"
{
	"name"		"aus2025_signature_fallen_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_fallen_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_fallen_holo"
	"sticker_material"		"aus2025/sig_fallen_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"424467"
}
"8982"
{
	"name"		"aus2025_signature_fallen_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_fallen_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_fallen_gold"
	"sticker_material"		"aus2025/sig_fallen_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"424467"
}
"8983"
{
	"name"		"aus2025_signature_yuurih_1"
	"item_name"		"#StickerKit_aus2025_signature_yuurih"
	"description_string"		"#StickerKit_desc_aus2025_signature_yuurih"
	"sticker_material"		"aus2025/sig_yuurih"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"204704832"
}
"8984"
{
	"name"		"aus2025_signature_yuurih_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_yuurih_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_yuurih_foil"
	"sticker_material"		"aus2025/sig_yuurih_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"204704832"
}
"8985"
{
	"name"		"aus2025_signature_yuurih_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_yuurih_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_yuurih_holo"
	"sticker_material"		"aus2025/sig_yuurih_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"204704832"
}
"8986"
{
	"name"		"aus2025_signature_yuurih_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_yuurih_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_yuurih_gold"
	"sticker_material"		"aus2025/sig_yuurih_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"204704832"
}
"8987"
{
	"name"		"aus2025_signature_kscerato_1"
	"item_name"		"#StickerKit_aus2025_signature_kscerato"
	"description_string"		"#StickerKit_desc_aus2025_signature_kscerato"
	"sticker_material"		"aus2025/sig_kscerato"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"98234764"
}
"8988"
{
	"name"		"aus2025_signature_kscerato_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_kscerato_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_kscerato_foil"
	"sticker_material"		"aus2025/sig_kscerato_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"98234764"
}
"8989"
{
	"name"		"aus2025_signature_kscerato_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_kscerato_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_kscerato_holo"
	"sticker_material"		"aus2025/sig_kscerato_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"98234764"
}
"8990"
{
	"name"		"aus2025_signature_kscerato_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_kscerato_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_kscerato_gold"
	"sticker_material"		"aus2025/sig_kscerato_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"98234764"
}
"8991"
{
	"name"		"aus2025_signature_skullz_1"
	"item_name"		"#StickerKit_aus2025_signature_skullz"
	"description_string"		"#StickerKit_desc_aus2025_signature_skullz"
	"sticker_material"		"aus2025/sig_skullz"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"158380916"
}
"8992"
{
	"name"		"aus2025_signature_skullz_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_skullz_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_skullz_foil"
	"sticker_material"		"aus2025/sig_skullz_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"158380916"
}
"8993"
{
	"name"		"aus2025_signature_skullz_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_skullz_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_skullz_holo"
	"sticker_material"		"aus2025/sig_skullz_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"158380916"
}
"8994"
{
	"name"		"aus2025_signature_skullz_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_skullz_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_skullz_gold"
	"sticker_material"		"aus2025/sig_skullz_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"158380916"
}
"8995"
{
	"name"		"aus2025_signature_molodoy_1"
	"item_name"		"#StickerKit_aus2025_signature_molodoy"
	"description_string"		"#StickerKit_desc_aus2025_signature_molodoy"
	"sticker_material"		"aus2025/sig_molodoy"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"240716562"
}
"8996"
{
	"name"		"aus2025_signature_molodoy_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_molodoy_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_molodoy_foil"
	"sticker_material"		"aus2025/sig_molodoy_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"240716562"
}
"8997"
{
	"name"		"aus2025_signature_molodoy_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_molodoy_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_molodoy_holo"
	"sticker_material"		"aus2025/sig_molodoy_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"240716562"
}
"8998"
{
	"name"		"aus2025_signature_molodoy_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_molodoy_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_molodoy_gold"
	"sticker_material"		"aus2025/sig_molodoy_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"85"
	"tournament_player_id"		"240716562"
}
"8999"
{
	"name"		"aus2025_signature_exit_1"
	"item_name"		"#StickerKit_aus2025_signature_exit"
	"description_string"		"#StickerKit_desc_aus2025_signature_exit"
	"sticker_material"		"aus2025/sig_exit"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"50230614"
}
"9000"
{
	"name"		"aus2025_signature_exit_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_exit_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_exit_foil"
	"sticker_material"		"aus2025/sig_exit_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"50230614"
}
"9001"
{
	"name"		"aus2025_signature_exit_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_exit_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_exit_holo"
	"sticker_material"		"aus2025/sig_exit_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"50230614"
}
"9002"
{
	"name"		"aus2025_signature_exit_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_exit_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_exit_gold"
	"sticker_material"		"aus2025/sig_exit_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"50230614"
}
"9003"
{
	"name"		"aus2025_signature_insani_1"
	"item_name"		"#StickerKit_aus2025_signature_insani"
	"description_string"		"#StickerKit_desc_aus2025_signature_insani"
	"sticker_material"		"aus2025/sig_insani"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"101158002"
}
"9004"
{
	"name"		"aus2025_signature_insani_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_insani_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_insani_foil"
	"sticker_material"		"aus2025/sig_insani_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"101158002"
}
"9005"
{
	"name"		"aus2025_signature_insani_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_insani_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_insani_holo"
	"sticker_material"		"aus2025/sig_insani_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"101158002"
}
"9006"
{
	"name"		"aus2025_signature_insani_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_insani_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_insani_gold"
	"sticker_material"		"aus2025/sig_insani_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"101158002"
}
"9007"
{
	"name"		"aus2025_signature_lucaozy_1"
	"item_name"		"#StickerKit_aus2025_signature_lucaozy"
	"description_string"		"#StickerKit_desc_aus2025_signature_lucaozy"
	"sticker_material"		"aus2025/sig_lucaozy"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"197122745"
}
"9008"
{
	"name"		"aus2025_signature_lucaozy_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_lucaozy_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_lucaozy_foil"
	"sticker_material"		"aus2025/sig_lucaozy_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"197122745"
}
"9009"
{
	"name"		"aus2025_signature_lucaozy_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_lucaozy_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_lucaozy_holo"
	"sticker_material"		"aus2025/sig_lucaozy_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"197122745"
}
"9010"
{
	"name"		"aus2025_signature_lucaozy_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_lucaozy_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_lucaozy_gold"
	"sticker_material"		"aus2025/sig_lucaozy_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"197122745"
}
"9011"
{
	"name"		"aus2025_signature_brnz4n_1"
	"item_name"		"#StickerKit_aus2025_signature_brnz4n"
	"description_string"		"#StickerKit_desc_aus2025_signature_brnz4n"
	"sticker_material"		"aus2025/sig_brnz4n"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"895610852"
}
"9012"
{
	"name"		"aus2025_signature_brnz4n_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_brnz4n_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_brnz4n_foil"
	"sticker_material"		"aus2025/sig_brnz4n_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"895610852"
}
"9013"
{
	"name"		"aus2025_signature_brnz4n_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_brnz4n_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_brnz4n_holo"
	"sticker_material"		"aus2025/sig_brnz4n_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"895610852"
}
"9014"
{
	"name"		"aus2025_signature_brnz4n_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_brnz4n_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_brnz4n_gold"
	"sticker_material"		"aus2025/sig_brnz4n_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"895610852"
}
"9015"
{
	"name"		"aus2025_signature_saffee_1"
	"item_name"		"#StickerKit_aus2025_signature_saffee"
	"description_string"		"#StickerKit_desc_aus2025_signature_saffee"
	"sticker_material"		"aus2025/sig_saffee"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"25299957"
}
"9016"
{
	"name"		"aus2025_signature_saffee_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_saffee_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_saffee_foil"
	"sticker_material"		"aus2025/sig_saffee_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"25299957"
}
"9017"
{
	"name"		"aus2025_signature_saffee_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_saffee_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_saffee_holo"
	"sticker_material"		"aus2025/sig_saffee_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"25299957"
}
"9018"
{
	"name"		"aus2025_signature_saffee_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_saffee_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_saffee_gold"
	"sticker_material"		"aus2025/sig_saffee_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"80"
	"tournament_player_id"		"25299957"
}
"9019"
{
	"name"		"aus2025_signature_reck_1"
	"item_name"		"#StickerKit_aus2025_signature_reck"
	"description_string"		"#StickerKit_desc_aus2025_signature_reck"
	"sticker_material"		"aus2025/sig_reck"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"374549101"
}
"9020"
{
	"name"		"aus2025_signature_reck_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_reck_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_reck_foil"
	"sticker_material"		"aus2025/sig_reck_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"374549101"
}
"9021"
{
	"name"		"aus2025_signature_reck_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_reck_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_reck_holo"
	"sticker_material"		"aus2025/sig_reck_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"374549101"
}
"9022"
{
	"name"		"aus2025_signature_reck_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_reck_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_reck_gold"
	"sticker_material"		"aus2025/sig_reck_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"374549101"
}
"9023"
{
	"name"		"aus2025_signature_lake_1"
	"item_name"		"#StickerKit_aus2025_signature_lake"
	"description_string"		"#StickerKit_desc_aus2025_signature_lake"
	"sticker_material"		"aus2025/sig_lake"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"377218468"
}
"9024"
{
	"name"		"aus2025_signature_lake_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_lake_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_lake_foil"
	"sticker_material"		"aus2025/sig_lake_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"377218468"
}
"9025"
{
	"name"		"aus2025_signature_lake_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_lake_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_lake_holo"
	"sticker_material"		"aus2025/sig_lake_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"377218468"
}
"9026"
{
	"name"		"aus2025_signature_lake_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_lake_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_lake_gold"
	"sticker_material"		"aus2025/sig_lake_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"377218468"
}
"9027"
{
	"name"		"aus2025_signature_swisher_1"
	"item_name"		"#StickerKit_aus2025_signature_swisher"
	"description_string"		"#StickerKit_desc_aus2025_signature_swisher"
	"sticker_material"		"aus2025/sig_swisher"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"222737943"
}
"9028"
{
	"name"		"aus2025_signature_swisher_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_swisher_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_swisher_foil"
	"sticker_material"		"aus2025/sig_swisher_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"222737943"
}
"9029"
{
	"name"		"aus2025_signature_swisher_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_swisher_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_swisher_holo"
	"sticker_material"		"aus2025/sig_swisher_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"222737943"
}
"9030"
{
	"name"		"aus2025_signature_swisher_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_swisher_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_swisher_gold"
	"sticker_material"		"aus2025/sig_swisher_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"222737943"
}
"9031"
{
	"name"		"aus2025_signature_slaxz_1"
	"item_name"		"#StickerKit_aus2025_signature_slaxz"
	"description_string"		"#StickerKit_desc_aus2025_signature_slaxz"
	"sticker_material"		"aus2025/sig_slaxz"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"104087441"
}
"9032"
{
	"name"		"aus2025_signature_slaxz_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_slaxz_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_slaxz_foil"
	"sticker_material"		"aus2025/sig_slaxz_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"104087441"
}
"9033"
{
	"name"		"aus2025_signature_slaxz_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_slaxz_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_slaxz_holo"
	"sticker_material"		"aus2025/sig_slaxz_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"104087441"
}
"9034"
{
	"name"		"aus2025_signature_slaxz_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_slaxz_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_slaxz_gold"
	"sticker_material"		"aus2025/sig_slaxz_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"104087441"
}
"9035"
{
	"name"		"aus2025_signature_s1n_1"
	"item_name"		"#StickerKit_aus2025_signature_s1n"
	"description_string"		"#StickerKit_desc_aus2025_signature_s1n"
	"sticker_material"		"aus2025/sig_s1n"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"230197733"
}
"9036"
{
	"name"		"aus2025_signature_s1n_1_foil"
	"item_name"		"#StickerKit_aus2025_signature_s1n_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_s1n_foil"
	"sticker_material"		"aus2025/sig_s1n_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"230197733"
}
"9037"
{
	"name"		"aus2025_signature_s1n_1_holo"
	"item_name"		"#StickerKit_aus2025_signature_s1n_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_s1n_holo"
	"sticker_material"		"aus2025/sig_s1n_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"230197733"
}
"9038"
{
	"name"		"aus2025_signature_s1n_1_gold"
	"item_name"		"#StickerKit_aus2025_signature_s1n_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_s1n_gold"
	"sticker_material"		"aus2025/sig_s1n_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"140"
	"tournament_player_id"		"230197733"
}
"9039"
{
	"name"		"aus2025_signature_cxzi_4"
	"item_name"		"#StickerKit_aus2025_signature_cxzi"
	"description_string"		"#StickerKit_desc_aus2025_signature_cxzi"
	"sticker_material"		"aus2025/sig_cxzi"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"211453961"
}
"9040"
{
	"name"		"aus2025_signature_cxzi_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_cxzi_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_cxzi_foil"
	"sticker_material"		"aus2025/sig_cxzi_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"211453961"
}
"9041"
{
	"name"		"aus2025_signature_cxzi_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_cxzi_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_cxzi_holo"
	"sticker_material"		"aus2025/sig_cxzi_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"211453961"
}
"9042"
{
	"name"		"aus2025_signature_cxzi_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_cxzi_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_cxzi_gold"
	"sticker_material"		"aus2025/sig_cxzi_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"211453961"
}
"9043"
{
	"name"		"aus2025_signature_grim_4"
	"item_name"		"#StickerKit_aus2025_signature_grim"
	"description_string"		"#StickerKit_desc_aus2025_signature_grim"
	"sticker_material"		"aus2025/sig_grim"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"230970467"
}
"9044"
{
	"name"		"aus2025_signature_grim_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_grim_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_grim_foil"
	"sticker_material"		"aus2025/sig_grim_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"230970467"
}
"9045"
{
	"name"		"aus2025_signature_grim_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_grim_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_grim_holo"
	"sticker_material"		"aus2025/sig_grim_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"230970467"
}
"9046"
{
	"name"		"aus2025_signature_grim_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_grim_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_grim_gold"
	"sticker_material"		"aus2025/sig_grim_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"230970467"
}
"9047"
{
	"name"		"aus2025_signature_hallzerk_4"
	"item_name"		"#StickerKit_aus2025_signature_hallzerk"
	"description_string"		"#StickerKit_desc_aus2025_signature_hallzerk"
	"sticker_material"		"aus2025/sig_hallzerk"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"100101582"
}
"9048"
{
	"name"		"aus2025_signature_hallzerk_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_hallzerk_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_hallzerk_foil"
	"sticker_material"		"aus2025/sig_hallzerk_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"100101582"
}
"9049"
{
	"name"		"aus2025_signature_hallzerk_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_hallzerk_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_hallzerk_holo"
	"sticker_material"		"aus2025/sig_hallzerk_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"100101582"
}
"9050"
{
	"name"		"aus2025_signature_hallzerk_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_hallzerk_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_hallzerk_gold"
	"sticker_material"		"aus2025/sig_hallzerk_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"100101582"
}
"9051"
{
	"name"		"aus2025_signature_jt_4"
	"item_name"		"#StickerKit_aus2025_signature_jt"
	"description_string"		"#StickerKit_desc_aus2025_signature_jt"
	"sticker_material"		"aus2025/sig_jt"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"61449372"
}
"9052"
{
	"name"		"aus2025_signature_jt_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_jt_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_jt_foil"
	"sticker_material"		"aus2025/sig_jt_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"61449372"
}
"9053"
{
	"name"		"aus2025_signature_jt_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_jt_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_jt_holo"
	"sticker_material"		"aus2025/sig_jt_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"61449372"
}
"9054"
{
	"name"		"aus2025_signature_jt_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_jt_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_jt_gold"
	"sticker_material"		"aus2025/sig_jt_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"61449372"
}
"9055"
{
	"name"		"aus2025_signature_nicx_4"
	"item_name"		"#StickerKit_aus2025_signature_nicx"
	"description_string"		"#StickerKit_desc_aus2025_signature_nicx"
	"sticker_material"		"aus2025/sig_nicx"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"449819483"
}
"9056"
{
	"name"		"aus2025_signature_nicx_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_nicx_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_nicx_foil"
	"sticker_material"		"aus2025/sig_nicx_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"449819483"
}
"9057"
{
	"name"		"aus2025_signature_nicx_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_nicx_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_nicx_holo"
	"sticker_material"		"aus2025/sig_nicx_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"449819483"
}
"9058"
{
	"name"		"aus2025_signature_nicx_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_nicx_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_nicx_gold"
	"sticker_material"		"aus2025/sig_nicx_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"111"
	"tournament_player_id"		"449819483"
}
"9059"
{
	"name"		"aus2025_signature_stanislaw_4"
	"item_name"		"#StickerKit_aus2025_signature_stanislaw"
	"description_string"		"#StickerKit_desc_aus2025_signature_stanislaw"
	"sticker_material"		"aus2025/sig_stanislaw"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"21583315"
}
"9060"
{
	"name"		"aus2025_signature_stanislaw_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_stanislaw_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_stanislaw_foil"
	"sticker_material"		"aus2025/sig_stanislaw_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"21583315"
}
"9061"
{
	"name"		"aus2025_signature_stanislaw_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_stanislaw_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_stanislaw_holo"
	"sticker_material"		"aus2025/sig_stanislaw_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"21583315"
}
"9062"
{
	"name"		"aus2025_signature_stanislaw_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_stanislaw_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_stanislaw_gold"
	"sticker_material"		"aus2025/sig_stanislaw_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"21583315"
}
"9063"
{
	"name"		"aus2025_signature_sonic_4"
	"item_name"		"#StickerKit_aus2025_signature_sonic"
	"description_string"		"#StickerKit_desc_aus2025_signature_sonic"
	"sticker_material"		"aus2025/sig_sonic"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"14864123"
}
"9064"
{
	"name"		"aus2025_signature_sonic_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_sonic_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_sonic_foil"
	"sticker_material"		"aus2025/sig_sonic_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"14864123"
}
"9065"
{
	"name"		"aus2025_signature_sonic_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_sonic_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_sonic_holo"
	"sticker_material"		"aus2025/sig_sonic_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"14864123"
}
"9066"
{
	"name"		"aus2025_signature_sonic_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_sonic_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_sonic_gold"
	"sticker_material"		"aus2025/sig_sonic_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"14864123"
}
"9067"
{
	"name"		"aus2025_signature_phzy_4"
	"item_name"		"#StickerKit_aus2025_signature_phzy"
	"description_string"		"#StickerKit_desc_aus2025_signature_phzy"
	"sticker_material"		"aus2025/sig_phzy"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"447933315"
}
"9068"
{
	"name"		"aus2025_signature_phzy_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_phzy_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_phzy_foil"
	"sticker_material"		"aus2025/sig_phzy_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"447933315"
}
"9069"
{
	"name"		"aus2025_signature_phzy_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_phzy_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_phzy_holo"
	"sticker_material"		"aus2025/sig_phzy_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"447933315"
}
"9070"
{
	"name"		"aus2025_signature_phzy_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_phzy_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_phzy_gold"
	"sticker_material"		"aus2025/sig_phzy_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"447933315"
}
"9071"
{
	"name"		"aus2025_signature_susp_4"
	"item_name"		"#StickerKit_aus2025_signature_susp"
	"description_string"		"#StickerKit_desc_aus2025_signature_susp"
	"sticker_material"		"aus2025/sig_susp"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"382452440"
}
"9072"
{
	"name"		"aus2025_signature_susp_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_susp_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_susp_foil"
	"sticker_material"		"aus2025/sig_susp_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"382452440"
}
"9073"
{
	"name"		"aus2025_signature_susp_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_susp_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_susp_holo"
	"sticker_material"		"aus2025/sig_susp_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"382452440"
}
"9074"
{
	"name"		"aus2025_signature_susp_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_susp_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_susp_gold"
	"sticker_material"		"aus2025/sig_susp_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"382452440"
}
"9075"
{
	"name"		"aus2025_signature_jba_4"
	"item_name"		"#StickerKit_aus2025_signature_jba"
	"description_string"		"#StickerKit_desc_aus2025_signature_jba"
	"sticker_material"		"aus2025/sig_jba"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"223887847"
}
"9076"
{
	"name"		"aus2025_signature_jba_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_jba_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_jba_foil"
	"sticker_material"		"aus2025/sig_jba_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"223887847"
}
"9077"
{
	"name"		"aus2025_signature_jba_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_jba_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_jba_holo"
	"sticker_material"		"aus2025/sig_jba_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"223887847"
}
"9078"
{
	"name"		"aus2025_signature_jba_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_jba_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_jba_gold"
	"sticker_material"		"aus2025/sig_jba_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"130"
	"tournament_player_id"		"223887847"
}
"9079"
{
	"name"		"aus2025_signature_tn1r_4"
	"item_name"		"#StickerKit_aus2025_signature_tn1r"
	"description_string"		"#StickerKit_desc_aus2025_signature_tn1r"
	"sticker_material"		"aus2025/sig_tn1r"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"911747440"
}
"9080"
{
	"name"		"aus2025_signature_tn1r_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_tn1r_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_tn1r_foil"
	"sticker_material"		"aus2025/sig_tn1r_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"911747440"
}
"9081"
{
	"name"		"aus2025_signature_tn1r_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_tn1r_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_tn1r_holo"
	"sticker_material"		"aus2025/sig_tn1r_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"911747440"
}
"9082"
{
	"name"		"aus2025_signature_tn1r_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_tn1r_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_tn1r_gold"
	"sticker_material"		"aus2025/sig_tn1r_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"911747440"
}
"9083"
{
	"name"		"aus2025_signature_sunpayus_4"
	"item_name"		"#StickerKit_aus2025_signature_sunpayus"
	"description_string"		"#StickerKit_desc_aus2025_signature_sunpayus"
	"sticker_material"		"aus2025/sig_sunpayus"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"349573813"
}
"9084"
{
	"name"		"aus2025_signature_sunpayus_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_sunpayus_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_sunpayus_foil"
	"sticker_material"		"aus2025/sig_sunpayus_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"349573813"
}
"9085"
{
	"name"		"aus2025_signature_sunpayus_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_sunpayus_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_sunpayus_holo"
	"sticker_material"		"aus2025/sig_sunpayus_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"349573813"
}
"9086"
{
	"name"		"aus2025_signature_sunpayus_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_sunpayus_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_sunpayus_gold"
	"sticker_material"		"aus2025/sig_sunpayus_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"349573813"
}
"9087"
{
	"name"		"aus2025_signature_xfl0ud_4"
	"item_name"		"#StickerKit_aus2025_signature_xfl0ud"
	"description_string"		"#StickerKit_desc_aus2025_signature_xfl0ud"
	"sticker_material"		"aus2025/sig_xfl0ud"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"217943381"
}
"9088"
{
	"name"		"aus2025_signature_xfl0ud_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_xfl0ud_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_xfl0ud_foil"
	"sticker_material"		"aus2025/sig_xfl0ud_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"217943381"
}
"9089"
{
	"name"		"aus2025_signature_xfl0ud_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_xfl0ud_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_xfl0ud_holo"
	"sticker_material"		"aus2025/sig_xfl0ud_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"217943381"
}
"9090"
{
	"name"		"aus2025_signature_xfl0ud_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_xfl0ud_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_xfl0ud_gold"
	"sticker_material"		"aus2025/sig_xfl0ud_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"217943381"
}
"9091"
{
	"name"		"aus2025_signature_lnz_4"
	"item_name"		"#StickerKit_aus2025_signature_lnz"
	"description_string"		"#StickerKit_desc_aus2025_signature_lnz"
	"sticker_material"		"aus2025/sig_lnz"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"144361165"
}
"9092"
{
	"name"		"aus2025_signature_lnz_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_lnz_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_lnz_foil"
	"sticker_material"		"aus2025/sig_lnz_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"144361165"
}
"9093"
{
	"name"		"aus2025_signature_lnz_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_lnz_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_lnz_holo"
	"sticker_material"		"aus2025/sig_lnz_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"144361165"
}
"9094"
{
	"name"		"aus2025_signature_lnz_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_lnz_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_lnz_gold"
	"sticker_material"		"aus2025/sig_lnz_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"144361165"
}
"9095"
{
	"name"		"aus2025_signature_yxngstxr_4"
	"item_name"		"#StickerKit_aus2025_signature_yxngstxr"
	"description_string"		"#StickerKit_desc_aus2025_signature_yxngstxr"
	"sticker_material"		"aus2025/sig_yxngstxr"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"1176878177"
}
"9096"
{
	"name"		"aus2025_signature_yxngstxr_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_yxngstxr_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_yxngstxr_foil"
	"sticker_material"		"aus2025/sig_yxngstxr_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"1176878177"
}
"9097"
{
	"name"		"aus2025_signature_yxngstxr_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_yxngstxr_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_yxngstxr_holo"
	"sticker_material"		"aus2025/sig_yxngstxr_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"1176878177"
}
"9098"
{
	"name"		"aus2025_signature_yxngstxr_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_yxngstxr_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_yxngstxr_gold"
	"sticker_material"		"aus2025/sig_yxngstxr_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"95"
	"tournament_player_id"		"1176878177"
}
"9099"
{
	"name"		"aus2025_signature_headtr1ck_4"
	"item_name"		"#StickerKit_aus2025_signature_headtr1ck"
	"description_string"		"#StickerKit_desc_aus2025_signature_headtr1ck"
	"sticker_material"		"aus2025/sig_headtr1ck"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"399254202"
}
"9100"
{
	"name"		"aus2025_signature_headtr1ck_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_headtr1ck_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_headtr1ck_foil"
	"sticker_material"		"aus2025/sig_headtr1ck_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"399254202"
}
"9101"
{
	"name"		"aus2025_signature_headtr1ck_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_headtr1ck_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_headtr1ck_holo"
	"sticker_material"		"aus2025/sig_headtr1ck_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"399254202"
}
"9102"
{
	"name"		"aus2025_signature_headtr1ck_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_headtr1ck_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_headtr1ck_gold"
	"sticker_material"		"aus2025/sig_headtr1ck_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"399254202"
}
"9103"
{
	"name"		"aus2025_signature_kensizor_4"
	"item_name"		"#StickerKit_aus2025_signature_kensizor"
	"description_string"		"#StickerKit_desc_aus2025_signature_kensizor"
	"sticker_material"		"aus2025/sig_kensizor"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"421907931"
}
"9104"
{
	"name"		"aus2025_signature_kensizor_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_kensizor_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_kensizor_foil"
	"sticker_material"		"aus2025/sig_kensizor_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"421907931"
}
"9105"
{
	"name"		"aus2025_signature_kensizor_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_kensizor_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_kensizor_holo"
	"sticker_material"		"aus2025/sig_kensizor_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"421907931"
}
"9106"
{
	"name"		"aus2025_signature_kensizor_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_kensizor_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_kensizor_gold"
	"sticker_material"		"aus2025/sig_kensizor_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"421907931"
}
"9107"
{
	"name"		"aus2025_signature_esenthial_4"
	"item_name"		"#StickerKit_aus2025_signature_esenthial"
	"description_string"		"#StickerKit_desc_aus2025_signature_esenthial"
	"sticker_material"		"aus2025/sig_esenthial"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"1189546625"
}
"9108"
{
	"name"		"aus2025_signature_esenthial_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_esenthial_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_esenthial_foil"
	"sticker_material"		"aus2025/sig_esenthial_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"1189546625"
}
"9109"
{
	"name"		"aus2025_signature_esenthial_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_esenthial_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_esenthial_holo"
	"sticker_material"		"aus2025/sig_esenthial_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"1189546625"
}
"9110"
{
	"name"		"aus2025_signature_esenthial_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_esenthial_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_esenthial_gold"
	"sticker_material"		"aus2025/sig_esenthial_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"1189546625"
}
"9111"
{
	"name"		"aus2025_signature_npl_4"
	"item_name"		"#StickerKit_aus2025_signature_npl"
	"description_string"		"#StickerKit_desc_aus2025_signature_npl"
	"sticker_material"		"aus2025/sig_npl"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"344771176"
}
"9112"
{
	"name"		"aus2025_signature_npl_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_npl_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_npl_foil"
	"sticker_material"		"aus2025/sig_npl_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"344771176"
}
"9113"
{
	"name"		"aus2025_signature_npl_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_npl_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_npl_holo"
	"sticker_material"		"aus2025/sig_npl_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"344771176"
}
"9114"
{
	"name"		"aus2025_signature_npl_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_npl_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_npl_gold"
	"sticker_material"		"aus2025/sig_npl_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"344771176"
}
"9115"
{
	"name"		"aus2025_signature_alex666_4"
	"item_name"		"#StickerKit_aus2025_signature_alex666"
	"description_string"		"#StickerKit_desc_aus2025_signature_alex666"
	"sticker_material"		"aus2025/sig_alex666"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"343849791"
}
"9116"
{
	"name"		"aus2025_signature_alex666_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_alex666_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_alex666_foil"
	"sticker_material"		"aus2025/sig_alex666_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"343849791"
}
"9117"
{
	"name"		"aus2025_signature_alex666_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_alex666_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_alex666_holo"
	"sticker_material"		"aus2025/sig_alex666_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"343849791"
}
"9118"
{
	"name"		"aus2025_signature_alex666_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_alex666_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_alex666_gold"
	"sticker_material"		"aus2025/sig_alex666_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"135"
	"tournament_player_id"		"343849791"
}
"9119"
{
	"name"		"aus2025_signature_chr1zn_4"
	"item_name"		"#StickerKit_aus2025_signature_chr1zn"
	"description_string"		"#StickerKit_desc_aus2025_signature_chr1zn"
	"sticker_material"		"aus2025/sig_chr1zn"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"332333072"
}
"9120"
{
	"name"		"aus2025_signature_chr1zn_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_chr1zn_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_chr1zn_foil"
	"sticker_material"		"aus2025/sig_chr1zn_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"332333072"
}
"9121"
{
	"name"		"aus2025_signature_chr1zn_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_chr1zn_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_chr1zn_holo"
	"sticker_material"		"aus2025/sig_chr1zn_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"332333072"
}
"9122"
{
	"name"		"aus2025_signature_chr1zn_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_chr1zn_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_chr1zn_gold"
	"sticker_material"		"aus2025/sig_chr1zn_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"332333072"
}
"9123"
{
	"name"		"aus2025_signature_f1ku_4"
	"item_name"		"#StickerKit_aus2025_signature_f1ku"
	"description_string"		"#StickerKit_desc_aus2025_signature_f1ku"
	"sticker_material"		"aus2025/sig_f1ku"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"292168772"
}
"9124"
{
	"name"		"aus2025_signature_f1ku_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_f1ku_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_f1ku_foil"
	"sticker_material"		"aus2025/sig_f1ku_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"292168772"
}
"9125"
{
	"name"		"aus2025_signature_f1ku_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_f1ku_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_f1ku_holo"
	"sticker_material"		"aus2025/sig_f1ku_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"292168772"
}
"9126"
{
	"name"		"aus2025_signature_f1ku_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_f1ku_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_f1ku_gold"
	"sticker_material"		"aus2025/sig_f1ku_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"292168772"
}
"9127"
{
	"name"		"aus2025_signature_nicoodoz_4"
	"item_name"		"#StickerKit_aus2025_signature_nicoodoz"
	"description_string"		"#StickerKit_desc_aus2025_signature_nicoodoz"
	"sticker_material"		"aus2025/sig_nicoodoz"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"112851399"
}
"9128"
{
	"name"		"aus2025_signature_nicoodoz_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_nicoodoz_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_nicoodoz_foil"
	"sticker_material"		"aus2025/sig_nicoodoz_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"112851399"
}
"9129"
{
	"name"		"aus2025_signature_nicoodoz_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_nicoodoz_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_nicoodoz_holo"
	"sticker_material"		"aus2025/sig_nicoodoz_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"112851399"
}
"9130"
{
	"name"		"aus2025_signature_nicoodoz_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_nicoodoz_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_nicoodoz_gold"
	"sticker_material"		"aus2025/sig_nicoodoz_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"112851399"
}
"9131"
{
	"name"		"aus2025_signature_spooke_4"
	"item_name"		"#StickerKit_aus2025_signature_spooke"
	"description_string"		"#StickerKit_desc_aus2025_signature_spooke"
	"sticker_material"		"aus2025/sig_spooke"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"118917633"
}
"9132"
{
	"name"		"aus2025_signature_spooke_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_spooke_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_spooke_foil"
	"sticker_material"		"aus2025/sig_spooke_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"118917633"
}
"9133"
{
	"name"		"aus2025_signature_spooke_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_spooke_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_spooke_holo"
	"sticker_material"		"aus2025/sig_spooke_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"118917633"
}
"9134"
{
	"name"		"aus2025_signature_spooke_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_spooke_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_spooke_gold"
	"sticker_material"		"aus2025/sig_spooke_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"118917633"
}
"9135"
{
	"name"		"aus2025_signature_buzz_4"
	"item_name"		"#StickerKit_aus2025_signature_buzz"
	"description_string"		"#StickerKit_desc_aus2025_signature_buzz"
	"sticker_material"		"aus2025/sig_buzz"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"288688034"
}
"9136"
{
	"name"		"aus2025_signature_buzz_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_buzz_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_buzz_foil"
	"sticker_material"		"aus2025/sig_buzz_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"288688034"
}
"9137"
{
	"name"		"aus2025_signature_buzz_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_buzz_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_buzz_holo"
	"sticker_material"		"aus2025/sig_buzz_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"288688034"
}
"9138"
{
	"name"		"aus2025_signature_buzz_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_buzz_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_buzz_gold"
	"sticker_material"		"aus2025/sig_buzz_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"96"
	"tournament_player_id"		"288688034"
}
"9139"
{
	"name"		"aus2025_signature_1eer_4"
	"item_name"		"#StickerKit_aus2025_signature_1eer"
	"description_string"		"#StickerKit_desc_aus2025_signature_1eer"
	"sticker_material"		"aus2025/sig_1eer"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"876851680"
}
"9140"
{
	"name"		"aus2025_signature_1eer_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_1eer_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_1eer_foil"
	"sticker_material"		"aus2025/sig_1eer_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"876851680"
}
"9141"
{
	"name"		"aus2025_signature_1eer_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_1eer_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_1eer_holo"
	"sticker_material"		"aus2025/sig_1eer_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"876851680"
}
"9142"
{
	"name"		"aus2025_signature_1eer_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_1eer_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_1eer_gold"
	"sticker_material"		"aus2025/sig_1eer_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"876851680"
}
"9143"
{
	"name"		"aus2025_signature_xant3r_4"
	"item_name"		"#StickerKit_aus2025_signature_xant3r"
	"description_string"		"#StickerKit_desc_aus2025_signature_xant3r"
	"sticker_material"		"aus2025/sig_xant3r"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"879040137"
}
"9144"
{
	"name"		"aus2025_signature_xant3r_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_xant3r_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_xant3r_foil"
	"sticker_material"		"aus2025/sig_xant3r_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"879040137"
}
"9145"
{
	"name"		"aus2025_signature_xant3r_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_xant3r_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_xant3r_holo"
	"sticker_material"		"aus2025/sig_xant3r_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"879040137"
}
"9146"
{
	"name"		"aus2025_signature_xant3r_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_xant3r_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_xant3r_gold"
	"sticker_material"		"aus2025/sig_xant3r_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"879040137"
}
"9147"
{
	"name"		"aus2025_signature_khan_4"
	"item_name"		"#StickerKit_aus2025_signature_khan"
	"description_string"		"#StickerKit_desc_aus2025_signature_khan"
	"sticker_material"		"aus2025/sig_khan"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"991201920"
}
"9148"
{
	"name"		"aus2025_signature_khan_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_khan_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_khan_foil"
	"sticker_material"		"aus2025/sig_khan_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"991201920"
}
"9149"
{
	"name"		"aus2025_signature_khan_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_khan_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_khan_holo"
	"sticker_material"		"aus2025/sig_khan_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"991201920"
}
"9150"
{
	"name"		"aus2025_signature_khan_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_khan_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_khan_gold"
	"sticker_material"		"aus2025/sig_khan_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"991201920"
}
"9151"
{
	"name"		"aus2025_signature_riskyb0b_4"
	"item_name"		"#StickerKit_aus2025_signature_riskyb0b"
	"description_string"		"#StickerKit_desc_aus2025_signature_riskyb0b"
	"sticker_material"		"aus2025/sig_riskyb0b"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"928974297"
}
"9152"
{
	"name"		"aus2025_signature_riskyb0b_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_riskyb0b_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_riskyb0b_foil"
	"sticker_material"		"aus2025/sig_riskyb0b_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"928974297"
}
"9153"
{
	"name"		"aus2025_signature_riskyb0b_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_riskyb0b_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_riskyb0b_holo"
	"sticker_material"		"aus2025/sig_riskyb0b_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"928974297"
}
"9154"
{
	"name"		"aus2025_signature_riskyb0b_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_riskyb0b_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_riskyb0b_gold"
	"sticker_material"		"aus2025/sig_riskyb0b_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"928974297"
}
"9155"
{
	"name"		"aus2025_signature_zweih_4"
	"item_name"		"#StickerKit_aus2025_signature_zweih"
	"description_string"		"#StickerKit_desc_aus2025_signature_zweih"
	"sticker_material"		"aus2025/sig_zweih"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"250361011"
}
"9156"
{
	"name"		"aus2025_signature_zweih_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_zweih_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_zweih_foil"
	"sticker_material"		"aus2025/sig_zweih_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"250361011"
}
"9157"
{
	"name"		"aus2025_signature_zweih_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_zweih_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_zweih_holo"
	"sticker_material"		"aus2025/sig_zweih_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"250361011"
}
"9158"
{
	"name"		"aus2025_signature_zweih_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_zweih_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_zweih_gold"
	"sticker_material"		"aus2025/sig_zweih_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"107"
	"tournament_player_id"		"250361011"
}
"9159"
{
	"name"		"aus2025_signature_zorte_4"
	"item_name"		"#StickerKit_aus2025_signature_zorte"
	"description_string"		"#StickerKit_desc_aus2025_signature_zorte"
	"sticker_material"		"aus2025/sig_zorte"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"99348674"
}
"9160"
{
	"name"		"aus2025_signature_zorte_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_zorte_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_zorte_foil"
	"sticker_material"		"aus2025/sig_zorte_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"99348674"
}
"9161"
{
	"name"		"aus2025_signature_zorte_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_zorte_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_zorte_holo"
	"sticker_material"		"aus2025/sig_zorte_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"99348674"
}
"9162"
{
	"name"		"aus2025_signature_zorte_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_zorte_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_zorte_gold"
	"sticker_material"		"aus2025/sig_zorte_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"99348674"
}
"9163"
{
	"name"		"aus2025_signature_s1ren_4"
	"item_name"		"#StickerKit_aus2025_signature_s1ren"
	"description_string"		"#StickerKit_desc_aus2025_signature_s1ren"
	"sticker_material"		"aus2025/sig_s1ren"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"207519341"
}
"9164"
{
	"name"		"aus2025_signature_s1ren_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_s1ren_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_s1ren_foil"
	"sticker_material"		"aus2025/sig_s1ren_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"207519341"
}
"9165"
{
	"name"		"aus2025_signature_s1ren_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_s1ren_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_s1ren_holo"
	"sticker_material"		"aus2025/sig_s1ren_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"207519341"
}
"9166"
{
	"name"		"aus2025_signature_s1ren_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_s1ren_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_s1ren_gold"
	"sticker_material"		"aus2025/sig_s1ren_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"207519341"
}
"9167"
{
	"name"		"aus2025_signature_magnojez_4"
	"item_name"		"#StickerKit_aus2025_signature_magnojez"
	"description_string"		"#StickerKit_desc_aus2025_signature_magnojez"
	"sticker_material"		"aus2025/sig_magnojez"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"411757486"
}
"9168"
{
	"name"		"aus2025_signature_magnojez_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_magnojez_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_magnojez_foil"
	"sticker_material"		"aus2025/sig_magnojez_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"411757486"
}
"9169"
{
	"name"		"aus2025_signature_magnojez_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_magnojez_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_magnojez_holo"
	"sticker_material"		"aus2025/sig_magnojez_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"411757486"
}
"9170"
{
	"name"		"aus2025_signature_magnojez_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_magnojez_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_magnojez_gold"
	"sticker_material"		"aus2025/sig_magnojez_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"411757486"
}
"9171"
{
	"name"		"aus2025_signature_ax1le_4"
	"item_name"		"#StickerKit_aus2025_signature_ax1le"
	"description_string"		"#StickerKit_desc_aus2025_signature_ax1le"
	"sticker_material"		"aus2025/sig_ax1le"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"85167576"
}
"9172"
{
	"name"		"aus2025_signature_ax1le_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_ax1le_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_ax1le_foil"
	"sticker_material"		"aus2025/sig_ax1le_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"85167576"
}
"9173"
{
	"name"		"aus2025_signature_ax1le_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_ax1le_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_ax1le_holo"
	"sticker_material"		"aus2025/sig_ax1le_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"85167576"
}
"9174"
{
	"name"		"aus2025_signature_ax1le_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_ax1le_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_ax1le_gold"
	"sticker_material"		"aus2025/sig_ax1le_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"85167576"
}
"9175"
{
	"name"		"aus2025_signature_boombl4_4"
	"item_name"		"#StickerKit_aus2025_signature_boombl4"
	"description_string"		"#StickerKit_desc_aus2025_signature_boombl4"
	"sticker_material"		"aus2025/sig_boombl4"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"185941338"
}
"9176"
{
	"name"		"aus2025_signature_boombl4_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_boombl4_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_boombl4_foil"
	"sticker_material"		"aus2025/sig_boombl4_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"185941338"
}
"9177"
{
	"name"		"aus2025_signature_boombl4_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_boombl4_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_boombl4_holo"
	"sticker_material"		"aus2025/sig_boombl4_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"185941338"
}
"9178"
{
	"name"		"aus2025_signature_boombl4_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_boombl4_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_boombl4_gold"
	"sticker_material"		"aus2025/sig_boombl4_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"137"
	"tournament_player_id"		"185941338"
}
"9179"
{
	"name"		"aus2025_signature_vini_4"
	"item_name"		"#StickerKit_aus2025_signature_vini"
	"description_string"		"#StickerKit_desc_aus2025_signature_vini"
	"sticker_material"		"aus2025/sig_vini"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"36104456"
}
"9180"
{
	"name"		"aus2025_signature_vini_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_vini_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_vini_foil"
	"sticker_material"		"aus2025/sig_vini_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"36104456"
}
"9181"
{
	"name"		"aus2025_signature_vini_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_vini_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_vini_holo"
	"sticker_material"		"aus2025/sig_vini_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"36104456"
}
"9182"
{
	"name"		"aus2025_signature_vini_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_vini_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_vini_gold"
	"sticker_material"		"aus2025/sig_vini_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"36104456"
}
"9183"
{
	"name"		"aus2025_signature_try_4"
	"item_name"		"#StickerKit_aus2025_signature_try"
	"description_string"		"#StickerKit_desc_aus2025_signature_try"
	"sticker_material"		"aus2025/sig_try"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"404852560"
}
"9184"
{
	"name"		"aus2025_signature_try_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_try_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_try_foil"
	"sticker_material"		"aus2025/sig_try_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"404852560"
}
"9185"
{
	"name"		"aus2025_signature_try_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_try_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_try_holo"
	"sticker_material"		"aus2025/sig_try_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"404852560"
}
"9186"
{
	"name"		"aus2025_signature_try_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_try_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_try_gold"
	"sticker_material"		"aus2025/sig_try_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"404852560"
}
"9187"
{
	"name"		"aus2025_signature_chayjesus_4"
	"item_name"		"#StickerKit_aus2025_signature_chayjesus"
	"description_string"		"#StickerKit_desc_aus2025_signature_chayjesus"
	"sticker_material"		"aus2025/sig_chayjesus"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"291666024"
}
"9188"
{
	"name"		"aus2025_signature_chayjesus_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_chayjesus_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_chayjesus_foil"
	"sticker_material"		"aus2025/sig_chayjesus_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"291666024"
}
"9189"
{
	"name"		"aus2025_signature_chayjesus_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_chayjesus_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_chayjesus_holo"
	"sticker_material"		"aus2025/sig_chayjesus_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"291666024"
}
"9190"
{
	"name"		"aus2025_signature_chayjesus_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_chayjesus_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_chayjesus_gold"
	"sticker_material"		"aus2025/sig_chayjesus_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"291666024"
}
"9191"
{
	"name"		"aus2025_signature_decenty_4"
	"item_name"		"#StickerKit_aus2025_signature_decenty"
	"description_string"		"#StickerKit_desc_aus2025_signature_decenty"
	"sticker_material"		"aus2025/sig_decenty"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"346906182"
}
"9192"
{
	"name"		"aus2025_signature_decenty_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_decenty_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_decenty_foil"
	"sticker_material"		"aus2025/sig_decenty_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"346906182"
}
"9193"
{
	"name"		"aus2025_signature_decenty_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_decenty_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_decenty_holo"
	"sticker_material"		"aus2025/sig_decenty_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"346906182"
}
"9194"
{
	"name"		"aus2025_signature_decenty_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_decenty_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_decenty_gold"
	"sticker_material"		"aus2025/sig_decenty_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"346906182"
}
"9195"
{
	"name"		"aus2025_signature_noway_4"
	"item_name"		"#StickerKit_aus2025_signature_noway"
	"description_string"		"#StickerKit_desc_aus2025_signature_noway"
	"sticker_material"		"aus2025/sig_noway"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"839943839"
}
"9196"
{
	"name"		"aus2025_signature_noway_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_noway_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_noway_foil"
	"sticker_material"		"aus2025/sig_noway_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"839943839"
}
"9197"
{
	"name"		"aus2025_signature_noway_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_noway_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_noway_holo"
	"sticker_material"		"aus2025/sig_noway_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"839943839"
}
"9198"
{
	"name"		"aus2025_signature_noway_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_noway_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_noway_gold"
	"sticker_material"		"aus2025/sig_noway_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"113"
	"tournament_player_id"		"839943839"
}
"9199"
{
	"name"		"aus2025_signature_osee_4"
	"item_name"		"#StickerKit_aus2025_signature_osee"
	"description_string"		"#StickerKit_desc_aus2025_signature_osee"
	"sticker_material"		"aus2025/sig_osee"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"87206806"
}
"9200"
{
	"name"		"aus2025_signature_osee_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_osee_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_osee_foil"
	"sticker_material"		"aus2025/sig_osee_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"87206806"
}
"9201"
{
	"name"		"aus2025_signature_osee_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_osee_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_osee_holo"
	"sticker_material"		"aus2025/sig_osee_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"87206806"
}
"9202"
{
	"name"		"aus2025_signature_osee_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_osee_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_osee_gold"
	"sticker_material"		"aus2025/sig_osee_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"87206806"
}
"9203"
{
	"name"		"aus2025_signature_hext_4"
	"item_name"		"#StickerKit_aus2025_signature_hext"
	"description_string"		"#StickerKit_desc_aus2025_signature_hext"
	"sticker_material"		"aus2025/sig_hext"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"250668735"
}
"9204"
{
	"name"		"aus2025_signature_hext_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_hext_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_hext_foil"
	"sticker_material"		"aus2025/sig_hext_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"250668735"
}
"9205"
{
	"name"		"aus2025_signature_hext_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_hext_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_hext_holo"
	"sticker_material"		"aus2025/sig_hext_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"250668735"
}
"9206"
{
	"name"		"aus2025_signature_hext_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_hext_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_hext_gold"
	"sticker_material"		"aus2025/sig_hext_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"250668735"
}
"9207"
{
	"name"		"aus2025_signature_br0_4"
	"item_name"		"#StickerKit_aus2025_signature_br0"
	"description_string"		"#StickerKit_desc_aus2025_signature_br0"
	"sticker_material"		"aus2025/sig_br0"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"100218065"
}
"9208"
{
	"name"		"aus2025_signature_br0_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_br0_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_br0_foil"
	"sticker_material"		"aus2025/sig_br0_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"100218065"
}
"9209"
{
	"name"		"aus2025_signature_br0_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_br0_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_br0_holo"
	"sticker_material"		"aus2025/sig_br0_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"100218065"
}
"9210"
{
	"name"		"aus2025_signature_br0_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_br0_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_br0_gold"
	"sticker_material"		"aus2025/sig_br0_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"100218065"
}
"9211"
{
	"name"		"aus2025_signature_nitro_4"
	"item_name"		"#StickerKit_aus2025_signature_nitro"
	"description_string"		"#StickerKit_desc_aus2025_signature_nitro"
	"sticker_material"		"aus2025/sig_nitro"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"35624002"
}
"9212"
{
	"name"		"aus2025_signature_nitro_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_nitro_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_nitro_foil"
	"sticker_material"		"aus2025/sig_nitro_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"35624002"
}
"9213"
{
	"name"		"aus2025_signature_nitro_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_nitro_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_nitro_holo"
	"sticker_material"		"aus2025/sig_nitro_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"35624002"
}
"9214"
{
	"name"		"aus2025_signature_nitro_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_nitro_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_nitro_gold"
	"sticker_material"		"aus2025/sig_nitro_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"35624002"
}
"9215"
{
	"name"		"aus2025_signature_jeorge_4"
	"item_name"		"#StickerKit_aus2025_signature_jeorge"
	"description_string"		"#StickerKit_desc_aus2025_signature_jeorge"
	"sticker_material"		"aus2025/sig_jeorge"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"393603607"
}
"9216"
{
	"name"		"aus2025_signature_jeorge_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_jeorge_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_jeorge_foil"
	"sticker_material"		"aus2025/sig_jeorge_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"393603607"
}
"9217"
{
	"name"		"aus2025_signature_jeorge_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_jeorge_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_jeorge_holo"
	"sticker_material"		"aus2025/sig_jeorge_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"393603607"
}
"9218"
{
	"name"		"aus2025_signature_jeorge_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_jeorge_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_jeorge_gold"
	"sticker_material"		"aus2025/sig_jeorge_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"87"
	"tournament_player_id"		"393603607"
}
"9219"
{
	"name"		"aus2025_signature_ins_4"
	"item_name"		"#StickerKit_aus2025_signature_ins"
	"description_string"		"#StickerKit_desc_aus2025_signature_ins"
	"sticker_material"		"aus2025/sig_ins"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"26946895"
}
"9220"
{
	"name"		"aus2025_signature_ins_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_ins_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_ins_foil"
	"sticker_material"		"aus2025/sig_ins_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"26946895"
}
"9221"
{
	"name"		"aus2025_signature_ins_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_ins_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_ins_holo"
	"sticker_material"		"aus2025/sig_ins_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"26946895"
}
"9222"
{
	"name"		"aus2025_signature_ins_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_ins_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_ins_gold"
	"sticker_material"		"aus2025/sig_ins_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"26946895"
}
"9223"
{
	"name"		"aus2025_signature_liazz_4"
	"item_name"		"#StickerKit_aus2025_signature_liazz"
	"description_string"		"#StickerKit_desc_aus2025_signature_liazz"
	"sticker_material"		"aus2025/sig_liazz"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"112055988"
}
"9224"
{
	"name"		"aus2025_signature_liazz_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_liazz_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_liazz_foil"
	"sticker_material"		"aus2025/sig_liazz_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"112055988"
}
"9225"
{
	"name"		"aus2025_signature_liazz_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_liazz_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_liazz_holo"
	"sticker_material"		"aus2025/sig_liazz_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"112055988"
}
"9226"
{
	"name"		"aus2025_signature_liazz_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_liazz_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_liazz_gold"
	"sticker_material"		"aus2025/sig_liazz_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"112055988"
}
"9227"
{
	"name"		"aus2025_signature_vexite_4"
	"item_name"		"#StickerKit_aus2025_signature_vexite"
	"description_string"		"#StickerKit_desc_aus2025_signature_vexite"
	"sticker_material"		"aus2025/sig_vexite"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"92622415"
}
"9228"
{
	"name"		"aus2025_signature_vexite_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_vexite_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_vexite_foil"
	"sticker_material"		"aus2025/sig_vexite_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"92622415"
}
"9229"
{
	"name"		"aus2025_signature_vexite_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_vexite_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_vexite_holo"
	"sticker_material"		"aus2025/sig_vexite_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"92622415"
}
"9230"
{
	"name"		"aus2025_signature_vexite_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_vexite_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_vexite_gold"
	"sticker_material"		"aus2025/sig_vexite_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"92622415"
}
"9231"
{
	"name"		"aus2025_signature_regali_4"
	"item_name"		"#StickerKit_aus2025_signature_regali"
	"description_string"		"#StickerKit_desc_aus2025_signature_regali"
	"sticker_material"		"aus2025/sig_regali"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"138197501"
}
"9232"
{
	"name"		"aus2025_signature_regali_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_regali_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_regali_foil"
	"sticker_material"		"aus2025/sig_regali_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"138197501"
}
"9233"
{
	"name"		"aus2025_signature_regali_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_regali_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_regali_holo"
	"sticker_material"		"aus2025/sig_regali_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"138197501"
}
"9234"
{
	"name"		"aus2025_signature_regali_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_regali_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_regali_gold"
	"sticker_material"		"aus2025/sig_regali_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"138197501"
}
"9235"
{
	"name"		"aus2025_signature_nettik_4"
	"item_name"		"#StickerKit_aus2025_signature_nettik"
	"description_string"		"#StickerKit_desc_aus2025_signature_nettik"
	"sticker_material"		"aus2025/sig_nettik"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"372579523"
}
"9236"
{
	"name"		"aus2025_signature_nettik_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_nettik_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_nettik_foil"
	"sticker_material"		"aus2025/sig_nettik_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"372579523"
}
"9237"
{
	"name"		"aus2025_signature_nettik_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_nettik_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_nettik_holo"
	"sticker_material"		"aus2025/sig_nettik_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"372579523"
}
"9238"
{
	"name"		"aus2025_signature_nettik_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_nettik_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_nettik_gold"
	"sticker_material"		"aus2025/sig_nettik_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"132"
	"tournament_player_id"		"372579523"
}
"9239"
{
	"name"		"aus2025_signature_hampus_4"
	"item_name"		"#StickerKit_aus2025_signature_hampus"
	"description_string"		"#StickerKit_desc_aus2025_signature_hampus"
	"sticker_material"		"aus2025/sig_hampus"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"126680222"
}
"9240"
{
	"name"		"aus2025_signature_hampus_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_hampus_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_hampus_foil"
	"sticker_material"		"aus2025/sig_hampus_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"126680222"
}
"9241"
{
	"name"		"aus2025_signature_hampus_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_hampus_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_hampus_holo"
	"sticker_material"		"aus2025/sig_hampus_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"126680222"
}
"9242"
{
	"name"		"aus2025_signature_hampus_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_hampus_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_hampus_gold"
	"sticker_material"		"aus2025/sig_hampus_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"126680222"
}
"9243"
{
	"name"		"aus2025_signature_isak_4"
	"item_name"		"#StickerKit_aus2025_signature_isak"
	"description_string"		"#StickerKit_desc_aus2025_signature_isak"
	"sticker_material"		"aus2025/sig_isak"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"111644637"
}
"9244"
{
	"name"		"aus2025_signature_isak_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_isak_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_isak_foil"
	"sticker_material"		"aus2025/sig_isak_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"111644637"
}
"9245"
{
	"name"		"aus2025_signature_isak_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_isak_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_isak_holo"
	"sticker_material"		"aus2025/sig_isak_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"111644637"
}
"9246"
{
	"name"		"aus2025_signature_isak_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_isak_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_isak_gold"
	"sticker_material"		"aus2025/sig_isak_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"111644637"
}
"9247"
{
	"name"		"aus2025_signature_plopski_4"
	"item_name"		"#StickerKit_aus2025_signature_plopski"
	"description_string"		"#StickerKit_desc_aus2025_signature_plopski"
	"sticker_material"		"aus2025/sig_plopski"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"175613070"
}
"9248"
{
	"name"		"aus2025_signature_plopski_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_plopski_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_plopski_foil"
	"sticker_material"		"aus2025/sig_plopski_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"175613070"
}
"9249"
{
	"name"		"aus2025_signature_plopski_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_plopski_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_plopski_holo"
	"sticker_material"		"aus2025/sig_plopski_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"175613070"
}
"9250"
{
	"name"		"aus2025_signature_plopski_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_plopski_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_plopski_gold"
	"sticker_material"		"aus2025/sig_plopski_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"175613070"
}
"9251"
{
	"name"		"aus2025_signature_l00m1_4"
	"item_name"		"#StickerKit_aus2025_signature_l00m1"
	"description_string"		"#StickerKit_desc_aus2025_signature_l00m1"
	"sticker_material"		"aus2025/sig_l00m1"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"930226076"
}
"9252"
{
	"name"		"aus2025_signature_l00m1_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_l00m1_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_l00m1_foil"
	"sticker_material"		"aus2025/sig_l00m1_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"930226076"
}
"9253"
{
	"name"		"aus2025_signature_l00m1_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_l00m1_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_l00m1_holo"
	"sticker_material"		"aus2025/sig_l00m1_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"930226076"
}
"9254"
{
	"name"		"aus2025_signature_l00m1_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_l00m1_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_l00m1_gold"
	"sticker_material"		"aus2025/sig_l00m1_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"930226076"
}
"9255"
{
	"name"		"aus2025_signature_adamb_4"
	"item_name"		"#StickerKit_aus2025_signature_adamb"
	"description_string"		"#StickerKit_desc_aus2025_signature_adamb"
	"sticker_material"		"aus2025/sig_adamb"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"890801811"
}
"9256"
{
	"name"		"aus2025_signature_adamb_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_adamb_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_adamb_foil"
	"sticker_material"		"aus2025/sig_adamb_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"890801811"
}
"9257"
{
	"name"		"aus2025_signature_adamb_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_adamb_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_adamb_holo"
	"sticker_material"		"aus2025/sig_adamb_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"890801811"
}
"9258"
{
	"name"		"aus2025_signature_adamb_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_adamb_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_adamb_gold"
	"sticker_material"		"aus2025/sig_adamb_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"141"
	"tournament_player_id"		"890801811"
}
"9259"
{
	"name"		"aus2025_signature_jamyoung_4"
	"item_name"		"#StickerKit_aus2025_signature_jamyoung"
	"description_string"		"#StickerKit_desc_aus2025_signature_jamyoung"
	"sticker_material"		"aus2025/sig_jamyoung"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"404671310"
}
"9260"
{
	"name"		"aus2025_signature_jamyoung_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_jamyoung_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_jamyoung_foil"
	"sticker_material"		"aus2025/sig_jamyoung_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"404671310"
}
"9261"
{
	"name"		"aus2025_signature_jamyoung_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_jamyoung_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_jamyoung_holo"
	"sticker_material"		"aus2025/sig_jamyoung_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"404671310"
}
"9262"
{
	"name"		"aus2025_signature_jamyoung_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_jamyoung_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_jamyoung_gold"
	"sticker_material"		"aus2025/sig_jamyoung_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"404671310"
}
"9263"
{
	"name"		"aus2025_signature_moseyuh_4"
	"item_name"		"#StickerKit_aus2025_signature_moseyuh"
	"description_string"		"#StickerKit_desc_aus2025_signature_moseyuh"
	"sticker_material"		"aus2025/sig_moseyuh"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"394931794"
}
"9264"
{
	"name"		"aus2025_signature_moseyuh_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_moseyuh_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_moseyuh_foil"
	"sticker_material"		"aus2025/sig_moseyuh_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"394931794"
}
"9265"
{
	"name"		"aus2025_signature_moseyuh_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_moseyuh_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_moseyuh_holo"
	"sticker_material"		"aus2025/sig_moseyuh_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"394931794"
}
"9266"
{
	"name"		"aus2025_signature_moseyuh_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_moseyuh_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_moseyuh_gold"
	"sticker_material"		"aus2025/sig_moseyuh_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"394931794"
}
"9267"
{
	"name"		"aus2025_signature_attacker_4"
	"item_name"		"#StickerKit_aus2025_signature_attacker"
	"description_string"		"#StickerKit_desc_aus2025_signature_attacker"
	"sticker_material"		"aus2025/sig_attacker"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"88001036"
}
"9268"
{
	"name"		"aus2025_signature_attacker_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_attacker_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_attacker_foil"
	"sticker_material"		"aus2025/sig_attacker_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"88001036"
}
"9269"
{
	"name"		"aus2025_signature_attacker_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_attacker_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_attacker_holo"
	"sticker_material"		"aus2025/sig_attacker_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"88001036"
}
"9270"
{
	"name"		"aus2025_signature_attacker_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_attacker_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_attacker_gold"
	"sticker_material"		"aus2025/sig_attacker_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"88001036"
}
"9271"
{
	"name"		"aus2025_signature_jee_4"
	"item_name"		"#StickerKit_aus2025_signature_jee"
	"description_string"		"#StickerKit_desc_aus2025_signature_jee"
	"sticker_material"		"aus2025/sig_jee"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"400141913"
}
"9272"
{
	"name"		"aus2025_signature_jee_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_jee_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_jee_foil"
	"sticker_material"		"aus2025/sig_jee_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"400141913"
}
"9273"
{
	"name"		"aus2025_signature_jee_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_jee_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_jee_holo"
	"sticker_material"		"aus2025/sig_jee_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"400141913"
}
"9274"
{
	"name"		"aus2025_signature_jee_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_jee_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_jee_gold"
	"sticker_material"		"aus2025/sig_jee_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"400141913"
}
"9275"
{
	"name"		"aus2025_signature_mercury_4"
	"item_name"		"#StickerKit_aus2025_signature_mercury"
	"description_string"		"#StickerKit_desc_aus2025_signature_mercury"
	"sticker_material"		"aus2025/sig_mercury"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"148530751"
}
"9276"
{
	"name"		"aus2025_signature_mercury_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_mercury_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_mercury_foil"
	"sticker_material"		"aus2025/sig_mercury_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"148530751"
}
"9277"
{
	"name"		"aus2025_signature_mercury_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_mercury_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_mercury_holo"
	"sticker_material"		"aus2025/sig_mercury_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"148530751"
}
"9278"
{
	"name"		"aus2025_signature_mercury_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_mercury_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_mercury_gold"
	"sticker_material"		"aus2025/sig_mercury_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"74"
	"tournament_player_id"		"148530751"
}
"9279"
{
	"name"		"aus2025_signature_art_4"
	"item_name"		"#StickerKit_aus2025_signature_art"
	"description_string"		"#StickerKit_desc_aus2025_signature_art"
	"sticker_material"		"aus2025/sig_art"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"83503844"
}
"9280"
{
	"name"		"aus2025_signature_art_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_art_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_art_foil"
	"sticker_material"		"aus2025/sig_art_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"83503844"
}
"9281"
{
	"name"		"aus2025_signature_art_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_art_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_art_holo"
	"sticker_material"		"aus2025/sig_art_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"83503844"
}
"9282"
{
	"name"		"aus2025_signature_art_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_art_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_art_gold"
	"sticker_material"		"aus2025/sig_art_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"83503844"
}
"9283"
{
	"name"		"aus2025_signature_piriajr_4"
	"item_name"		"#StickerKit_aus2025_signature_piriajr"
	"description_string"		"#StickerKit_desc_aus2025_signature_piriajr"
	"sticker_material"		"aus2025/sig_piriajr"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"436072455"
}
"9284"
{
	"name"		"aus2025_signature_piriajr_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_piriajr_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_piriajr_foil"
	"sticker_material"		"aus2025/sig_piriajr_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"436072455"
}
"9285"
{
	"name"		"aus2025_signature_piriajr_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_piriajr_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_piriajr_holo"
	"sticker_material"		"aus2025/sig_piriajr_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"436072455"
}
"9286"
{
	"name"		"aus2025_signature_piriajr_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_piriajr_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_piriajr_gold"
	"sticker_material"		"aus2025/sig_piriajr_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"436072455"
}
"9287"
{
	"name"		"aus2025_signature_zevy_4"
	"item_name"		"#StickerKit_aus2025_signature_zevy"
	"description_string"		"#StickerKit_desc_aus2025_signature_zevy"
	"sticker_material"		"aus2025/sig_zevy"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"911593093"
}
"9288"
{
	"name"		"aus2025_signature_zevy_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_zevy_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_zevy_foil"
	"sticker_material"		"aus2025/sig_zevy_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"911593093"
}
"9289"
{
	"name"		"aus2025_signature_zevy_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_zevy_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_zevy_holo"
	"sticker_material"		"aus2025/sig_zevy_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"911593093"
}
"9290"
{
	"name"		"aus2025_signature_zevy_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_zevy_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_zevy_gold"
	"sticker_material"		"aus2025/sig_zevy_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"911593093"
}
"9291"
{
	"name"		"aus2025_signature_kye_4"
	"item_name"		"#StickerKit_aus2025_signature_kye"
	"description_string"		"#StickerKit_desc_aus2025_signature_kye"
	"sticker_material"		"aus2025/sig_kye"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"1135765413"
}
"9292"
{
	"name"		"aus2025_signature_kye_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_kye_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_kye_foil"
	"sticker_material"		"aus2025/sig_kye_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"1135765413"
}
"9293"
{
	"name"		"aus2025_signature_kye_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_kye_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_kye_holo"
	"sticker_material"		"aus2025/sig_kye_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"1135765413"
}
"9294"
{
	"name"		"aus2025_signature_kye_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_kye_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_kye_gold"
	"sticker_material"		"aus2025/sig_kye_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"1135765413"
}
"9295"
{
	"name"		"aus2025_signature_mlhzin_4"
	"item_name"		"#StickerKit_aus2025_signature_mlhzin"
	"description_string"		"#StickerKit_desc_aus2025_signature_mlhzin"
	"sticker_material"		"aus2025/sig_mlhzin"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"439220479"
}
"9296"
{
	"name"		"aus2025_signature_mlhzin_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_mlhzin_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_mlhzin_foil"
	"sticker_material"		"aus2025/sig_mlhzin_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"439220479"
}
"9297"
{
	"name"		"aus2025_signature_mlhzin_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_mlhzin_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_mlhzin_holo"
	"sticker_material"		"aus2025/sig_mlhzin_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"439220479"
}
"9298"
{
	"name"		"aus2025_signature_mlhzin_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_mlhzin_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_mlhzin_gold"
	"sticker_material"		"aus2025/sig_mlhzin_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"121"
	"tournament_player_id"		"439220479"
}
"9299"
{
	"name"		"aus2025_signature_controlez_4"
	"item_name"		"#StickerKit_aus2025_signature_controlez"
	"description_string"		"#StickerKit_desc_aus2025_signature_controlez"
	"sticker_material"		"aus2025/sig_controlez"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"402172443"
}
"9300"
{
	"name"		"aus2025_signature_controlez_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_controlez_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_controlez_foil"
	"sticker_material"		"aus2025/sig_controlez_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"402172443"
}
"9301"
{
	"name"		"aus2025_signature_controlez_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_controlez_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_controlez_holo"
	"sticker_material"		"aus2025/sig_controlez_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"402172443"
}
"9302"
{
	"name"		"aus2025_signature_controlez_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_controlez_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_controlez_gold"
	"sticker_material"		"aus2025/sig_controlez_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"402172443"
}
"9303"
{
	"name"		"aus2025_signature_efire_4"
	"item_name"		"#StickerKit_aus2025_signature_efire"
	"description_string"		"#StickerKit_desc_aus2025_signature_efire"
	"sticker_material"		"aus2025/sig_efire"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"1287152892"
}
"9304"
{
	"name"		"aus2025_signature_efire_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_efire_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_efire_foil"
	"sticker_material"		"aus2025/sig_efire_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"1287152892"
}
"9305"
{
	"name"		"aus2025_signature_efire_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_efire_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_efire_holo"
	"sticker_material"		"aus2025/sig_efire_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"1287152892"
}
"9306"
{
	"name"		"aus2025_signature_efire_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_efire_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_efire_gold"
	"sticker_material"		"aus2025/sig_efire_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"1287152892"
}
"9307"
{
	"name"		"aus2025_signature_roux_4"
	"item_name"		"#StickerKit_aus2025_signature_roux"
	"description_string"		"#StickerKit_desc_aus2025_signature_roux"
	"sticker_material"		"aus2025/sig_roux"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"977087142"
}
"9308"
{
	"name"		"aus2025_signature_roux_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_roux_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_roux_foil"
	"sticker_material"		"aus2025/sig_roux_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"977087142"
}
"9309"
{
	"name"		"aus2025_signature_roux_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_roux_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_roux_holo"
	"sticker_material"		"aus2025/sig_roux_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"977087142"
}
"9310"
{
	"name"		"aus2025_signature_roux_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_roux_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_roux_gold"
	"sticker_material"		"aus2025/sig_roux_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"977087142"
}
"9311"
{
	"name"		"aus2025_signature_ariucle_4"
	"item_name"		"#StickerKit_aus2025_signature_ariucle"
	"description_string"		"#StickerKit_desc_aus2025_signature_ariucle"
	"sticker_material"		"aus2025/sig_ariucle"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"469468594"
}
"9312"
{
	"name"		"aus2025_signature_ariucle_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_ariucle_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_ariucle_foil"
	"sticker_material"		"aus2025/sig_ariucle_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"469468594"
}
"9313"
{
	"name"		"aus2025_signature_ariucle_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_ariucle_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_ariucle_holo"
	"sticker_material"		"aus2025/sig_ariucle_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"469468594"
}
"9314"
{
	"name"		"aus2025_signature_ariucle_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_ariucle_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_ariucle_gold"
	"sticker_material"		"aus2025/sig_ariucle_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"469468594"
}
"9315"
{
	"name"		"aus2025_signature_cool4st_4"
	"item_name"		"#StickerKit_aus2025_signature_cool4st"
	"description_string"		"#StickerKit_desc_aus2025_signature_cool4st"
	"sticker_material"		"aus2025/sig_cool4st"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"882582488"
}
"9316"
{
	"name"		"aus2025_signature_cool4st_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_cool4st_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_cool4st_foil"
	"sticker_material"		"aus2025/sig_cool4st_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"882582488"
}
"9317"
{
	"name"		"aus2025_signature_cool4st_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_cool4st_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_cool4st_holo"
	"sticker_material"		"aus2025/sig_cool4st_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"882582488"
}
"9318"
{
	"name"		"aus2025_signature_cool4st_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_cool4st_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_cool4st_gold"
	"sticker_material"		"aus2025/sig_cool4st_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"138"
	"tournament_player_id"		"882582488"
}
"9319"
{
	"name"		"aus2025_signature_westmelon_4"
	"item_name"		"#StickerKit_aus2025_signature_westmelon"
	"description_string"		"#StickerKit_desc_aus2025_signature_westmelon"
	"sticker_material"		"aus2025/sig_westmelon"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"146974312"
}
"9320"
{
	"name"		"aus2025_signature_westmelon_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_westmelon_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_westmelon_foil"
	"sticker_material"		"aus2025/sig_westmelon_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"146974312"
}
"9321"
{
	"name"		"aus2025_signature_westmelon_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_westmelon_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_westmelon_holo"
	"sticker_material"		"aus2025/sig_westmelon_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"146974312"
}
"9322"
{
	"name"		"aus2025_signature_westmelon_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_westmelon_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_westmelon_gold"
	"sticker_material"		"aus2025/sig_westmelon_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"146974312"
}
"9323"
{
	"name"		"aus2025_signature_z4kr_4"
	"item_name"		"#StickerKit_aus2025_signature_z4kr"
	"description_string"		"#StickerKit_desc_aus2025_signature_z4kr"
	"sticker_material"		"aus2025/sig_z4kr"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"177517735"
}
"9324"
{
	"name"		"aus2025_signature_z4kr_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_z4kr_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_z4kr_foil"
	"sticker_material"		"aus2025/sig_z4kr_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"177517735"
}
"9325"
{
	"name"		"aus2025_signature_z4kr_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_z4kr_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_z4kr_holo"
	"sticker_material"		"aus2025/sig_z4kr_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"177517735"
}
"9326"
{
	"name"		"aus2025_signature_z4kr_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_z4kr_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_z4kr_gold"
	"sticker_material"		"aus2025/sig_z4kr_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"177517735"
}
"9327"
{
	"name"		"aus2025_signature_starry_4"
	"item_name"		"#StickerKit_aus2025_signature_starry"
	"description_string"		"#StickerKit_desc_aus2025_signature_starry"
	"sticker_material"		"aus2025/sig_starry"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"920033815"
}
"9328"
{
	"name"		"aus2025_signature_starry_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_starry_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_starry_foil"
	"sticker_material"		"aus2025/sig_starry_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"920033815"
}
"9329"
{
	"name"		"aus2025_signature_starry_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_starry_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_starry_holo"
	"sticker_material"		"aus2025/sig_starry_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"920033815"
}
"9330"
{
	"name"		"aus2025_signature_starry_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_starry_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_starry_gold"
	"sticker_material"		"aus2025/sig_starry_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"920033815"
}
"9331"
{
	"name"		"aus2025_signature_emiliaqaq_4"
	"item_name"		"#StickerKit_aus2025_signature_emiliaqaq"
	"description_string"		"#StickerKit_desc_aus2025_signature_emiliaqaq"
	"sticker_material"		"aus2025/sig_emiliaqaq"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"856465673"
}
"9332"
{
	"name"		"aus2025_signature_emiliaqaq_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_emiliaqaq_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_emiliaqaq_foil"
	"sticker_material"		"aus2025/sig_emiliaqaq_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"856465673"
}
"9333"
{
	"name"		"aus2025_signature_emiliaqaq_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_emiliaqaq_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_emiliaqaq_holo"
	"sticker_material"		"aus2025/sig_emiliaqaq_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"856465673"
}
"9334"
{
	"name"		"aus2025_signature_emiliaqaq_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_emiliaqaq_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_emiliaqaq_gold"
	"sticker_material"		"aus2025/sig_emiliaqaq_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"856465673"
}
"9335"
{
	"name"		"aus2025_signature_c4llm3su3_4"
	"item_name"		"#StickerKit_aus2025_signature_c4llm3su3"
	"description_string"		"#StickerKit_desc_aus2025_signature_c4llm3su3"
	"sticker_material"		"aus2025/sig_c4llm3su3"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"456122416"
}
"9336"
{
	"name"		"aus2025_signature_c4llm3su3_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_c4llm3su3_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_c4llm3su3_foil"
	"sticker_material"		"aus2025/sig_c4llm3su3_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"456122416"
}
"9337"
{
	"name"		"aus2025_signature_c4llm3su3_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_c4llm3su3_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_c4llm3su3_holo"
	"sticker_material"		"aus2025/sig_c4llm3su3_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"456122416"
}
"9338"
{
	"name"		"aus2025_signature_c4llm3su3_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_c4llm3su3_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_c4llm3su3_gold"
	"sticker_material"		"aus2025/sig_c4llm3su3_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"127"
	"tournament_player_id"		"456122416"
}
"9339"
{
	"name"		"aus2025_signature_lux_4"
	"item_name"		"#StickerKit_aus2025_signature_lux"
	"description_string"		"#StickerKit_desc_aus2025_signature_lux"
	"sticker_material"		"aus2025/sig_lux"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"113751940"
}
"9340"
{
	"name"		"aus2025_signature_lux_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_lux_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_lux_foil"
	"sticker_material"		"aus2025/sig_lux_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"113751940"
}
"9341"
{
	"name"		"aus2025_signature_lux_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_lux_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_lux_holo"
	"sticker_material"		"aus2025/sig_lux_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"113751940"
}
"9342"
{
	"name"		"aus2025_signature_lux_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_lux_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_lux_gold"
	"sticker_material"		"aus2025/sig_lux_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"113751940"
}
"9343"
{
	"name"		"aus2025_signature_saadzin_4"
	"item_name"		"#StickerKit_aus2025_signature_saadzin"
	"description_string"		"#StickerKit_desc_aus2025_signature_saadzin"
	"sticker_material"		"aus2025/sig_saadzin"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"140229234"
}
"9344"
{
	"name"		"aus2025_signature_saadzin_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_saadzin_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_saadzin_foil"
	"sticker_material"		"aus2025/sig_saadzin_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"140229234"
}
"9345"
{
	"name"		"aus2025_signature_saadzin_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_saadzin_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_saadzin_holo"
	"sticker_material"		"aus2025/sig_saadzin_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"140229234"
}
"9346"
{
	"name"		"aus2025_signature_saadzin_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_saadzin_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_saadzin_gold"
	"sticker_material"		"aus2025/sig_saadzin_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"140229234"
}
"9347"
{
	"name"		"aus2025_signature_latto_4"
	"item_name"		"#StickerKit_aus2025_signature_latto"
	"description_string"		"#StickerKit_desc_aus2025_signature_latto"
	"sticker_material"		"aus2025/sig_latto"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"889754458"
}
"9348"
{
	"name"		"aus2025_signature_latto_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_latto_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_latto_foil"
	"sticker_material"		"aus2025/sig_latto_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"889754458"
}
"9349"
{
	"name"		"aus2025_signature_latto_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_latto_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_latto_holo"
	"sticker_material"		"aus2025/sig_latto_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"889754458"
}
"9350"
{
	"name"		"aus2025_signature_latto_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_latto_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_latto_gold"
	"sticker_material"		"aus2025/sig_latto_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"889754458"
}
"9351"
{
	"name"		"aus2025_signature_dumau_4"
	"item_name"		"#StickerKit_aus2025_signature_dumau"
	"description_string"		"#StickerKit_desc_aus2025_signature_dumau"
	"sticker_material"		"aus2025/sig_dumau"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"234059589"
}
"9352"
{
	"name"		"aus2025_signature_dumau_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_dumau_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_dumau_foil"
	"sticker_material"		"aus2025/sig_dumau_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"234059589"
}
"9353"
{
	"name"		"aus2025_signature_dumau_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_dumau_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_dumau_holo"
	"sticker_material"		"aus2025/sig_dumau_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"234059589"
}
"9354"
{
	"name"		"aus2025_signature_dumau_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_dumau_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_dumau_gold"
	"sticker_material"		"aus2025/sig_dumau_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"234059589"
}
"9355"
{
	"name"		"aus2025_signature_n1ssim_4"
	"item_name"		"#StickerKit_aus2025_signature_n1ssim"
	"description_string"		"#StickerKit_desc_aus2025_signature_n1ssim"
	"sticker_material"		"aus2025/sig_n1ssim"
	"item_rarity"		"rare"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"101497868"
}
"9356"
{
	"name"		"aus2025_signature_n1ssim_4_foil"
	"item_name"		"#StickerKit_aus2025_signature_n1ssim_foil"
	"description_string"		"#StickerKit_desc_aus2025_signature_n1ssim_foil"
	"sticker_material"		"aus2025/sig_n1ssim_foil"
	"item_rarity"		"mythical"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"101497868"
}
"9357"
{
	"name"		"aus2025_signature_n1ssim_4_holo"
	"item_name"		"#StickerKit_aus2025_signature_n1ssim_holo"
	"description_string"		"#StickerKit_desc_aus2025_signature_n1ssim_holo"
	"sticker_material"		"aus2025/sig_n1ssim_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"101497868"
}
"9358"
{
	"name"		"aus2025_signature_n1ssim_4_gold"
	"item_name"		"#StickerKit_aus2025_signature_n1ssim_gold"
	"description_string"		"#StickerKit_desc_aus2025_signature_n1ssim_gold"
	"sticker_material"		"aus2025/sig_n1ssim_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"24"
	"tournament_team_id"		"126"
	"tournament_player_id"		"101497868"
}            
""";

        var result = ParseStickerInput(input);

        // Printing the result

        List<Sticker> stickers = new List<Sticker>();

        foreach (var item in result)
        {
            var entry = item.Value;
            string name = GetStickerName(entry);
            string tournamentName = GetTournamentName(name);
            string tournamentNameUrl = tournamentName
                .Replace(" ", string.Empty)
                .ToLower()
                .Trim();


            string path = "aus2025";


            string rarity = "HighGrade";

            if (name.Contains("(Foil)"))
            {
                rarity = "Remarkable";
            }
            else if (name.Contains("(Holo)"))
            {
                rarity = "Exotic";
            }
            else if (name.Contains("(Gold)") || name.Contains("(Lenticular)"))
            {
                rarity = "Extraordinary";
            }

            stickers.Add(new Sticker
            {
                gen_id = item.Key,
                name = name,
                tournament = tournamentName,
                rarity = rarity,
                BuffGoodsId = null,
                BuffStickerId = null,
                Image = $"/assets/img/items/stickers/{entry.sticker_material}_png.png"
            });
        }

        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        foreach (var item in stickers.GroupBy(x => x.tournament))
        {
            List<Sticker> stickerList = item.ToList();
            string json = JsonSerializer.Serialize(stickerList, options);
            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{item.Key}.json");

            await File.WriteAllTextAsync(filename, json);
        }
    }

    static string GetTournamentName(string name)
    {
        var match = _tournamentRegex.Match(name);
        if (match.Success && match.Groups.Count > 0)
        {
            return match.Groups[0].Value.Replace("\"", string.Empty).Trim();
        }

        return string.Empty;
    }
    static string GetStickerName(StickerEntry entry)
    {
        string nameSanitized = entry.item_name.Replace("#", string.Empty);
        string pattern = $"(?<={nameSanitized}...).*\"";
        Regex nameRegex = new Regex(pattern);
        var match = nameRegex.Match(_translations);
        if (match.Success && match.Groups.Count > 0)
        {
            return match.Groups[0].Value.Replace("\"", string.Empty).Trim();
        }

        return string.Empty;
    }

    static string GetTranslation(string name)
    {
        string nameSanitized = name.Replace("#", string.Empty);
        string pattern = $"(?<={nameSanitized}...).*\"";
        Regex nameRegex = new Regex(pattern);
        var match = nameRegex.Match(_translations);
        if (match.Success && match.Groups.Count > 0)
        {
            return match.Groups[0].Value.Replace("\"", string.Empty).Trim();
        }

        return string.Empty;
    }

    static string GetCollectionName(string content)
    {

        return string.Empty;
    }

    static string GetWeaponName(WeaponEntry entry)
    {
        string nameSanitized = entry.description_tag.Replace("#", string.Empty);
        string pattern = $"(?<={nameSanitized}...).*\"";
        Regex nameRegex = new Regex(pattern);
        var match = nameRegex.Match(_translations);
        if (match.Success && match.Groups.Count > 0)
        {
            return match.Groups[0].Value.Replace("\"", string.Empty).Trim();
        }

        return string.Empty;
    }
    static Dictionary<int, StickerEntry> ParseStickerInput(string input)
    {
        var results = new Dictionary<int, StickerEntry>();

        string[] items = input.Split(new[] { "}" }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string item in items)
        {
            string[] lines = item.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length < 7)
            {
                continue;
            }

            // Parse lines
            // key first
            string keyBase = lines[0].Replace("\"", string.Empty).Trim();
            _ = int.TryParse(keyBase, out int gen_id);

            // name
            string nameKey = lines[2]
                .Replace("\"name\"", string.Empty)
                .Replace("\"", string.Empty).Trim();
            // item_name
            string itemNameKey = lines[3]
                .Replace("\"item_name\"", string.Empty)
                .Replace("\"", string.Empty).Trim();
            // sticker_material
            string stickerMaterialKey = lines[5]
                .Replace("\"sticker_material\"", string.Empty)
                .Replace("\"", string.Empty).Trim();
            //item_rarity
            string rarityKey = lines[6]
                .Replace("\"item_rarity\"", string.Empty)
                .Replace("\"", string.Empty).Trim();



            StickerEntry entry = new StickerEntry
            {
                name = nameKey,
                item_name = itemNameKey,
                item_rarity = rarityKey,
                sticker_material = stickerMaterialKey,
            };

            results.Add(gen_id, entry);
        }

        return results;
    }

    static Dictionary<int, WeaponEntry> ParseCollectionInput(string input)
    {
        var results = new Dictionary<int, WeaponEntry>();

        string[] items = input.Split(new[] { "}" }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string item in items)
        {
            string[] lines = item.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length < 9)
            {
                continue;
            }

            // Parse lines
            // key first
            string keyBase = lines[0].Replace("\"", string.Empty).Trim();
            _ = int.TryParse(keyBase, out int gen_id);

            // name
            string nameKey = lines[2]
                .Replace("\"name\"", string.Empty)
                .Replace("\"", string.Empty).Trim();
            // description_string
            string description_stringKey = lines[3]
                .Replace("\"description_string\"", string.Empty)
                .Replace("\"", string.Empty).Trim();

            // description_tag
            string description_tagKey = lines[4]
                .Replace("\"description_tag\"", string.Empty)
                .Replace("\"", string.Empty).Trim();

            // style
            string styleKey = lines[5]
                .Replace("\"style\"", string.Empty)
                .Replace("\"", string.Empty).Trim();

            // wear_remap_min
            string wear_remap_minKey = lines[6]
                .Replace("\"wear_remap_min\"", string.Empty)
                .Replace("\"", string.Empty).Trim();

            // wear_remap_max
            string wear_remap_maxKey = lines[7]
                .Replace("\"wear_remap_max\"", string.Empty)
                .Replace("\"", string.Empty).Trim();

            //composite_material_path
            string composite_material_pathKey = lines[8]
                .Replace("\"composite_material_path\"", string.Empty)
                .Replace("\"", string.Empty).Trim();



            WeaponEntry entry = new WeaponEntry
            {
                name = nameKey,
                description_string = description_stringKey,
                description_tag = description_tagKey,
                style = styleKey,
                wear_remap_min = wear_remap_minKey,
                wear_remap_max = wear_remap_maxKey,
                composite_material_path = composite_material_pathKey
            };

            results.Add(gen_id, entry);
        }

        return results;
    }
}

public class LootListEntry
{
    public string Id { get; set; }
    public Dictionary<string, string> Items { get; set; } = [];
}

