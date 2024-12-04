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
    static Program()
    {
        string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "csgo_english.txt");
        _translations = File.ReadAllText(filename);
        filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "items_game.txt");
        _items_game = File.ReadAllText(filename);
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
            "106"
            {
            	"name"		"m4a1s_vaporwave"
            	"description_string"		"PaintKit_m4a1s_vaporwave"
            	"description_tag"		"PaintKit_m4a1s_vaporwave_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.597321"
            	"composite_material_path"		"weapons/paints/community/community_34/m4a1s_vaporwave.vcompmat"
            }
            "112"
            {
            	"name"		"dual_elite_hydro_strike"
            	"description_string"		"PaintKit_dual_elite_hydro_strike"
            	"description_tag"		"PaintKit_dual_elite_hydro_strike_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.801418"
            	"composite_material_path"		"weapons/paints/community/community_34/dual_elite_hydro_strike.vcompmat"
            }
            "113"
            {
            	"name"		"ak47_t_bus"
            	"description_string"		"PaintKit_ak47_t_bus"
            	"description_tag"		"PaintKit_ak47_t_bus_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.900000"
            	"composite_material_path"		"weapons/paints/community/community_34/ak47_t_bus.vcompmat"
            }
            "114"
            {
            	"name"		"deagle_calligraff"
            	"description_string"		"PaintKit_deagle_calligraff"
            	"description_tag"		"PaintKit_deagle_calligraff_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_34/deagle_calligraff.vcompmat"
            }
            "115"
            {
            	"name"		"usp_field_snake"
            	"description_string"		"PaintKit_usp_field_snake"
            	"description_tag"		"PaintKit_usp_field_snake_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_34/usp_field_snake.vcompmat"
            }
            "117"
            {
            	"name"		"scar20_fury_topo"
            	"description_string"		"PaintKit_scar20_fury_topo"
            	"description_tag"		"PaintKit_scar20_fury_topo_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.702614"
            	"composite_material_path"		"weapons/paints/community/community_34/scar20_fury_topo.vcompmat"
            }
            "118"
            {
            	"name"		"m4a4_fusion"
            	"description_string"		"PaintKit_m4a4_fusion"
            	"description_tag"		"PaintKit_m4a4_fusion_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.850000"
            	"composite_material_path"		"weapons/paints/community/community_34/m4a4_fusion.vcompmat"
            }
            "120"
            {
            	"name"		"m249_hypnosis"
            	"description_string"		"PaintKit_m249_hypnosis"
            	"description_tag"		"PaintKit_m249_hypnosis_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_34/m249_hypnosis.vcompmat"
            }
            "121"
            {
            	"name"		"aug_puffer"
            	"description_string"		"PaintKit_aug_puffer"
            	"description_tag"		"PaintKit_aug_puffer_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.900000"
            	"composite_material_path"		"weapons/paints/community/community_34/aug_puffer.vcompmat"
            }
            "123"
            {
            	"name"		"r8_roses_and_guns"
            	"description_string"		"PaintKit_r8_roses_and_guns"
            	"description_tag"		"PaintKit_r8_roses_and_guns_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.851064"
            	"composite_material_path"		"weapons/paints/community/community_34/r8_roses_and_guns.vcompmat"
            }
            "126"
            {
            	"name"		"mac10_ozaki"
            	"description_string"		"PaintKit_mac10_ozaki"
            	"description_tag"		"PaintKit_mac10_ozaki_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.660000"
            	"composite_material_path"		"weapons/paints/community/community_34/mac10_ozaki.vcompmat"
            }
            "127"
            {
            	"name"		"p90_randy_rush"
            	"description_string"		"PaintKit_p90_randy_rush"
            	"description_tag"		"PaintKit_p90_randy_rush_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/community/community_34/p90_randy_rush.vcompmat"
            }
            "128"
            {
            	"name"		"ssg08_transit_white"
            	"description_string"		"PaintKit_ssg08_transit_white"
            	"description_tag"		"PaintKit_ssg08_transit_white_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/community/community_34/ssg08_transit_white.vcompmat"
            }
            "129"
            {
            	"name"		"glock_chomper"
            	"description_string"		"PaintKit_glock_chomper"
            	"description_tag"		"PaintKit_glock_chomper_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.730496"
            	"composite_material_path"		"weapons/paints/community/community_34/glock_chomper.vcompmat"
            }
            "130"
            {
            	"name"		"p250_impact"
            	"description_string"		"PaintKit_p250_impact"
            	"description_tag"		"PaintKit_p250_impact_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.800000"
            	"composite_material_path"		"weapons/paints/community/community_34/p250_impact.vcompmat"
            }
            "131"
            {
            	"name"		"ump45_neo_noir"
            	"description_string"		"PaintKit_ump45_neo_noir"
            	"description_tag"		"PaintKit_cu_glock_noir_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_34/ump45_neo_noir.vcompmat"
            }
            "133"
            {
            	"name"		"sp_overpass_doodle_plum"
            	"description_string"		"#PaintKit_sp_overpass_doodle_plum"
            	"description_tag"		"#PaintKit_sp_overpass_doodle_plum_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.500000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/sp_overpass_doodle_plum.vcompmat"
            }
            "134"
            {
            	"name"		"cu_overpass_graf_aug"
            	"description_string"		"#PaintKit_cu_overpass_graf_aug"
            	"description_tag"		"#PaintKit_cu_overpass_graf_aug_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.850000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/cu_overpass_graf_aug.vcompmat"
            }
            "137"
            {
            	"name"		"cu_overpass_crakow_awp"
            	"description_string"		"#PaintKit_cu_overpass_crakow_awp"
            	"description_tag"		"#PaintKit_cu_overpass_crakow_awp_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/cu_overpass_crakow_awp.vcompmat"
            }
            "138"
            {
            	"name"		"cu_overpass_aqua_deagle"
            	"description_string"		"#PaintKit_cu_overpass_aqua_deagle"
            	"description_tag"		"#PaintKit_cu_overpass_aqua_deagle_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/cu_overpass_aqua_deagle.vcompmat"
            }
            "139"
            {
            	"name"		"cu_overpass_baby_dualies"
            	"description_string"		"#PaintKit_cu_overpass_baby_dualies"
            	"description_tag"		"#PaintKit_cu_overpass_baby_dualies_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.820000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/cu_overpass_baby_dualies.vcompmat"
            }
            "140"
            {
            	"name"		"cu_overpass_squeak_mac10"
            	"description_string"		"#PaintKit_cu_overpass_squeak_mac10"
            	"description_tag"		"#PaintKit_cu_overpass_squeak_mac10_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.900000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/cu_overpass_squeak_mac10.vcompmat"
            }
            "142"
            {
            	"name"		"cu_overpass_monster_ak47"
            	"description_string"		"#PaintKit_cu_overpass_monster_ak47"
            	"description_tag"		"#PaintKit_cu_overpass_monster_ak47_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.800000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/cu_overpass_monster_ak47.vcompmat"
            }
            "144"
            {
            	"name"		"cu_overpass_graf_negev"
            	"description_string"		"#PaintKit_cu_overpass_graf_negev"
            	"description_tag"		"#PaintKit_cu_overpass_graf_negev_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/cu_overpass_graf_negev.vcompmat"
            }
            "145"
            {
            	"name"		"cu_overpass_wurst_nova"
            	"description_string"		"#PaintKit_cu_overpass_wurst_nova"
            	"description_tag"		"#PaintKit_cu_overpass_wurst_nova_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/cu_overpass_wurst_nova.vcompmat"
            }
            "146"
            {
            	"name"		"cu_overpass_monsters_xm"
            	"description_string"		"#PaintKit_cu_overpass_monsters_xm"
            	"description_tag"		"#PaintKit_cu_overpass_monsters_xm_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/cu_overpass_monsters_xm.vcompmat"
            }
            "152"
            {
            	"name"		"hy_overpass_tagged_teal"
            	"description_string"		"#PaintKit_hy_overpass_tagged_teal"
            	"description_tag"		"#PaintKit_hy_overpass_tagged_teal_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.500000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/hy_overpass_tagged_teal.vcompmat"
            }
            "160"
            {
            	"name"		"hy_overpass_doodle_m4a1s"
            	"description_string"		"#PaintKit_hy_overpass_doodle_m4a1s"
            	"description_tag"		"#PaintKit_hy_overpass_doodle_m4a1s_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.580000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/hy_overpass_doodle_m4a1s.vcompmat"
            }
            "161"
            {
            	"name"		"sp_overpass_paint_pen_neon"
            	"description_string"		"#PaintKit_sp_overpass_paint_pen_neon"
            	"description_tag"		"#PaintKit_sp_overpass_paint_pen_neon_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.200000"
            	"wear_remap_max"		"0.900000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/sp_overpass_paint_pen_neon.vcompmat"
            }
            "163"
            {
            	"name"		"gs_independe_awp"
            	"description_string"		"#PaintKit_gs_independe_awp"
            	"description_tag"		"#PaintKit_gs_independe_awp_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.800000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/gs_independe_awp.vcompmat"
            }
            "173"
            {
            	"name"		"gs_lilpig_aug"
            	"description_string"		"#PaintKit_gs_lilpig_aug"
            	"description_tag"		"#PaintKit_gs_lilpig_aug_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.800000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/gs_lilpig_aug.vcompmat"
            }
            "239"
            {
            	"name"		"sp_overpass_paint_pen_metal"
            	"description_string"		"#PaintKit_sp_overpass_paint_pen_metal"
            	"description_tag"		"#PaintKit_sp_overpass_paint_pen_metal_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/sp_overpass_paint_pen_metal.vcompmat"
            }
            "292"
            {
            	"name"		"cu_overpass_dragon_zeus"
            	"description_string"		"#PaintKit_cu_overpass_dragon_zeus"
            	"description_tag"		"#PaintKit_cu_overpass_dragon_zeus_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.800000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/cu_overpass_dragon_zeus.vcompmat"
            }
            "324"
            {
            	"name"		"gs_ripple_nova"
            	"description_string"		"#PaintKit_gs_ripple_nova"
            	"description_tag"		"#PaintKit_gs_ripple_nova_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/gs_ripple_nova.vcompmat"
            }
            "331"
            {
            	"name"		"gs_arctic_mp9"
            	"description_string"		"#PaintKit_gs_arctic_mp9"
            	"description_tag"		"#PaintKit_gs_arctic_mp9_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/gs_arctic_mp9.vcompmat"
            }
            "412"
            {
            	"name"		"gsch_sport_ump45"
            	"description_string"		"#PaintKit_gsch_sport_ump45"
            	"description_tag"		"#PaintKit_gsch_sport_ump45_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.680000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/gsch_sport_ump45.vcompmat"
            }
            "461"
            {
            	"name"		"gs_gamebred_famas"
            	"description_string"		"#PaintKit_gs_gamebred_famas"
            	"description_tag"		"#PaintKit_gs_gamebred_famas_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/gs_gamebred_famas.vcompmat"
            }
            "513"
            {
            	"name"		"gsch_zeno_ssg08"
            	"description_string"		"#PaintKit_gsch_zeno_ssg08"
            	"description_tag"		"#PaintKit_gsch_zeno_ssg08_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/gsch_zeno_ssg08.vcompmat"
            }
            "766"
            {
            	"name"		"soch_tiger_stencil_tec9"
            	"description_string"		"#PaintKit_soch_tiger_stencil"
            	"description_tag"		"#PaintKit_soch_tiger_stencil_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/soch_tiger_stencil_tec9.vcompmat"
            }
            "768"
            {
            	"name"		"ht_blur_camo_mp5sd"
            	"description_string"		"#PaintKit_ht_blur_camo_mp5sd"
            	"description_tag"		"#PaintKit_ht_blur_camo_mp5sd_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.250000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/ht_blur_camo_mp5sd.vcompmat"
            }
            "770"
            {
            	"name"		"sp_wax_rub_bizon"
            	"description_string"		"#PaintKit_sp_wax_rub_bizon"
            	"description_tag"		"#PaintKit_sp_wax_rub_bizon_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.400000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/sp_wax_rub_bizon.vcompmat"
            }
            "773"
            {
            	"name"		"soch_wildwood_mag7"
            	"description_string"		"#PaintKit_soch_wildwood"
            	"description_tag"		"#PaintKit_soch_wildwood_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/soch_wildwood_mag7.vcompmat"
            }
            "774"
            {
            	"name"		"soch_hunter_blaze_p250"
            	"description_string"		"#PaintKit_soch_hunter_blaze"
            	"description_tag"		"#PaintKit_soch_hunter_blaze_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/soch_hunter_blaze_p250.vcompmat"
            }
            "830"
            {
            	"name"		"gsch_bright_camo_usp"
            	"description_string"		"#PaintKit_gsch_bright_camo_usp"
            	"description_tag"		"#PaintKit_gsch_bright_camo_usp_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.680000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/gsch_bright_camo_usp.vcompmat"
            }
            "831"
            {
            	"name"		"aq_case_hardened_fiveseven"
            	"description_string"		"#PaintKit_aq_case_hardened_2"
            	"description_tag"		"#PaintKit_aq_case_hardened_2_Tag"
            	"style"		"10"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/aq_case_hardened_fiveseven.vcompmat"
            }
            "832"
            {
            	"name"		"gsch_axia_glock"
            	"description_string"		"#PaintKit_gsch_axia_glock"
            	"description_tag"		"#PaintKit_gsch_axia_glock_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.700000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/gsch_axia_glock.vcompmat"
            }
            "834"
            {
            	"name"		"ht_shapes_xm1014"
            	"description_string"		"#PaintKit_ht_shapes"
            	"description_tag"		"#PaintKit_ht_shapes_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.600000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/ht_shapes_xm1014.vcompmat"
            }
            "874"
            {
            	"name"		"soo_polysoup_m4a4"
            	"description_string"		"#PaintKit_soo_polysoup_m4a4"
            	"description_tag"		"#PaintKit_soo_polysoup_m4a4_Tag"
            	"style"		"1"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.640000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/soo_polysoup_m4a4.vcompmat"
            }
            "875"
            {
            	"name"		"ht_peaks_rainbow"
            	"description_string"		"#PaintKit_ht_peaks_rainbow"
            	"description_tag"		"#PaintKit_ht_peaks_rainbow_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.500000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/ht_peaks_rainbow.vcompmat"
            }
            "877"
            {
            	"name"		"ht_swirl_ssg08"
            	"description_string"		"#PaintKit_ht_swirl"
            	"description_tag"		"#PaintKit_ht_swirl_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.500000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/ht_swirl_ssg08.vcompmat"
            }
            "878"
            {
            	"name"		"ht_facet_p2000"
            	"description_string"		"#PaintKit_ht_facet_p2000"
            	"description_tag"		"#PaintKit_ht_facet_p2000_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.520000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/ht_facet_p2000.vcompmat"
            }
            "882"
            {
            	"name"		"ht_splash_famas"
            	"description_string"		"#PaintKit_ht_splash"
            	"description_tag"		"#PaintKit_ht_splash_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.500000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/ht_splash_famas.vcompmat"
            }
            "883"
            {
            	"name"		"cu_chevron_scar20"
            	"description_string"		"#PaintKit_cu_chevron_scar20"
            	"description_tag"		"#PaintKit_cu_chevron_scar20_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.650000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/cu_chevron_scar20.vcompmat"
            }
            "901"
            {
            	"name"		"gs_happy_red_sg556"
            	"description_string"		"#PaintKit_gs_happy_red_sg556"
            	"description_tag"		"#PaintKit_gs_happy_red_sg556_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.800000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/gs_happy_red_sg556.vcompmat"
            }
            "912"
            {
            	"name"		"cu_graphic_overlay_ak47"
            	"description_string"		"#PaintKit_cu_graphic_overlay_ak47"
            	"description_tag"		"#PaintKit_cu_graphic_overlay_ak47_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.500000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/cu_graphic_overlay_ak47.vcompmat"
            }
            "936"
            {
            	"name"		"cu_poly_violet_p90"
            	"description_string"		"#PaintKit_cu_poly_violet_p90"
            	"description_tag"		"#PaintKit_cu_poly_violet_p90_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.550000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/cu_poly_violet_p90.vcompmat"
            }
            "937"
            {
            	"name"		"cu_abstract_white_cz"
            	"description_string"		"#PaintKit_cu_abstract_white_cz"
            	"description_tag"		"#PaintKit_cu_abstract_white_cz_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.570000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/cu_abstract_white_cz.vcompmat"
            }
            "938"
            {
            	"name"		"cu_glitter_deagle"
            	"description_string"		"#PaintKit_cu_glitter_deagle"
            	"description_tag"		"#PaintKit_cu_glitter_deagle_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.750000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/cu_glitter_deagle.vcompmat"
            }
            "939"
            {
            	"name"		"cu_poly_green_galil"
            	"description_string"		"#PaintKit_cu_poly_green_galil"
            	"description_tag"		"#PaintKit_cu_poly_green_galil_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.470000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/cu_poly_green_galil.vcompmat"
            }
            "940"
            {
            	"name"		"gs_constellation_dark_mp7"
            	"description_string"		"#PaintKit_gs_constellation_dark_mp7"
            	"description_tag"		"#PaintKit_gs_constellation_dark_mp7_Tag"
            	"style"		"9"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/set_graphic_design/gs_constellation_dark_mp7.vcompmat"
            }
            "1054"
            {
            	"name"		"aq_deagle_case_hardened_2"
            	"description_string"		"#PaintKit_aq_case_hardened_2"
            	"description_tag"		"#PaintKit_aq_case_hardened_2_Tag"
            	"style"		"10"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/limited_time/aq_deagle_case_hardened_2.vcompmat"
            }
            "1062"
            {
            	"name"		"hy_overpass_paintover_teal"
            	"description_string"		"#PaintKit_hy_overpass_paintover_teal"
            	"description_tag"		"#PaintKit_hy_overpass_paintover_teal_Tag"
            	"style"		"2"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.500000"
            	"composite_material_path"		"weapons/paints/set_overpass_2024/hy_overpass_paintover_teal.vcompmat"
            }
            "1177"
            {
            	"name"		"aa_fade_m4a1s"
            	"description_string"		"#PaintKit_aa_fade"
            	"description_tag"		"#PaintKit_aa_fade_Tag"
            	"style"		"6"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.080000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/aa_fade_m4a1s.vcompmat"
            }
            "1178"
            {
            	"name"		"aq_titanium_rainbow_galilar"
            	"description_string"		"#PaintKit_aq_titanium_rainbow"
            	"description_tag"		"#PaintKit_aq_titanium_rainbow_Tag"
            	"style"		"10"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.554422"
            	"composite_material_path"		"weapons/paints/set_realism_camo/aq_titanium_rainbow_galilar.vcompmat"
            }
            "1179"
            {
            	"name"		"ht_poly_camo_ak47"
            	"description_string"		"#PaintKit_ht_poly_camo"
            	"description_tag"		"#PaintKit_ht_poly_camo_Tag"
            	"style"		"3"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"0.500000"
            	"composite_material_path"		"weapons/paints/set_realism_camo/ht_poly_camo_ak47.vcompmat"
            }
            "1180"
            {
            	"name"		"mp5_statics_blue"
            	"description_string"		"#PaintKit_mp5_statics_blue"
            	"description_tag"		"#PaintKit_mp5_statics_blue_Tag"
            	"style"		"7"
            	"wear_remap_min"		"0.000000"
            	"wear_remap_max"		"1.000000"
            	"composite_material_path"		"weapons/paints/community/community_34/mp5_statics_blue.vcompmat"
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


            string collection_name = string.Empty;
            string imageDirectory = string.Empty;

            if (entry.composite_material_path.Contains("community_34"))
            {
                collection_name = "Gallery Collection";
                imageDirectory = "gallery_collection";
            }
            else if (entry.composite_material_path.Contains("set_graphic_design"))
            {
                collection_name = "Graphic Design Collection";
                imageDirectory = "graphic_design_collection";
            }
            else if (entry.composite_material_path.Contains("set_overpass_2024"))
            {
                collection_name = "Overpass 2024 Collection";
                imageDirectory = "overpass_2024_collection";
            }
            else if (entry.composite_material_path.Contains("set_realism_camo"))
            {
                collection_name = "Sport and Field Collection";
                imageDirectory = "sport_and_field_collection";
            }


            weapons.Add(new Weapon
            {
                gen_id = item.Key,
                name = $"{weapon_name} | {name}",
                min_wear = decimal.Parse(entry.wear_remap_min, CultureInfo.InvariantCulture),
                max_wear = decimal.Parse(entry.wear_remap_max, CultureInfo.InvariantCulture),
                trade_up = true,
                weapon_id = weapon_id,
                rarity = "Milspec",
                collection = collection_name,
                Image = $"/assets/img/items/weapons/{imageDirectory}/weapon_{econ_name}_{entry.name}_light_png.png"

            });

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
            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{item.Key}.json");

            await File.WriteAllTextAsync(filename, json);
        }    
    }

    private static (string name, int weapon_id, string econ_name) GetWeaponType(WeaponEntry entry)
    {
        string name = entry.name;

        if (name.StartsWith("ak47_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_ak47", StringComparison.OrdinalIgnoreCase))
        {
            return ("AK-47", 7, "ak47");
        }
        else if (name.StartsWith("m4a1s_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_m4a1s", StringComparison.OrdinalIgnoreCase))
        {
            return ("M4A1-S", 60, "m4a1_silencer");
        }
        else if (name.StartsWith("dual_elite_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_dualies", StringComparison.OrdinalIgnoreCase))
        {
            return ("Dual Berettas", 2, "elite_gs");
        }
        else if (name.StartsWith("deagle_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_deagle", StringComparison.OrdinalIgnoreCase))
        {
            return ("Desert Eagle", 1, "deagle");
        }
        else if (name.StartsWith("usp_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_usp", StringComparison.OrdinalIgnoreCase))
        {
            return ("USP-S", 61, "usp_silencer");
        }
        else if (name.StartsWith("scar20_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_scar20", StringComparison.OrdinalIgnoreCase))
        {
            return ("SCAR-20", 38, "scar20");
        }
        else if (name.StartsWith("m4a4_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_m4a4", StringComparison.OrdinalIgnoreCase))
        {
            return ("M4A4", 16, "m4a1");
        }
        else if (name.StartsWith("m249_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_m249", StringComparison.OrdinalIgnoreCase))
        {
            return ("M249", 14, "m249");
        }
        else if (name.StartsWith("aug_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_aug", StringComparison.OrdinalIgnoreCase))
        {
            return ("AUG", 8, "aug");
        }
        else if (name.StartsWith("r8_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_r8", StringComparison.OrdinalIgnoreCase))
        {
            return ("R8 Revolver", 64, "revolver");
        }
        else if (name.StartsWith("mac10_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_mac10", StringComparison.OrdinalIgnoreCase))
        {
            return ("MAC-10", 17, "mac10");
        }
        else if (name.StartsWith("p90_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_p90", StringComparison.OrdinalIgnoreCase))
        {
            return ("P90", 19, "p90");
        }
        else if (name.StartsWith("ssg08_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_ssg08", StringComparison.OrdinalIgnoreCase))
        {
            return ("SSG 08", 40, "ssg08");
        }
        else if (name.StartsWith("glock_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_glock", StringComparison.OrdinalIgnoreCase))
        {
            return ("Glock-18", 4, "glock");
        }
        else if (name.StartsWith("p250_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_p250", StringComparison.OrdinalIgnoreCase))
        {
            return ("P250", 36, "p250");
        }
        else if (name.StartsWith("ump45_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_ump45", StringComparison.OrdinalIgnoreCase))
        {
            return ("UMP-45", 24, "ump45");
        }
        else if (name.StartsWith("awp_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_awp", StringComparison.OrdinalIgnoreCase))
        {
            return ("AWP", 9, "awp");
        }
        else if (name.StartsWith("negev_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_negev", StringComparison.OrdinalIgnoreCase))
        {
            return ("Negev", 28, "negev");
        }
        else if (name.StartsWith("nova_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_nova", StringComparison.OrdinalIgnoreCase))
        {
            return ("Nova", 35, "nova");
        }
        else if (name.StartsWith("xm_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_xm1014", StringComparison.OrdinalIgnoreCase))
        {
            return ("XM1014", 25, "xm1014");
        }
        else if (name.StartsWith("mp5_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_mp5", StringComparison.OrdinalIgnoreCase))
        {
            return ("MP5-SD", 23, "mp5sd");
        }
        else if (name.StartsWith("galil_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_galil", StringComparison.OrdinalIgnoreCase))
        {
            return ("Galil AR", 13, "galilar");
        }
        else if (name.StartsWith("zeus_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_zeus", StringComparison.OrdinalIgnoreCase))
        {
            return ("Zeus", 31, "taser");
        }
        else if (name.StartsWith("mp9_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_mp9", StringComparison.OrdinalIgnoreCase))
        {
            return ("MP9", 34, "mp9");
        }
        else if (name.StartsWith("famas_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_famas", StringComparison.OrdinalIgnoreCase))
        {
            return ("FAMAS", 10, "famas");
        }
        else if (name.StartsWith("tec9_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_tec9", StringComparison.OrdinalIgnoreCase))
        {
            return ("Tec-9", 30, "tec9");
        }
        else if (name.StartsWith("bizon_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_bizon", StringComparison.OrdinalIgnoreCase))
        {
            return ("PP-Bizon", 26, "bizon");
        }
        else if (name.StartsWith("mag7_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_mag7", StringComparison.OrdinalIgnoreCase))
        {
            return ("MAG-7", 27, "mag7");
        }
        else if (name.StartsWith("fiveseven_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_fiveseven", StringComparison.OrdinalIgnoreCase))
        {
            return ("Five-SeveN", 3, "fiveseven");
        }
        else if (name.StartsWith("p2000_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_p2000", StringComparison.OrdinalIgnoreCase))
        {
            return ("P2000", 32, "hkp2000");
        }
        else if (name.StartsWith("sg556_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_sg556", StringComparison.OrdinalIgnoreCase))
        {
            return ("SG 553", 39, "sg556");
        }
        else if (name.StartsWith("cz_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_cz", StringComparison.OrdinalIgnoreCase))
        {
            return ("CZ75-Auto", 63, "cz75a");
        }
        else if (name.StartsWith("mp7_", StringComparison.OrdinalIgnoreCase) || name.EndsWith("_mp7", StringComparison.OrdinalIgnoreCase))
        {
            return ("MP7", 33, "mp7");
        }

        Console.WriteLine($"Weapon for \"{name}\" could not be found.");
        return (string.Empty, 0, string.Empty);
    }

    private static async Task CreateStickers()
    {
        string input =
                    """
            "7928"
            {
            	"name"		"sha2024_team_g2"
            	"item_name"		"#StickerKit_sha2024_team_g2"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/g2"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            }
            "7929"
            {
            	"name"		"sha2024_team_g2_glitter"
            	"item_name"		"#StickerKit_sha2024_team_g2_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/g2_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            }
            "7930"
            {
            	"name"		"sha2024_team_g2_holo"
            	"item_name"		"#StickerKit_sha2024_team_g2_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/g2_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            }
            "7931"
            {
            	"name"		"sha2024_team_g2_gold"
            	"item_name"		"#StickerKit_sha2024_team_g2_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/g2_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            }
            "7932"
            {
            	"name"		"sha2024_team_navi"
            	"item_name"		"#StickerKit_sha2024_team_navi"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/navi"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            }
            "7933"
            {
            	"name"		"sha2024_team_navi_glitter"
            	"item_name"		"#StickerKit_sha2024_team_navi_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/navi_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            }
            "7934"
            {
            	"name"		"sha2024_team_navi_holo"
            	"item_name"		"#StickerKit_sha2024_team_navi_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/navi_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            }
            "7935"
            {
            	"name"		"sha2024_team_navi_gold"
            	"item_name"		"#StickerKit_sha2024_team_navi_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/navi_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            }
            "7936"
            {
            	"name"		"sha2024_team_vita"
            	"item_name"		"#StickerKit_sha2024_team_vita"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/vita"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            }
            "7937"
            {
            	"name"		"sha2024_team_vita_glitter"
            	"item_name"		"#StickerKit_sha2024_team_vita_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/vita_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            }
            "7938"
            {
            	"name"		"sha2024_team_vita_holo"
            	"item_name"		"#StickerKit_sha2024_team_vita_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/vita_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            }
            "7939"
            {
            	"name"		"sha2024_team_vita_gold"
            	"item_name"		"#StickerKit_sha2024_team_vita_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/vita_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            }
            "7940"
            {
            	"name"		"sha2024_team_spir"
            	"item_name"		"#StickerKit_sha2024_team_spir"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/spir"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            }
            "7941"
            {
            	"name"		"sha2024_team_spir_glitter"
            	"item_name"		"#StickerKit_sha2024_team_spir_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/spir_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            }
            "7942"
            {
            	"name"		"sha2024_team_spir_holo"
            	"item_name"		"#StickerKit_sha2024_team_spir_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/spir_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            }
            "7943"
            {
            	"name"		"sha2024_team_spir_gold"
            	"item_name"		"#StickerKit_sha2024_team_spir_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/spir_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            }
            "7944"
            {
            	"name"		"sha2024_team_mouz"
            	"item_name"		"#StickerKit_sha2024_team_mouz"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/mouz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            }
            "7945"
            {
            	"name"		"sha2024_team_mouz_glitter"
            	"item_name"		"#StickerKit_sha2024_team_mouz_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/mouz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            }
            "7946"
            {
            	"name"		"sha2024_team_mouz_holo"
            	"item_name"		"#StickerKit_sha2024_team_mouz_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/mouz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            }
            "7947"
            {
            	"name"		"sha2024_team_mouz_gold"
            	"item_name"		"#StickerKit_sha2024_team_mouz_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/mouz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            }
            "7948"
            {
            	"name"		"sha2024_team_faze"
            	"item_name"		"#StickerKit_sha2024_team_faze"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/faze"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            }
            "7949"
            {
            	"name"		"sha2024_team_faze_glitter"
            	"item_name"		"#StickerKit_sha2024_team_faze_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/faze_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            }
            "7950"
            {
            	"name"		"sha2024_team_faze_holo"
            	"item_name"		"#StickerKit_sha2024_team_faze_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/faze_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            }
            "7951"
            {
            	"name"		"sha2024_team_faze_gold"
            	"item_name"		"#StickerKit_sha2024_team_faze_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/faze_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            }
            "7952"
            {
            	"name"		"sha2024_team_hero"
            	"item_name"		"#StickerKit_sha2024_team_hero"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/hero"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            }
            "7953"
            {
            	"name"		"sha2024_team_hero_glitter"
            	"item_name"		"#StickerKit_sha2024_team_hero_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/hero_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            }
            "7954"
            {
            	"name"		"sha2024_team_hero_holo"
            	"item_name"		"#StickerKit_sha2024_team_hero_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/hero_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            }
            "7955"
            {
            	"name"		"sha2024_team_hero_gold"
            	"item_name"		"#StickerKit_sha2024_team_hero_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/hero_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            }
            "7956"
            {
            	"name"		"sha2024_team_3dm"
            	"item_name"		"#StickerKit_sha2024_team_3dm"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/3dm"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            }
            "7957"
            {
            	"name"		"sha2024_team_3dm_glitter"
            	"item_name"		"#StickerKit_sha2024_team_3dm_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/3dm_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            }
            "7958"
            {
            	"name"		"sha2024_team_3dm_holo"
            	"item_name"		"#StickerKit_sha2024_team_3dm_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/3dm_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            }
            "7959"
            {
            	"name"		"sha2024_team_3dm_gold"
            	"item_name"		"#StickerKit_sha2024_team_3dm_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/3dm_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            }
            "7960"
            {
            	"name"		"sha2024_team_furi"
            	"item_name"		"#StickerKit_sha2024_team_furi"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/furi"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            }
            "7961"
            {
            	"name"		"sha2024_team_furi_glitter"
            	"item_name"		"#StickerKit_sha2024_team_furi_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/furi_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            }
            "7962"
            {
            	"name"		"sha2024_team_furi_holo"
            	"item_name"		"#StickerKit_sha2024_team_furi_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/furi_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            }
            "7963"
            {
            	"name"		"sha2024_team_furi_gold"
            	"item_name"		"#StickerKit_sha2024_team_furi_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/furi_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            }
            "7964"
            {
            	"name"		"sha2024_team_vp"
            	"item_name"		"#StickerKit_sha2024_team_vp"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/vp"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            }
            "7965"
            {
            	"name"		"sha2024_team_vp_glitter"
            	"item_name"		"#StickerKit_sha2024_team_vp_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/vp_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            }
            "7966"
            {
            	"name"		"sha2024_team_vp_holo"
            	"item_name"		"#StickerKit_sha2024_team_vp_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/vp_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            }
            "7967"
            {
            	"name"		"sha2024_team_vp_gold"
            	"item_name"		"#StickerKit_sha2024_team_vp_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/vp_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            }
            "7968"
            {
            	"name"		"sha2024_team_liq"
            	"item_name"		"#StickerKit_sha2024_team_liq"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/liq"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            }
            "7969"
            {
            	"name"		"sha2024_team_liq_glitter"
            	"item_name"		"#StickerKit_sha2024_team_liq_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/liq_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            }
            "7970"
            {
            	"name"		"sha2024_team_liq_holo"
            	"item_name"		"#StickerKit_sha2024_team_liq_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/liq_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            }
            "7971"
            {
            	"name"		"sha2024_team_liq_gold"
            	"item_name"		"#StickerKit_sha2024_team_liq_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/liq_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            }
            "7972"
            {
            	"name"		"sha2024_team_cplx"
            	"item_name"		"#StickerKit_sha2024_team_cplx"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/cplx"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            }
            "7973"
            {
            	"name"		"sha2024_team_cplx_glitter"
            	"item_name"		"#StickerKit_sha2024_team_cplx_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/cplx_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            }
            "7974"
            {
            	"name"		"sha2024_team_cplx_holo"
            	"item_name"		"#StickerKit_sha2024_team_cplx_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/cplx_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            }
            "7975"
            {
            	"name"		"sha2024_team_cplx_gold"
            	"item_name"		"#StickerKit_sha2024_team_cplx_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/cplx_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            }
            "7976"
            {
            	"name"		"sha2024_team_big"
            	"item_name"		"#StickerKit_sha2024_team_big"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/big"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            }
            "7977"
            {
            	"name"		"sha2024_team_big_glitter"
            	"item_name"		"#StickerKit_sha2024_team_big_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/big_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            }
            "7978"
            {
            	"name"		"sha2024_team_big_holo"
            	"item_name"		"#StickerKit_sha2024_team_big_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/big_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            }
            "7979"
            {
            	"name"		"sha2024_team_big_gold"
            	"item_name"		"#StickerKit_sha2024_team_big_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/big_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            }
            "7980"
            {
            	"name"		"sha2024_team_fntc"
            	"item_name"		"#StickerKit_sha2024_team_fntc"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/fntc"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            }
            "7981"
            {
            	"name"		"sha2024_team_fntc_glitter"
            	"item_name"		"#StickerKit_sha2024_team_fntc_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/fntc_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            }
            "7982"
            {
            	"name"		"sha2024_team_fntc_holo"
            	"item_name"		"#StickerKit_sha2024_team_fntc_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/fntc_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            }
            "7983"
            {
            	"name"		"sha2024_team_fntc_gold"
            	"item_name"		"#StickerKit_sha2024_team_fntc_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/fntc_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            }
            "7984"
            {
            	"name"		"sha2024_team_mngz"
            	"item_name"		"#StickerKit_sha2024_team_mngz"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/mngz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            }
            "7985"
            {
            	"name"		"sha2024_team_mngz_glitter"
            	"item_name"		"#StickerKit_sha2024_team_mngz_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/mngz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            }
            "7986"
            {
            	"name"		"sha2024_team_mngz_holo"
            	"item_name"		"#StickerKit_sha2024_team_mngz_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/mngz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            }
            "7987"
            {
            	"name"		"sha2024_team_mngz_gold"
            	"item_name"		"#StickerKit_sha2024_team_mngz_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/mngz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            }
            "7988"
            {
            	"name"		"sha2024_team_pain"
            	"item_name"		"#StickerKit_sha2024_team_pain"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/pain"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            }
            "7989"
            {
            	"name"		"sha2024_team_pain_glitter"
            	"item_name"		"#StickerKit_sha2024_team_pain_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/pain_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            }
            "7990"
            {
            	"name"		"sha2024_team_pain_holo"
            	"item_name"		"#StickerKit_sha2024_team_pain_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/pain_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            }
            "7991"
            {
            	"name"		"sha2024_team_pain_gold"
            	"item_name"		"#StickerKit_sha2024_team_pain_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/pain_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            }
            "7992"
            {
            	"name"		"sha2024_team_gl"
            	"item_name"		"#StickerKit_sha2024_team_gl"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/gl"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            }
            "7993"
            {
            	"name"		"sha2024_team_gl_glitter"
            	"item_name"		"#StickerKit_sha2024_team_gl_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/gl_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            }
            "7994"
            {
            	"name"		"sha2024_team_gl_holo"
            	"item_name"		"#StickerKit_sha2024_team_gl_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/gl_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            }
            "7995"
            {
            	"name"		"sha2024_team_gl_gold"
            	"item_name"		"#StickerKit_sha2024_team_gl_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/gl_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            }
            "7996"
            {
            	"name"		"sha2024_team_mibr"
            	"item_name"		"#StickerKit_sha2024_team_mibr"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/mibr"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            }
            "7997"
            {
            	"name"		"sha2024_team_mibr_glitter"
            	"item_name"		"#StickerKit_sha2024_team_mibr_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/mibr_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            }
            "7998"
            {
            	"name"		"sha2024_team_mibr_holo"
            	"item_name"		"#StickerKit_sha2024_team_mibr_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/mibr_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            }
            "7999"
            {
            	"name"		"sha2024_team_mibr_gold"
            	"item_name"		"#StickerKit_sha2024_team_mibr_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/mibr_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            }
            "8000"
            {
            	"name"		"sha2024_team_c9"
            	"item_name"		"#StickerKit_sha2024_team_c9"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/c9"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            }
            "8001"
            {
            	"name"		"sha2024_team_c9_glitter"
            	"item_name"		"#StickerKit_sha2024_team_c9_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/c9_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            }
            "8002"
            {
            	"name"		"sha2024_team_c9_holo"
            	"item_name"		"#StickerKit_sha2024_team_c9_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/c9_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            }
            "8003"
            {
            	"name"		"sha2024_team_c9_gold"
            	"item_name"		"#StickerKit_sha2024_team_c9_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/c9_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            }
            "8004"
            {
            	"name"		"sha2024_team_fq"
            	"item_name"		"#StickerKit_sha2024_team_fq"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/fq"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            }
            "8005"
            {
            	"name"		"sha2024_team_fq_glitter"
            	"item_name"		"#StickerKit_sha2024_team_fq_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/fq_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            }
            "8006"
            {
            	"name"		"sha2024_team_fq_holo"
            	"item_name"		"#StickerKit_sha2024_team_fq_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/fq_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            }
            "8007"
            {
            	"name"		"sha2024_team_fq_gold"
            	"item_name"		"#StickerKit_sha2024_team_fq_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/fq_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            }
            "8008"
            {
            	"name"		"sha2024_team_psnu"
            	"item_name"		"#StickerKit_sha2024_team_psnu"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/psnu"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            }
            "8009"
            {
            	"name"		"sha2024_team_psnu_glitter"
            	"item_name"		"#StickerKit_sha2024_team_psnu_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/psnu_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            }
            "8010"
            {
            	"name"		"sha2024_team_psnu_holo"
            	"item_name"		"#StickerKit_sha2024_team_psnu_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/psnu_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            }
            "8011"
            {
            	"name"		"sha2024_team_psnu_gold"
            	"item_name"		"#StickerKit_sha2024_team_psnu_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/psnu_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            }
            "8012"
            {
            	"name"		"sha2024_team_wcrd"
            	"item_name"		"#StickerKit_sha2024_team_wcrd"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/wcrd"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            }
            "8013"
            {
            	"name"		"sha2024_team_wcrd_glitter"
            	"item_name"		"#StickerKit_sha2024_team_wcrd_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/wcrd_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            }
            "8014"
            {
            	"name"		"sha2024_team_wcrd_holo"
            	"item_name"		"#StickerKit_sha2024_team_wcrd_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/wcrd_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            }
            "8015"
            {
            	"name"		"sha2024_team_wcrd_gold"
            	"item_name"		"#StickerKit_sha2024_team_wcrd_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/wcrd_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            }
            "8016"
            {
            	"name"		"sha2024_team_ratm"
            	"item_name"		"#StickerKit_sha2024_team_ratm"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/ratm"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            }
            "8017"
            {
            	"name"		"sha2024_team_ratm_glitter"
            	"item_name"		"#StickerKit_sha2024_team_ratm_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/ratm_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            }
            "8018"
            {
            	"name"		"sha2024_team_ratm_holo"
            	"item_name"		"#StickerKit_sha2024_team_ratm_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/ratm_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            }
            "8019"
            {
            	"name"		"sha2024_team_ratm_gold"
            	"item_name"		"#StickerKit_sha2024_team_ratm_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/ratm_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            }
            "8020"
            {
            	"name"		"sha2024_team_imp"
            	"item_name"		"#StickerKit_sha2024_team_imp"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/imp"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            }
            "8021"
            {
            	"name"		"sha2024_team_imp_glitter"
            	"item_name"		"#StickerKit_sha2024_team_imp_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/imp_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            }
            "8022"
            {
            	"name"		"sha2024_team_imp_holo"
            	"item_name"		"#StickerKit_sha2024_team_imp_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/imp_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            }
            "8023"
            {
            	"name"		"sha2024_team_imp_gold"
            	"item_name"		"#StickerKit_sha2024_team_imp_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_team"
            	"sticker_material"		"sha2024/imp_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            }
            "8024"
            {
            	"name"		"sha2024_team_pw"
            	"item_name"		"#StickerKit_sha2024_team_pw"
            	"description_string"		"#EventItemDesc_sha2024_sticker_org"
            	"sticker_material"		"sha2024/pw"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"0"
            }
            "8025"
            {
            	"name"		"sha2024_team_pw_glitter"
            	"item_name"		"#StickerKit_sha2024_team_pw_glitter"
            	"description_string"		"#EventItemDesc_sha2024_sticker_org"
            	"sticker_material"		"sha2024/pw_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"0"
            }
            "8026"
            {
            	"name"		"sha2024_team_pw_holo"
            	"item_name"		"#StickerKit_sha2024_team_pw_holo"
            	"description_string"		"#EventItemDesc_sha2024_sticker_org"
            	"sticker_material"		"sha2024/pw_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"0"
            }
            "8027"
            {
            	"name"		"sha2024_team_pw_gold"
            	"item_name"		"#StickerKit_sha2024_team_pw_gold"
            	"description_string"		"#EventItemDesc_sha2024_sticker_org"
            	"sticker_material"		"sha2024/pw_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"0"
            }
            "8028"
            {
            	"name"		"sha2024_team_g2_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_g2"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/g2_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            }
            "8029"
            {
            	"name"		"sha2024_team_navi_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_navi"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/navi_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            }
            "8030"
            {
            	"name"		"sha2024_team_vita_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_vita"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/vita_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            }
            "8031"
            {
            	"name"		"sha2024_team_spir_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_spir"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/spir_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            }
            "8032"
            {
            	"name"		"sha2024_team_mouz_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_mouz"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/mouz_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            }
            "8033"
            {
            	"name"		"sha2024_team_faze_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_faze"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/faze_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            }
            "8034"
            {
            	"name"		"sha2024_team_hero_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_hero"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/hero_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            }
            "8035"
            {
            	"name"		"sha2024_team_3dm_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_3dm"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/3dm_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            }
            "8036"
            {
            	"name"		"sha2024_team_furi_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_furi"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/furi_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            }
            "8037"
            {
            	"name"		"sha2024_team_vp_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_vp"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/vp_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            }
            "8038"
            {
            	"name"		"sha2024_team_liq_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_liq"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/liq_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            }
            "8039"
            {
            	"name"		"sha2024_team_cplx_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_cplx"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/cplx_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            }
            "8040"
            {
            	"name"		"sha2024_team_big_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_big"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/big_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            }
            "8041"
            {
            	"name"		"sha2024_team_fntc_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_fntc"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/fntc_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            }
            "8042"
            {
            	"name"		"sha2024_team_mngz_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_mngz"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/mngz_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            }
            "8043"
            {
            	"name"		"sha2024_team_pain_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_pain"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/pain_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            }
            "8044"
            {
            	"name"		"sha2024_team_gl_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_gl"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/gl_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            }
            "8045"
            {
            	"name"		"sha2024_team_mibr_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_mibr"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/mibr_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            }
            "8046"
            {
            	"name"		"sha2024_team_c9_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_c9"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/c9_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            }
            "8047"
            {
            	"name"		"sha2024_team_fq_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_fq"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/fq_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            }
            "8048"
            {
            	"name"		"sha2024_team_psnu_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_psnu"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/psnu_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            }
            "8049"
            {
            	"name"		"sha2024_team_wcrd_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_wcrd"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/wcrd_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            }
            "8050"
            {
            	"name"		"sha2024_team_ratm_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_ratm"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/ratm_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            }
            "8051"
            {
            	"name"		"sha2024_team_imp_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_imp"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_team"
            	"sticker_material"		"sha2024/imp_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            }
            "8052"
            {
            	"name"		"sha2024_team_pw_graffiti"
            	"item_name"		"#StickerKit_sha2024_team_pw"
            	"description_string"		"#EventItemDesc_sha2024_graffiti_org"
            	"sticker_material"		"sha2024/pw_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"0"
            }
            "8053"
            {
            	"name"		"sha2024_signature_snax_2"
            	"item_name"		"#StickerKit_sha2024_signature_snax"
            	"description_string"		"#StickerKit_desc_sha2024_signature_snax"
            	"sticker_material"		"sha2024/sig_snax"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"21875845"
            }
            "8054"
            {
            	"name"		"sha2024_signature_snax_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_snax_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_snax_glitter"
            	"sticker_material"		"sha2024/sig_snax_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"21875845"
            }
            "8055"
            {
            	"name"		"sha2024_signature_snax_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_snax_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_snax_holo"
            	"sticker_material"		"sha2024/sig_snax_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"21875845"
            }
            "8056"
            {
            	"name"		"sha2024_signature_snax_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_snax_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_snax_gold"
            	"sticker_material"		"sha2024/sig_snax_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"21875845"
            }
            "8057"
            {
            	"name"		"sha2024_signature_hunter_2"
            	"item_name"		"#StickerKit_sha2024_signature_hunter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_hunter"
            	"sticker_material"		"sha2024/sig_hunter"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"52606325"
            }
            "8058"
            {
            	"name"		"sha2024_signature_hunter_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_hunter_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_hunter_glitter"
            	"sticker_material"		"sha2024/sig_hunter_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"52606325"
            }
            "8059"
            {
            	"name"		"sha2024_signature_hunter_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_hunter_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_hunter_holo"
            	"sticker_material"		"sha2024/sig_hunter_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"52606325"
            }
            "8060"
            {
            	"name"		"sha2024_signature_hunter_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_hunter_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_hunter_gold"
            	"sticker_material"		"sha2024/sig_hunter_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"52606325"
            }
            "8061"
            {
            	"name"		"sha2024_signature_malbsmd_2"
            	"item_name"		"#StickerKit_sha2024_signature_malbsmd"
            	"description_string"		"#StickerKit_desc_sha2024_signature_malbsmd"
            	"sticker_material"		"sha2024/sig_malbsmd"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"120437415"
            }
            "8062"
            {
            	"name"		"sha2024_signature_malbsmd_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_malbsmd_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_malbsmd_glitter"
            	"sticker_material"		"sha2024/sig_malbsmd_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"120437415"
            }
            "8063"
            {
            	"name"		"sha2024_signature_malbsmd_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_malbsmd_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_malbsmd_holo"
            	"sticker_material"		"sha2024/sig_malbsmd_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"120437415"
            }
            "8064"
            {
            	"name"		"sha2024_signature_malbsmd_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_malbsmd_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_malbsmd_gold"
            	"sticker_material"		"sha2024/sig_malbsmd_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"120437415"
            }
            "8065"
            {
            	"name"		"sha2024_signature_m0nesy_2"
            	"item_name"		"#StickerKit_sha2024_signature_m0nesy"
            	"description_string"		"#StickerKit_desc_sha2024_signature_m0nesy"
            	"sticker_material"		"sha2024/sig_m0nesy"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"114497073"
            }
            "8066"
            {
            	"name"		"sha2024_signature_m0nesy_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_m0nesy_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_m0nesy_glitter"
            	"sticker_material"		"sha2024/sig_m0nesy_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"114497073"
            }
            "8067"
            {
            	"name"		"sha2024_signature_m0nesy_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_m0nesy_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_m0nesy_holo"
            	"sticker_material"		"sha2024/sig_m0nesy_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"114497073"
            }
            "8068"
            {
            	"name"		"sha2024_signature_m0nesy_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_m0nesy_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_m0nesy_gold"
            	"sticker_material"		"sha2024/sig_m0nesy_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"114497073"
            }
            "8069"
            {
            	"name"		"sha2024_signature_niko_2"
            	"item_name"		"#StickerKit_sha2024_signature_niko"
            	"description_string"		"#StickerKit_desc_sha2024_signature_niko"
            	"sticker_material"		"sha2024/sig_niko"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"81417650"
            }
            "8070"
            {
            	"name"		"sha2024_signature_niko_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_niko_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_niko_glitter"
            	"sticker_material"		"sha2024/sig_niko_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"81417650"
            }
            "8071"
            {
            	"name"		"sha2024_signature_niko_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_niko_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_niko_holo"
            	"sticker_material"		"sha2024/sig_niko_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"81417650"
            }
            "8072"
            {
            	"name"		"sha2024_signature_niko_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_niko_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_niko_gold"
            	"sticker_material"		"sha2024/sig_niko_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"81417650"
            }
            "8073"
            {
            	"name"		"sha2024_signature_w0nderful_2"
            	"item_name"		"#StickerKit_sha2024_signature_w0nderful"
            	"description_string"		"#StickerKit_desc_sha2024_signature_w0nderful"
            	"sticker_material"		"sha2024/sig_w0nderful"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"1102803112"
            }
            "8074"
            {
            	"name"		"sha2024_signature_w0nderful_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_w0nderful_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_w0nderful_glitter"
            	"sticker_material"		"sha2024/sig_w0nderful_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"1102803112"
            }
            "8075"
            {
            	"name"		"sha2024_signature_w0nderful_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_w0nderful_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_w0nderful_holo"
            	"sticker_material"		"sha2024/sig_w0nderful_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"1102803112"
            }
            "8076"
            {
            	"name"		"sha2024_signature_w0nderful_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_w0nderful_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_w0nderful_gold"
            	"sticker_material"		"sha2024/sig_w0nderful_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"1102803112"
            }
            "8077"
            {
            	"name"		"sha2024_signature_aleksib_2"
            	"item_name"		"#StickerKit_sha2024_signature_aleksib"
            	"description_string"		"#StickerKit_desc_sha2024_signature_aleksib"
            	"sticker_material"		"sha2024/sig_aleksib"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"52977598"
            }
            "8078"
            {
            	"name"		"sha2024_signature_aleksib_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_aleksib_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_aleksib_glitter"
            	"sticker_material"		"sha2024/sig_aleksib_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"52977598"
            }
            "8079"
            {
            	"name"		"sha2024_signature_aleksib_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_aleksib_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_aleksib_holo"
            	"sticker_material"		"sha2024/sig_aleksib_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"52977598"
            }
            "8080"
            {
            	"name"		"sha2024_signature_aleksib_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_aleksib_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_aleksib_gold"
            	"sticker_material"		"sha2024/sig_aleksib_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"52977598"
            }
            "8081"
            {
            	"name"		"sha2024_signature_jl_2"
            	"item_name"		"#StickerKit_sha2024_signature_jl"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jl"
            	"sticker_material"		"sha2024/sig_jl"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"216612575"
            }
            "8082"
            {
            	"name"		"sha2024_signature_jl_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_jl_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jl_glitter"
            	"sticker_material"		"sha2024/sig_jl_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"216612575"
            }
            "8083"
            {
            	"name"		"sha2024_signature_jl_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_jl_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jl_holo"
            	"sticker_material"		"sha2024/sig_jl_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"216612575"
            }
            "8084"
            {
            	"name"		"sha2024_signature_jl_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_jl_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jl_gold"
            	"sticker_material"		"sha2024/sig_jl_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"216612575"
            }
            "8085"
            {
            	"name"		"sha2024_signature_b1t_2"
            	"item_name"		"#StickerKit_sha2024_signature_b1t"
            	"description_string"		"#StickerKit_desc_sha2024_signature_b1t"
            	"sticker_material"		"sha2024/sig_b1t"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"286341748"
            }
            "8086"
            {
            	"name"		"sha2024_signature_b1t_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_b1t_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_b1t_glitter"
            	"sticker_material"		"sha2024/sig_b1t_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"286341748"
            }
            "8087"
            {
            	"name"		"sha2024_signature_b1t_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_b1t_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_b1t_holo"
            	"sticker_material"		"sha2024/sig_b1t_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"286341748"
            }
            "8088"
            {
            	"name"		"sha2024_signature_b1t_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_b1t_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_b1t_gold"
            	"sticker_material"		"sha2024/sig_b1t_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"286341748"
            }
            "8089"
            {
            	"name"		"sha2024_signature_im_2"
            	"item_name"		"#StickerKit_sha2024_signature_im"
            	"description_string"		"#StickerKit_desc_sha2024_signature_im"
            	"sticker_material"		"sha2024/sig_im"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"89984505"
            }
            "8090"
            {
            	"name"		"sha2024_signature_im_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_im_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_im_glitter"
            	"sticker_material"		"sha2024/sig_im_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"89984505"
            }
            "8091"
            {
            	"name"		"sha2024_signature_im_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_im_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_im_holo"
            	"sticker_material"		"sha2024/sig_im_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"89984505"
            }
            "8092"
            {
            	"name"		"sha2024_signature_im_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_im_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_im_gold"
            	"sticker_material"		"sha2024/sig_im_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"89984505"
            }
            "8093"
            {
            	"name"		"sha2024_signature_zywoo_2"
            	"item_name"		"#StickerKit_sha2024_signature_zywoo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_zywoo"
            	"sticker_material"		"sha2024/sig_zywoo"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"153400465"
            }
            "8094"
            {
            	"name"		"sha2024_signature_zywoo_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_zywoo_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_zywoo_glitter"
            	"sticker_material"		"sha2024/sig_zywoo_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"153400465"
            }
            "8095"
            {
            	"name"		"sha2024_signature_zywoo_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_zywoo_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_zywoo_holo"
            	"sticker_material"		"sha2024/sig_zywoo_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"153400465"
            }
            "8096"
            {
            	"name"		"sha2024_signature_zywoo_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_zywoo_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_zywoo_gold"
            	"sticker_material"		"sha2024/sig_zywoo_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"153400465"
            }
            "8097"
            {
            	"name"		"sha2024_signature_apex_2"
            	"item_name"		"#StickerKit_sha2024_signature_apex"
            	"description_string"		"#StickerKit_desc_sha2024_signature_apex"
            	"sticker_material"		"sha2024/sig_apex"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"29478439"
            }
            "8098"
            {
            	"name"		"sha2024_signature_apex_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_apex_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_apex_glitter"
            	"sticker_material"		"sha2024/sig_apex_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"29478439"
            }
            "8099"
            {
            	"name"		"sha2024_signature_apex_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_apex_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_apex_holo"
            	"sticker_material"		"sha2024/sig_apex_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"29478439"
            }
            "8100"
            {
            	"name"		"sha2024_signature_apex_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_apex_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_apex_gold"
            	"sticker_material"		"sha2024/sig_apex_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"29478439"
            }
            "8101"
            {
            	"name"		"sha2024_signature_mezii_2"
            	"item_name"		"#StickerKit_sha2024_signature_mezii"
            	"description_string"		"#StickerKit_desc_sha2024_signature_mezii"
            	"sticker_material"		"sha2024/sig_mezii"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"12874964"
            }
            "8102"
            {
            	"name"		"sha2024_signature_mezii_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_mezii_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_mezii_glitter"
            	"sticker_material"		"sha2024/sig_mezii_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"12874964"
            }
            "8103"
            {
            	"name"		"sha2024_signature_mezii_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_mezii_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_mezii_holo"
            	"sticker_material"		"sha2024/sig_mezii_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"12874964"
            }
            "8104"
            {
            	"name"		"sha2024_signature_mezii_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_mezii_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_mezii_gold"
            	"sticker_material"		"sha2024/sig_mezii_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"12874964"
            }
            "8105"
            {
            	"name"		"sha2024_signature_flamez_2"
            	"item_name"		"#StickerKit_sha2024_signature_flamez"
            	"description_string"		"#StickerKit_desc_sha2024_signature_flamez"
            	"sticker_material"		"sha2024/sig_flamez"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"18569432"
            }
            "8106"
            {
            	"name"		"sha2024_signature_flamez_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_flamez_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_flamez_glitter"
            	"sticker_material"		"sha2024/sig_flamez_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"18569432"
            }
            "8107"
            {
            	"name"		"sha2024_signature_flamez_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_flamez_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_flamez_holo"
            	"sticker_material"		"sha2024/sig_flamez_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"18569432"
            }
            "8108"
            {
            	"name"		"sha2024_signature_flamez_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_flamez_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_flamez_gold"
            	"sticker_material"		"sha2024/sig_flamez_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"18569432"
            }
            "8109"
            {
            	"name"		"sha2024_signature_spinx_2"
            	"item_name"		"#StickerKit_sha2024_signature_spinx"
            	"description_string"		"#StickerKit_desc_sha2024_signature_spinx"
            	"sticker_material"		"sha2024/sig_spinx"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"103070679"
            }
            "8110"
            {
            	"name"		"sha2024_signature_spinx_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_spinx_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_spinx_glitter"
            	"sticker_material"		"sha2024/sig_spinx_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"103070679"
            }
            "8111"
            {
            	"name"		"sha2024_signature_spinx_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_spinx_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_spinx_holo"
            	"sticker_material"		"sha2024/sig_spinx_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"103070679"
            }
            "8112"
            {
            	"name"		"sha2024_signature_spinx_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_spinx_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_spinx_gold"
            	"sticker_material"		"sha2024/sig_spinx_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"103070679"
            }
            "8113"
            {
            	"name"		"sha2024_signature_chopper_2"
            	"item_name"		"#StickerKit_sha2024_signature_chopper"
            	"description_string"		"#StickerKit_desc_sha2024_signature_chopper"
            	"sticker_material"		"sha2024/sig_chopper"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"85633136"
            }
            "8114"
            {
            	"name"		"sha2024_signature_chopper_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_chopper_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_chopper_glitter"
            	"sticker_material"		"sha2024/sig_chopper_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"85633136"
            }
            "8115"
            {
            	"name"		"sha2024_signature_chopper_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_chopper_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_chopper_holo"
            	"sticker_material"		"sha2024/sig_chopper_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"85633136"
            }
            "8116"
            {
            	"name"		"sha2024_signature_chopper_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_chopper_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_chopper_gold"
            	"sticker_material"		"sha2024/sig_chopper_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"85633136"
            }
            "8117"
            {
            	"name"		"sha2024_signature_magixx_2"
            	"item_name"		"#StickerKit_sha2024_signature_magixx"
            	"description_string"		"#StickerKit_desc_sha2024_signature_magixx"
            	"sticker_material"		"sha2024/sig_magixx"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"868554"
            }
            "8118"
            {
            	"name"		"sha2024_signature_magixx_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_magixx_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_magixx_glitter"
            	"sticker_material"		"sha2024/sig_magixx_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"868554"
            }
            "8119"
            {
            	"name"		"sha2024_signature_magixx_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_magixx_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_magixx_holo"
            	"sticker_material"		"sha2024/sig_magixx_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"868554"
            }
            "8120"
            {
            	"name"		"sha2024_signature_magixx_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_magixx_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_magixx_gold"
            	"sticker_material"		"sha2024/sig_magixx_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"868554"
            }
            "8121"
            {
            	"name"		"sha2024_signature_donk_2"
            	"item_name"		"#StickerKit_sha2024_signature_donk"
            	"description_string"		"#StickerKit_desc_sha2024_signature_donk"
            	"sticker_material"		"sha2024/sig_donk"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"425999755"
            }
            "8122"
            {
            	"name"		"sha2024_signature_donk_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_donk_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_donk_glitter"
            	"sticker_material"		"sha2024/sig_donk_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"425999755"
            }
            "8123"
            {
            	"name"		"sha2024_signature_donk_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_donk_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_donk_holo"
            	"sticker_material"		"sha2024/sig_donk_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"425999755"
            }
            "8124"
            {
            	"name"		"sha2024_signature_donk_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_donk_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_donk_gold"
            	"sticker_material"		"sha2024/sig_donk_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"425999755"
            }
            "8125"
            {
            	"name"		"sha2024_signature_sh1ro_2"
            	"item_name"		"#StickerKit_sha2024_signature_sh1ro"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sh1ro"
            	"sticker_material"		"sha2024/sig_sh1ro"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"121219047"
            }
            "8126"
            {
            	"name"		"sha2024_signature_sh1ro_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_sh1ro_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sh1ro_glitter"
            	"sticker_material"		"sha2024/sig_sh1ro_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"121219047"
            }
            "8127"
            {
            	"name"		"sha2024_signature_sh1ro_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_sh1ro_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sh1ro_holo"
            	"sticker_material"		"sha2024/sig_sh1ro_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"121219047"
            }
            "8128"
            {
            	"name"		"sha2024_signature_sh1ro_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_sh1ro_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sh1ro_gold"
            	"sticker_material"		"sha2024/sig_sh1ro_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"121219047"
            }
            "8129"
            {
            	"name"		"sha2024_signature_zont1x_2"
            	"item_name"		"#StickerKit_sha2024_signature_zont1x"
            	"description_string"		"#StickerKit_desc_sha2024_signature_zont1x"
            	"sticker_material"		"sha2024/sig_zont1x"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"1035615149"
            }
            "8130"
            {
            	"name"		"sha2024_signature_zont1x_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_zont1x_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_zont1x_glitter"
            	"sticker_material"		"sha2024/sig_zont1x_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"1035615149"
            }
            "8131"
            {
            	"name"		"sha2024_signature_zont1x_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_zont1x_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_zont1x_holo"
            	"sticker_material"		"sha2024/sig_zont1x_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"1035615149"
            }
            "8132"
            {
            	"name"		"sha2024_signature_zont1x_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_zont1x_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_zont1x_gold"
            	"sticker_material"		"sha2024/sig_zont1x_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"1035615149"
            }
            "8133"
            {
            	"name"		"sha2024_signature_torzsi_2"
            	"item_name"		"#StickerKit_sha2024_signature_torzsi"
            	"description_string"		"#StickerKit_desc_sha2024_signature_torzsi"
            	"sticker_material"		"sha2024/sig_torzsi"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"395473484"
            }
            "8134"
            {
            	"name"		"sha2024_signature_torzsi_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_torzsi_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_torzsi_glitter"
            	"sticker_material"		"sha2024/sig_torzsi_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"395473484"
            }
            "8135"
            {
            	"name"		"sha2024_signature_torzsi_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_torzsi_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_torzsi_holo"
            	"sticker_material"		"sha2024/sig_torzsi_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"395473484"
            }
            "8136"
            {
            	"name"		"sha2024_signature_torzsi_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_torzsi_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_torzsi_gold"
            	"sticker_material"		"sha2024/sig_torzsi_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"395473484"
            }
            "8137"
            {
            	"name"		"sha2024_signature_xertion_2"
            	"item_name"		"#StickerKit_sha2024_signature_xertion"
            	"description_string"		"#StickerKit_desc_sha2024_signature_xertion"
            	"sticker_material"		"sha2024/sig_xertion"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"232908406"
            }
            "8138"
            {
            	"name"		"sha2024_signature_xertion_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_xertion_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_xertion_glitter"
            	"sticker_material"		"sha2024/sig_xertion_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"232908406"
            }
            "8139"
            {
            	"name"		"sha2024_signature_xertion_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_xertion_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_xertion_holo"
            	"sticker_material"		"sha2024/sig_xertion_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"232908406"
            }
            "8140"
            {
            	"name"		"sha2024_signature_xertion_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_xertion_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_xertion_gold"
            	"sticker_material"		"sha2024/sig_xertion_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"232908406"
            }
            "8141"
            {
            	"name"		"sha2024_signature_brollan_2"
            	"item_name"		"#StickerKit_sha2024_signature_brollan"
            	"description_string"		"#StickerKit_desc_sha2024_signature_brollan"
            	"sticker_material"		"sha2024/sig_brollan"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"178562747"
            }
            "8142"
            {
            	"name"		"sha2024_signature_brollan_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_brollan_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_brollan_glitter"
            	"sticker_material"		"sha2024/sig_brollan_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"178562747"
            }
            "8143"
            {
            	"name"		"sha2024_signature_brollan_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_brollan_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_brollan_holo"
            	"sticker_material"		"sha2024/sig_brollan_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"178562747"
            }
            "8144"
            {
            	"name"		"sha2024_signature_brollan_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_brollan_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_brollan_gold"
            	"sticker_material"		"sha2024/sig_brollan_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"178562747"
            }
            "8145"
            {
            	"name"		"sha2024_signature_jimpphat_2"
            	"item_name"		"#StickerKit_sha2024_signature_jimpphat"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jimpphat"
            	"sticker_material"		"sha2024/sig_jimpphat"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"895109597"
            }
            "8146"
            {
            	"name"		"sha2024_signature_jimpphat_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_jimpphat_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jimpphat_glitter"
            	"sticker_material"		"sha2024/sig_jimpphat_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"895109597"
            }
            "8147"
            {
            	"name"		"sha2024_signature_jimpphat_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_jimpphat_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jimpphat_holo"
            	"sticker_material"		"sha2024/sig_jimpphat_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"895109597"
            }
            "8148"
            {
            	"name"		"sha2024_signature_jimpphat_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_jimpphat_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jimpphat_gold"
            	"sticker_material"		"sha2024/sig_jimpphat_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"895109597"
            }
            "8149"
            {
            	"name"		"sha2024_signature_siuhy_2"
            	"item_name"		"#StickerKit_sha2024_signature_siuhy"
            	"description_string"		"#StickerKit_desc_sha2024_signature_siuhy"
            	"sticker_material"		"sha2024/sig_siuhy"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"190407632"
            }
            "8150"
            {
            	"name"		"sha2024_signature_siuhy_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_siuhy_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_siuhy_glitter"
            	"sticker_material"		"sha2024/sig_siuhy_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"190407632"
            }
            "8151"
            {
            	"name"		"sha2024_signature_siuhy_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_siuhy_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_siuhy_holo"
            	"sticker_material"		"sha2024/sig_siuhy_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"190407632"
            }
            "8152"
            {
            	"name"		"sha2024_signature_siuhy_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_siuhy_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_siuhy_gold"
            	"sticker_material"		"sha2024/sig_siuhy_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"190407632"
            }
            "8153"
            {
            	"name"		"sha2024_signature_karrigan_2"
            	"item_name"		"#StickerKit_sha2024_signature_karrigan"
            	"description_string"		"#StickerKit_desc_sha2024_signature_karrigan"
            	"sticker_material"		"sha2024/sig_karrigan"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"29164525"
            }
            "8154"
            {
            	"name"		"sha2024_signature_karrigan_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_karrigan_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_karrigan_glitter"
            	"sticker_material"		"sha2024/sig_karrigan_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"29164525"
            }
            "8155"
            {
            	"name"		"sha2024_signature_karrigan_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_karrigan_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_karrigan_holo"
            	"sticker_material"		"sha2024/sig_karrigan_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"29164525"
            }
            "8156"
            {
            	"name"		"sha2024_signature_karrigan_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_karrigan_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_karrigan_gold"
            	"sticker_material"		"sha2024/sig_karrigan_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"29164525"
            }
            "8157"
            {
            	"name"		"sha2024_signature_rain_2"
            	"item_name"		"#StickerKit_sha2024_signature_rain"
            	"description_string"		"#StickerKit_desc_sha2024_signature_rain"
            	"sticker_material"		"sha2024/sig_rain"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"37085479"
            }
            "8158"
            {
            	"name"		"sha2024_signature_rain_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_rain_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_rain_glitter"
            	"sticker_material"		"sha2024/sig_rain_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"37085479"
            }
            "8159"
            {
            	"name"		"sha2024_signature_rain_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_rain_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_rain_holo"
            	"sticker_material"		"sha2024/sig_rain_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"37085479"
            }
            "8160"
            {
            	"name"		"sha2024_signature_rain_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_rain_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_rain_gold"
            	"sticker_material"		"sha2024/sig_rain_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"37085479"
            }
            "8161"
            {
            	"name"		"sha2024_signature_ropz_2"
            	"item_name"		"#StickerKit_sha2024_signature_ropz"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ropz"
            	"sticker_material"		"sha2024/sig_ropz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"31006590"
            }
            "8162"
            {
            	"name"		"sha2024_signature_ropz_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_ropz_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ropz_glitter"
            	"sticker_material"		"sha2024/sig_ropz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"31006590"
            }
            "8163"
            {
            	"name"		"sha2024_signature_ropz_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_ropz_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ropz_holo"
            	"sticker_material"		"sha2024/sig_ropz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"31006590"
            }
            "8164"
            {
            	"name"		"sha2024_signature_ropz_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_ropz_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ropz_gold"
            	"sticker_material"		"sha2024/sig_ropz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"31006590"
            }
            "8165"
            {
            	"name"		"sha2024_signature_broky_2"
            	"item_name"		"#StickerKit_sha2024_signature_broky"
            	"description_string"		"#StickerKit_desc_sha2024_signature_broky"
            	"sticker_material"		"sha2024/sig_broky"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"241354762"
            }
            "8166"
            {
            	"name"		"sha2024_signature_broky_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_broky_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_broky_glitter"
            	"sticker_material"		"sha2024/sig_broky_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"241354762"
            }
            "8167"
            {
            	"name"		"sha2024_signature_broky_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_broky_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_broky_holo"
            	"sticker_material"		"sha2024/sig_broky_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"241354762"
            }
            "8168"
            {
            	"name"		"sha2024_signature_broky_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_broky_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_broky_gold"
            	"sticker_material"		"sha2024/sig_broky_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"241354762"
            }
            "8169"
            {
            	"name"		"sha2024_signature_frozen_2"
            	"item_name"		"#StickerKit_sha2024_signature_frozen"
            	"description_string"		"#StickerKit_desc_sha2024_signature_frozen"
            	"sticker_material"		"sha2024/sig_frozen"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"108157034"
            }
            "8170"
            {
            	"name"		"sha2024_signature_frozen_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_frozen_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_frozen_glitter"
            	"sticker_material"		"sha2024/sig_frozen_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"108157034"
            }
            "8171"
            {
            	"name"		"sha2024_signature_frozen_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_frozen_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_frozen_holo"
            	"sticker_material"		"sha2024/sig_frozen_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"108157034"
            }
            "8172"
            {
            	"name"		"sha2024_signature_frozen_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_frozen_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_frozen_gold"
            	"sticker_material"		"sha2024/sig_frozen_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"108157034"
            }
            "8173"
            {
            	"name"		"sha2024_signature_teses_2"
            	"item_name"		"#StickerKit_sha2024_signature_teses"
            	"description_string"		"#StickerKit_desc_sha2024_signature_teses"
            	"sticker_material"		"sha2024/sig_teses"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"36412550"
            }
            "8174"
            {
            	"name"		"sha2024_signature_teses_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_teses_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_teses_glitter"
            	"sticker_material"		"sha2024/sig_teses_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"36412550"
            }
            "8175"
            {
            	"name"		"sha2024_signature_teses_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_teses_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_teses_holo"
            	"sticker_material"		"sha2024/sig_teses_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"36412550"
            }
            "8176"
            {
            	"name"		"sha2024_signature_teses_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_teses_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_teses_gold"
            	"sticker_material"		"sha2024/sig_teses_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"36412550"
            }
            "8177"
            {
            	"name"		"sha2024_signature_sjuush_2"
            	"item_name"		"#StickerKit_sha2024_signature_sjuush"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sjuush"
            	"sticker_material"		"sha2024/sig_sjuush"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"200443857"
            }
            "8178"
            {
            	"name"		"sha2024_signature_sjuush_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_sjuush_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sjuush_glitter"
            	"sticker_material"		"sha2024/sig_sjuush_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"200443857"
            }
            "8179"
            {
            	"name"		"sha2024_signature_sjuush_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_sjuush_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sjuush_holo"
            	"sticker_material"		"sha2024/sig_sjuush_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"200443857"
            }
            "8180"
            {
            	"name"		"sha2024_signature_sjuush_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_sjuush_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sjuush_gold"
            	"sticker_material"		"sha2024/sig_sjuush_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"200443857"
            }
            "8181"
            {
            	"name"		"sha2024_signature_kyxsan_2"
            	"item_name"		"#StickerKit_sha2024_signature_kyxsan"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kyxsan"
            	"sticker_material"		"sha2024/sig_kyxsan"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"97016704"
            }
            "8182"
            {
            	"name"		"sha2024_signature_kyxsan_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_kyxsan_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kyxsan_glitter"
            	"sticker_material"		"sha2024/sig_kyxsan_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"97016704"
            }
            "8183"
            {
            	"name"		"sha2024_signature_kyxsan_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_kyxsan_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kyxsan_holo"
            	"sticker_material"		"sha2024/sig_kyxsan_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"97016704"
            }
            "8184"
            {
            	"name"		"sha2024_signature_kyxsan_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_kyxsan_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kyxsan_gold"
            	"sticker_material"		"sha2024/sig_kyxsan_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"97016704"
            }
            "8185"
            {
            	"name"		"sha2024_signature_nertz_2"
            	"item_name"		"#StickerKit_sha2024_signature_nertz"
            	"description_string"		"#StickerKit_desc_sha2024_signature_nertz"
            	"sticker_material"		"sha2024/sig_nertz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"92860917"
            }
            "8186"
            {
            	"name"		"sha2024_signature_nertz_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_nertz_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_nertz_glitter"
            	"sticker_material"		"sha2024/sig_nertz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"92860917"
            }
            "8187"
            {
            	"name"		"sha2024_signature_nertz_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_nertz_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_nertz_holo"
            	"sticker_material"		"sha2024/sig_nertz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"92860917"
            }
            "8188"
            {
            	"name"		"sha2024_signature_nertz_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_nertz_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_nertz_gold"
            	"sticker_material"		"sha2024/sig_nertz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"92860917"
            }
            "8189"
            {
            	"name"		"sha2024_signature_degster_2"
            	"item_name"		"#StickerKit_sha2024_signature_degster"
            	"description_string"		"#StickerKit_desc_sha2024_signature_degster"
            	"sticker_material"		"sha2024/sig_degster"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"839074394"
            }
            "8190"
            {
            	"name"		"sha2024_signature_degster_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_degster_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_degster_glitter"
            	"sticker_material"		"sha2024/sig_degster_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"839074394"
            }
            "8191"
            {
            	"name"		"sha2024_signature_degster_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_degster_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_degster_holo"
            	"sticker_material"		"sha2024/sig_degster_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"839074394"
            }
            "8192"
            {
            	"name"		"sha2024_signature_degster_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_degster_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_degster_gold"
            	"sticker_material"		"sha2024/sig_degster_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"839074394"
            }
            "8193"
            {
            	"name"		"sha2024_signature_ex3rcice_2"
            	"item_name"		"#StickerKit_sha2024_signature_ex3rcice"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ex3rcice"
            	"sticker_material"		"sha2024/sig_ex3rcice"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"207932472"
            }
            "8194"
            {
            	"name"		"sha2024_signature_ex3rcice_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_ex3rcice_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ex3rcice_glitter"
            	"sticker_material"		"sha2024/sig_ex3rcice_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"207932472"
            }
            "8195"
            {
            	"name"		"sha2024_signature_ex3rcice_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_ex3rcice_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ex3rcice_holo"
            	"sticker_material"		"sha2024/sig_ex3rcice_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"207932472"
            }
            "8196"
            {
            	"name"		"sha2024_signature_ex3rcice_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_ex3rcice_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ex3rcice_gold"
            	"sticker_material"		"sha2024/sig_ex3rcice_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"207932472"
            }
            "8197"
            {
            	"name"		"sha2024_signature_djoko_2"
            	"item_name"		"#StickerKit_sha2024_signature_djoko"
            	"description_string"		"#StickerKit_desc_sha2024_signature_djoko"
            	"sticker_material"		"sha2024/sig_djoko"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"87611242"
            }
            "8198"
            {
            	"name"		"sha2024_signature_djoko_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_djoko_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_djoko_glitter"
            	"sticker_material"		"sha2024/sig_djoko_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"87611242"
            }
            "8199"
            {
            	"name"		"sha2024_signature_djoko_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_djoko_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_djoko_holo"
            	"sticker_material"		"sha2024/sig_djoko_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"87611242"
            }
            "8200"
            {
            	"name"		"sha2024_signature_djoko_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_djoko_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_djoko_gold"
            	"sticker_material"		"sha2024/sig_djoko_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"87611242"
            }
            "8201"
            {
            	"name"		"sha2024_signature_maka_2"
            	"item_name"		"#StickerKit_sha2024_signature_maka"
            	"description_string"		"#StickerKit_desc_sha2024_signature_maka"
            	"sticker_material"		"sha2024/sig_maka"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"85474033"
            }
            "8202"
            {
            	"name"		"sha2024_signature_maka_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_maka_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_maka_glitter"
            	"sticker_material"		"sha2024/sig_maka_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"85474033"
            }
            "8203"
            {
            	"name"		"sha2024_signature_maka_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_maka_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_maka_holo"
            	"sticker_material"		"sha2024/sig_maka_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"85474033"
            }
            "8204"
            {
            	"name"		"sha2024_signature_maka_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_maka_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_maka_gold"
            	"sticker_material"		"sha2024/sig_maka_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"85474033"
            }
            "8205"
            {
            	"name"		"sha2024_signature_lucky_2"
            	"item_name"		"#StickerKit_sha2024_signature_lucky"
            	"description_string"		"#StickerKit_desc_sha2024_signature_lucky"
            	"sticker_material"		"sha2024/sig_lucky"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"71624387"
            }
            "8206"
            {
            	"name"		"sha2024_signature_lucky_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_lucky_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_lucky_glitter"
            	"sticker_material"		"sha2024/sig_lucky_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"71624387"
            }
            "8207"
            {
            	"name"		"sha2024_signature_lucky_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_lucky_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_lucky_holo"
            	"sticker_material"		"sha2024/sig_lucky_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"71624387"
            }
            "8208"
            {
            	"name"		"sha2024_signature_lucky_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_lucky_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_lucky_gold"
            	"sticker_material"		"sha2024/sig_lucky_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"71624387"
            }
            "8209"
            {
            	"name"		"sha2024_signature_graviti_2"
            	"item_name"		"#StickerKit_sha2024_signature_graviti"
            	"description_string"		"#StickerKit_desc_sha2024_signature_graviti"
            	"sticker_material"		"sha2024/sig_graviti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"219272777"
            }
            "8210"
            {
            	"name"		"sha2024_signature_graviti_2_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_graviti_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_graviti_glitter"
            	"sticker_material"		"sha2024/sig_graviti_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"219272777"
            }
            "8211"
            {
            	"name"		"sha2024_signature_graviti_2_holo"
            	"item_name"		"#StickerKit_sha2024_signature_graviti_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_graviti_holo"
            	"sticker_material"		"sha2024/sig_graviti_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"219272777"
            }
            "8212"
            {
            	"name"		"sha2024_signature_graviti_2_gold"
            	"item_name"		"#StickerKit_sha2024_signature_graviti_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_graviti_gold"
            	"sticker_material"		"sha2024/sig_graviti_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"28"
            	"tournament_player_id"		"219272777"
            }
            "8213"
            {
            	"name"		"sha2024_signature_fallen_1"
            	"item_name"		"#StickerKit_sha2024_signature_fallen"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fallen"
            	"sticker_material"		"sha2024/sig_fallen"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"424467"
            }
            "8214"
            {
            	"name"		"sha2024_signature_fallen_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_fallen_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fallen_glitter"
            	"sticker_material"		"sha2024/sig_fallen_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"424467"
            }
            "8215"
            {
            	"name"		"sha2024_signature_fallen_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_fallen_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fallen_holo"
            	"sticker_material"		"sha2024/sig_fallen_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"424467"
            }
            "8216"
            {
            	"name"		"sha2024_signature_fallen_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_fallen_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fallen_gold"
            	"sticker_material"		"sha2024/sig_fallen_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"424467"
            }
            "8217"
            {
            	"name"		"sha2024_signature_chelo_1"
            	"item_name"		"#StickerKit_sha2024_signature_chelo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_chelo"
            	"sticker_material"		"sha2024/sig_chelo"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"107498100"
            }
            "8218"
            {
            	"name"		"sha2024_signature_chelo_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_chelo_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_chelo_glitter"
            	"sticker_material"		"sha2024/sig_chelo_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"107498100"
            }
            "8219"
            {
            	"name"		"sha2024_signature_chelo_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_chelo_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_chelo_holo"
            	"sticker_material"		"sha2024/sig_chelo_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"107498100"
            }
            "8220"
            {
            	"name"		"sha2024_signature_chelo_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_chelo_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_chelo_gold"
            	"sticker_material"		"sha2024/sig_chelo_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"107498100"
            }
            "8221"
            {
            	"name"		"sha2024_signature_yuurih_1"
            	"item_name"		"#StickerKit_sha2024_signature_yuurih"
            	"description_string"		"#StickerKit_desc_sha2024_signature_yuurih"
            	"sticker_material"		"sha2024/sig_yuurih"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"204704832"
            }
            "8222"
            {
            	"name"		"sha2024_signature_yuurih_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_yuurih_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_yuurih_glitter"
            	"sticker_material"		"sha2024/sig_yuurih_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"204704832"
            }
            "8223"
            {
            	"name"		"sha2024_signature_yuurih_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_yuurih_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_yuurih_holo"
            	"sticker_material"		"sha2024/sig_yuurih_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"204704832"
            }
            "8224"
            {
            	"name"		"sha2024_signature_yuurih_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_yuurih_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_yuurih_gold"
            	"sticker_material"		"sha2024/sig_yuurih_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"204704832"
            }
            "8225"
            {
            	"name"		"sha2024_signature_kscerato_1"
            	"item_name"		"#StickerKit_sha2024_signature_kscerato"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kscerato"
            	"sticker_material"		"sha2024/sig_kscerato"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"98234764"
            }
            "8226"
            {
            	"name"		"sha2024_signature_kscerato_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_kscerato_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kscerato_glitter"
            	"sticker_material"		"sha2024/sig_kscerato_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"98234764"
            }
            "8227"
            {
            	"name"		"sha2024_signature_kscerato_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_kscerato_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kscerato_holo"
            	"sticker_material"		"sha2024/sig_kscerato_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"98234764"
            }
            "8228"
            {
            	"name"		"sha2024_signature_kscerato_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_kscerato_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kscerato_gold"
            	"sticker_material"		"sha2024/sig_kscerato_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"98234764"
            }
            "8229"
            {
            	"name"		"sha2024_signature_skullz_1"
            	"item_name"		"#StickerKit_sha2024_signature_skullz"
            	"description_string"		"#StickerKit_desc_sha2024_signature_skullz"
            	"sticker_material"		"sha2024/sig_skullz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"158380916"
            }
            "8230"
            {
            	"name"		"sha2024_signature_skullz_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_skullz_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_skullz_glitter"
            	"sticker_material"		"sha2024/sig_skullz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"158380916"
            }
            "8231"
            {
            	"name"		"sha2024_signature_skullz_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_skullz_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_skullz_holo"
            	"sticker_material"		"sha2024/sig_skullz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"158380916"
            }
            "8232"
            {
            	"name"		"sha2024_signature_skullz_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_skullz_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_skullz_gold"
            	"sticker_material"		"sha2024/sig_skullz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"158380916"
            }
            "8233"
            {
            	"name"		"sha2024_signature_fl1t_1"
            	"item_name"		"#StickerKit_sha2024_signature_fl1t"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fl1t"
            	"sticker_material"		"sha2024/sig_fl1t"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"35551773"
            }
            "8234"
            {
            	"name"		"sha2024_signature_fl1t_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_fl1t_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fl1t_glitter"
            	"sticker_material"		"sha2024/sig_fl1t_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"35551773"
            }
            "8235"
            {
            	"name"		"sha2024_signature_fl1t_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_fl1t_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fl1t_holo"
            	"sticker_material"		"sha2024/sig_fl1t_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"35551773"
            }
            "8236"
            {
            	"name"		"sha2024_signature_fl1t_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_fl1t_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fl1t_gold"
            	"sticker_material"		"sha2024/sig_fl1t_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"35551773"
            }
            "8237"
            {
            	"name"		"sha2024_signature_jame_1"
            	"item_name"		"#StickerKit_sha2024_signature_jame"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jame"
            	"sticker_material"		"sha2024/sig_jame"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"75859856"
            }
            "8238"
            {
            	"name"		"sha2024_signature_jame_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_jame_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jame_glitter"
            	"sticker_material"		"sha2024/sig_jame_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"75859856"
            }
            "8239"
            {
            	"name"		"sha2024_signature_jame_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_jame_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jame_holo"
            	"sticker_material"		"sha2024/sig_jame_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"75859856"
            }
            "8240"
            {
            	"name"		"sha2024_signature_jame_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_jame_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jame_gold"
            	"sticker_material"		"sha2024/sig_jame_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"75859856"
            }
            "8241"
            {
            	"name"		"sha2024_signature_fame_1"
            	"item_name"		"#StickerKit_sha2024_signature_fame"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fame"
            	"sticker_material"		"sha2024/sig_fame"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"119848818"
            }
            "8242"
            {
            	"name"		"sha2024_signature_fame_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_fame_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fame_glitter"
            	"sticker_material"		"sha2024/sig_fame_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"119848818"
            }
            "8243"
            {
            	"name"		"sha2024_signature_fame_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_fame_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fame_holo"
            	"sticker_material"		"sha2024/sig_fame_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"119848818"
            }
            "8244"
            {
            	"name"		"sha2024_signature_fame_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_fame_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fame_gold"
            	"sticker_material"		"sha2024/sig_fame_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"119848818"
            }
            "8245"
            {
            	"name"		"sha2024_signature_n0rb3r7_1"
            	"item_name"		"#StickerKit_sha2024_signature_n0rb3r7"
            	"description_string"		"#StickerKit_desc_sha2024_signature_n0rb3r7"
            	"sticker_material"		"sha2024/sig_n0rb3r7"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"262176776"
            }
            "8246"
            {
            	"name"		"sha2024_signature_n0rb3r7_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_n0rb3r7_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_n0rb3r7_glitter"
            	"sticker_material"		"sha2024/sig_n0rb3r7_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"262176776"
            }
            "8247"
            {
            	"name"		"sha2024_signature_n0rb3r7_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_n0rb3r7_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_n0rb3r7_holo"
            	"sticker_material"		"sha2024/sig_n0rb3r7_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"262176776"
            }
            "8248"
            {
            	"name"		"sha2024_signature_n0rb3r7_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_n0rb3r7_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_n0rb3r7_gold"
            	"sticker_material"		"sha2024/sig_n0rb3r7_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"262176776"
            }
            "8249"
            {
            	"name"		"sha2024_signature_electronic_1"
            	"item_name"		"#StickerKit_sha2024_signature_electronic"
            	"description_string"		"#StickerKit_desc_sha2024_signature_electronic"
            	"sticker_material"		"sha2024/sig_electronic"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"83779379"
            }
            "8250"
            {
            	"name"		"sha2024_signature_electronic_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_electronic_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_electronic_glitter"
            	"sticker_material"		"sha2024/sig_electronic_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"83779379"
            }
            "8251"
            {
            	"name"		"sha2024_signature_electronic_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_electronic_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_electronic_holo"
            	"sticker_material"		"sha2024/sig_electronic_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"83779379"
            }
            "8252"
            {
            	"name"		"sha2024_signature_electronic_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_electronic_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_electronic_gold"
            	"sticker_material"		"sha2024/sig_electronic_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"83779379"
            }
            "8253"
            {
            	"name"		"sha2024_signature_twistzz_1"
            	"item_name"		"#StickerKit_sha2024_signature_twistzz"
            	"description_string"		"#StickerKit_desc_sha2024_signature_twistzz"
            	"sticker_material"		"sha2024/sig_twistzz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"55989477"
            }
            "8254"
            {
            	"name"		"sha2024_signature_twistzz_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_twistzz_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_twistzz_glitter"
            	"sticker_material"		"sha2024/sig_twistzz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"55989477"
            }
            "8255"
            {
            	"name"		"sha2024_signature_twistzz_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_twistzz_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_twistzz_holo"
            	"sticker_material"		"sha2024/sig_twistzz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"55989477"
            }
            "8256"
            {
            	"name"		"sha2024_signature_twistzz_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_twistzz_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_twistzz_gold"
            	"sticker_material"		"sha2024/sig_twistzz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"55989477"
            }
            "8257"
            {
            	"name"		"sha2024_signature_ultimate_1"
            	"item_name"		"#StickerKit_sha2024_signature_ultimate"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ultimate"
            	"sticker_material"		"sha2024/sig_ultimate"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"323723495"
            }
            "8258"
            {
            	"name"		"sha2024_signature_ultimate_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_ultimate_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ultimate_glitter"
            	"sticker_material"		"sha2024/sig_ultimate_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"323723495"
            }
            "8259"
            {
            	"name"		"sha2024_signature_ultimate_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_ultimate_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ultimate_holo"
            	"sticker_material"		"sha2024/sig_ultimate_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"323723495"
            }
            "8260"
            {
            	"name"		"sha2024_signature_ultimate_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_ultimate_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ultimate_gold"
            	"sticker_material"		"sha2024/sig_ultimate_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"323723495"
            }
            "8261"
            {
            	"name"		"sha2024_signature_yekindar_1"
            	"item_name"		"#StickerKit_sha2024_signature_yekindar"
            	"description_string"		"#StickerKit_desc_sha2024_signature_yekindar"
            	"sticker_material"		"sha2024/sig_yekindar"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"174136197"
            }
            "8262"
            {
            	"name"		"sha2024_signature_yekindar_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_yekindar_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_yekindar_glitter"
            	"sticker_material"		"sha2024/sig_yekindar_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"174136197"
            }
            "8263"
            {
            	"name"		"sha2024_signature_yekindar_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_yekindar_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_yekindar_holo"
            	"sticker_material"		"sha2024/sig_yekindar_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"174136197"
            }
            "8264"
            {
            	"name"		"sha2024_signature_yekindar_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_yekindar_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_yekindar_gold"
            	"sticker_material"		"sha2024/sig_yekindar_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"174136197"
            }
            "8265"
            {
            	"name"		"sha2024_signature_jks_1"
            	"item_name"		"#StickerKit_sha2024_signature_jks"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jks"
            	"sticker_material"		"sha2024/sig_jks"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"16839456"
            }
            "8266"
            {
            	"name"		"sha2024_signature_jks_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_jks_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jks_glitter"
            	"sticker_material"		"sha2024/sig_jks_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"16839456"
            }
            "8267"
            {
            	"name"		"sha2024_signature_jks_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_jks_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jks_holo"
            	"sticker_material"		"sha2024/sig_jks_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"16839456"
            }
            "8268"
            {
            	"name"		"sha2024_signature_jks_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_jks_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jks_gold"
            	"sticker_material"		"sha2024/sig_jks_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"16839456"
            }
            "8269"
            {
            	"name"		"sha2024_signature_naf_1"
            	"item_name"		"#StickerKit_sha2024_signature_naf"
            	"description_string"		"#StickerKit_desc_sha2024_signature_naf"
            	"sticker_material"		"sha2024/sig_naf"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"40885967"
            }
            "8270"
            {
            	"name"		"sha2024_signature_naf_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_naf_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_naf_glitter"
            	"sticker_material"		"sha2024/sig_naf_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"40885967"
            }
            "8271"
            {
            	"name"		"sha2024_signature_naf_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_naf_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_naf_holo"
            	"sticker_material"		"sha2024/sig_naf_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"40885967"
            }
            "8272"
            {
            	"name"		"sha2024_signature_naf_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_naf_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_naf_gold"
            	"sticker_material"		"sha2024/sig_naf_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"48"
            	"tournament_player_id"		"40885967"
            }
            "8273"
            {
            	"name"		"sha2024_signature_elige_1"
            	"item_name"		"#StickerKit_sha2024_signature_elige"
            	"description_string"		"#StickerKit_desc_sha2024_signature_elige"
            	"sticker_material"		"sha2024/sig_elige"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"106428011"
            }
            "8274"
            {
            	"name"		"sha2024_signature_elige_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_elige_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_elige_glitter"
            	"sticker_material"		"sha2024/sig_elige_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"106428011"
            }
            "8275"
            {
            	"name"		"sha2024_signature_elige_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_elige_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_elige_holo"
            	"sticker_material"		"sha2024/sig_elige_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"106428011"
            }
            "8276"
            {
            	"name"		"sha2024_signature_elige_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_elige_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_elige_gold"
            	"sticker_material"		"sha2024/sig_elige_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"106428011"
            }
            "8277"
            {
            	"name"		"sha2024_signature_floppy_1"
            	"item_name"		"#StickerKit_sha2024_signature_floppy"
            	"description_string"		"#StickerKit_desc_sha2024_signature_floppy"
            	"sticker_material"		"sha2024/sig_floppy"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"346253535"
            }
            "8278"
            {
            	"name"		"sha2024_signature_floppy_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_floppy_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_floppy_glitter"
            	"sticker_material"		"sha2024/sig_floppy_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"346253535"
            }
            "8279"
            {
            	"name"		"sha2024_signature_floppy_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_floppy_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_floppy_holo"
            	"sticker_material"		"sha2024/sig_floppy_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"346253535"
            }
            "8280"
            {
            	"name"		"sha2024_signature_floppy_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_floppy_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_floppy_gold"
            	"sticker_material"		"sha2024/sig_floppy_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"346253535"
            }
            "8281"
            {
            	"name"		"sha2024_signature_grim_1"
            	"item_name"		"#StickerKit_sha2024_signature_grim"
            	"description_string"		"#StickerKit_desc_sha2024_signature_grim"
            	"sticker_material"		"sha2024/sig_grim"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"230970467"
            }
            "8282"
            {
            	"name"		"sha2024_signature_grim_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_grim_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_grim_glitter"
            	"sticker_material"		"sha2024/sig_grim_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"230970467"
            }
            "8283"
            {
            	"name"		"sha2024_signature_grim_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_grim_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_grim_holo"
            	"sticker_material"		"sha2024/sig_grim_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"230970467"
            }
            "8284"
            {
            	"name"		"sha2024_signature_grim_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_grim_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_grim_gold"
            	"sticker_material"		"sha2024/sig_grim_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"230970467"
            }
            "8285"
            {
            	"name"		"sha2024_signature_hallzerk_1"
            	"item_name"		"#StickerKit_sha2024_signature_hallzerk"
            	"description_string"		"#StickerKit_desc_sha2024_signature_hallzerk"
            	"sticker_material"		"sha2024/sig_hallzerk"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"100101582"
            }
            "8286"
            {
            	"name"		"sha2024_signature_hallzerk_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_hallzerk_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_hallzerk_glitter"
            	"sticker_material"		"sha2024/sig_hallzerk_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"100101582"
            }
            "8287"
            {
            	"name"		"sha2024_signature_hallzerk_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_hallzerk_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_hallzerk_holo"
            	"sticker_material"		"sha2024/sig_hallzerk_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"100101582"
            }
            "8288"
            {
            	"name"		"sha2024_signature_hallzerk_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_hallzerk_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_hallzerk_gold"
            	"sticker_material"		"sha2024/sig_hallzerk_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"100101582"
            }
            "8289"
            {
            	"name"		"sha2024_signature_jt_1"
            	"item_name"		"#StickerKit_sha2024_signature_jt"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jt"
            	"sticker_material"		"sha2024/sig_jt"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"61449372"
            }
            "8290"
            {
            	"name"		"sha2024_signature_jt_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_jt_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jt_glitter"
            	"sticker_material"		"sha2024/sig_jt_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"61449372"
            }
            "8291"
            {
            	"name"		"sha2024_signature_jt_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_jt_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jt_holo"
            	"sticker_material"		"sha2024/sig_jt_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"61449372"
            }
            "8292"
            {
            	"name"		"sha2024_signature_jt_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_jt_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jt_gold"
            	"sticker_material"		"sha2024/sig_jt_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"61449372"
            }
            "8293"
            {
            	"name"		"sha2024_signature_tabsen_1"
            	"item_name"		"#StickerKit_sha2024_signature_tabsen"
            	"description_string"		"#StickerKit_desc_sha2024_signature_tabsen"
            	"sticker_material"		"sha2024/sig_tabsen"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"1225952"
            }
            "8294"
            {
            	"name"		"sha2024_signature_tabsen_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_tabsen_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_tabsen_glitter"
            	"sticker_material"		"sha2024/sig_tabsen_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"1225952"
            }
            "8295"
            {
            	"name"		"sha2024_signature_tabsen_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_tabsen_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_tabsen_holo"
            	"sticker_material"		"sha2024/sig_tabsen_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"1225952"
            }
            "8296"
            {
            	"name"		"sha2024_signature_tabsen_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_tabsen_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_tabsen_gold"
            	"sticker_material"		"sha2024/sig_tabsen_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"1225952"
            }
            "8297"
            {
            	"name"		"sha2024_signature_krimbo_1"
            	"item_name"		"#StickerKit_sha2024_signature_krimbo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_krimbo"
            	"sticker_material"		"sha2024/sig_krimbo"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"210365363"
            }
            "8298"
            {
            	"name"		"sha2024_signature_krimbo_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_krimbo_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_krimbo_glitter"
            	"sticker_material"		"sha2024/sig_krimbo_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"210365363"
            }
            "8299"
            {
            	"name"		"sha2024_signature_krimbo_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_krimbo_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_krimbo_holo"
            	"sticker_material"		"sha2024/sig_krimbo_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"210365363"
            }
            "8300"
            {
            	"name"		"sha2024_signature_krimbo_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_krimbo_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_krimbo_gold"
            	"sticker_material"		"sha2024/sig_krimbo_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"210365363"
            }
            "8301"
            {
            	"name"		"sha2024_signature_jdc_1"
            	"item_name"		"#StickerKit_sha2024_signature_jdc"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jdc"
            	"sticker_material"		"sha2024/sig_jdc"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"118505645"
            }
            "8302"
            {
            	"name"		"sha2024_signature_jdc_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_jdc_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jdc_glitter"
            	"sticker_material"		"sha2024/sig_jdc_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"118505645"
            }
            "8303"
            {
            	"name"		"sha2024_signature_jdc_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_jdc_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jdc_holo"
            	"sticker_material"		"sha2024/sig_jdc_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"118505645"
            }
            "8304"
            {
            	"name"		"sha2024_signature_jdc_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_jdc_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jdc_gold"
            	"sticker_material"		"sha2024/sig_jdc_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"118505645"
            }
            "8305"
            {
            	"name"		"sha2024_signature_syrson_1"
            	"item_name"		"#StickerKit_sha2024_signature_syrson"
            	"description_string"		"#StickerKit_desc_sha2024_signature_syrson"
            	"sticker_material"		"sha2024/sig_syrson"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"19857269"
            }
            "8306"
            {
            	"name"		"sha2024_signature_syrson_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_syrson_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_syrson_glitter"
            	"sticker_material"		"sha2024/sig_syrson_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"19857269"
            }
            "8307"
            {
            	"name"		"sha2024_signature_syrson_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_syrson_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_syrson_holo"
            	"sticker_material"		"sha2024/sig_syrson_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"19857269"
            }
            "8308"
            {
            	"name"		"sha2024_signature_syrson_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_syrson_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_syrson_gold"
            	"sticker_material"		"sha2024/sig_syrson_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"19857269"
            }
            "8309"
            {
            	"name"		"sha2024_signature_rigon_1"
            	"item_name"		"#StickerKit_sha2024_signature_rigon"
            	"description_string"		"#StickerKit_desc_sha2024_signature_rigon"
            	"sticker_material"		"sha2024/sig_rigon"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"212571293"
            }
            "8310"
            {
            	"name"		"sha2024_signature_rigon_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_rigon_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_rigon_glitter"
            	"sticker_material"		"sha2024/sig_rigon_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"212571293"
            }
            "8311"
            {
            	"name"		"sha2024_signature_rigon_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_rigon_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_rigon_holo"
            	"sticker_material"		"sha2024/sig_rigon_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"212571293"
            }
            "8312"
            {
            	"name"		"sha2024_signature_rigon_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_rigon_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_rigon_gold"
            	"sticker_material"		"sha2024/sig_rigon_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"69"
            	"tournament_player_id"		"212571293"
            }
            "8313"
            {
            	"name"		"sha2024_signature_krimz_1"
            	"item_name"		"#StickerKit_sha2024_signature_krimz"
            	"description_string"		"#StickerKit_desc_sha2024_signature_krimz"
            	"sticker_material"		"sha2024/sig_krimz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"71385856"
            }
            "8314"
            {
            	"name"		"sha2024_signature_krimz_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_krimz_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_krimz_glitter"
            	"sticker_material"		"sha2024/sig_krimz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"71385856"
            }
            "8315"
            {
            	"name"		"sha2024_signature_krimz_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_krimz_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_krimz_holo"
            	"sticker_material"		"sha2024/sig_krimz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"71385856"
            }
            "8316"
            {
            	"name"		"sha2024_signature_krimz_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_krimz_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_krimz_gold"
            	"sticker_material"		"sha2024/sig_krimz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"71385856"
            }
            "8317"
            {
            	"name"		"sha2024_signature_bodyy_1"
            	"item_name"		"#StickerKit_sha2024_signature_bodyy"
            	"description_string"		"#StickerKit_desc_sha2024_signature_bodyy"
            	"sticker_material"		"sha2024/sig_bodyy"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"53029647"
            }
            "8318"
            {
            	"name"		"sha2024_signature_bodyy_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_bodyy_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_bodyy_glitter"
            	"sticker_material"		"sha2024/sig_bodyy_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"53029647"
            }
            "8319"
            {
            	"name"		"sha2024_signature_bodyy_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_bodyy_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_bodyy_holo"
            	"sticker_material"		"sha2024/sig_bodyy_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"53029647"
            }
            "8320"
            {
            	"name"		"sha2024_signature_bodyy_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_bodyy_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_bodyy_gold"
            	"sticker_material"		"sha2024/sig_bodyy_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"53029647"
            }
            "8321"
            {
            	"name"		"sha2024_signature_matys_1"
            	"item_name"		"#StickerKit_sha2024_signature_matys"
            	"description_string"		"#StickerKit_desc_sha2024_signature_matys"
            	"sticker_material"		"sha2024/sig_matys"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"1086212773"
            }
            "8322"
            {
            	"name"		"sha2024_signature_matys_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_matys_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_matys_glitter"
            	"sticker_material"		"sha2024/sig_matys_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"1086212773"
            }
            "8323"
            {
            	"name"		"sha2024_signature_matys_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_matys_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_matys_holo"
            	"sticker_material"		"sha2024/sig_matys_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"1086212773"
            }
            "8324"
            {
            	"name"		"sha2024_signature_matys_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_matys_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_matys_gold"
            	"sticker_material"		"sha2024/sig_matys_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"1086212773"
            }
            "8325"
            {
            	"name"		"sha2024_signature_blamef_1"
            	"item_name"		"#StickerKit_sha2024_signature_blamef"
            	"description_string"		"#StickerKit_desc_sha2024_signature_blamef"
            	"sticker_material"		"sha2024/sig_blamef"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"68193075"
            }
            "8326"
            {
            	"name"		"sha2024_signature_blamef_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_blamef_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_blamef_glitter"
            	"sticker_material"		"sha2024/sig_blamef_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"68193075"
            }
            "8327"
            {
            	"name"		"sha2024_signature_blamef_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_blamef_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_blamef_holo"
            	"sticker_material"		"sha2024/sig_blamef_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"68193075"
            }
            "8328"
            {
            	"name"		"sha2024_signature_blamef_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_blamef_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_blamef_gold"
            	"sticker_material"		"sha2024/sig_blamef_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"68193075"
            }
            "8329"
            {
            	"name"		"sha2024_signature_afro_1"
            	"item_name"		"#StickerKit_sha2024_signature_afro"
            	"description_string"		"#StickerKit_desc_sha2024_signature_afro"
            	"sticker_material"		"sha2024/sig_afro"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"75315373"
            }
            "8330"
            {
            	"name"		"sha2024_signature_afro_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_afro_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_afro_glitter"
            	"sticker_material"		"sha2024/sig_afro_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"75315373"
            }
            "8331"
            {
            	"name"		"sha2024_signature_afro_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_afro_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_afro_holo"
            	"sticker_material"		"sha2024/sig_afro_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"75315373"
            }
            "8332"
            {
            	"name"		"sha2024_signature_afro_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_afro_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_afro_gold"
            	"sticker_material"		"sha2024/sig_afro_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"6"
            	"tournament_player_id"		"75315373"
            }
            "8333"
            {
            	"name"		"sha2024_signature_blitz_1"
            	"item_name"		"#StickerKit_sha2024_signature_blitz"
            	"description_string"		"#StickerKit_desc_sha2024_signature_blitz"
            	"sticker_material"		"sha2024/sig_blitz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"999558360"
            }
            "8334"
            {
            	"name"		"sha2024_signature_blitz_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_blitz_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_blitz_glitter"
            	"sticker_material"		"sha2024/sig_blitz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"999558360"
            }
            "8335"
            {
            	"name"		"sha2024_signature_blitz_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_blitz_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_blitz_holo"
            	"sticker_material"		"sha2024/sig_blitz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"999558360"
            }
            "8336"
            {
            	"name"		"sha2024_signature_blitz_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_blitz_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_blitz_gold"
            	"sticker_material"		"sha2024/sig_blitz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"999558360"
            }
            "8337"
            {
            	"name"		"sha2024_signature_910_1"
            	"item_name"		"#StickerKit_sha2024_signature_910"
            	"description_string"		"#StickerKit_desc_sha2024_signature_910"
            	"sticker_material"		"sha2024/sig_910"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1243297617"
            }
            "8338"
            {
            	"name"		"sha2024_signature_910_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_910_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_910_glitter"
            	"sticker_material"		"sha2024/sig_910_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1243297617"
            }
            "8339"
            {
            	"name"		"sha2024_signature_910_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_910_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_910_holo"
            	"sticker_material"		"sha2024/sig_910_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1243297617"
            }
            "8340"
            {
            	"name"		"sha2024_signature_910_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_910_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_910_gold"
            	"sticker_material"		"sha2024/sig_910_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1243297617"
            }
            "8341"
            {
            	"name"		"sha2024_signature_techno4k_1"
            	"item_name"		"#StickerKit_sha2024_signature_techno4k"
            	"description_string"		"#StickerKit_desc_sha2024_signature_techno4k"
            	"sticker_material"		"sha2024/sig_techno4k"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1006074432"
            }
            "8342"
            {
            	"name"		"sha2024_signature_techno4k_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_techno4k_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_techno4k_glitter"
            	"sticker_material"		"sha2024/sig_techno4k_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1006074432"
            }
            "8343"
            {
            	"name"		"sha2024_signature_techno4k_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_techno4k_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_techno4k_holo"
            	"sticker_material"		"sha2024/sig_techno4k_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1006074432"
            }
            "8344"
            {
            	"name"		"sha2024_signature_techno4k_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_techno4k_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_techno4k_gold"
            	"sticker_material"		"sha2024/sig_techno4k_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1006074432"
            }
            "8345"
            {
            	"name"		"sha2024_signature_senzu_1"
            	"item_name"		"#StickerKit_sha2024_signature_senzu"
            	"description_string"		"#StickerKit_desc_sha2024_signature_senzu"
            	"sticker_material"		"sha2024/sig_senzu"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"960454289"
            }
            "8346"
            {
            	"name"		"sha2024_signature_senzu_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_senzu_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_senzu_glitter"
            	"sticker_material"		"sha2024/sig_senzu_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"960454289"
            }
            "8347"
            {
            	"name"		"sha2024_signature_senzu_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_senzu_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_senzu_holo"
            	"sticker_material"		"sha2024/sig_senzu_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"960454289"
            }
            "8348"
            {
            	"name"		"sha2024_signature_senzu_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_senzu_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_senzu_gold"
            	"sticker_material"		"sha2024/sig_senzu_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"960454289"
            }
            "8349"
            {
            	"name"		"sha2024_signature_mzinho_1"
            	"item_name"		"#StickerKit_sha2024_signature_mzinho"
            	"description_string"		"#StickerKit_desc_sha2024_signature_mzinho"
            	"sticker_material"		"sha2024/sig_mzinho"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"878556854"
            }
            "8350"
            {
            	"name"		"sha2024_signature_mzinho_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_mzinho_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_mzinho_glitter"
            	"sticker_material"		"sha2024/sig_mzinho_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"878556854"
            }
            "8351"
            {
            	"name"		"sha2024_signature_mzinho_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_mzinho_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_mzinho_holo"
            	"sticker_material"		"sha2024/sig_mzinho_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"878556854"
            }
            "8352"
            {
            	"name"		"sha2024_signature_mzinho_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_mzinho_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_mzinho_gold"
            	"sticker_material"		"sha2024/sig_mzinho_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"878556854"
            }
            "8353"
            {
            	"name"		"sha2024_signature_biguzera_1"
            	"item_name"		"#StickerKit_sha2024_signature_biguzera"
            	"description_string"		"#StickerKit_desc_sha2024_signature_biguzera"
            	"sticker_material"		"sha2024/sig_biguzera"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"55043156"
            }
            "8354"
            {
            	"name"		"sha2024_signature_biguzera_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_biguzera_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_biguzera_glitter"
            	"sticker_material"		"sha2024/sig_biguzera_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"55043156"
            }
            "8355"
            {
            	"name"		"sha2024_signature_biguzera_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_biguzera_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_biguzera_holo"
            	"sticker_material"		"sha2024/sig_biguzera_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"55043156"
            }
            "8356"
            {
            	"name"		"sha2024_signature_biguzera_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_biguzera_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_biguzera_gold"
            	"sticker_material"		"sha2024/sig_biguzera_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"55043156"
            }
            "8357"
            {
            	"name"		"sha2024_signature_lux_1"
            	"item_name"		"#StickerKit_sha2024_signature_lux"
            	"description_string"		"#StickerKit_desc_sha2024_signature_lux"
            	"sticker_material"		"sha2024/sig_lux"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"113751940"
            }
            "8358"
            {
            	"name"		"sha2024_signature_lux_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_lux_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_lux_glitter"
            	"sticker_material"		"sha2024/sig_lux_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"113751940"
            }
            "8359"
            {
            	"name"		"sha2024_signature_lux_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_lux_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_lux_holo"
            	"sticker_material"		"sha2024/sig_lux_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"113751940"
            }
            "8360"
            {
            	"name"		"sha2024_signature_lux_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_lux_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_lux_gold"
            	"sticker_material"		"sha2024/sig_lux_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"113751940"
            }
            "8361"
            {
            	"name"		"sha2024_signature_kauez_1"
            	"item_name"		"#StickerKit_sha2024_signature_kauez"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kauez"
            	"sticker_material"		"sha2024/sig_kauez"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"425391947"
            }
            "8362"
            {
            	"name"		"sha2024_signature_kauez_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_kauez_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kauez_glitter"
            	"sticker_material"		"sha2024/sig_kauez_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"425391947"
            }
            "8363"
            {
            	"name"		"sha2024_signature_kauez_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_kauez_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kauez_holo"
            	"sticker_material"		"sha2024/sig_kauez_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"425391947"
            }
            "8364"
            {
            	"name"		"sha2024_signature_kauez_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_kauez_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kauez_gold"
            	"sticker_material"		"sha2024/sig_kauez_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"425391947"
            }
            "8365"
            {
            	"name"		"sha2024_signature_nqz_1"
            	"item_name"		"#StickerKit_sha2024_signature_nqz"
            	"description_string"		"#StickerKit_desc_sha2024_signature_nqz"
            	"sticker_material"		"sha2024/sig_nqz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"390076777"
            }
            "8366"
            {
            	"name"		"sha2024_signature_nqz_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_nqz_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_nqz_glitter"
            	"sticker_material"		"sha2024/sig_nqz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"390076777"
            }
            "8367"
            {
            	"name"		"sha2024_signature_nqz_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_nqz_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_nqz_holo"
            	"sticker_material"		"sha2024/sig_nqz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"390076777"
            }
            "8368"
            {
            	"name"		"sha2024_signature_nqz_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_nqz_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_nqz_gold"
            	"sticker_material"		"sha2024/sig_nqz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"390076777"
            }
            "8369"
            {
            	"name"		"sha2024_signature_snow_1"
            	"item_name"		"#StickerKit_sha2024_signature_snow"
            	"description_string"		"#StickerKit_desc_sha2024_signature_snow"
            	"sticker_material"		"sha2024/sig_snow"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"417070118"
            }
            "8370"
            {
            	"name"		"sha2024_signature_snow_1_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_snow_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_snow_glitter"
            	"sticker_material"		"sha2024/sig_snow_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"417070118"
            }
            "8371"
            {
            	"name"		"sha2024_signature_snow_1_holo"
            	"item_name"		"#StickerKit_sha2024_signature_snow_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_snow_holo"
            	"sticker_material"		"sha2024/sig_snow_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"417070118"
            }
            "8372"
            {
            	"name"		"sha2024_signature_snow_1_gold"
            	"item_name"		"#StickerKit_sha2024_signature_snow_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_snow_gold"
            	"sticker_material"		"sha2024/sig_snow_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"417070118"
            }
            "8373"
            {
            	"name"		"sha2024_signature_ztr_4"
            	"item_name"		"#StickerKit_sha2024_signature_ztr"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ztr"
            	"sticker_material"		"sha2024/sig_ztr"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"1049202927"
            }
            "8374"
            {
            	"name"		"sha2024_signature_ztr_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_ztr_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ztr_glitter"
            	"sticker_material"		"sha2024/sig_ztr_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"1049202927"
            }
            "8375"
            {
            	"name"		"sha2024_signature_ztr_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_ztr_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ztr_holo"
            	"sticker_material"		"sha2024/sig_ztr_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"1049202927"
            }
            "8376"
            {
            	"name"		"sha2024_signature_ztr_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_ztr_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ztr_gold"
            	"sticker_material"		"sha2024/sig_ztr_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"1049202927"
            }
            "8377"
            {
            	"name"		"sha2024_signature_sl3nd_4"
            	"item_name"		"#StickerKit_sha2024_signature_sl3nd"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sl3nd"
            	"sticker_material"		"sha2024/sig_sl3nd"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"137805965"
            }
            "8378"
            {
            	"name"		"sha2024_signature_sl3nd_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_sl3nd_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sl3nd_glitter"
            	"sticker_material"		"sha2024/sig_sl3nd_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"137805965"
            }
            "8379"
            {
            	"name"		"sha2024_signature_sl3nd_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_sl3nd_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sl3nd_holo"
            	"sticker_material"		"sha2024/sig_sl3nd_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"137805965"
            }
            "8380"
            {
            	"name"		"sha2024_signature_sl3nd_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_sl3nd_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sl3nd_gold"
            	"sticker_material"		"sha2024/sig_sl3nd_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"137805965"
            }
            "8381"
            {
            	"name"		"sha2024_signature_volt_4"
            	"item_name"		"#StickerKit_sha2024_signature_volt"
            	"description_string"		"#StickerKit_desc_sha2024_signature_volt"
            	"sticker_material"		"sha2024/sig_volt"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"195488719"
            }
            "8382"
            {
            	"name"		"sha2024_signature_volt_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_volt_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_volt_glitter"
            	"sticker_material"		"sha2024/sig_volt_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"195488719"
            }
            "8383"
            {
            	"name"		"sha2024_signature_volt_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_volt_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_volt_holo"
            	"sticker_material"		"sha2024/sig_volt_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"195488719"
            }
            "8384"
            {
            	"name"		"sha2024_signature_volt_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_volt_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_volt_gold"
            	"sticker_material"		"sha2024/sig_volt_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"195488719"
            }
            "8385"
            {
            	"name"		"sha2024_signature_fl4mus_4"
            	"item_name"		"#StickerKit_sha2024_signature_fl4mus"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fl4mus"
            	"sticker_material"		"sha2024/sig_fl4mus"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"53993406"
            }
            "8386"
            {
            	"name"		"sha2024_signature_fl4mus_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_fl4mus_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fl4mus_glitter"
            	"sticker_material"		"sha2024/sig_fl4mus_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"53993406"
            }
            "8387"
            {
            	"name"		"sha2024_signature_fl4mus_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_fl4mus_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fl4mus_holo"
            	"sticker_material"		"sha2024/sig_fl4mus_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"53993406"
            }
            "8388"
            {
            	"name"		"sha2024_signature_fl4mus_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_fl4mus_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fl4mus_gold"
            	"sticker_material"		"sha2024/sig_fl4mus_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"53993406"
            }
            "8389"
            {
            	"name"		"sha2024_signature_andu_4"
            	"item_name"		"#StickerKit_sha2024_signature_andu"
            	"description_string"		"#StickerKit_desc_sha2024_signature_andu"
            	"sticker_material"		"sha2024/sig_andu"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"258613327"
            }
            "8390"
            {
            	"name"		"sha2024_signature_andu_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_andu_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_andu_glitter"
            	"sticker_material"		"sha2024/sig_andu_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"258613327"
            }
            "8391"
            {
            	"name"		"sha2024_signature_andu_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_andu_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_andu_holo"
            	"sticker_material"		"sha2024/sig_andu_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"258613327"
            }
            "8392"
            {
            	"name"		"sha2024_signature_andu_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_andu_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_andu_gold"
            	"sticker_material"		"sha2024/sig_andu_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"258613327"
            }
            "8393"
            {
            	"name"		"sha2024_signature_drop_4"
            	"item_name"		"#StickerKit_sha2024_signature_drop"
            	"description_string"		"#StickerKit_desc_sha2024_signature_drop"
            	"sticker_material"		"sha2024/sig_drop"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"427790854"
            }
            "8394"
            {
            	"name"		"sha2024_signature_drop_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_drop_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_drop_glitter"
            	"sticker_material"		"sha2024/sig_drop_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"427790854"
            }
            "8395"
            {
            	"name"		"sha2024_signature_drop_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_drop_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_drop_holo"
            	"sticker_material"		"sha2024/sig_drop_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"427790854"
            }
            "8396"
            {
            	"name"		"sha2024_signature_drop_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_drop_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_drop_gold"
            	"sticker_material"		"sha2024/sig_drop_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"427790854"
            }
            "8397"
            {
            	"name"		"sha2024_signature_saffee_4"
            	"item_name"		"#StickerKit_sha2024_signature_saffee"
            	"description_string"		"#StickerKit_desc_sha2024_signature_saffee"
            	"sticker_material"		"sha2024/sig_saffee"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"25299957"
            }
            "8398"
            {
            	"name"		"sha2024_signature_saffee_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_saffee_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_saffee_glitter"
            	"sticker_material"		"sha2024/sig_saffee_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"25299957"
            }
            "8399"
            {
            	"name"		"sha2024_signature_saffee_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_saffee_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_saffee_holo"
            	"sticker_material"		"sha2024/sig_saffee_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"25299957"
            }
            "8400"
            {
            	"name"		"sha2024_signature_saffee_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_saffee_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_saffee_gold"
            	"sticker_material"		"sha2024/sig_saffee_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"25299957"
            }
            "8401"
            {
            	"name"		"sha2024_signature_insani_4"
            	"item_name"		"#StickerKit_sha2024_signature_insani"
            	"description_string"		"#StickerKit_desc_sha2024_signature_insani"
            	"sticker_material"		"sha2024/sig_insani"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"101158002"
            }
            "8402"
            {
            	"name"		"sha2024_signature_insani_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_insani_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_insani_glitter"
            	"sticker_material"		"sha2024/sig_insani_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"101158002"
            }
            "8403"
            {
            	"name"		"sha2024_signature_insani_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_insani_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_insani_holo"
            	"sticker_material"		"sha2024/sig_insani_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"101158002"
            }
            "8404"
            {
            	"name"		"sha2024_signature_insani_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_insani_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_insani_gold"
            	"sticker_material"		"sha2024/sig_insani_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"101158002"
            }
            "8405"
            {
            	"name"		"sha2024_signature_brnz4n_4"
            	"item_name"		"#StickerKit_sha2024_signature_brnz4n"
            	"description_string"		"#StickerKit_desc_sha2024_signature_brnz4n"
            	"sticker_material"		"sha2024/sig_brnz4n"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"895610852"
            }
            "8406"
            {
            	"name"		"sha2024_signature_brnz4n_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_brnz4n_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_brnz4n_glitter"
            	"sticker_material"		"sha2024/sig_brnz4n_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"895610852"
            }
            "8407"
            {
            	"name"		"sha2024_signature_brnz4n_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_brnz4n_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_brnz4n_holo"
            	"sticker_material"		"sha2024/sig_brnz4n_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"895610852"
            }
            "8408"
            {
            	"name"		"sha2024_signature_brnz4n_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_brnz4n_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_brnz4n_gold"
            	"sticker_material"		"sha2024/sig_brnz4n_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"895610852"
            }
            "8409"
            {
            	"name"		"sha2024_signature_exit_4"
            	"item_name"		"#StickerKit_sha2024_signature_exit"
            	"description_string"		"#StickerKit_desc_sha2024_signature_exit"
            	"sticker_material"		"sha2024/sig_exit"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"50230614"
            }
            "8410"
            {
            	"name"		"sha2024_signature_exit_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_exit_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_exit_glitter"
            	"sticker_material"		"sha2024/sig_exit_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"50230614"
            }
            "8411"
            {
            	"name"		"sha2024_signature_exit_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_exit_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_exit_holo"
            	"sticker_material"		"sha2024/sig_exit_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"50230614"
            }
            "8412"
            {
            	"name"		"sha2024_signature_exit_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_exit_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_exit_gold"
            	"sticker_material"		"sha2024/sig_exit_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"80"
            	"tournament_player_id"		"50230614"
            }
            "8413"
            {
            	"name"		"sha2024_signature_boombl4_4"
            	"item_name"		"#StickerKit_sha2024_signature_boombl4"
            	"description_string"		"#StickerKit_desc_sha2024_signature_boombl4"
            	"sticker_material"		"sha2024/sig_boombl4"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"185941338"
            }
            "8414"
            {
            	"name"		"sha2024_signature_boombl4_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_boombl4_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_boombl4_glitter"
            	"sticker_material"		"sha2024/sig_boombl4_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"185941338"
            }
            "8415"
            {
            	"name"		"sha2024_signature_boombl4_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_boombl4_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_boombl4_holo"
            	"sticker_material"		"sha2024/sig_boombl4_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"185941338"
            }
            "8416"
            {
            	"name"		"sha2024_signature_boombl4_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_boombl4_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_boombl4_gold"
            	"sticker_material"		"sha2024/sig_boombl4_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"185941338"
            }
            "8417"
            {
            	"name"		"sha2024_signature_ax1le_4"
            	"item_name"		"#StickerKit_sha2024_signature_ax1le"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ax1le"
            	"sticker_material"		"sha2024/sig_ax1le"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"85167576"
            }
            "8418"
            {
            	"name"		"sha2024_signature_ax1le_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_ax1le_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ax1le_glitter"
            	"sticker_material"		"sha2024/sig_ax1le_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"85167576"
            }
            "8419"
            {
            	"name"		"sha2024_signature_ax1le_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_ax1le_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ax1le_holo"
            	"sticker_material"		"sha2024/sig_ax1le_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"85167576"
            }
            "8420"
            {
            	"name"		"sha2024_signature_ax1le_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_ax1le_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ax1le_gold"
            	"sticker_material"		"sha2024/sig_ax1le_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"85167576"
            }
            "8421"
            {
            	"name"		"sha2024_signature_heavygod_4"
            	"item_name"		"#StickerKit_sha2024_signature_heavygod"
            	"description_string"		"#StickerKit_desc_sha2024_signature_heavygod"
            	"sticker_material"		"sha2024/sig_heavygod"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"107737265"
            }
            "8422"
            {
            	"name"		"sha2024_signature_heavygod_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_heavygod_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_heavygod_glitter"
            	"sticker_material"		"sha2024/sig_heavygod_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"107737265"
            }
            "8423"
            {
            	"name"		"sha2024_signature_heavygod_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_heavygod_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_heavygod_holo"
            	"sticker_material"		"sha2024/sig_heavygod_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"107737265"
            }
            "8424"
            {
            	"name"		"sha2024_signature_heavygod_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_heavygod_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_heavygod_gold"
            	"sticker_material"		"sha2024/sig_heavygod_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"107737265"
            }
            "8425"
            {
            	"name"		"sha2024_signature_icy_4"
            	"item_name"		"#StickerKit_sha2024_signature_icy"
            	"description_string"		"#StickerKit_desc_sha2024_signature_icy"
            	"sticker_material"		"sha2024/sig_icy"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"94843300"
            }
            "8426"
            {
            	"name"		"sha2024_signature_icy_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_icy_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_icy_glitter"
            	"sticker_material"		"sha2024/sig_icy_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"94843300"
            }
            "8427"
            {
            	"name"		"sha2024_signature_icy_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_icy_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_icy_holo"
            	"sticker_material"		"sha2024/sig_icy_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"94843300"
            }
            "8428"
            {
            	"name"		"sha2024_signature_icy_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_icy_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_icy_gold"
            	"sticker_material"		"sha2024/sig_icy_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"94843300"
            }
            "8429"
            {
            	"name"		"sha2024_signature_perfecto_4"
            	"item_name"		"#StickerKit_sha2024_signature_perfecto"
            	"description_string"		"#StickerKit_desc_sha2024_signature_perfecto"
            	"sticker_material"		"sha2024/sig_perfecto"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"160954758"
            }
            "8430"
            {
            	"name"		"sha2024_signature_perfecto_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_perfecto_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_perfecto_glitter"
            	"sticker_material"		"sha2024/sig_perfecto_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"160954758"
            }
            "8431"
            {
            	"name"		"sha2024_signature_perfecto_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_perfecto_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_perfecto_holo"
            	"sticker_material"		"sha2024/sig_perfecto_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"160954758"
            }
            "8432"
            {
            	"name"		"sha2024_signature_perfecto_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_perfecto_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_perfecto_gold"
            	"sticker_material"		"sha2024/sig_perfecto_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"160954758"
            }
            "8433"
            {
            	"name"		"sha2024_signature_dexter_4"
            	"item_name"		"#StickerKit_sha2024_signature_dexter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_dexter"
            	"sticker_material"		"sha2024/sig_dexter"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"101535513"
            }
            "8434"
            {
            	"name"		"sha2024_signature_dexter_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_dexter_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_dexter_glitter"
            	"sticker_material"		"sha2024/sig_dexter_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"101535513"
            }
            "8435"
            {
            	"name"		"sha2024_signature_dexter_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_dexter_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_dexter_holo"
            	"sticker_material"		"sha2024/sig_dexter_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"101535513"
            }
            "8436"
            {
            	"name"		"sha2024_signature_dexter_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_dexter_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_dexter_gold"
            	"sticker_material"		"sha2024/sig_dexter_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"101535513"
            }
            "8437"
            {
            	"name"		"sha2024_signature_liazz_4"
            	"item_name"		"#StickerKit_sha2024_signature_liazz"
            	"description_string"		"#StickerKit_desc_sha2024_signature_liazz"
            	"sticker_material"		"sha2024/sig_liazz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"112055988"
            }
            "8438"
            {
            	"name"		"sha2024_signature_liazz_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_liazz_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_liazz_glitter"
            	"sticker_material"		"sha2024/sig_liazz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"112055988"
            }
            "8439"
            {
            	"name"		"sha2024_signature_liazz_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_liazz_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_liazz_holo"
            	"sticker_material"		"sha2024/sig_liazz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"112055988"
            }
            "8440"
            {
            	"name"		"sha2024_signature_liazz_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_liazz_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_liazz_gold"
            	"sticker_material"		"sha2024/sig_liazz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"112055988"
            }
            "8441"
            {
            	"name"		"sha2024_signature_alistair_4"
            	"item_name"		"#StickerKit_sha2024_signature_alistair"
            	"description_string"		"#StickerKit_desc_sha2024_signature_alistair"
            	"sticker_material"		"sha2024/sig_alistair"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"138080982"
            }
            "8442"
            {
            	"name"		"sha2024_signature_alistair_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_alistair_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_alistair_glitter"
            	"sticker_material"		"sha2024/sig_alistair_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"138080982"
            }
            "8443"
            {
            	"name"		"sha2024_signature_alistair_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_alistair_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_alistair_holo"
            	"sticker_material"		"sha2024/sig_alistair_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"138080982"
            }
            "8444"
            {
            	"name"		"sha2024_signature_alistair_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_alistair_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_alistair_gold"
            	"sticker_material"		"sha2024/sig_alistair_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"138080982"
            }
            "8445"
            {
            	"name"		"sha2024_signature_ins_4"
            	"item_name"		"#StickerKit_sha2024_signature_ins"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ins"
            	"sticker_material"		"sha2024/sig_ins"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"26946895"
            }
            "8446"
            {
            	"name"		"sha2024_signature_ins_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_ins_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ins_glitter"
            	"sticker_material"		"sha2024/sig_ins_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"26946895"
            }
            "8447"
            {
            	"name"		"sha2024_signature_ins_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_ins_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ins_holo"
            	"sticker_material"		"sha2024/sig_ins_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"26946895"
            }
            "8448"
            {
            	"name"		"sha2024_signature_ins_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_ins_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_ins_gold"
            	"sticker_material"		"sha2024/sig_ins_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"26946895"
            }
            "8449"
            {
            	"name"		"sha2024_signature_vexite_4"
            	"item_name"		"#StickerKit_sha2024_signature_vexite"
            	"description_string"		"#StickerKit_desc_sha2024_signature_vexite"
            	"sticker_material"		"sha2024/sig_vexite"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"92622415"
            }
            "8450"
            {
            	"name"		"sha2024_signature_vexite_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_vexite_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_vexite_glitter"
            	"sticker_material"		"sha2024/sig_vexite_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"92622415"
            }
            "8451"
            {
            	"name"		"sha2024_signature_vexite_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_vexite_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_vexite_holo"
            	"sticker_material"		"sha2024/sig_vexite_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"92622415"
            }
            "8452"
            {
            	"name"		"sha2024_signature_vexite_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_vexite_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_vexite_gold"
            	"sticker_material"		"sha2024/sig_vexite_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"132"
            	"tournament_player_id"		"92622415"
            }
            "8453"
            {
            	"name"		"sha2024_signature_fear_4"
            	"item_name"		"#StickerKit_sha2024_signature_fear"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fear"
            	"sticker_material"		"sha2024/sig_fear"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"171760452"
            }
            "8454"
            {
            	"name"		"sha2024_signature_fear_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_fear_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fear_glitter"
            	"sticker_material"		"sha2024/sig_fear_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"171760452"
            }
            "8455"
            {
            	"name"		"sha2024_signature_fear_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_fear_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fear_holo"
            	"sticker_material"		"sha2024/sig_fear_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"171760452"
            }
            "8456"
            {
            	"name"		"sha2024_signature_fear_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_fear_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_fear_gold"
            	"sticker_material"		"sha2024/sig_fear_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"171760452"
            }
            "8457"
            {
            	"name"		"sha2024_signature_jambo_4"
            	"item_name"		"#StickerKit_sha2024_signature_jambo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jambo"
            	"sticker_material"		"sha2024/sig_jambo"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"839987798"
            }
            "8458"
            {
            	"name"		"sha2024_signature_jambo_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_jambo_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jambo_glitter"
            	"sticker_material"		"sha2024/sig_jambo_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"839987798"
            }
            "8459"
            {
            	"name"		"sha2024_signature_jambo_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_jambo_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jambo_holo"
            	"sticker_material"		"sha2024/sig_jambo_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"839987798"
            }
            "8460"
            {
            	"name"		"sha2024_signature_jambo_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_jambo_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jambo_gold"
            	"sticker_material"		"sha2024/sig_jambo_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"839987798"
            }
            "8461"
            {
            	"name"		"sha2024_signature_jackasmo_4"
            	"item_name"		"#StickerKit_sha2024_signature_jackasmo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jackasmo"
            	"sticker_material"		"sha2024/sig_jackasmo"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"486179556"
            }
            "8462"
            {
            	"name"		"sha2024_signature_jackasmo_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_jackasmo_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jackasmo_glitter"
            	"sticker_material"		"sha2024/sig_jackasmo_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"486179556"
            }
            "8463"
            {
            	"name"		"sha2024_signature_jackasmo_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_jackasmo_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jackasmo_holo"
            	"sticker_material"		"sha2024/sig_jackasmo_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"486179556"
            }
            "8464"
            {
            	"name"		"sha2024_signature_jackasmo_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_jackasmo_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jackasmo_gold"
            	"sticker_material"		"sha2024/sig_jackasmo_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"486179556"
            }
            "8465"
            {
            	"name"		"sha2024_signature_schilla_4"
            	"item_name"		"#StickerKit_sha2024_signature_schilla"
            	"description_string"		"#StickerKit_desc_sha2024_signature_schilla"
            	"sticker_material"		"sha2024/sig_schilla"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"1003776983"
            }
            "8466"
            {
            	"name"		"sha2024_signature_schilla_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_schilla_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_schilla_glitter"
            	"sticker_material"		"sha2024/sig_schilla_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"1003776983"
            }
            "8467"
            {
            	"name"		"sha2024_signature_schilla_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_schilla_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_schilla_holo"
            	"sticker_material"		"sha2024/sig_schilla_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"1003776983"
            }
            "8468"
            {
            	"name"		"sha2024_signature_schilla_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_schilla_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_schilla_gold"
            	"sticker_material"		"sha2024/sig_schilla_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"1003776983"
            }
            "8469"
            {
            	"name"		"sha2024_signature_zerrofix_4"
            	"item_name"		"#StickerKit_sha2024_signature_zerrofix"
            	"description_string"		"#StickerKit_desc_sha2024_signature_zerrofix"
            	"sticker_material"		"sha2024/sig_zerrofix"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"1160822835"
            }
            "8470"
            {
            	"name"		"sha2024_signature_zerrofix_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_zerrofix_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_zerrofix_glitter"
            	"sticker_material"		"sha2024/sig_zerrofix_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"1160822835"
            }
            "8471"
            {
            	"name"		"sha2024_signature_zerrofix_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_zerrofix_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_zerrofix_holo"
            	"sticker_material"		"sha2024/sig_zerrofix_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"1160822835"
            }
            "8472"
            {
            	"name"		"sha2024_signature_zerrofix_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_zerrofix_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_zerrofix_gold"
            	"sticker_material"		"sha2024/sig_zerrofix_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"133"
            	"tournament_player_id"		"1160822835"
            }
            "8473"
            {
            	"name"		"sha2024_signature_stanislaw_4"
            	"item_name"		"#StickerKit_sha2024_signature_stanislaw"
            	"description_string"		"#StickerKit_desc_sha2024_signature_stanislaw"
            	"sticker_material"		"sha2024/sig_stanislaw"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"21583315"
            }
            "8474"
            {
            	"name"		"sha2024_signature_stanislaw_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_stanislaw_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_stanislaw_glitter"
            	"sticker_material"		"sha2024/sig_stanislaw_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"21583315"
            }
            "8475"
            {
            	"name"		"sha2024_signature_stanislaw_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_stanislaw_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_stanislaw_holo"
            	"sticker_material"		"sha2024/sig_stanislaw_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"21583315"
            }
            "8476"
            {
            	"name"		"sha2024_signature_stanislaw_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_stanislaw_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_stanislaw_gold"
            	"sticker_material"		"sha2024/sig_stanislaw_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"21583315"
            }
            "8477"
            {
            	"name"		"sha2024_signature_sonic_4"
            	"item_name"		"#StickerKit_sha2024_signature_sonic"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sonic"
            	"sticker_material"		"sha2024/sig_sonic"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"14864123"
            }
            "8478"
            {
            	"name"		"sha2024_signature_sonic_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_sonic_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sonic_glitter"
            	"sticker_material"		"sha2024/sig_sonic_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"14864123"
            }
            "8479"
            {
            	"name"		"sha2024_signature_sonic_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_sonic_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sonic_holo"
            	"sticker_material"		"sha2024/sig_sonic_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"14864123"
            }
            "8480"
            {
            	"name"		"sha2024_signature_sonic_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_sonic_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_sonic_gold"
            	"sticker_material"		"sha2024/sig_sonic_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"14864123"
            }
            "8481"
            {
            	"name"		"sha2024_signature_jba_4"
            	"item_name"		"#StickerKit_sha2024_signature_jba"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jba"
            	"sticker_material"		"sha2024/sig_jba"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"223887847"
            }
            "8482"
            {
            	"name"		"sha2024_signature_jba_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_jba_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jba_glitter"
            	"sticker_material"		"sha2024/sig_jba_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"223887847"
            }
            "8483"
            {
            	"name"		"sha2024_signature_jba_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_jba_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jba_holo"
            	"sticker_material"		"sha2024/sig_jba_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"223887847"
            }
            "8484"
            {
            	"name"		"sha2024_signature_jba_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_jba_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_jba_gold"
            	"sticker_material"		"sha2024/sig_jba_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"223887847"
            }
            "8485"
            {
            	"name"		"sha2024_signature_phzy_4"
            	"item_name"		"#StickerKit_sha2024_signature_phzy"
            	"description_string"		"#StickerKit_desc_sha2024_signature_phzy"
            	"sticker_material"		"sha2024/sig_phzy"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"447933315"
            }
            "8486"
            {
            	"name"		"sha2024_signature_phzy_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_phzy_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_phzy_glitter"
            	"sticker_material"		"sha2024/sig_phzy_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"447933315"
            }
            "8487"
            {
            	"name"		"sha2024_signature_phzy_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_phzy_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_phzy_holo"
            	"sticker_material"		"sha2024/sig_phzy_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"447933315"
            }
            "8488"
            {
            	"name"		"sha2024_signature_phzy_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_phzy_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_phzy_gold"
            	"sticker_material"		"sha2024/sig_phzy_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"447933315"
            }
            "8489"
            {
            	"name"		"sha2024_signature_susp_4"
            	"item_name"		"#StickerKit_sha2024_signature_susp"
            	"description_string"		"#StickerKit_desc_sha2024_signature_susp"
            	"sticker_material"		"sha2024/sig_susp"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"382452440"
            }
            "8490"
            {
            	"name"		"sha2024_signature_susp_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_susp_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_susp_glitter"
            	"sticker_material"		"sha2024/sig_susp_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"382452440"
            }
            "8491"
            {
            	"name"		"sha2024_signature_susp_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_susp_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_susp_holo"
            	"sticker_material"		"sha2024/sig_susp_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"382452440"
            }
            "8492"
            {
            	"name"		"sha2024_signature_susp_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_susp_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_susp_gold"
            	"sticker_material"		"sha2024/sig_susp_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"130"
            	"tournament_player_id"		"382452440"
            }
            "8493"
            {
            	"name"		"sha2024_signature_summer_4"
            	"item_name"		"#StickerKit_sha2024_signature_summer"
            	"description_string"		"#StickerKit_desc_sha2024_signature_summer"
            	"sticker_material"		"sha2024/sig_summer"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"52964519"
            }
            "8494"
            {
            	"name"		"sha2024_signature_summer_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_summer_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_summer_glitter"
            	"sticker_material"		"sha2024/sig_summer_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"52964519"
            }
            "8495"
            {
            	"name"		"sha2024_signature_summer_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_summer_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_summer_holo"
            	"sticker_material"		"sha2024/sig_summer_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"52964519"
            }
            "8496"
            {
            	"name"		"sha2024_signature_summer_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_summer_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_summer_gold"
            	"sticker_material"		"sha2024/sig_summer_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"52964519"
            }
            "8497"
            {
            	"name"		"sha2024_signature_childking_4"
            	"item_name"		"#StickerKit_sha2024_signature_childking"
            	"description_string"		"#StickerKit_desc_sha2024_signature_childking"
            	"sticker_material"		"sha2024/sig_childking"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"392390376"
            }
            "8498"
            {
            	"name"		"sha2024_signature_childking_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_childking_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_childking_glitter"
            	"sticker_material"		"sha2024/sig_childking_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"392390376"
            }
            "8499"
            {
            	"name"		"sha2024_signature_childking_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_childking_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_childking_holo"
            	"sticker_material"		"sha2024/sig_childking_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"392390376"
            }
            "8500"
            {
            	"name"		"sha2024_signature_childking_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_childking_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_childking_gold"
            	"sticker_material"		"sha2024/sig_childking_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"392390376"
            }
            "8501"
            {
            	"name"		"sha2024_signature_somebody_4"
            	"item_name"		"#StickerKit_sha2024_signature_somebody"
            	"description_string"		"#StickerKit_desc_sha2024_signature_somebody"
            	"sticker_material"		"sha2024/sig_somebody"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"85131873"
            }
            "8502"
            {
            	"name"		"sha2024_signature_somebody_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_somebody_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_somebody_glitter"
            	"sticker_material"		"sha2024/sig_somebody_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"85131873"
            }
            "8503"
            {
            	"name"		"sha2024_signature_somebody_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_somebody_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_somebody_holo"
            	"sticker_material"		"sha2024/sig_somebody_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"85131873"
            }
            "8504"
            {
            	"name"		"sha2024_signature_somebody_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_somebody_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_somebody_gold"
            	"sticker_material"		"sha2024/sig_somebody_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"85131873"
            }
            "8505"
            {
            	"name"		"sha2024_signature_l1hang_4"
            	"item_name"		"#StickerKit_sha2024_signature_l1hang"
            	"description_string"		"#StickerKit_desc_sha2024_signature_l1hang"
            	"sticker_material"		"sha2024/sig_l1hang"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"1055940590"
            }
            "8506"
            {
            	"name"		"sha2024_signature_l1hang_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_l1hang_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_l1hang_glitter"
            	"sticker_material"		"sha2024/sig_l1hang_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"1055940590"
            }
            "8507"
            {
            	"name"		"sha2024_signature_l1hang_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_l1hang_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_l1hang_holo"
            	"sticker_material"		"sha2024/sig_l1hang_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"1055940590"
            }
            "8508"
            {
            	"name"		"sha2024_signature_l1hang_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_l1hang_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_l1hang_gold"
            	"sticker_material"		"sha2024/sig_l1hang_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"1055940590"
            }
            "8509"
            {
            	"name"		"sha2024_signature_kaze_4"
            	"item_name"		"#StickerKit_sha2024_signature_kaze"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kaze"
            	"sticker_material"		"sha2024/sig_kaze"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"16127541"
            }
            "8510"
            {
            	"name"		"sha2024_signature_kaze_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_kaze_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kaze_glitter"
            	"sticker_material"		"sha2024/sig_kaze_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"16127541"
            }
            "8511"
            {
            	"name"		"sha2024_signature_kaze_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_kaze_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kaze_holo"
            	"sticker_material"		"sha2024/sig_kaze_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"16127541"
            }
            "8512"
            {
            	"name"		"sha2024_signature_kaze_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_kaze_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_kaze_gold"
            	"sticker_material"		"sha2024/sig_kaze_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"131"
            	"tournament_player_id"		"16127541"
            }
            "8513"
            {
            	"name"		"sha2024_signature_vini_4"
            	"item_name"		"#StickerKit_sha2024_signature_vini"
            	"description_string"		"#StickerKit_desc_sha2024_signature_vini"
            	"sticker_material"		"sha2024/sig_vini"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"36104456"
            }
            "8514"
            {
            	"name"		"sha2024_signature_vini_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_vini_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_vini_glitter"
            	"sticker_material"		"sha2024/sig_vini_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"36104456"
            }
            "8515"
            {
            	"name"		"sha2024_signature_vini_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_vini_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_vini_holo"
            	"sticker_material"		"sha2024/sig_vini_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"36104456"
            }
            "8516"
            {
            	"name"		"sha2024_signature_vini_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_vini_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_vini_gold"
            	"sticker_material"		"sha2024/sig_vini_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"36104456"
            }
            "8517"
            {
            	"name"		"sha2024_signature_felps_4"
            	"item_name"		"#StickerKit_sha2024_signature_felps"
            	"description_string"		"#StickerKit_desc_sha2024_signature_felps"
            	"sticker_material"		"sha2024/sig_felps"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"22765766"
            }
            "8518"
            {
            	"name"		"sha2024_signature_felps_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_felps_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_felps_glitter"
            	"sticker_material"		"sha2024/sig_felps_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"22765766"
            }
            "8519"
            {
            	"name"		"sha2024_signature_felps_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_felps_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_felps_holo"
            	"sticker_material"		"sha2024/sig_felps_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"22765766"
            }
            "8520"
            {
            	"name"		"sha2024_signature_felps_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_felps_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_felps_gold"
            	"sticker_material"		"sha2024/sig_felps_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"22765766"
            }
            "8521"
            {
            	"name"		"sha2024_signature_try_4"
            	"item_name"		"#StickerKit_sha2024_signature_try"
            	"description_string"		"#StickerKit_desc_sha2024_signature_try"
            	"sticker_material"		"sha2024/sig_try"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"404852560"
            }
            "8522"
            {
            	"name"		"sha2024_signature_try_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_try_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_try_glitter"
            	"sticker_material"		"sha2024/sig_try_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"404852560"
            }
            "8523"
            {
            	"name"		"sha2024_signature_try_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_try_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_try_holo"
            	"sticker_material"		"sha2024/sig_try_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"404852560"
            }
            "8524"
            {
            	"name"		"sha2024_signature_try_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_try_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_try_gold"
            	"sticker_material"		"sha2024/sig_try_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"404852560"
            }
            "8525"
            {
            	"name"		"sha2024_signature_decenty_4"
            	"item_name"		"#StickerKit_sha2024_signature_decenty"
            	"description_string"		"#StickerKit_desc_sha2024_signature_decenty"
            	"sticker_material"		"sha2024/sig_decenty"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"346906182"
            }
            "8526"
            {
            	"name"		"sha2024_signature_decenty_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_decenty_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_decenty_glitter"
            	"sticker_material"		"sha2024/sig_decenty_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"346906182"
            }
            "8527"
            {
            	"name"		"sha2024_signature_decenty_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_decenty_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_decenty_holo"
            	"sticker_material"		"sha2024/sig_decenty_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"346906182"
            }
            "8528"
            {
            	"name"		"sha2024_signature_decenty_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_decenty_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_decenty_gold"
            	"sticker_material"		"sha2024/sig_decenty_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"346906182"
            }
            "8529"
            {
            	"name"		"sha2024_signature_noway_4"
            	"item_name"		"#StickerKit_sha2024_signature_noway"
            	"description_string"		"#StickerKit_desc_sha2024_signature_noway"
            	"sticker_material"		"sha2024/sig_noway"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"839943839"
            }
            "8530"
            {
            	"name"		"sha2024_signature_noway_4_glitter"
            	"item_name"		"#StickerKit_sha2024_signature_noway_glitter"
            	"description_string"		"#StickerKit_desc_sha2024_signature_noway_glitter"
            	"sticker_material"		"sha2024/sig_noway_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"839943839"
            }
            "8531"
            {
            	"name"		"sha2024_signature_noway_4_holo"
            	"item_name"		"#StickerKit_sha2024_signature_noway_holo"
            	"description_string"		"#StickerKit_desc_sha2024_signature_noway_holo"
            	"sticker_material"		"sha2024/sig_noway_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"839943839"
            }
            "8532"
            {
            	"name"		"sha2024_signature_noway_4_gold"
            	"item_name"		"#StickerKit_sha2024_signature_noway_gold"
            	"description_string"		"#StickerKit_desc_sha2024_signature_noway_gold"
            	"sticker_material"		"sha2024/sig_noway_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"23"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"839943839"
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

            
            string path = string.Empty;
            if (item.Value.sticker_material.Contains("sticker_craft"))
            {
                tournamentName = "Character Craft";
                path = "sticker_craft";
            }
            else if(item.Value.sticker_material.Contains("elemental_craft"))
            {
                tournamentName = "Elemental Craft";
                path = "elemental_craft";
            }

            string rarity = "HighGrade";

            if (name.Contains("(Glitter)"))
            {
                rarity = "Remarkable";
            }
            else if (name.Contains("(Holo)"))
            {
                rarity = "Exotic";
            }
            else if (name.Contains("(Foil)"))
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