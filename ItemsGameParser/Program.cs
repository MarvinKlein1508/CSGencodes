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
            "7879"
            {
            	"name"		"paper_t_left_hand"
            	"item_name"		"#StickerKit_sticker_craft_paper_t_left_hand"
            	"description_string"		"#StickerKit_desc_sticker_craft_paper_t_left_hand"
            	"sticker_material"		"community/sticker_craft/paper_t_left_hand"
            	"item_rarity"		"rare"
            }
            "7880"
            {
            	"name"		"foil_sunglasses"
            	"item_name"		"#StickerKit_sticker_craft_foil_sunglasses"
            	"description_string"		"#StickerKit_desc_sticker_craft_foil_sunglasses"
            	"sticker_material"		"community/sticker_craft/foil_sunglasses"
            	"item_rarity"		"legendary"
            }
            "7881"
            {
            	"name"		"foil_mustache"
            	"item_name"		"#StickerKit_sticker_craft_foil_mustache"
            	"description_string"		"#StickerKit_desc_sticker_craft_foil_mustache"
            	"sticker_material"		"community/sticker_craft/foil_mustache"
            	"item_rarity"		"legendary"
            }
            "7882"
            {
            	"name"		"paper_lightning_two"
            	"item_name"		"#StickerKit_elemental_craft_paper_lightning_two"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_lightning_two"
            	"sticker_material"		"community/elemental_craft/paper_lightning_two"
            	"item_rarity"		"rare"
            }
            "7883"
            {
            	"name"		"paper_lightning_three"
            	"item_name"		"#StickerKit_elemental_craft_paper_lightning_three"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_lightning_three"
            	"sticker_material"		"community/elemental_craft/paper_lightning_three"
            	"item_rarity"		"rare"
            }
            "7884"
            {
            	"name"		"paper_lightning_one"
            	"item_name"		"#StickerKit_elemental_craft_paper_lightning_one"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_lightning_one"
            	"sticker_material"		"community/elemental_craft/paper_lightning_one"
            	"item_rarity"		"rare"
            }
            "7885"
            {
            	"name"		"paper_flames_two"
            	"item_name"		"#StickerKit_elemental_craft_paper_flames_two"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_flames_two"
            	"sticker_material"		"community/elemental_craft/paper_flames_two"
            	"item_rarity"		"rare"
            }
            "7886"
            {
            	"name"		"paper_flames"
            	"item_name"		"#StickerKit_elemental_craft_paper_flames"
            	"description_string"		"#StickerKit_desc_elemental_craftpaper_flames"
            	"sticker_material"		"community/elemental_craft/paper_flames"
            	"item_rarity"		"rare"
            }
            "7887"
            {
            	"name"		"paper_fire_two"
            	"item_name"		"#StickerKit_elemental_craft_paper_fire_two"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_fire_two"
            	"sticker_material"		"community/elemental_craft/paper_fire_two"
            	"item_rarity"		"rare"
            }
            "7888"
            {
            	"name"		"paper_fire_three"
            	"item_name"		"#StickerKit_elemental_craft_paper_fire_three"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_fire_three"
            	"sticker_material"		"community/elemental_craft/paper_fire_three"
            	"item_rarity"		"rare"
            }
            "7891"
            {
            	"name"		"paper_fire_one"
            	"item_name"		"#StickerKit_elemental_craft_paper_fire_one"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_fire_one"
            	"sticker_material"		"community/elemental_craft/paper_fire_one"
            	"item_rarity"		"rare"
            }
            "7892"
            {
            	"name"		"paper_explosion_two"
            	"item_name"		"#StickerKit_elemental_craft_paper_explosion_two"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_explosion_two"
            	"sticker_material"		"community/elemental_craft/paper_explosion_two"
            	"item_rarity"		"rare"
            }
            "7893"
            {
            	"name"		"paper_explosion_three"
            	"item_name"		"#StickerKit_elemental_craft_paper_explosion_three"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_explosion_three"
            	"sticker_material"		"community/elemental_craft/paper_explosion_three"
            	"item_rarity"		"rare"
            }
            "7894"
            {
            	"name"		"paper_explosion_one"
            	"item_name"		"#StickerKit_elemental_craft_paper_explosion_one"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_explosion_one"
            	"sticker_material"		"community/elemental_craft/paper_explosion_one"
            	"item_rarity"		"rare"
            }
            "7895"
            {
            	"name"		"paper_explosion_four"
            	"item_name"		"#StickerKit_elemental_craft_paper_explosion_four"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_explosion_four"
            	"sticker_material"		"community/elemental_craft/paper_explosion_four"
            	"item_rarity"		"rare"
            }
            "7896"
            {
            	"name"		"holo_rainbow_trail"
            	"item_name"		"#StickerKit_elemental_craft_holo_rainbow_trail"
            	"description_string"		"#StickerKit_desc_elemental_craft_holo_rainbow_trail"
            	"sticker_material"		"community/elemental_craft/holo_rainbow_trail"
            	"item_rarity"		"mythical"
            }
            "7897"
            {
            	"name"		"glitter_explosion_two"
            	"item_name"		"#StickerKit_elemental_craft_glitter_explosion_two"
            	"description_string"		"#StickerKit_desc_elemental_craft_glitter_explosion_two"
            	"sticker_material"		"community/elemental_craft/glitter_explosion_two"
            	"item_rarity"		"mythical"
            }
            "7898"
            {
            	"name"		"glitter_explosion_three"
            	"item_name"		"#StickerKit_elemental_craft_glitter_explosion_three"
            	"description_string"		"#StickerKit_desc_elemental_craft_glitter_explosion_three"
            	"sticker_material"		"community/elemental_craft/glitter_explosion_three"
            	"item_rarity"		"mythical"
            }
            "7899"
            {
            	"name"		"glitter_explosion_one"
            	"item_name"		"#StickerKit_elemental_craft_glitter_explosion_one"
            	"description_string"		"#StickerKit_desc_elemental_craft_glitter_explosion_one"
            	"sticker_material"		"community/elemental_craft/glitter_explosion_one"
            	"item_rarity"		"mythical"
            }
            "7900"
            {
            	"name"		"glitter_explosion_four"
            	"item_name"		"#StickerKit_elemental_craft_glitter_explosion_four"
            	"description_string"		"#StickerKit_desc_elemental_craft_glitter_explosion_four"
            	"sticker_material"		"community/elemental_craft/glitter_explosion_four"
            	"item_rarity"		"mythical"
            }
            "7901"
            {
            	"name"		"foil_lightning_two"
            	"item_name"		"#StickerKit_elemental_craft_foil_lightning_two"
            	"description_string"		"#StickerKit_desc_elemental_craft_foil_lightning_two"
            	"sticker_material"		"community/elemental_craft/foil_lightning_two"
            	"item_rarity"		"legendary"
            }
            "7902"
            {
            	"name"		"foil_lightning_three"
            	"item_name"		"#StickerKit_elemental_craft_foil_lightning_three"
            	"description_string"		"#StickerKit_desc_elemental_craft_foil_lightning_three"
            	"sticker_material"		"community/elemental_craft/foil_lightning_three"
            	"item_rarity"		"legendary"
            }
            "7903"
            {
            	"name"		"foil_lightning_one"
            	"item_name"		"#StickerKit_elemental_craft_foil_lightning_one"
            	"description_string"		"#StickerKit_desc_elemental_craft_foil_lightning_one"
            	"sticker_material"		"community/elemental_craft/foil_lightning_one"
            	"item_rarity"		"legendary"
            }
            "7904"
            {
            	"name"		"foil_fire_three"
            	"item_name"		"#StickerKit_elemental_craft_foil_fire_three"
            	"description_string"		"#StickerKit_desc_elemental_craft_foil_fire_three"
            	"sticker_material"		"community/elemental_craft/foil_fire_three"
            	"item_rarity"		"legendary"
            }
            "7905"
            {
            	"name"		"paper_arm_flex"
            	"item_name"		"#StickerKit_sticker_craft_paper_arm_flex"
            	"description_string"		"#StickerKit_desc_sticker_craft_paper_arm_flex"
            	"sticker_material"		"community/sticker_craft/paper_arm_flex"
            	"item_rarity"		"rare"
            }
            "7906"
            {
            	"name"		"paper_clown_nose"
            	"item_name"		"#StickerKit_sticker_craft_paper_clown_nose"
            	"description_string"		"#StickerKit_desc_sticker_craft_paper_clown_nose"
            	"sticker_material"		"community/sticker_craft/paper_clown_nose"
            	"item_rarity"		"rare"
            }
            "7907"
            {
            	"name"		"paper_clown_wig"
            	"item_name"		"#StickerKit_sticker_craft_paper_clown_wig"
            	"description_string"		"#StickerKit_desc_sticker_craft_paper_clown_wig"
            	"sticker_material"		"community/sticker_craft/paper_clown_wig"
            	"item_rarity"		"rare"
            }
            "7909"
            {
            	"name"		"paper_googly_eye_small"
            	"item_name"		"#StickerKit_sticker_craft_paper_googly_eye_small"
            	"description_string"		"#StickerKit_desc_sticker_craft_paper_googly_eye_small"
            	"sticker_material"		"community/sticker_craft/paper_googly_eye_small"
            	"item_rarity"		"rare"
            }
            "7910"
            {
            	"name"		"paper_mouth"
            	"item_name"		"#StickerKit_sticker_craft_paper_mouth"
            	"description_string"		"#StickerKit_desc_sticker_craft_paper_mouth"
            	"sticker_material"		"community/sticker_craft/paper_mouth"
            	"item_rarity"		"rare"
            }
            "7911"
            {
            	"name"		"paper_ribbon"
            	"item_name"		"#StickerKit_sticker_craft_paper_ribbon"
            	"description_string"		"#StickerKit_desc_sticker_craft_paper_ribbon"
            	"sticker_material"		"community/sticker_craft/paper_ribbon"
            	"item_rarity"		"rare"
            }
            "7912"
            {
            	"name"		"paper_tongue"
            	"item_name"		"#StickerKit_sticker_craft_paper_tongue"
            	"description_string"		"#StickerKit_desc_sticker_craft_paper_tongue"
            	"sticker_material"		"community/sticker_craft/paper_tongue"
            	"item_rarity"		"rare"
            }
            "7913"
            {
            	"name"		"glitter_kawaii_eyes"
            	"item_name"		"#StickerKit_sticker_craft_glitter_kawaii_eyes"
            	"description_string"		"#StickerKit_desc_sticker_craft_glitter_kawaii_eyes"
            	"sticker_material"		"community/sticker_craft/glitter_kawaii_eyes"
            	"item_rarity"		"mythical"
            }
            "7914"
            {
            	"name"		"glitter_tentacle"
            	"item_name"		"#StickerKit_sticker_craft_glitter_tentacle"
            	"description_string"		"#StickerKit_desc_sticker_craft_glitter_tentacle"
            	"sticker_material"		"community/sticker_craft/glitter_tentacle"
            	"item_rarity"		"mythical"
            }
            "7915"
            {
            	"name"		"holo_mouth"
            	"item_name"		"#StickerKit_sticker_craft_holo_mouth"
            	"description_string"		"#StickerKit_desc_sticker_craft_holo_mouth"
            	"sticker_material"		"community/sticker_craft/holo_mouth"
            	"item_rarity"		"mythical"
            }
            "7916"
            {
            	"name"		"holo_tongue"
            	"item_name"		"#StickerKit_sticker_craft_holo_tongue"
            	"description_string"		"#StickerKit_desc_sticker_craft_holo_tongue"
            	"sticker_material"		"community/sticker_craft/holo_tongue"
            	"item_rarity"		"mythical"
            }
            "7917"
            {
            	"name"		"foil_mouth"
            	"item_name"		"#StickerKit_sticker_craft_foil_mouth"
            	"description_string"		"#StickerKit_desc_sticker_craft_foil_mouth"
            	"sticker_material"		"community/sticker_craft/foil_mouth"
            	"item_rarity"		"legendary"
            }
            "7918"
            {
            	"name"		"lenticular_cheeky_eyes"
            	"item_name"		"#StickerKit_sticker_craft_lenticular_cheeky_eyes"
            	"description_string"		"#StickerKit_desc_sticker_craft_lenticular_cheeky_eyes"
            	"sticker_material"		"community/sticker_craft/lenticular_cheeky_eyes"
            	"item_rarity"		"ancient"
            }
            "7919"
            {
            	"name"		"lenticular_googly_eye"
            	"item_name"		"#StickerKit_sticker_craft_lenticular_googly_eye"
            	"description_string"		"#StickerKit_desc_sticker_craft_lenticular_googly_eye"
            	"sticker_material"		"community/sticker_craft/lenticular_googly_eye"
            	"item_rarity"		"ancient"
            }
            "7921"
            {
            	"name"		"lenticular_angry_eyes"
            	"item_name"		"#StickerKit_sticker_craft_lenticular_angry_eyes"
            	"description_string"		"#StickerKit_desc_sticker_craft_lenticular_angry_eyes"
            	"sticker_material"		"community/sticker_craft/lenticular_angry_eyes"
            	"item_rarity"		"mythical"
            }
            "7922"
            {
            	"name"		"paper_water_two"
            	"item_name"		"#StickerKit_elemental_craft_paper_water_two"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_water_two"
            	"sticker_material"		"community/elemental_craft/paper_water_two"
            	"item_rarity"		"rare"
            }
            "7923"
            {
            	"name"		"paper_water_three"
            	"item_name"		"#StickerKit_elemental_craft_paper_water_three"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_water_three"
            	"sticker_material"		"community/elemental_craft/paper_water_three"
            	"item_rarity"		"rare"
            }
            "7924"
            {
            	"name"		"paper_water_one"
            	"item_name"		"#StickerKit_elemental_craft_paper_water_one"
            	"description_string"		"#StickerKit_desc_elemental_craft_paper_water_one"
            	"sticker_material"		"community/elemental_craft/paper_water_one"
            	"item_rarity"		"rare"
            }
            "7925"
            {
            	"name"		"lenticular_blood_one"
            	"item_name"		"#StickerKit_elemental_craft_lenticular_blood_one"
            	"description_string"		"#StickerKit_descelemental_craft__lenticular_blood_one"
            	"sticker_material"		"community/elemental_craft/lenticular_blood_one"
            	"item_rarity"		"ancient"
            }
            "7926"
            {
            	"name"		"lenticular_blood_two"
            	"item_name"		"#StickerKit_elemental_craft_lenticular_blood_two"
            	"description_string"		"#StickerKit_desc_elemental_craft_lenticular_blood_two"
            	"sticker_material"		"community/elemental_craft/lenticular_blood_two"
            	"item_rarity"		"ancient"
            }
            "7927"
            {
            	"name"		"paper_male_anime_face"
            	"item_name"		"#StickerKit_sticker_craft_paper_male_anime_face"
            	"description_string"		"#StickerKit_desc_sticker_craft_paper_male_anime_face"
            	"sticker_material"		"community/sticker_craft/paper_male_anime_face"
            	"item_rarity"		"rare"
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