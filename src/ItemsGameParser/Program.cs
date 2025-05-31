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
"8533"
{
	"name"		"sha2024_signature_chopper_32"
	"item_name"		"#StickerKit_sha2024_signature_chopper_champion"
	"description_string"		"#StickerKit_desc_sha2024_signature_chopper_champion"
	"sticker_material"		"sha2024/sig_chopper_champion"
	"item_rarity"		"rare"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"85633136"
}
"8534"
{
	"name"		"sha2024_signature_chopper_32_glitter"
	"item_name"		"#StickerKit_sha2024_signature_chopper_champion_glitter"
	"description_string"		"#StickerKit_desc_sha2024_signature_chopper_champion_glitter"
	"sticker_material"		"sha2024/sig_chopper_champion_glitter"
	"item_rarity"		"mythical"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"85633136"
}
"8535"
{
	"name"		"sha2024_signature_chopper_32_holo"
	"item_name"		"#StickerKit_sha2024_signature_chopper_champion_holo"
	"description_string"		"#StickerKit_desc_sha2024_signature_chopper_champion_holo"
	"sticker_material"		"sha2024/sig_chopper_champion_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"85633136"
}
"8536"
{
	"name"		"sha2024_signature_chopper_32_gold"
	"item_name"		"#StickerKit_sha2024_signature_chopper_champion_gold"
	"description_string"		"#StickerKit_desc_sha2024_signature_chopper_champion_gold"
	"sticker_material"		"sha2024/sig_chopper_champion_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"85633136"
}
"8537"
{
	"name"		"sha2024_signature_magixx_32"
	"item_name"		"#StickerKit_sha2024_signature_magixx_champion"
	"description_string"		"#StickerKit_desc_sha2024_signature_magixx_champion"
	"sticker_material"		"sha2024/sig_magixx_champion"
	"item_rarity"		"rare"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"868554"
}
"8538"
{
	"name"		"sha2024_signature_magixx_32_glitter"
	"item_name"		"#StickerKit_sha2024_signature_magixx_champion_glitter"
	"description_string"		"#StickerKit_desc_sha2024_signature_magixx_champion_glitter"
	"sticker_material"		"sha2024/sig_magixx_champion_glitter"
	"item_rarity"		"mythical"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"868554"
}
"8539"
{
	"name"		"sha2024_signature_magixx_32_holo"
	"item_name"		"#StickerKit_sha2024_signature_magixx_champion_holo"
	"description_string"		"#StickerKit_desc_sha2024_signature_magixx_champion_holo"
	"sticker_material"		"sha2024/sig_magixx_champion_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"868554"
}
"8540"
{
	"name"		"sha2024_signature_magixx_32_gold"
	"item_name"		"#StickerKit_sha2024_signature_magixx_champion_gold"
	"description_string"		"#StickerKit_desc_sha2024_signature_magixx_champion_gold"
	"sticker_material"		"sha2024/sig_magixx_champion_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"868554"
}
"8541"
{
	"name"		"sha2024_signature_donk_32"
	"item_name"		"#StickerKit_sha2024_signature_donk_champion"
	"description_string"		"#StickerKit_desc_sha2024_signature_donk_champion"
	"sticker_material"		"sha2024/sig_donk_champion"
	"item_rarity"		"rare"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"425999755"
}
"8542"
{
	"name"		"sha2024_signature_donk_32_glitter"
	"item_name"		"#StickerKit_sha2024_signature_donk_champion_glitter"
	"description_string"		"#StickerKit_desc_sha2024_signature_donk_champion_glitter"
	"sticker_material"		"sha2024/sig_donk_champion_glitter"
	"item_rarity"		"mythical"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"425999755"
}
"8543"
{
	"name"		"sha2024_signature_donk_32_holo"
	"item_name"		"#StickerKit_sha2024_signature_donk_champion_holo"
	"description_string"		"#StickerKit_desc_sha2024_signature_donk_champion_holo"
	"sticker_material"		"sha2024/sig_donk_champion_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"425999755"
}
"8544"
{
	"name"		"sha2024_signature_donk_32_gold"
	"item_name"		"#StickerKit_sha2024_signature_donk_champion_gold"
	"description_string"		"#StickerKit_desc_sha2024_signature_donk_champion_gold"
	"sticker_material"		"sha2024/sig_donk_champion_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"425999755"
}
"8545"
{
	"name"		"sha2024_signature_sh1ro_32"
	"item_name"		"#StickerKit_sha2024_signature_sh1ro_champion"
	"description_string"		"#StickerKit_desc_sha2024_signature_sh1ro_champion"
	"sticker_material"		"sha2024/sig_sh1ro_champion"
	"item_rarity"		"rare"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"121219047"
}
"8546"
{
	"name"		"sha2024_signature_sh1ro_32_glitter"
	"item_name"		"#StickerKit_sha2024_signature_sh1ro_champion_glitter"
	"description_string"		"#StickerKit_desc_sha2024_signature_sh1ro_champion_glitter"
	"sticker_material"		"sha2024/sig_sh1ro_champion_glitter"
	"item_rarity"		"mythical"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"121219047"
}
"8547"
{
	"name"		"sha2024_signature_sh1ro_32_holo"
	"item_name"		"#StickerKit_sha2024_signature_sh1ro_champion_holo"
	"description_string"		"#StickerKit_desc_sha2024_signature_sh1ro_champion_holo"
	"sticker_material"		"sha2024/sig_sh1ro_champion_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"121219047"
}
"8548"
{
	"name"		"sha2024_signature_sh1ro_32_gold"
	"item_name"		"#StickerKit_sha2024_signature_sh1ro_champion_gold"
	"description_string"		"#StickerKit_desc_sha2024_signature_sh1ro_champion_gold"
	"sticker_material"		"sha2024/sig_sh1ro_champion_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"121219047"
}
"8549"
{
	"name"		"sha2024_signature_zont1x_32"
	"item_name"		"#StickerKit_sha2024_signature_zont1x_champion"
	"description_string"		"#StickerKit_desc_sha2024_signature_zont1x_champion"
	"sticker_material"		"sha2024/sig_zont1x_champion"
	"item_rarity"		"rare"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"1035615149"
}
"8550"
{
	"name"		"sha2024_signature_zont1x_32_glitter"
	"item_name"		"#StickerKit_sha2024_signature_zont1x_champion_glitter"
	"description_string"		"#StickerKit_desc_sha2024_signature_zont1x_champion_glitter"
	"sticker_material"		"sha2024/sig_zont1x_champion_glitter"
	"item_rarity"		"mythical"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"1035615149"
}
"8551"
{
	"name"		"sha2024_signature_zont1x_32_holo"
	"item_name"		"#StickerKit_sha2024_signature_zont1x_champion_holo"
	"description_string"		"#StickerKit_desc_sha2024_signature_zont1x_champion_holo"
	"sticker_material"		"sha2024/sig_zont1x_champion_holo"
	"item_rarity"		"legendary"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"1035615149"
}
"8552"
{
	"name"		"sha2024_signature_zont1x_32_gold"
	"item_name"		"#StickerKit_sha2024_signature_zont1x_champion_gold"
	"description_string"		"#StickerKit_desc_sha2024_signature_zont1x_champion_gold"
	"sticker_material"		"sha2024/sig_zont1x_champion_gold"
	"item_rarity"		"ancient"
	"tournament_event_id"		"23"
	"tournament_team_id"		"81"
	"tournament_player_id"		"1035615149"
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

            if (name.Contains("(Glitter)"))
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
                StickerId = item.Key,
                Name = name,
                Collection = tournamentName,
                Image = $"/assets/img/items/stickers/{entry.sticker_material}_png.png"
            });
        }

        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        foreach (var item in stickers.GroupBy(x => x.Collection))
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

