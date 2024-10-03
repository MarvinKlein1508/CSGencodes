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
        await CreateCollections();
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
            "7254"
            {
            	"name"		"cph2024_team_navi"
            	"item_name"		"#StickerKit_cph2024_team_navi"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/navi"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            }
            "7255"
            {
            	"name"		"cph2024_team_navi_glitter"
            	"item_name"		"#StickerKit_cph2024_team_navi_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/navi_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            }
            "7256"
            {
            	"name"		"cph2024_team_navi_holo"
            	"item_name"		"#StickerKit_cph2024_team_navi_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/navi_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            }
            "7257"
            {
            	"name"		"cph2024_team_navi_gold"
            	"item_name"		"#StickerKit_cph2024_team_navi_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/navi_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            }
            "7258"
            {
            	"name"		"cph2024_team_vp"
            	"item_name"		"#StickerKit_cph2024_team_vp"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/vp"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            }
            "7259"
            {
            	"name"		"cph2024_team_vp_glitter"
            	"item_name"		"#StickerKit_cph2024_team_vp_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/vp_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            }
            "7260"
            {
            	"name"		"cph2024_team_vp_holo"
            	"item_name"		"#StickerKit_cph2024_team_vp_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/vp_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            }
            "7261"
            {
            	"name"		"cph2024_team_vp_gold"
            	"item_name"		"#StickerKit_cph2024_team_vp_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/vp_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            }
            "7262"
            {
            	"name"		"cph2024_team_g2"
            	"item_name"		"#StickerKit_cph2024_team_g2"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/g2"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            }
            "7263"
            {
            	"name"		"cph2024_team_g2_glitter"
            	"item_name"		"#StickerKit_cph2024_team_g2_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/g2_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            }
            "7264"
            {
            	"name"		"cph2024_team_g2_holo"
            	"item_name"		"#StickerKit_cph2024_team_g2_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/g2_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            }
            "7265"
            {
            	"name"		"cph2024_team_g2_gold"
            	"item_name"		"#StickerKit_cph2024_team_g2_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/g2_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            }
            "7266"
            {
            	"name"		"cph2024_team_faze"
            	"item_name"		"#StickerKit_cph2024_team_faze"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/faze"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            }
            "7267"
            {
            	"name"		"cph2024_team_faze_glitter"
            	"item_name"		"#StickerKit_cph2024_team_faze_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/faze_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            }
            "7268"
            {
            	"name"		"cph2024_team_faze_holo"
            	"item_name"		"#StickerKit_cph2024_team_faze_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/faze_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            }
            "7269"
            {
            	"name"		"cph2024_team_faze_gold"
            	"item_name"		"#StickerKit_cph2024_team_faze_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/faze_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            }
            "7270"
            {
            	"name"		"cph2024_team_spir"
            	"item_name"		"#StickerKit_cph2024_team_spir"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/spir"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            }
            "7271"
            {
            	"name"		"cph2024_team_spir_glitter"
            	"item_name"		"#StickerKit_cph2024_team_spir_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/spir_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            }
            "7272"
            {
            	"name"		"cph2024_team_spir_holo"
            	"item_name"		"#StickerKit_cph2024_team_spir_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/spir_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            }
            "7273"
            {
            	"name"		"cph2024_team_spir_gold"
            	"item_name"		"#StickerKit_cph2024_team_spir_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/spir_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            }
            "7274"
            {
            	"name"		"cph2024_team_vita"
            	"item_name"		"#StickerKit_cph2024_team_vita"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/vita"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            }
            "7275"
            {
            	"name"		"cph2024_team_vita_glitter"
            	"item_name"		"#StickerKit_cph2024_team_vita_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/vita_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            }
            "7276"
            {
            	"name"		"cph2024_team_vita_holo"
            	"item_name"		"#StickerKit_cph2024_team_vita_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/vita_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            }
            "7277"
            {
            	"name"		"cph2024_team_vita_gold"
            	"item_name"		"#StickerKit_cph2024_team_vita_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/vita_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            }
            "7278"
            {
            	"name"		"cph2024_team_mouz"
            	"item_name"		"#StickerKit_cph2024_team_mouz"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/mouz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            }
            "7279"
            {
            	"name"		"cph2024_team_mouz_glitter"
            	"item_name"		"#StickerKit_cph2024_team_mouz_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/mouz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            }
            "7280"
            {
            	"name"		"cph2024_team_mouz_holo"
            	"item_name"		"#StickerKit_cph2024_team_mouz_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/mouz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            }
            "7281"
            {
            	"name"		"cph2024_team_mouz_gold"
            	"item_name"		"#StickerKit_cph2024_team_mouz_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/mouz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            }
            "7282"
            {
            	"name"		"cph2024_team_cplx"
            	"item_name"		"#StickerKit_cph2024_team_cplx"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/cplx"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            }
            "7283"
            {
            	"name"		"cph2024_team_cplx_glitter"
            	"item_name"		"#StickerKit_cph2024_team_cplx_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/cplx_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            }
            "7284"
            {
            	"name"		"cph2024_team_cplx_holo"
            	"item_name"		"#StickerKit_cph2024_team_cplx_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/cplx_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            }
            "7285"
            {
            	"name"		"cph2024_team_cplx_gold"
            	"item_name"		"#StickerKit_cph2024_team_cplx_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/cplx_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            }
            "7286"
            {
            	"name"		"cph2024_team_c9"
            	"item_name"		"#StickerKit_cph2024_team_c9"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/c9"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            }
            "7287"
            {
            	"name"		"cph2024_team_c9_glitter"
            	"item_name"		"#StickerKit_cph2024_team_c9_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/c9_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            }
            "7288"
            {
            	"name"		"cph2024_team_c9_holo"
            	"item_name"		"#StickerKit_cph2024_team_c9_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/c9_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            }
            "7289"
            {
            	"name"		"cph2024_team_c9_gold"
            	"item_name"		"#StickerKit_cph2024_team_c9_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/c9_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            }
            "7290"
            {
            	"name"		"cph2024_team_ence"
            	"item_name"		"#StickerKit_cph2024_team_ence"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/ence"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            }
            "7291"
            {
            	"name"		"cph2024_team_ence_glitter"
            	"item_name"		"#StickerKit_cph2024_team_ence_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/ence_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            }
            "7292"
            {
            	"name"		"cph2024_team_ence_holo"
            	"item_name"		"#StickerKit_cph2024_team_ence_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/ence_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            }
            "7293"
            {
            	"name"		"cph2024_team_ence_gold"
            	"item_name"		"#StickerKit_cph2024_team_ence_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/ence_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            }
            "7294"
            {
            	"name"		"cph2024_team_furi"
            	"item_name"		"#StickerKit_cph2024_team_furi"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/furi"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            }
            "7295"
            {
            	"name"		"cph2024_team_furi_glitter"
            	"item_name"		"#StickerKit_cph2024_team_furi_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/furi_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            }
            "7296"
            {
            	"name"		"cph2024_team_furi_holo"
            	"item_name"		"#StickerKit_cph2024_team_furi_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/furi_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            }
            "7297"
            {
            	"name"		"cph2024_team_furi_gold"
            	"item_name"		"#StickerKit_cph2024_team_furi_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/furi_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            }
            "7298"
            {
            	"name"		"cph2024_team_hero"
            	"item_name"		"#StickerKit_cph2024_team_hero"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/hero"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            }
            "7299"
            {
            	"name"		"cph2024_team_hero_glitter"
            	"item_name"		"#StickerKit_cph2024_team_hero_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/hero_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            }
            "7300"
            {
            	"name"		"cph2024_team_hero_holo"
            	"item_name"		"#StickerKit_cph2024_team_hero_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/hero_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            }
            "7301"
            {
            	"name"		"cph2024_team_hero_gold"
            	"item_name"		"#StickerKit_cph2024_team_hero_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/hero_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            }
            "7302"
            {
            	"name"		"cph2024_team_eter"
            	"item_name"		"#StickerKit_cph2024_team_eter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/eter"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            }
            "7303"
            {
            	"name"		"cph2024_team_eter_glitter"
            	"item_name"		"#StickerKit_cph2024_team_eter_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/eter_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            }
            "7304"
            {
            	"name"		"cph2024_team_eter_holo"
            	"item_name"		"#StickerKit_cph2024_team_eter_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/eter_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            }
            "7305"
            {
            	"name"		"cph2024_team_eter_gold"
            	"item_name"		"#StickerKit_cph2024_team_eter_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/eter_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            }
            "7306"
            {
            	"name"		"cph2024_team_apex"
            	"item_name"		"#StickerKit_cph2024_team_apex"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/apex"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            }
            "7307"
            {
            	"name"		"cph2024_team_apex_glitter"
            	"item_name"		"#StickerKit_cph2024_team_apex_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/apex_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            }
            "7308"
            {
            	"name"		"cph2024_team_apex_holo"
            	"item_name"		"#StickerKit_cph2024_team_apex_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/apex_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            }
            "7309"
            {
            	"name"		"cph2024_team_apex_gold"
            	"item_name"		"#StickerKit_cph2024_team_apex_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/apex_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            }
            "7310"
            {
            	"name"		"cph2024_team_gl"
            	"item_name"		"#StickerKit_cph2024_team_gl"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/gl"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            }
            "7311"
            {
            	"name"		"cph2024_team_gl_glitter"
            	"item_name"		"#StickerKit_cph2024_team_gl_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/gl_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            }
            "7312"
            {
            	"name"		"cph2024_team_gl_holo"
            	"item_name"		"#StickerKit_cph2024_team_gl_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/gl_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            }
            "7313"
            {
            	"name"		"cph2024_team_gl_gold"
            	"item_name"		"#StickerKit_cph2024_team_gl_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/gl_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            }
            "7314"
            {
            	"name"		"cph2024_team_saw"
            	"item_name"		"#StickerKit_cph2024_team_saw"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/saw"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            }
            "7315"
            {
            	"name"		"cph2024_team_saw_glitter"
            	"item_name"		"#StickerKit_cph2024_team_saw_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/saw_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            }
            "7316"
            {
            	"name"		"cph2024_team_saw_holo"
            	"item_name"		"#StickerKit_cph2024_team_saw_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/saw_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            }
            "7317"
            {
            	"name"		"cph2024_team_saw_gold"
            	"item_name"		"#StickerKit_cph2024_team_saw_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/saw_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            }
            "7318"
            {
            	"name"		"cph2024_team_pain"
            	"item_name"		"#StickerKit_cph2024_team_pain"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/pain"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            }
            "7319"
            {
            	"name"		"cph2024_team_pain_glitter"
            	"item_name"		"#StickerKit_cph2024_team_pain_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/pain_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            }
            "7320"
            {
            	"name"		"cph2024_team_pain_holo"
            	"item_name"		"#StickerKit_cph2024_team_pain_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/pain_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            }
            "7321"
            {
            	"name"		"cph2024_team_pain_gold"
            	"item_name"		"#StickerKit_cph2024_team_pain_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/pain_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            }
            "7322"
            {
            	"name"		"cph2024_team_imp"
            	"item_name"		"#StickerKit_cph2024_team_imp"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/imp"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            }
            "7323"
            {
            	"name"		"cph2024_team_imp_glitter"
            	"item_name"		"#StickerKit_cph2024_team_imp_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/imp_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            }
            "7324"
            {
            	"name"		"cph2024_team_imp_holo"
            	"item_name"		"#StickerKit_cph2024_team_imp_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/imp_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            }
            "7325"
            {
            	"name"		"cph2024_team_imp_gold"
            	"item_name"		"#StickerKit_cph2024_team_imp_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/imp_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            }
            "7326"
            {
            	"name"		"cph2024_team_mngz"
            	"item_name"		"#StickerKit_cph2024_team_mngz"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/mngz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            }
            "7327"
            {
            	"name"		"cph2024_team_mngz_glitter"
            	"item_name"		"#StickerKit_cph2024_team_mngz_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/mngz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            }
            "7328"
            {
            	"name"		"cph2024_team_mngz_holo"
            	"item_name"		"#StickerKit_cph2024_team_mngz_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/mngz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            }
            "7329"
            {
            	"name"		"cph2024_team_mngz_gold"
            	"item_name"		"#StickerKit_cph2024_team_mngz_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/mngz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            }
            "7330"
            {
            	"name"		"cph2024_team_amka"
            	"item_name"		"#StickerKit_cph2024_team_amka"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/amka"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            }
            "7331"
            {
            	"name"		"cph2024_team_amka_glitter"
            	"item_name"		"#StickerKit_cph2024_team_amka_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/amka_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            }
            "7332"
            {
            	"name"		"cph2024_team_amka_holo"
            	"item_name"		"#StickerKit_cph2024_team_amka_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/amka_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            }
            "7333"
            {
            	"name"		"cph2024_team_amka_gold"
            	"item_name"		"#StickerKit_cph2024_team_amka_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/amka_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            }
            "7334"
            {
            	"name"		"cph2024_team_ecst"
            	"item_name"		"#StickerKit_cph2024_team_ecst"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/ecst"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            }
            "7335"
            {
            	"name"		"cph2024_team_ecst_glitter"
            	"item_name"		"#StickerKit_cph2024_team_ecst_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/ecst_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            }
            "7336"
            {
            	"name"		"cph2024_team_ecst_holo"
            	"item_name"		"#StickerKit_cph2024_team_ecst_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/ecst_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            }
            "7337"
            {
            	"name"		"cph2024_team_ecst_gold"
            	"item_name"		"#StickerKit_cph2024_team_ecst_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/ecst_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            }
            "7338"
            {
            	"name"		"cph2024_team_koi"
            	"item_name"		"#StickerKit_cph2024_team_koi"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/koi"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            }
            "7339"
            {
            	"name"		"cph2024_team_koi_glitter"
            	"item_name"		"#StickerKit_cph2024_team_koi_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/koi_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            }
            "7340"
            {
            	"name"		"cph2024_team_koi_holo"
            	"item_name"		"#StickerKit_cph2024_team_koi_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/koi_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            }
            "7341"
            {
            	"name"		"cph2024_team_koi_gold"
            	"item_name"		"#StickerKit_cph2024_team_koi_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/koi_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            }
            "7342"
            {
            	"name"		"cph2024_team_lgcy"
            	"item_name"		"#StickerKit_cph2024_team_lgcy"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/lgcy"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            }
            "7343"
            {
            	"name"		"cph2024_team_lgcy_glitter"
            	"item_name"		"#StickerKit_cph2024_team_lgcy_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/lgcy_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            }
            "7344"
            {
            	"name"		"cph2024_team_lgcy_holo"
            	"item_name"		"#StickerKit_cph2024_team_lgcy_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/lgcy_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            }
            "7345"
            {
            	"name"		"cph2024_team_lgcy_gold"
            	"item_name"		"#StickerKit_cph2024_team_lgcy_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/lgcy_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            }
            "7346"
            {
            	"name"		"cph2024_team_lynn"
            	"item_name"		"#StickerKit_cph2024_team_lynn"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/lynn"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            }
            "7347"
            {
            	"name"		"cph2024_team_lynn_glitter"
            	"item_name"		"#StickerKit_cph2024_team_lynn_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/lynn_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            }
            "7348"
            {
            	"name"		"cph2024_team_lynn_holo"
            	"item_name"		"#StickerKit_cph2024_team_lynn_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/lynn_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            }
            "7349"
            {
            	"name"		"cph2024_team_lynn_gold"
            	"item_name"		"#StickerKit_cph2024_team_lynn_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_team"
            	"sticker_material"		"cph2024/lynn_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            }
            "7350"
            {
            	"name"		"cph2024_team_pgl"
            	"item_name"		"#StickerKit_cph2024_team_pgl"
            	"description_string"		"#EventItemDesc_cph2024_sticker_org"
            	"sticker_material"		"cph2024/pgl"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"0"
            }
            "7351"
            {
            	"name"		"cph2024_team_pgl_glitter"
            	"item_name"		"#StickerKit_cph2024_team_pgl_glitter"
            	"description_string"		"#EventItemDesc_cph2024_sticker_org"
            	"sticker_material"		"cph2024/pgl_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"0"
            }
            "7352"
            {
            	"name"		"cph2024_team_pgl_holo"
            	"item_name"		"#StickerKit_cph2024_team_pgl_holo"
            	"description_string"		"#EventItemDesc_cph2024_sticker_org"
            	"sticker_material"		"cph2024/pgl_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"0"
            }
            "7353"
            {
            	"name"		"cph2024_team_pgl_gold"
            	"item_name"		"#StickerKit_cph2024_team_pgl_gold"
            	"description_string"		"#EventItemDesc_cph2024_sticker_org"
            	"sticker_material"		"cph2024/pgl_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"0"
            }
            "7354"
            {
            	"name"		"cph2024_team_navi_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_navi"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/navi_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            }
            "7355"
            {
            	"name"		"cph2024_team_vp_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_vp"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/vp_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            }
            "7356"
            {
            	"name"		"cph2024_team_g2_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_g2"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/g2_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            }
            "7357"
            {
            	"name"		"cph2024_team_faze_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_faze"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/faze_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            }
            "7358"
            {
            	"name"		"cph2024_team_spir_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_spir"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/spir_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            }
            "7359"
            {
            	"name"		"cph2024_team_vita_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_vita"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/vita_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            }
            "7360"
            {
            	"name"		"cph2024_team_mouz_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_mouz"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/mouz_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            }
            "7361"
            {
            	"name"		"cph2024_team_cplx_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_cplx"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/cplx_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            }
            "7362"
            {
            	"name"		"cph2024_team_c9_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_c9"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/c9_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            }
            "7363"
            {
            	"name"		"cph2024_team_ence_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_ence"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/ence_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            }
            "7364"
            {
            	"name"		"cph2024_team_furi_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_furi"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/furi_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            }
            "7365"
            {
            	"name"		"cph2024_team_hero_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_hero"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/hero_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            }
            "7366"
            {
            	"name"		"cph2024_team_eter_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_eter"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/eter_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            }
            "7367"
            {
            	"name"		"cph2024_team_apex_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_apex"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/apex_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            }
            "7368"
            {
            	"name"		"cph2024_team_gl_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_gl"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/gl_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            }
            "7369"
            {
            	"name"		"cph2024_team_saw_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_saw"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/saw_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            }
            "7370"
            {
            	"name"		"cph2024_team_pain_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_pain"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/pain_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            }
            "7371"
            {
            	"name"		"cph2024_team_imp_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_imp"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/imp_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            }
            "7372"
            {
            	"name"		"cph2024_team_mngz_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_mngz"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/mngz_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            }
            "7373"
            {
            	"name"		"cph2024_team_amka_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_amka"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/amka_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            }
            "7374"
            {
            	"name"		"cph2024_team_ecst_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_ecst"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/ecst_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            }
            "7375"
            {
            	"name"		"cph2024_team_koi_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_koi"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/koi_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            }
            "7376"
            {
            	"name"		"cph2024_team_lgcy_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_lgcy"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/lgcy_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            }
            "7377"
            {
            	"name"		"cph2024_team_lynn_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_lynn"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_team"
            	"sticker_material"		"cph2024/lynn_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            }
            "7378"
            {
            	"name"		"cph2024_team_pgl_graffiti"
            	"item_name"		"#StickerKit_cph2024_team_pgl"
            	"description_string"		"#EventItemDesc_cph2024_graffiti_org"
            	"sticker_material"		"cph2024/pgl_graffiti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"0"
            }
            "7379"
            {
            	"name"		"cph2024_signature_jl_2"
            	"item_name"		"#StickerKit_cph2024_signature_jl"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jl"
            	"sticker_material"		"cph2024/sig_jl"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"216612575"
            }
            "7380"
            {
            	"name"		"cph2024_signature_jl_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_jl_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jl_glitter"
            	"sticker_material"		"cph2024/sig_jl_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"216612575"
            }
            "7381"
            {
            	"name"		"cph2024_signature_jl_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_jl_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jl_holo"
            	"sticker_material"		"cph2024/sig_jl_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"216612575"
            }
            "7382"
            {
            	"name"		"cph2024_signature_jl_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_jl_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jl_gold"
            	"sticker_material"		"cph2024/sig_jl_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"216612575"
            }
            "7383"
            {
            	"name"		"cph2024_signature_aleksib_2"
            	"item_name"		"#StickerKit_cph2024_signature_aleksib"
            	"description_string"		"#StickerKit_desc_cph2024_signature_aleksib"
            	"sticker_material"		"cph2024/sig_aleksib"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"52977598"
            }
            "7384"
            {
            	"name"		"cph2024_signature_aleksib_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_aleksib_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_aleksib_glitter"
            	"sticker_material"		"cph2024/sig_aleksib_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"52977598"
            }
            "7385"
            {
            	"name"		"cph2024_signature_aleksib_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_aleksib_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_aleksib_holo"
            	"sticker_material"		"cph2024/sig_aleksib_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"52977598"
            }
            "7386"
            {
            	"name"		"cph2024_signature_aleksib_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_aleksib_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_aleksib_gold"
            	"sticker_material"		"cph2024/sig_aleksib_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"52977598"
            }
            "7387"
            {
            	"name"		"cph2024_signature_b1t_2"
            	"item_name"		"#StickerKit_cph2024_signature_b1t"
            	"description_string"		"#StickerKit_desc_cph2024_signature_b1t"
            	"sticker_material"		"cph2024/sig_b1t"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"286341748"
            }
            "7388"
            {
            	"name"		"cph2024_signature_b1t_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_b1t_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_b1t_glitter"
            	"sticker_material"		"cph2024/sig_b1t_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"286341748"
            }
            "7389"
            {
            	"name"		"cph2024_signature_b1t_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_b1t_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_b1t_holo"
            	"sticker_material"		"cph2024/sig_b1t_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"286341748"
            }
            "7390"
            {
            	"name"		"cph2024_signature_b1t_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_b1t_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_b1t_gold"
            	"sticker_material"		"cph2024/sig_b1t_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"286341748"
            }
            "7391"
            {
            	"name"		"cph2024_signature_im_2"
            	"item_name"		"#StickerKit_cph2024_signature_im"
            	"description_string"		"#StickerKit_desc_cph2024_signature_im"
            	"sticker_material"		"cph2024/sig_im"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"89984505"
            }
            "7392"
            {
            	"name"		"cph2024_signature_im_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_im_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_im_glitter"
            	"sticker_material"		"cph2024/sig_im_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"89984505"
            }
            "7393"
            {
            	"name"		"cph2024_signature_im_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_im_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_im_holo"
            	"sticker_material"		"cph2024/sig_im_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"89984505"
            }
            "7394"
            {
            	"name"		"cph2024_signature_im_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_im_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_im_gold"
            	"sticker_material"		"cph2024/sig_im_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"89984505"
            }
            "7395"
            {
            	"name"		"cph2024_signature_w0nderful_2"
            	"item_name"		"#StickerKit_cph2024_signature_w0nderful"
            	"description_string"		"#StickerKit_desc_cph2024_signature_w0nderful"
            	"sticker_material"		"cph2024/sig_w0nderful"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"1102803112"
            }
            "7396"
            {
            	"name"		"cph2024_signature_w0nderful_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_w0nderful_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_w0nderful_glitter"
            	"sticker_material"		"cph2024/sig_w0nderful_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"1102803112"
            }
            "7397"
            {
            	"name"		"cph2024_signature_w0nderful_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_w0nderful_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_w0nderful_holo"
            	"sticker_material"		"cph2024/sig_w0nderful_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"1102803112"
            }
            "7398"
            {
            	"name"		"cph2024_signature_w0nderful_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_w0nderful_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_w0nderful_gold"
            	"sticker_material"		"cph2024/sig_w0nderful_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"12"
            	"tournament_player_id"		"1102803112"
            }
            "7399"
            {
            	"name"		"cph2024_signature_fame_2"
            	"item_name"		"#StickerKit_cph2024_signature_fame"
            	"description_string"		"#StickerKit_desc_cph2024_signature_fame"
            	"sticker_material"		"cph2024/sig_fame"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"119848818"
            }
            "7400"
            {
            	"name"		"cph2024_signature_fame_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_fame_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_fame_glitter"
            	"sticker_material"		"cph2024/sig_fame_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"119848818"
            }
            "7401"
            {
            	"name"		"cph2024_signature_fame_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_fame_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_fame_holo"
            	"sticker_material"		"cph2024/sig_fame_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"119848818"
            }
            "7402"
            {
            	"name"		"cph2024_signature_fame_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_fame_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_fame_gold"
            	"sticker_material"		"cph2024/sig_fame_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"119848818"
            }
            "7403"
            {
            	"name"		"cph2024_signature_fl1t_2"
            	"item_name"		"#StickerKit_cph2024_signature_fl1t"
            	"description_string"		"#StickerKit_desc_cph2024_signature_fl1t"
            	"sticker_material"		"cph2024/sig_fl1t"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"35551773"
            }
            "7404"
            {
            	"name"		"cph2024_signature_fl1t_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_fl1t_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_fl1t_glitter"
            	"sticker_material"		"cph2024/sig_fl1t_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"35551773"
            }
            "7405"
            {
            	"name"		"cph2024_signature_fl1t_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_fl1t_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_fl1t_holo"
            	"sticker_material"		"cph2024/sig_fl1t_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"35551773"
            }
            "7406"
            {
            	"name"		"cph2024_signature_fl1t_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_fl1t_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_fl1t_gold"
            	"sticker_material"		"cph2024/sig_fl1t_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"35551773"
            }
            "7407"
            {
            	"name"		"cph2024_signature_jame_2"
            	"item_name"		"#StickerKit_cph2024_signature_jame"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jame"
            	"sticker_material"		"cph2024/sig_jame"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"75859856"
            }
            "7408"
            {
            	"name"		"cph2024_signature_jame_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_jame_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jame_glitter"
            	"sticker_material"		"cph2024/sig_jame_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"75859856"
            }
            "7409"
            {
            	"name"		"cph2024_signature_jame_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_jame_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jame_holo"
            	"sticker_material"		"cph2024/sig_jame_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"75859856"
            }
            "7410"
            {
            	"name"		"cph2024_signature_jame_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_jame_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jame_gold"
            	"sticker_material"		"cph2024/sig_jame_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"75859856"
            }
            "7411"
            {
            	"name"		"cph2024_signature_mir_2"
            	"item_name"		"#StickerKit_cph2024_signature_mir"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mir"
            	"sticker_material"		"cph2024/sig_mir"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"40562076"
            }
            "7412"
            {
            	"name"		"cph2024_signature_mir_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_mir_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mir_glitter"
            	"sticker_material"		"cph2024/sig_mir_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"40562076"
            }
            "7413"
            {
            	"name"		"cph2024_signature_mir_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_mir_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mir_holo"
            	"sticker_material"		"cph2024/sig_mir_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"40562076"
            }
            "7414"
            {
            	"name"		"cph2024_signature_mir_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_mir_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mir_gold"
            	"sticker_material"		"cph2024/sig_mir_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"40562076"
            }
            "7415"
            {
            	"name"		"cph2024_signature_n0rb3r7_2"
            	"item_name"		"#StickerKit_cph2024_signature_n0rb3r7"
            	"description_string"		"#StickerKit_desc_cph2024_signature_n0rb3r7"
            	"sticker_material"		"cph2024/sig_n0rb3r7"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"262176776"
            }
            "7416"
            {
            	"name"		"cph2024_signature_n0rb3r7_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_n0rb3r7_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_n0rb3r7_glitter"
            	"sticker_material"		"cph2024/sig_n0rb3r7_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"262176776"
            }
            "7417"
            {
            	"name"		"cph2024_signature_n0rb3r7_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_n0rb3r7_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_n0rb3r7_holo"
            	"sticker_material"		"cph2024/sig_n0rb3r7_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"262176776"
            }
            "7418"
            {
            	"name"		"cph2024_signature_n0rb3r7_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_n0rb3r7_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_n0rb3r7_gold"
            	"sticker_material"		"cph2024/sig_n0rb3r7_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"31"
            	"tournament_player_id"		"262176776"
            }
            "7419"
            {
            	"name"		"cph2024_signature_hooxi_2"
            	"item_name"		"#StickerKit_cph2024_signature_hooxi"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hooxi"
            	"sticker_material"		"cph2024/sig_hooxi"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"38661042"
            }
            "7420"
            {
            	"name"		"cph2024_signature_hooxi_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_hooxi_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hooxi_glitter"
            	"sticker_material"		"cph2024/sig_hooxi_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"38661042"
            }
            "7421"
            {
            	"name"		"cph2024_signature_hooxi_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_hooxi_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hooxi_holo"
            	"sticker_material"		"cph2024/sig_hooxi_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"38661042"
            }
            "7422"
            {
            	"name"		"cph2024_signature_hooxi_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_hooxi_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hooxi_gold"
            	"sticker_material"		"cph2024/sig_hooxi_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"38661042"
            }
            "7423"
            {
            	"name"		"cph2024_signature_hunter_2"
            	"item_name"		"#StickerKit_cph2024_signature_hunter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hunter"
            	"sticker_material"		"cph2024/sig_hunter"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"52606325"
            }
            "7424"
            {
            	"name"		"cph2024_signature_hunter_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_hunter_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hunter_glitter"
            	"sticker_material"		"cph2024/sig_hunter_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"52606325"
            }
            "7425"
            {
            	"name"		"cph2024_signature_hunter_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_hunter_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hunter_holo"
            	"sticker_material"		"cph2024/sig_hunter_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"52606325"
            }
            "7426"
            {
            	"name"		"cph2024_signature_hunter_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_hunter_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hunter_gold"
            	"sticker_material"		"cph2024/sig_hunter_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"52606325"
            }
            "7427"
            {
            	"name"		"cph2024_signature_m0nesy_2"
            	"item_name"		"#StickerKit_cph2024_signature_m0nesy"
            	"description_string"		"#StickerKit_desc_cph2024_signature_m0nesy"
            	"sticker_material"		"cph2024/sig_m0nesy"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"114497073"
            }
            "7428"
            {
            	"name"		"cph2024_signature_m0nesy_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_m0nesy_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_m0nesy_glitter"
            	"sticker_material"		"cph2024/sig_m0nesy_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"114497073"
            }
            "7429"
            {
            	"name"		"cph2024_signature_m0nesy_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_m0nesy_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_m0nesy_holo"
            	"sticker_material"		"cph2024/sig_m0nesy_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"114497073"
            }
            "7430"
            {
            	"name"		"cph2024_signature_m0nesy_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_m0nesy_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_m0nesy_gold"
            	"sticker_material"		"cph2024/sig_m0nesy_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"114497073"
            }
            "7431"
            {
            	"name"		"cph2024_signature_nexa_2"
            	"item_name"		"#StickerKit_cph2024_signature_nexa"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nexa"
            	"sticker_material"		"cph2024/sig_nexa"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"39559694"
            }
            "7432"
            {
            	"name"		"cph2024_signature_nexa_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_nexa_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nexa_glitter"
            	"sticker_material"		"cph2024/sig_nexa_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"39559694"
            }
            "7433"
            {
            	"name"		"cph2024_signature_nexa_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_nexa_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nexa_holo"
            	"sticker_material"		"cph2024/sig_nexa_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"39559694"
            }
            "7434"
            {
            	"name"		"cph2024_signature_nexa_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_nexa_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nexa_gold"
            	"sticker_material"		"cph2024/sig_nexa_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"39559694"
            }
            "7435"
            {
            	"name"		"cph2024_signature_niko_2"
            	"item_name"		"#StickerKit_cph2024_signature_niko"
            	"description_string"		"#StickerKit_desc_cph2024_signature_niko"
            	"sticker_material"		"cph2024/sig_niko"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"81417650"
            }
            "7436"
            {
            	"name"		"cph2024_signature_niko_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_niko_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_niko_glitter"
            	"sticker_material"		"cph2024/sig_niko_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"81417650"
            }
            "7437"
            {
            	"name"		"cph2024_signature_niko_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_niko_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_niko_holo"
            	"sticker_material"		"cph2024/sig_niko_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"81417650"
            }
            "7438"
            {
            	"name"		"cph2024_signature_niko_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_niko_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_niko_gold"
            	"sticker_material"		"cph2024/sig_niko_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"59"
            	"tournament_player_id"		"81417650"
            }
            "7439"
            {
            	"name"		"cph2024_signature_broky_2"
            	"item_name"		"#StickerKit_cph2024_signature_broky"
            	"description_string"		"#StickerKit_desc_cph2024_signature_broky"
            	"sticker_material"		"cph2024/sig_broky"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"241354762"
            }
            "7440"
            {
            	"name"		"cph2024_signature_broky_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_broky_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_broky_glitter"
            	"sticker_material"		"cph2024/sig_broky_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"241354762"
            }
            "7441"
            {
            	"name"		"cph2024_signature_broky_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_broky_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_broky_holo"
            	"sticker_material"		"cph2024/sig_broky_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"241354762"
            }
            "7442"
            {
            	"name"		"cph2024_signature_broky_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_broky_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_broky_gold"
            	"sticker_material"		"cph2024/sig_broky_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"241354762"
            }
            "7443"
            {
            	"name"		"cph2024_signature_frozen_2"
            	"item_name"		"#StickerKit_cph2024_signature_frozen"
            	"description_string"		"#StickerKit_desc_cph2024_signature_frozen"
            	"sticker_material"		"cph2024/sig_frozen"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"108157034"
            }
            "7444"
            {
            	"name"		"cph2024_signature_frozen_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_frozen_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_frozen_glitter"
            	"sticker_material"		"cph2024/sig_frozen_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"108157034"
            }
            "7445"
            {
            	"name"		"cph2024_signature_frozen_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_frozen_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_frozen_holo"
            	"sticker_material"		"cph2024/sig_frozen_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"108157034"
            }
            "7446"
            {
            	"name"		"cph2024_signature_frozen_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_frozen_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_frozen_gold"
            	"sticker_material"		"cph2024/sig_frozen_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"108157034"
            }
            "7447"
            {
            	"name"		"cph2024_signature_karrigan_2"
            	"item_name"		"#StickerKit_cph2024_signature_karrigan"
            	"description_string"		"#StickerKit_desc_cph2024_signature_karrigan"
            	"sticker_material"		"cph2024/sig_karrigan"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"29164525"
            }
            "7448"
            {
            	"name"		"cph2024_signature_karrigan_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_karrigan_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_karrigan_glitter"
            	"sticker_material"		"cph2024/sig_karrigan_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"29164525"
            }
            "7449"
            {
            	"name"		"cph2024_signature_karrigan_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_karrigan_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_karrigan_holo"
            	"sticker_material"		"cph2024/sig_karrigan_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"29164525"
            }
            "7450"
            {
            	"name"		"cph2024_signature_karrigan_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_karrigan_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_karrigan_gold"
            	"sticker_material"		"cph2024/sig_karrigan_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"29164525"
            }
            "7451"
            {
            	"name"		"cph2024_signature_rain_2"
            	"item_name"		"#StickerKit_cph2024_signature_rain"
            	"description_string"		"#StickerKit_desc_cph2024_signature_rain"
            	"sticker_material"		"cph2024/sig_rain"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"37085479"
            }
            "7452"
            {
            	"name"		"cph2024_signature_rain_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_rain_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_rain_glitter"
            	"sticker_material"		"cph2024/sig_rain_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"37085479"
            }
            "7453"
            {
            	"name"		"cph2024_signature_rain_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_rain_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_rain_holo"
            	"sticker_material"		"cph2024/sig_rain_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"37085479"
            }
            "7454"
            {
            	"name"		"cph2024_signature_rain_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_rain_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_rain_gold"
            	"sticker_material"		"cph2024/sig_rain_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"37085479"
            }
            "7455"
            {
            	"name"		"cph2024_signature_ropz_2"
            	"item_name"		"#StickerKit_cph2024_signature_ropz"
            	"description_string"		"#StickerKit_desc_cph2024_signature_ropz"
            	"sticker_material"		"cph2024/sig_ropz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"31006590"
            }
            "7456"
            {
            	"name"		"cph2024_signature_ropz_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_ropz_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_ropz_glitter"
            	"sticker_material"		"cph2024/sig_ropz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"31006590"
            }
            "7457"
            {
            	"name"		"cph2024_signature_ropz_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_ropz_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_ropz_holo"
            	"sticker_material"		"cph2024/sig_ropz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"31006590"
            }
            "7458"
            {
            	"name"		"cph2024_signature_ropz_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_ropz_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_ropz_gold"
            	"sticker_material"		"cph2024/sig_ropz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"61"
            	"tournament_player_id"		"31006590"
            }
            "7459"
            {
            	"name"		"cph2024_signature_chopper_2"
            	"item_name"		"#StickerKit_cph2024_signature_chopper"
            	"description_string"		"#StickerKit_desc_cph2024_signature_chopper"
            	"sticker_material"		"cph2024/sig_chopper"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"85633136"
            }
            "7460"
            {
            	"name"		"cph2024_signature_chopper_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_chopper_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_chopper_glitter"
            	"sticker_material"		"cph2024/sig_chopper_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"85633136"
            }
            "7461"
            {
            	"name"		"cph2024_signature_chopper_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_chopper_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_chopper_holo"
            	"sticker_material"		"cph2024/sig_chopper_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"85633136"
            }
            "7462"
            {
            	"name"		"cph2024_signature_chopper_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_chopper_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_chopper_gold"
            	"sticker_material"		"cph2024/sig_chopper_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"85633136"
            }
            "7463"
            {
            	"name"		"cph2024_signature_donk_2"
            	"item_name"		"#StickerKit_cph2024_signature_donk"
            	"description_string"		"#StickerKit_desc_cph2024_signature_donk"
            	"sticker_material"		"cph2024/sig_donk"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"425999755"
            }
            "7464"
            {
            	"name"		"cph2024_signature_donk_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_donk_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_donk_glitter"
            	"sticker_material"		"cph2024/sig_donk_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"425999755"
            }
            "7465"
            {
            	"name"		"cph2024_signature_donk_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_donk_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_donk_holo"
            	"sticker_material"		"cph2024/sig_donk_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"425999755"
            }
            "7466"
            {
            	"name"		"cph2024_signature_donk_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_donk_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_donk_gold"
            	"sticker_material"		"cph2024/sig_donk_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"425999755"
            }
            "7467"
            {
            	"name"		"cph2024_signature_magixx_2"
            	"item_name"		"#StickerKit_cph2024_signature_magixx"
            	"description_string"		"#StickerKit_desc_cph2024_signature_magixx"
            	"sticker_material"		"cph2024/sig_magixx"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"868554"
            }
            "7468"
            {
            	"name"		"cph2024_signature_magixx_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_magixx_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_magixx_glitter"
            	"sticker_material"		"cph2024/sig_magixx_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"868554"
            }
            "7469"
            {
            	"name"		"cph2024_signature_magixx_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_magixx_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_magixx_holo"
            	"sticker_material"		"cph2024/sig_magixx_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"868554"
            }
            "7470"
            {
            	"name"		"cph2024_signature_magixx_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_magixx_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_magixx_gold"
            	"sticker_material"		"cph2024/sig_magixx_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"868554"
            }
            "7471"
            {
            	"name"		"cph2024_signature_sh1ro_2"
            	"item_name"		"#StickerKit_cph2024_signature_sh1ro"
            	"description_string"		"#StickerKit_desc_cph2024_signature_sh1ro"
            	"sticker_material"		"cph2024/sig_sh1ro"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"121219047"
            }
            "7472"
            {
            	"name"		"cph2024_signature_sh1ro_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_sh1ro_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_sh1ro_glitter"
            	"sticker_material"		"cph2024/sig_sh1ro_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"121219047"
            }
            "7473"
            {
            	"name"		"cph2024_signature_sh1ro_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_sh1ro_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_sh1ro_holo"
            	"sticker_material"		"cph2024/sig_sh1ro_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"121219047"
            }
            "7474"
            {
            	"name"		"cph2024_signature_sh1ro_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_sh1ro_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_sh1ro_gold"
            	"sticker_material"		"cph2024/sig_sh1ro_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"121219047"
            }
            "7475"
            {
            	"name"		"cph2024_signature_zont1x_2"
            	"item_name"		"#StickerKit_cph2024_signature_zont1x"
            	"description_string"		"#StickerKit_desc_cph2024_signature_zont1x"
            	"sticker_material"		"cph2024/sig_zont1x"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"1035615149"
            }
            "7476"
            {
            	"name"		"cph2024_signature_zont1x_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_zont1x_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_zont1x_glitter"
            	"sticker_material"		"cph2024/sig_zont1x_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"1035615149"
            }
            "7477"
            {
            	"name"		"cph2024_signature_zont1x_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_zont1x_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_zont1x_holo"
            	"sticker_material"		"cph2024/sig_zont1x_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"1035615149"
            }
            "7478"
            {
            	"name"		"cph2024_signature_zont1x_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_zont1x_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_zont1x_gold"
            	"sticker_material"		"cph2024/sig_zont1x_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"81"
            	"tournament_player_id"		"1035615149"
            }
            "7479"
            {
            	"name"		"cph2024_signature_apex_2"
            	"item_name"		"#StickerKit_cph2024_signature_apex"
            	"description_string"		"#StickerKit_desc_cph2024_signature_apex"
            	"sticker_material"		"cph2024/sig_apex"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"29478439"
            }
            "7480"
            {
            	"name"		"cph2024_signature_apex_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_apex_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_apex_glitter"
            	"sticker_material"		"cph2024/sig_apex_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"29478439"
            }
            "7481"
            {
            	"name"		"cph2024_signature_apex_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_apex_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_apex_holo"
            	"sticker_material"		"cph2024/sig_apex_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"29478439"
            }
            "7482"
            {
            	"name"		"cph2024_signature_apex_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_apex_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_apex_gold"
            	"sticker_material"		"cph2024/sig_apex_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"29478439"
            }
            "7483"
            {
            	"name"		"cph2024_signature_flamez_2"
            	"item_name"		"#StickerKit_cph2024_signature_flamez"
            	"description_string"		"#StickerKit_desc_cph2024_signature_flamez"
            	"sticker_material"		"cph2024/sig_flamez"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"18569432"
            }
            "7484"
            {
            	"name"		"cph2024_signature_flamez_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_flamez_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_flamez_glitter"
            	"sticker_material"		"cph2024/sig_flamez_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"18569432"
            }
            "7485"
            {
            	"name"		"cph2024_signature_flamez_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_flamez_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_flamez_holo"
            	"sticker_material"		"cph2024/sig_flamez_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"18569432"
            }
            "7486"
            {
            	"name"		"cph2024_signature_flamez_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_flamez_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_flamez_gold"
            	"sticker_material"		"cph2024/sig_flamez_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"18569432"
            }
            "7487"
            {
            	"name"		"cph2024_signature_mezii_2"
            	"item_name"		"#StickerKit_cph2024_signature_mezii"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mezii"
            	"sticker_material"		"cph2024/sig_mezii"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"12874964"
            }
            "7488"
            {
            	"name"		"cph2024_signature_mezii_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_mezii_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mezii_glitter"
            	"sticker_material"		"cph2024/sig_mezii_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"12874964"
            }
            "7489"
            {
            	"name"		"cph2024_signature_mezii_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_mezii_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mezii_holo"
            	"sticker_material"		"cph2024/sig_mezii_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"12874964"
            }
            "7490"
            {
            	"name"		"cph2024_signature_mezii_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_mezii_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mezii_gold"
            	"sticker_material"		"cph2024/sig_mezii_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"12874964"
            }
            "7491"
            {
            	"name"		"cph2024_signature_spinx_2"
            	"item_name"		"#StickerKit_cph2024_signature_spinx"
            	"description_string"		"#StickerKit_desc_cph2024_signature_spinx"
            	"sticker_material"		"cph2024/sig_spinx"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"103070679"
            }
            "7492"
            {
            	"name"		"cph2024_signature_spinx_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_spinx_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_spinx_glitter"
            	"sticker_material"		"cph2024/sig_spinx_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"103070679"
            }
            "7493"
            {
            	"name"		"cph2024_signature_spinx_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_spinx_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_spinx_holo"
            	"sticker_material"		"cph2024/sig_spinx_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"103070679"
            }
            "7494"
            {
            	"name"		"cph2024_signature_spinx_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_spinx_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_spinx_gold"
            	"sticker_material"		"cph2024/sig_spinx_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"103070679"
            }
            "7495"
            {
            	"name"		"cph2024_signature_zywoo_2"
            	"item_name"		"#StickerKit_cph2024_signature_zywoo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_zywoo"
            	"sticker_material"		"cph2024/sig_zywoo"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"153400465"
            }
            "7496"
            {
            	"name"		"cph2024_signature_zywoo_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_zywoo_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_zywoo_glitter"
            	"sticker_material"		"cph2024/sig_zywoo_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"153400465"
            }
            "7497"
            {
            	"name"		"cph2024_signature_zywoo_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_zywoo_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_zywoo_holo"
            	"sticker_material"		"cph2024/sig_zywoo_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"153400465"
            }
            "7498"
            {
            	"name"		"cph2024_signature_zywoo_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_zywoo_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_zywoo_gold"
            	"sticker_material"		"cph2024/sig_zywoo_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"89"
            	"tournament_player_id"		"153400465"
            }
            "7499"
            {
            	"name"		"cph2024_signature_brollan_2"
            	"item_name"		"#StickerKit_cph2024_signature_brollan"
            	"description_string"		"#StickerKit_desc_cph2024_signature_brollan"
            	"sticker_material"		"cph2024/sig_brollan"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"178562747"
            }
            "7500"
            {
            	"name"		"cph2024_signature_brollan_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_brollan_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_brollan_glitter"
            	"sticker_material"		"cph2024/sig_brollan_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"178562747"
            }
            "7501"
            {
            	"name"		"cph2024_signature_brollan_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_brollan_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_brollan_holo"
            	"sticker_material"		"cph2024/sig_brollan_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"178562747"
            }
            "7502"
            {
            	"name"		"cph2024_signature_brollan_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_brollan_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_brollan_gold"
            	"sticker_material"		"cph2024/sig_brollan_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"178562747"
            }
            "7503"
            {
            	"name"		"cph2024_signature_jimpphat_2"
            	"item_name"		"#StickerKit_cph2024_signature_jimpphat"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jimpphat"
            	"sticker_material"		"cph2024/sig_jimpphat"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"895109597"
            }
            "7504"
            {
            	"name"		"cph2024_signature_jimpphat_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_jimpphat_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jimpphat_glitter"
            	"sticker_material"		"cph2024/sig_jimpphat_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"895109597"
            }
            "7505"
            {
            	"name"		"cph2024_signature_jimpphat_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_jimpphat_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jimpphat_holo"
            	"sticker_material"		"cph2024/sig_jimpphat_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"895109597"
            }
            "7506"
            {
            	"name"		"cph2024_signature_jimpphat_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_jimpphat_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jimpphat_gold"
            	"sticker_material"		"cph2024/sig_jimpphat_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"895109597"
            }
            "7507"
            {
            	"name"		"cph2024_signature_siuhy_2"
            	"item_name"		"#StickerKit_cph2024_signature_siuhy"
            	"description_string"		"#StickerKit_desc_cph2024_signature_siuhy"
            	"sticker_material"		"cph2024/sig_siuhy"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"190407632"
            }
            "7508"
            {
            	"name"		"cph2024_signature_siuhy_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_siuhy_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_siuhy_glitter"
            	"sticker_material"		"cph2024/sig_siuhy_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"190407632"
            }
            "7509"
            {
            	"name"		"cph2024_signature_siuhy_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_siuhy_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_siuhy_holo"
            	"sticker_material"		"cph2024/sig_siuhy_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"190407632"
            }
            "7510"
            {
            	"name"		"cph2024_signature_siuhy_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_siuhy_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_siuhy_gold"
            	"sticker_material"		"cph2024/sig_siuhy_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"190407632"
            }
            "7511"
            {
            	"name"		"cph2024_signature_torzsi_2"
            	"item_name"		"#StickerKit_cph2024_signature_torzsi"
            	"description_string"		"#StickerKit_desc_cph2024_signature_torzsi"
            	"sticker_material"		"cph2024/sig_torzsi"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"395473484"
            }
            "7512"
            {
            	"name"		"cph2024_signature_torzsi_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_torzsi_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_torzsi_glitter"
            	"sticker_material"		"cph2024/sig_torzsi_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"395473484"
            }
            "7513"
            {
            	"name"		"cph2024_signature_torzsi_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_torzsi_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_torzsi_holo"
            	"sticker_material"		"cph2024/sig_torzsi_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"395473484"
            }
            "7514"
            {
            	"name"		"cph2024_signature_torzsi_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_torzsi_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_torzsi_gold"
            	"sticker_material"		"cph2024/sig_torzsi_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"395473484"
            }
            "7515"
            {
            	"name"		"cph2024_signature_xertion_2"
            	"item_name"		"#StickerKit_cph2024_signature_xertion"
            	"description_string"		"#StickerKit_desc_cph2024_signature_xertion"
            	"sticker_material"		"cph2024/sig_xertion"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"232908406"
            }
            "7516"
            {
            	"name"		"cph2024_signature_xertion_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_xertion_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_xertion_glitter"
            	"sticker_material"		"cph2024/sig_xertion_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"232908406"
            }
            "7517"
            {
            	"name"		"cph2024_signature_xertion_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_xertion_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_xertion_holo"
            	"sticker_material"		"cph2024/sig_xertion_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"232908406"
            }
            "7518"
            {
            	"name"		"cph2024_signature_xertion_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_xertion_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_xertion_gold"
            	"sticker_material"		"cph2024/sig_xertion_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"106"
            	"tournament_player_id"		"232908406"
            }
            "7519"
            {
            	"name"		"cph2024_signature_hallzerk_2"
            	"item_name"		"#StickerKit_cph2024_signature_hallzerk"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hallzerk"
            	"sticker_material"		"cph2024/sig_hallzerk"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"100101582"
            }
            "7520"
            {
            	"name"		"cph2024_signature_hallzerk_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_hallzerk_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hallzerk_glitter"
            	"sticker_material"		"cph2024/sig_hallzerk_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"100101582"
            }
            "7521"
            {
            	"name"		"cph2024_signature_hallzerk_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_hallzerk_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hallzerk_holo"
            	"sticker_material"		"cph2024/sig_hallzerk_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"100101582"
            }
            "7522"
            {
            	"name"		"cph2024_signature_hallzerk_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_hallzerk_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hallzerk_gold"
            	"sticker_material"		"cph2024/sig_hallzerk_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"100101582"
            }
            "7523"
            {
            	"name"		"cph2024_signature_elige_2"
            	"item_name"		"#StickerKit_cph2024_signature_elige"
            	"description_string"		"#StickerKit_desc_cph2024_signature_elige"
            	"sticker_material"		"cph2024/sig_elige"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"106428011"
            }
            "7524"
            {
            	"name"		"cph2024_signature_elige_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_elige_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_elige_glitter"
            	"sticker_material"		"cph2024/sig_elige_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"106428011"
            }
            "7525"
            {
            	"name"		"cph2024_signature_elige_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_elige_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_elige_holo"
            	"sticker_material"		"cph2024/sig_elige_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"106428011"
            }
            "7526"
            {
            	"name"		"cph2024_signature_elige_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_elige_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_elige_gold"
            	"sticker_material"		"cph2024/sig_elige_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"106428011"
            }
            "7527"
            {
            	"name"		"cph2024_signature_floppy_2"
            	"item_name"		"#StickerKit_cph2024_signature_floppy"
            	"description_string"		"#StickerKit_desc_cph2024_signature_floppy"
            	"sticker_material"		"cph2024/sig_floppy"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"346253535"
            }
            "7528"
            {
            	"name"		"cph2024_signature_floppy_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_floppy_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_floppy_glitter"
            	"sticker_material"		"cph2024/sig_floppy_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"346253535"
            }
            "7529"
            {
            	"name"		"cph2024_signature_floppy_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_floppy_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_floppy_holo"
            	"sticker_material"		"cph2024/sig_floppy_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"346253535"
            }
            "7530"
            {
            	"name"		"cph2024_signature_floppy_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_floppy_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_floppy_gold"
            	"sticker_material"		"cph2024/sig_floppy_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"346253535"
            }
            "7531"
            {
            	"name"		"cph2024_signature_grim_2"
            	"item_name"		"#StickerKit_cph2024_signature_grim"
            	"description_string"		"#StickerKit_desc_cph2024_signature_grim"
            	"sticker_material"		"cph2024/sig_grim"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"230970467"
            }
            "7532"
            {
            	"name"		"cph2024_signature_grim_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_grim_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_grim_glitter"
            	"sticker_material"		"cph2024/sig_grim_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"230970467"
            }
            "7533"
            {
            	"name"		"cph2024_signature_grim_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_grim_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_grim_holo"
            	"sticker_material"		"cph2024/sig_grim_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"230970467"
            }
            "7534"
            {
            	"name"		"cph2024_signature_grim_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_grim_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_grim_gold"
            	"sticker_material"		"cph2024/sig_grim_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"230970467"
            }
            "7535"
            {
            	"name"		"cph2024_signature_jt_2"
            	"item_name"		"#StickerKit_cph2024_signature_jt"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jt"
            	"sticker_material"		"cph2024/sig_jt"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"61449372"
            }
            "7536"
            {
            	"name"		"cph2024_signature_jt_2_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_jt_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jt_glitter"
            	"sticker_material"		"cph2024/sig_jt_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"61449372"
            }
            "7537"
            {
            	"name"		"cph2024_signature_jt_2_holo"
            	"item_name"		"#StickerKit_cph2024_signature_jt_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jt_holo"
            	"sticker_material"		"cph2024/sig_jt_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"61449372"
            }
            "7538"
            {
            	"name"		"cph2024_signature_jt_2_gold"
            	"item_name"		"#StickerKit_cph2024_signature_jt_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jt_gold"
            	"sticker_material"		"cph2024/sig_jt_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"111"
            	"tournament_player_id"		"61449372"
            }
            "7539"
            {
            	"name"		"cph2024_signature_ax1le_1"
            	"item_name"		"#StickerKit_cph2024_signature_ax1le"
            	"description_string"		"#StickerKit_desc_cph2024_signature_ax1le"
            	"sticker_material"		"cph2024/sig_ax1le"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"85167576"
            }
            "7540"
            {
            	"name"		"cph2024_signature_ax1le_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_ax1le_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_ax1le_glitter"
            	"sticker_material"		"cph2024/sig_ax1le_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"85167576"
            }
            "7541"
            {
            	"name"		"cph2024_signature_ax1le_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_ax1le_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_ax1le_holo"
            	"sticker_material"		"cph2024/sig_ax1le_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"85167576"
            }
            "7542"
            {
            	"name"		"cph2024_signature_ax1le_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_ax1le_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_ax1le_gold"
            	"sticker_material"		"cph2024/sig_ax1le_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"85167576"
            }
            "7543"
            {
            	"name"		"cph2024_signature_boombl4_1"
            	"item_name"		"#StickerKit_cph2024_signature_boombl4"
            	"description_string"		"#StickerKit_desc_cph2024_signature_boombl4"
            	"sticker_material"		"cph2024/sig_boombl4"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"185941338"
            }
            "7544"
            {
            	"name"		"cph2024_signature_boombl4_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_boombl4_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_boombl4_glitter"
            	"sticker_material"		"cph2024/sig_boombl4_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"185941338"
            }
            "7545"
            {
            	"name"		"cph2024_signature_boombl4_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_boombl4_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_boombl4_holo"
            	"sticker_material"		"cph2024/sig_boombl4_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"185941338"
            }
            "7546"
            {
            	"name"		"cph2024_signature_boombl4_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_boombl4_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_boombl4_gold"
            	"sticker_material"		"cph2024/sig_boombl4_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"185941338"
            }
            "7547"
            {
            	"name"		"cph2024_signature_electronic_1"
            	"item_name"		"#StickerKit_cph2024_signature_electronic"
            	"description_string"		"#StickerKit_desc_cph2024_signature_electronic"
            	"sticker_material"		"cph2024/sig_electronic"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"83779379"
            }
            "7548"
            {
            	"name"		"cph2024_signature_electronic_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_electronic_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_electronic_glitter"
            	"sticker_material"		"cph2024/sig_electronic_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"83779379"
            }
            "7549"
            {
            	"name"		"cph2024_signature_electronic_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_electronic_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_electronic_holo"
            	"sticker_material"		"cph2024/sig_electronic_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"83779379"
            }
            "7550"
            {
            	"name"		"cph2024_signature_electronic_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_electronic_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_electronic_gold"
            	"sticker_material"		"cph2024/sig_electronic_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"83779379"
            }
            "7551"
            {
            	"name"		"cph2024_signature_hobbit_1"
            	"item_name"		"#StickerKit_cph2024_signature_hobbit"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hobbit"
            	"sticker_material"		"cph2024/sig_hobbit"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"68027030"
            }
            "7552"
            {
            	"name"		"cph2024_signature_hobbit_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_hobbit_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hobbit_glitter"
            	"sticker_material"		"cph2024/sig_hobbit_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"68027030"
            }
            "7553"
            {
            	"name"		"cph2024_signature_hobbit_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_hobbit_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hobbit_holo"
            	"sticker_material"		"cph2024/sig_hobbit_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"68027030"
            }
            "7554"
            {
            	"name"		"cph2024_signature_hobbit_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_hobbit_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hobbit_gold"
            	"sticker_material"		"cph2024/sig_hobbit_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"68027030"
            }
            "7555"
            {
            	"name"		"cph2024_signature_perfecto_1"
            	"item_name"		"#StickerKit_cph2024_signature_perfecto"
            	"description_string"		"#StickerKit_desc_cph2024_signature_perfecto"
            	"sticker_material"		"cph2024/sig_perfecto"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"160954758"
            }
            "7556"
            {
            	"name"		"cph2024_signature_perfecto_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_perfecto_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_perfecto_glitter"
            	"sticker_material"		"cph2024/sig_perfecto_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"160954758"
            }
            "7557"
            {
            	"name"		"cph2024_signature_perfecto_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_perfecto_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_perfecto_holo"
            	"sticker_material"		"cph2024/sig_perfecto_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"160954758"
            }
            "7558"
            {
            	"name"		"cph2024_signature_perfecto_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_perfecto_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_perfecto_gold"
            	"sticker_material"		"cph2024/sig_perfecto_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"33"
            	"tournament_player_id"		"160954758"
            }
            "7559"
            {
            	"name"		"cph2024_signature_goofy_1"
            	"item_name"		"#StickerKit_cph2024_signature_goofy"
            	"description_string"		"#StickerKit_desc_cph2024_signature_goofy"
            	"sticker_material"		"cph2024/sig_goofy"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"300617878"
            }
            "7560"
            {
            	"name"		"cph2024_signature_goofy_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_goofy_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_goofy_glitter"
            	"sticker_material"		"cph2024/sig_goofy_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"300617878"
            }
            "7561"
            {
            	"name"		"cph2024_signature_goofy_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_goofy_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_goofy_holo"
            	"sticker_material"		"cph2024/sig_goofy_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"300617878"
            }
            "7562"
            {
            	"name"		"cph2024_signature_goofy_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_goofy_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_goofy_gold"
            	"sticker_material"		"cph2024/sig_goofy_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"300617878"
            }
            "7563"
            {
            	"name"		"cph2024_signature_kylar_1"
            	"item_name"		"#StickerKit_cph2024_signature_kylar"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kylar"
            	"sticker_material"		"cph2024/sig_kylar"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"116431013"
            }
            "7564"
            {
            	"name"		"cph2024_signature_kylar_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_kylar_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kylar_glitter"
            	"sticker_material"		"cph2024/sig_kylar_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"116431013"
            }
            "7565"
            {
            	"name"		"cph2024_signature_kylar_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_kylar_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kylar_holo"
            	"sticker_material"		"cph2024/sig_kylar_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"116431013"
            }
            "7566"
            {
            	"name"		"cph2024_signature_kylar_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_kylar_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kylar_gold"
            	"sticker_material"		"cph2024/sig_kylar_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"116431013"
            }
            "7567"
            {
            	"name"		"cph2024_signature_dycha_1"
            	"item_name"		"#StickerKit_cph2024_signature_dycha"
            	"description_string"		"#StickerKit_desc_cph2024_signature_dycha"
            	"sticker_material"		"cph2024/sig_dycha"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"81151265"
            }
            "7568"
            {
            	"name"		"cph2024_signature_dycha_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_dycha_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_dycha_glitter"
            	"sticker_material"		"cph2024/sig_dycha_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"81151265"
            }
            "7569"
            {
            	"name"		"cph2024_signature_dycha_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_dycha_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_dycha_holo"
            	"sticker_material"		"cph2024/sig_dycha_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"81151265"
            }
            "7570"
            {
            	"name"		"cph2024_signature_dycha_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_dycha_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_dycha_gold"
            	"sticker_material"		"cph2024/sig_dycha_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"81151265"
            }
            "7571"
            {
            	"name"		"cph2024_signature_gla1ve_1"
            	"item_name"		"#StickerKit_cph2024_signature_gla1ve"
            	"description_string"		"#StickerKit_desc_cph2024_signature_gla1ve"
            	"sticker_material"		"cph2024/sig_gla1ve"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"50245293"
            }
            "7572"
            {
            	"name"		"cph2024_signature_gla1ve_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_gla1ve_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_gla1ve_glitter"
            	"sticker_material"		"cph2024/sig_gla1ve_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"50245293"
            }
            "7573"
            {
            	"name"		"cph2024_signature_gla1ve_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_gla1ve_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_gla1ve_holo"
            	"sticker_material"		"cph2024/sig_gla1ve_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"50245293"
            }
            "7574"
            {
            	"name"		"cph2024_signature_gla1ve_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_gla1ve_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_gla1ve_gold"
            	"sticker_material"		"cph2024/sig_gla1ve_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"50245293"
            }
            "7575"
            {
            	"name"		"cph2024_signature_hades_1"
            	"item_name"		"#StickerKit_cph2024_signature_hades"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hades"
            	"sticker_material"		"cph2024/sig_hades"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"90656280"
            }
            "7576"
            {
            	"name"		"cph2024_signature_hades_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_hades_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hades_glitter"
            	"sticker_material"		"cph2024/sig_hades_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"90656280"
            }
            "7577"
            {
            	"name"		"cph2024_signature_hades_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_hades_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hades_holo"
            	"sticker_material"		"cph2024/sig_hades_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"90656280"
            }
            "7578"
            {
            	"name"		"cph2024_signature_hades_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_hades_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hades_gold"
            	"sticker_material"		"cph2024/sig_hades_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"84"
            	"tournament_player_id"		"90656280"
            }
            "7579"
            {
            	"name"		"cph2024_signature_art_1"
            	"item_name"		"#StickerKit_cph2024_signature_art"
            	"description_string"		"#StickerKit_desc_cph2024_signature_art"
            	"sticker_material"		"cph2024/sig_art"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"83503844"
            }
            "7580"
            {
            	"name"		"cph2024_signature_art_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_art_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_art_glitter"
            	"sticker_material"		"cph2024/sig_art_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"83503844"
            }
            "7581"
            {
            	"name"		"cph2024_signature_art_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_art_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_art_holo"
            	"sticker_material"		"cph2024/sig_art_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"83503844"
            }
            "7582"
            {
            	"name"		"cph2024_signature_art_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_art_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_art_gold"
            	"sticker_material"		"cph2024/sig_art_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"83503844"
            }
            "7583"
            {
            	"name"		"cph2024_signature_chelo_1"
            	"item_name"		"#StickerKit_cph2024_signature_chelo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_chelo"
            	"sticker_material"		"cph2024/sig_chelo"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"107498100"
            }
            "7584"
            {
            	"name"		"cph2024_signature_chelo_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_chelo_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_chelo_glitter"
            	"sticker_material"		"cph2024/sig_chelo_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"107498100"
            }
            "7585"
            {
            	"name"		"cph2024_signature_chelo_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_chelo_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_chelo_holo"
            	"sticker_material"		"cph2024/sig_chelo_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"107498100"
            }
            "7586"
            {
            	"name"		"cph2024_signature_chelo_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_chelo_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_chelo_gold"
            	"sticker_material"		"cph2024/sig_chelo_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"107498100"
            }
            "7587"
            {
            	"name"		"cph2024_signature_fallen_1"
            	"item_name"		"#StickerKit_cph2024_signature_fallen"
            	"description_string"		"#StickerKit_desc_cph2024_signature_fallen"
            	"sticker_material"		"cph2024/sig_fallen"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"424467"
            }
            "7588"
            {
            	"name"		"cph2024_signature_fallen_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_fallen_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_fallen_glitter"
            	"sticker_material"		"cph2024/sig_fallen_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"424467"
            }
            "7589"
            {
            	"name"		"cph2024_signature_fallen_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_fallen_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_fallen_holo"
            	"sticker_material"		"cph2024/sig_fallen_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"424467"
            }
            "7590"
            {
            	"name"		"cph2024_signature_fallen_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_fallen_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_fallen_gold"
            	"sticker_material"		"cph2024/sig_fallen_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"424467"
            }
            "7591"
            {
            	"name"		"cph2024_signature_kscerato_1"
            	"item_name"		"#StickerKit_cph2024_signature_kscerato"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kscerato"
            	"sticker_material"		"cph2024/sig_kscerato"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"98234764"
            }
            "7592"
            {
            	"name"		"cph2024_signature_kscerato_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_kscerato_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kscerato_glitter"
            	"sticker_material"		"cph2024/sig_kscerato_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"98234764"
            }
            "7593"
            {
            	"name"		"cph2024_signature_kscerato_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_kscerato_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kscerato_holo"
            	"sticker_material"		"cph2024/sig_kscerato_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"98234764"
            }
            "7594"
            {
            	"name"		"cph2024_signature_kscerato_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_kscerato_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kscerato_gold"
            	"sticker_material"		"cph2024/sig_kscerato_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"98234764"
            }
            "7595"
            {
            	"name"		"cph2024_signature_yuurih_1"
            	"item_name"		"#StickerKit_cph2024_signature_yuurih"
            	"description_string"		"#StickerKit_desc_cph2024_signature_yuurih"
            	"sticker_material"		"cph2024/sig_yuurih"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"204704832"
            }
            "7596"
            {
            	"name"		"cph2024_signature_yuurih_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_yuurih_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_yuurih_glitter"
            	"sticker_material"		"cph2024/sig_yuurih_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"204704832"
            }
            "7597"
            {
            	"name"		"cph2024_signature_yuurih_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_yuurih_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_yuurih_holo"
            	"sticker_material"		"cph2024/sig_yuurih_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"204704832"
            }
            "7598"
            {
            	"name"		"cph2024_signature_yuurih_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_yuurih_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_yuurih_gold"
            	"sticker_material"		"cph2024/sig_yuurih_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"85"
            	"tournament_player_id"		"204704832"
            }
            "7599"
            {
            	"name"		"cph2024_signature_kyxsan_1"
            	"item_name"		"#StickerKit_cph2024_signature_kyxsan"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kyxsan"
            	"sticker_material"		"cph2024/sig_kyxsan"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"97016704"
            }
            "7600"
            {
            	"name"		"cph2024_signature_kyxsan_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_kyxsan_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kyxsan_glitter"
            	"sticker_material"		"cph2024/sig_kyxsan_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"97016704"
            }
            "7601"
            {
            	"name"		"cph2024_signature_kyxsan_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_kyxsan_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kyxsan_holo"
            	"sticker_material"		"cph2024/sig_kyxsan_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"97016704"
            }
            "7602"
            {
            	"name"		"cph2024_signature_kyxsan_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_kyxsan_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kyxsan_gold"
            	"sticker_material"		"cph2024/sig_kyxsan_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"97016704"
            }
            "7603"
            {
            	"name"		"cph2024_signature_nertz_1"
            	"item_name"		"#StickerKit_cph2024_signature_nertz"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nertz"
            	"sticker_material"		"cph2024/sig_nertz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"92860917"
            }
            "7604"
            {
            	"name"		"cph2024_signature_nertz_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_nertz_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nertz_glitter"
            	"sticker_material"		"cph2024/sig_nertz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"92860917"
            }
            "7605"
            {
            	"name"		"cph2024_signature_nertz_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_nertz_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nertz_holo"
            	"sticker_material"		"cph2024/sig_nertz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"92860917"
            }
            "7606"
            {
            	"name"		"cph2024_signature_nertz_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_nertz_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nertz_gold"
            	"sticker_material"		"cph2024/sig_nertz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"92860917"
            }
            "7607"
            {
            	"name"		"cph2024_signature_nicoodoz_1"
            	"item_name"		"#StickerKit_cph2024_signature_nicoodoz"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nicoodoz"
            	"sticker_material"		"cph2024/sig_nicoodoz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"112851399"
            }
            "7608"
            {
            	"name"		"cph2024_signature_nicoodoz_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_nicoodoz_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nicoodoz_glitter"
            	"sticker_material"		"cph2024/sig_nicoodoz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"112851399"
            }
            "7609"
            {
            	"name"		"cph2024_signature_nicoodoz_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_nicoodoz_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nicoodoz_holo"
            	"sticker_material"		"cph2024/sig_nicoodoz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"112851399"
            }
            "7610"
            {
            	"name"		"cph2024_signature_nicoodoz_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_nicoodoz_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nicoodoz_gold"
            	"sticker_material"		"cph2024/sig_nicoodoz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"112851399"
            }
            "7611"
            {
            	"name"		"cph2024_signature_sjuush_1"
            	"item_name"		"#StickerKit_cph2024_signature_sjuush"
            	"description_string"		"#StickerKit_desc_cph2024_signature_sjuush"
            	"sticker_material"		"cph2024/sig_sjuush"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"200443857"
            }
            "7612"
            {
            	"name"		"cph2024_signature_sjuush_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_sjuush_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_sjuush_glitter"
            	"sticker_material"		"cph2024/sig_sjuush_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"200443857"
            }
            "7613"
            {
            	"name"		"cph2024_signature_sjuush_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_sjuush_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_sjuush_holo"
            	"sticker_material"		"cph2024/sig_sjuush_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"200443857"
            }
            "7614"
            {
            	"name"		"cph2024_signature_sjuush_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_sjuush_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_sjuush_gold"
            	"sticker_material"		"cph2024/sig_sjuush_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"200443857"
            }
            "7615"
            {
            	"name"		"cph2024_signature_teses_1"
            	"item_name"		"#StickerKit_cph2024_signature_teses"
            	"description_string"		"#StickerKit_desc_cph2024_signature_teses"
            	"sticker_material"		"cph2024/sig_teses"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"36412550"
            }
            "7616"
            {
            	"name"		"cph2024_signature_teses_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_teses_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_teses_glitter"
            	"sticker_material"		"cph2024/sig_teses_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"36412550"
            }
            "7617"
            {
            	"name"		"cph2024_signature_teses_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_teses_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_teses_holo"
            	"sticker_material"		"cph2024/sig_teses_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"36412550"
            }
            "7618"
            {
            	"name"		"cph2024_signature_teses_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_teses_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_teses_gold"
            	"sticker_material"		"cph2024/sig_teses_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"95"
            	"tournament_player_id"		"36412550"
            }
            "7619"
            {
            	"name"		"cph2024_signature_calyx_1"
            	"item_name"		"#StickerKit_cph2024_signature_calyx"
            	"description_string"		"#StickerKit_desc_cph2024_signature_calyx"
            	"sticker_material"		"cph2024/sig_calyx"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"92280537"
            }
            "7620"
            {
            	"name"		"cph2024_signature_calyx_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_calyx_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_calyx_glitter"
            	"sticker_material"		"cph2024/sig_calyx_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"92280537"
            }
            "7621"
            {
            	"name"		"cph2024_signature_calyx_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_calyx_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_calyx_holo"
            	"sticker_material"		"cph2024/sig_calyx_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"92280537"
            }
            "7622"
            {
            	"name"		"cph2024_signature_calyx_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_calyx_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_calyx_gold"
            	"sticker_material"		"cph2024/sig_calyx_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"92280537"
            }
            "7623"
            {
            	"name"		"cph2024_signature_maj3r_1"
            	"item_name"		"#StickerKit_cph2024_signature_maj3r"
            	"description_string"		"#StickerKit_desc_cph2024_signature_maj3r"
            	"sticker_material"		"cph2024/sig_maj3r"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"7167161"
            }
            "7624"
            {
            	"name"		"cph2024_signature_maj3r_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_maj3r_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_maj3r_glitter"
            	"sticker_material"		"cph2024/sig_maj3r_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"7167161"
            }
            "7625"
            {
            	"name"		"cph2024_signature_maj3r_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_maj3r_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_maj3r_holo"
            	"sticker_material"		"cph2024/sig_maj3r_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"7167161"
            }
            "7626"
            {
            	"name"		"cph2024_signature_maj3r_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_maj3r_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_maj3r_gold"
            	"sticker_material"		"cph2024/sig_maj3r_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"7167161"
            }
            "7627"
            {
            	"name"		"cph2024_signature_wicadia_1"
            	"item_name"		"#StickerKit_cph2024_signature_wicadia"
            	"description_string"		"#StickerKit_desc_cph2024_signature_wicadia"
            	"sticker_material"		"cph2024/sig_wicadia"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"852248195"
            }
            "7628"
            {
            	"name"		"cph2024_signature_wicadia_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_wicadia_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_wicadia_glitter"
            	"sticker_material"		"cph2024/sig_wicadia_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"852248195"
            }
            "7629"
            {
            	"name"		"cph2024_signature_wicadia_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_wicadia_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_wicadia_holo"
            	"sticker_material"		"cph2024/sig_wicadia_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"852248195"
            }
            "7630"
            {
            	"name"		"cph2024_signature_wicadia_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_wicadia_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_wicadia_gold"
            	"sticker_material"		"cph2024/sig_wicadia_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"852248195"
            }
            "7631"
            {
            	"name"		"cph2024_signature_woxic_1"
            	"item_name"		"#StickerKit_cph2024_signature_woxic"
            	"description_string"		"#StickerKit_desc_cph2024_signature_woxic"
            	"sticker_material"		"cph2024/sig_woxic"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"123219778"
            }
            "7632"
            {
            	"name"		"cph2024_signature_woxic_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_woxic_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_woxic_glitter"
            	"sticker_material"		"cph2024/sig_woxic_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"123219778"
            }
            "7633"
            {
            	"name"		"cph2024_signature_woxic_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_woxic_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_woxic_holo"
            	"sticker_material"		"cph2024/sig_woxic_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"123219778"
            }
            "7634"
            {
            	"name"		"cph2024_signature_woxic_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_woxic_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_woxic_gold"
            	"sticker_material"		"cph2024/sig_woxic_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"123219778"
            }
            "7635"
            {
            	"name"		"cph2024_signature_xantares_1"
            	"item_name"		"#StickerKit_cph2024_signature_xantares"
            	"description_string"		"#StickerKit_desc_cph2024_signature_xantares"
            	"sticker_material"		"cph2024/sig_xantares"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"83853068"
            }
            "7636"
            {
            	"name"		"cph2024_signature_xantares_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_xantares_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_xantares_glitter"
            	"sticker_material"		"cph2024/sig_xantares_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"83853068"
            }
            "7637"
            {
            	"name"		"cph2024_signature_xantares_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_xantares_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_xantares_holo"
            	"sticker_material"		"cph2024/sig_xantares_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"83853068"
            }
            "7638"
            {
            	"name"		"cph2024_signature_xantares_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_xantares_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_xantares_gold"
            	"sticker_material"		"cph2024/sig_xantares_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"110"
            	"tournament_player_id"		"83853068"
            }
            "7639"
            {
            	"name"		"cph2024_signature_nawwk_1"
            	"item_name"		"#StickerKit_cph2024_signature_nawwk"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nawwk"
            	"sticker_material"		"cph2024/sig_nawwk"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"193386133"
            }
            "7640"
            {
            	"name"		"cph2024_signature_nawwk_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_nawwk_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nawwk_glitter"
            	"sticker_material"		"cph2024/sig_nawwk_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"193386133"
            }
            "7641"
            {
            	"name"		"cph2024_signature_nawwk_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_nawwk_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nawwk_holo"
            	"sticker_material"		"cph2024/sig_nawwk_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"193386133"
            }
            "7642"
            {
            	"name"		"cph2024_signature_nawwk_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_nawwk_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nawwk_gold"
            	"sticker_material"		"cph2024/sig_nawwk_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"193386133"
            }
            "7643"
            {
            	"name"		"cph2024_signature_cacanito_1"
            	"item_name"		"#StickerKit_cph2024_signature_cacanito"
            	"description_string"		"#StickerKit_desc_cph2024_signature_cacanito"
            	"sticker_material"		"cph2024/sig_cacanito"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"303390740"
            }
            "7644"
            {
            	"name"		"cph2024_signature_cacanito_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_cacanito_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_cacanito_glitter"
            	"sticker_material"		"cph2024/sig_cacanito_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"303390740"
            }
            "7645"
            {
            	"name"		"cph2024_signature_cacanito_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_cacanito_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_cacanito_holo"
            	"sticker_material"		"cph2024/sig_cacanito_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"303390740"
            }
            "7646"
            {
            	"name"		"cph2024_signature_cacanito_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_cacanito_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_cacanito_gold"
            	"sticker_material"		"cph2024/sig_cacanito_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"303390740"
            }
            "7647"
            {
            	"name"		"cph2024_signature_jkaem_1"
            	"item_name"		"#StickerKit_cph2024_signature_jkaem"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jkaem"
            	"sticker_material"		"cph2024/sig_jkaem"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"42442914"
            }
            "7648"
            {
            	"name"		"cph2024_signature_jkaem_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_jkaem_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jkaem_glitter"
            	"sticker_material"		"cph2024/sig_jkaem_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"42442914"
            }
            "7649"
            {
            	"name"		"cph2024_signature_jkaem_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_jkaem_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jkaem_holo"
            	"sticker_material"		"cph2024/sig_jkaem_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"42442914"
            }
            "7650"
            {
            	"name"		"cph2024_signature_jkaem_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_jkaem_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jkaem_gold"
            	"sticker_material"		"cph2024/sig_jkaem_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"42442914"
            }
            "7651"
            {
            	"name"		"cph2024_signature_sense_1"
            	"item_name"		"#StickerKit_cph2024_signature_sense"
            	"description_string"		"#StickerKit_desc_cph2024_signature_sense"
            	"sticker_material"		"cph2024/sig_sense"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"232661813"
            }
            "7652"
            {
            	"name"		"cph2024_signature_sense_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_sense_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_sense_glitter"
            	"sticker_material"		"cph2024/sig_sense_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"232661813"
            }
            "7653"
            {
            	"name"		"cph2024_signature_sense_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_sense_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_sense_holo"
            	"sticker_material"		"cph2024/sig_sense_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"232661813"
            }
            "7654"
            {
            	"name"		"cph2024_signature_sense_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_sense_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_sense_gold"
            	"sticker_material"		"cph2024/sig_sense_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"232661813"
            }
            "7655"
            {
            	"name"		"cph2024_signature_styko_1"
            	"item_name"		"#StickerKit_cph2024_signature_styko"
            	"description_string"		"#StickerKit_desc_cph2024_signature_styko"
            	"sticker_material"		"cph2024/sig_styko"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"55928431"
            }
            "7656"
            {
            	"name"		"cph2024_signature_styko_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_styko_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_styko_glitter"
            	"sticker_material"		"cph2024/sig_styko_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"55928431"
            }
            "7657"
            {
            	"name"		"cph2024_signature_styko_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_styko_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_styko_holo"
            	"sticker_material"		"cph2024/sig_styko_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"55928431"
            }
            "7658"
            {
            	"name"		"cph2024_signature_styko_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_styko_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_styko_gold"
            	"sticker_material"		"cph2024/sig_styko_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"117"
            	"tournament_player_id"		"55928431"
            }
            "7659"
            {
            	"name"		"cph2024_signature_acor_1"
            	"item_name"		"#StickerKit_cph2024_signature_acor"
            	"description_string"		"#StickerKit_desc_cph2024_signature_acor"
            	"sticker_material"		"cph2024/sig_acor"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"42677035"
            }
            "7660"
            {
            	"name"		"cph2024_signature_acor_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_acor_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_acor_glitter"
            	"sticker_material"		"cph2024/sig_acor_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"42677035"
            }
            "7661"
            {
            	"name"		"cph2024_signature_acor_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_acor_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_acor_holo"
            	"sticker_material"		"cph2024/sig_acor_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"42677035"
            }
            "7662"
            {
            	"name"		"cph2024_signature_acor_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_acor_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_acor_gold"
            	"sticker_material"		"cph2024/sig_acor_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"42677035"
            }
            "7663"
            {
            	"name"		"cph2024_signature_isak_1"
            	"item_name"		"#StickerKit_cph2024_signature_isak"
            	"description_string"		"#StickerKit_desc_cph2024_signature_isak"
            	"sticker_material"		"cph2024/sig_isak"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"111644637"
            }
            "7664"
            {
            	"name"		"cph2024_signature_isak_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_isak_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_isak_glitter"
            	"sticker_material"		"cph2024/sig_isak_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"111644637"
            }
            "7665"
            {
            	"name"		"cph2024_signature_isak_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_isak_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_isak_holo"
            	"sticker_material"		"cph2024/sig_isak_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"111644637"
            }
            "7666"
            {
            	"name"		"cph2024_signature_isak_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_isak_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_isak_gold"
            	"sticker_material"		"cph2024/sig_isak_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"111644637"
            }
            "7667"
            {
            	"name"		"cph2024_signature_keoz_1"
            	"item_name"		"#StickerKit_cph2024_signature_keoz"
            	"description_string"		"#StickerKit_desc_cph2024_signature_keoz"
            	"sticker_material"		"cph2024/sig_keoz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"138078516"
            }
            "7668"
            {
            	"name"		"cph2024_signature_keoz_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_keoz_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_keoz_glitter"
            	"sticker_material"		"cph2024/sig_keoz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"138078516"
            }
            "7669"
            {
            	"name"		"cph2024_signature_keoz_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_keoz_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_keoz_holo"
            	"sticker_material"		"cph2024/sig_keoz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"138078516"
            }
            "7670"
            {
            	"name"		"cph2024_signature_keoz_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_keoz_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_keoz_gold"
            	"sticker_material"		"cph2024/sig_keoz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"138078516"
            }
            "7671"
            {
            	"name"		"cph2024_signature_snax_1"
            	"item_name"		"#StickerKit_cph2024_signature_snax"
            	"description_string"		"#StickerKit_desc_cph2024_signature_snax"
            	"sticker_material"		"cph2024/sig_snax"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"21875845"
            }
            "7672"
            {
            	"name"		"cph2024_signature_snax_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_snax_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_snax_glitter"
            	"sticker_material"		"cph2024/sig_snax_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"21875845"
            }
            "7673"
            {
            	"name"		"cph2024_signature_snax_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_snax_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_snax_holo"
            	"sticker_material"		"cph2024/sig_snax_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"21875845"
            }
            "7674"
            {
            	"name"		"cph2024_signature_snax_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_snax_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_snax_gold"
            	"sticker_material"		"cph2024/sig_snax_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"21875845"
            }
            "7675"
            {
            	"name"		"cph2024_signature_volt_1"
            	"item_name"		"#StickerKit_cph2024_signature_volt"
            	"description_string"		"#StickerKit_desc_cph2024_signature_volt"
            	"sticker_material"		"cph2024/sig_volt"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"195488719"
            }
            "7676"
            {
            	"name"		"cph2024_signature_volt_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_volt_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_volt_glitter"
            	"sticker_material"		"cph2024/sig_volt_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"195488719"
            }
            "7677"
            {
            	"name"		"cph2024_signature_volt_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_volt_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_volt_holo"
            	"sticker_material"		"cph2024/sig_volt_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"195488719"
            }
            "7678"
            {
            	"name"		"cph2024_signature_volt_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_volt_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_volt_gold"
            	"sticker_material"		"cph2024/sig_volt_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"115"
            	"tournament_player_id"		"195488719"
            }
            "7679"
            {
            	"name"		"cph2024_signature_arrozdoce_1"
            	"item_name"		"#StickerKit_cph2024_signature_arrozdoce"
            	"description_string"		"#StickerKit_desc_cph2024_signature_arrozdoce"
            	"sticker_material"		"cph2024/sig_arrozdoce"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"13492074"
            }
            "7680"
            {
            	"name"		"cph2024_signature_arrozdoce_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_arrozdoce_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_arrozdoce_glitter"
            	"sticker_material"		"cph2024/sig_arrozdoce_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"13492074"
            }
            "7681"
            {
            	"name"		"cph2024_signature_arrozdoce_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_arrozdoce_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_arrozdoce_holo"
            	"sticker_material"		"cph2024/sig_arrozdoce_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"13492074"
            }
            "7682"
            {
            	"name"		"cph2024_signature_arrozdoce_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_arrozdoce_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_arrozdoce_gold"
            	"sticker_material"		"cph2024/sig_arrozdoce_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"13492074"
            }
            "7683"
            {
            	"name"		"cph2024_signature_ewjerkz_1"
            	"item_name"		"#StickerKit_cph2024_signature_ewjerkz"
            	"description_string"		"#StickerKit_desc_cph2024_signature_ewjerkz"
            	"sticker_material"		"cph2024/sig_ewjerkz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"302194534"
            }
            "7684"
            {
            	"name"		"cph2024_signature_ewjerkz_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_ewjerkz_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_ewjerkz_glitter"
            	"sticker_material"		"cph2024/sig_ewjerkz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"302194534"
            }
            "7685"
            {
            	"name"		"cph2024_signature_ewjerkz_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_ewjerkz_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_ewjerkz_holo"
            	"sticker_material"		"cph2024/sig_ewjerkz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"302194534"
            }
            "7686"
            {
            	"name"		"cph2024_signature_ewjerkz_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_ewjerkz_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_ewjerkz_gold"
            	"sticker_material"		"cph2024/sig_ewjerkz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"302194534"
            }
            "7687"
            {
            	"name"		"cph2024_signature_mutiris_1"
            	"item_name"		"#StickerKit_cph2024_signature_mutiris"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mutiris"
            	"sticker_material"		"cph2024/sig_mutiris"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"37715442"
            }
            "7688"
            {
            	"name"		"cph2024_signature_mutiris_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_mutiris_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mutiris_glitter"
            	"sticker_material"		"cph2024/sig_mutiris_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"37715442"
            }
            "7689"
            {
            	"name"		"cph2024_signature_mutiris_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_mutiris_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mutiris_holo"
            	"sticker_material"		"cph2024/sig_mutiris_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"37715442"
            }
            "7690"
            {
            	"name"		"cph2024_signature_mutiris_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_mutiris_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mutiris_gold"
            	"sticker_material"		"cph2024/sig_mutiris_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"37715442"
            }
            "7691"
            {
            	"name"		"cph2024_signature_roman_1"
            	"item_name"		"#StickerKit_cph2024_signature_roman"
            	"description_string"		"#StickerKit_desc_cph2024_signature_roman"
            	"sticker_material"		"cph2024/sig_roman"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"34129763"
            }
            "7692"
            {
            	"name"		"cph2024_signature_roman_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_roman_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_roman_glitter"
            	"sticker_material"		"cph2024/sig_roman_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"34129763"
            }
            "7693"
            {
            	"name"		"cph2024_signature_roman_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_roman_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_roman_holo"
            	"sticker_material"		"cph2024/sig_roman_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"34129763"
            }
            "7694"
            {
            	"name"		"cph2024_signature_roman_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_roman_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_roman_gold"
            	"sticker_material"		"cph2024/sig_roman_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"34129763"
            }
            "7695"
            {
            	"name"		"cph2024_signature_story_1"
            	"item_name"		"#StickerKit_cph2024_signature_story"
            	"description_string"		"#StickerKit_desc_cph2024_signature_story"
            	"sticker_material"		"cph2024/sig_story"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"105182632"
            }
            "7696"
            {
            	"name"		"cph2024_signature_story_1_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_story_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_story_glitter"
            	"sticker_material"		"cph2024/sig_story_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"105182632"
            }
            "7697"
            {
            	"name"		"cph2024_signature_story_1_holo"
            	"item_name"		"#StickerKit_cph2024_signature_story_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_story_holo"
            	"sticker_material"		"cph2024/sig_story_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"105182632"
            }
            "7698"
            {
            	"name"		"cph2024_signature_story_1_gold"
            	"item_name"		"#StickerKit_cph2024_signature_story_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_story_gold"
            	"sticker_material"		"cph2024/sig_story_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"129"
            	"tournament_player_id"		"105182632"
            }
            "7699"
            {
            	"name"		"cph2024_signature_biguzera_4"
            	"item_name"		"#StickerKit_cph2024_signature_biguzera"
            	"description_string"		"#StickerKit_desc_cph2024_signature_biguzera"
            	"sticker_material"		"cph2024/sig_biguzera"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"55043156"
            }
            "7700"
            {
            	"name"		"cph2024_signature_biguzera_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_biguzera_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_biguzera_glitter"
            	"sticker_material"		"cph2024/sig_biguzera_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"55043156"
            }
            "7701"
            {
            	"name"		"cph2024_signature_biguzera_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_biguzera_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_biguzera_holo"
            	"sticker_material"		"cph2024/sig_biguzera_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"55043156"
            }
            "7702"
            {
            	"name"		"cph2024_signature_biguzera_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_biguzera_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_biguzera_gold"
            	"sticker_material"		"cph2024/sig_biguzera_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"55043156"
            }
            "7703"
            {
            	"name"		"cph2024_signature_kauez_4"
            	"item_name"		"#StickerKit_cph2024_signature_kauez"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kauez"
            	"sticker_material"		"cph2024/sig_kauez"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"425391947"
            }
            "7704"
            {
            	"name"		"cph2024_signature_kauez_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_kauez_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kauez_glitter"
            	"sticker_material"		"cph2024/sig_kauez_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"425391947"
            }
            "7705"
            {
            	"name"		"cph2024_signature_kauez_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_kauez_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kauez_holo"
            	"sticker_material"		"cph2024/sig_kauez_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"425391947"
            }
            "7706"
            {
            	"name"		"cph2024_signature_kauez_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_kauez_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kauez_gold"
            	"sticker_material"		"cph2024/sig_kauez_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"425391947"
            }
            "7707"
            {
            	"name"		"cph2024_signature_lux_4"
            	"item_name"		"#StickerKit_cph2024_signature_lux"
            	"description_string"		"#StickerKit_desc_cph2024_signature_lux"
            	"sticker_material"		"cph2024/sig_lux"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"113751940"
            }
            "7708"
            {
            	"name"		"cph2024_signature_lux_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_lux_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_lux_glitter"
            	"sticker_material"		"cph2024/sig_lux_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"113751940"
            }
            "7709"
            {
            	"name"		"cph2024_signature_lux_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_lux_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_lux_holo"
            	"sticker_material"		"cph2024/sig_lux_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"113751940"
            }
            "7710"
            {
            	"name"		"cph2024_signature_lux_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_lux_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_lux_gold"
            	"sticker_material"		"cph2024/sig_lux_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"113751940"
            }
            "7711"
            {
            	"name"		"cph2024_signature_n1ssim_4"
            	"item_name"		"#StickerKit_cph2024_signature_n1ssim"
            	"description_string"		"#StickerKit_desc_cph2024_signature_n1ssim"
            	"sticker_material"		"cph2024/sig_n1ssim"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"101497868"
            }
            "7712"
            {
            	"name"		"cph2024_signature_n1ssim_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_n1ssim_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_n1ssim_glitter"
            	"sticker_material"		"cph2024/sig_n1ssim_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"101497868"
            }
            "7713"
            {
            	"name"		"cph2024_signature_n1ssim_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_n1ssim_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_n1ssim_holo"
            	"sticker_material"		"cph2024/sig_n1ssim_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"101497868"
            }
            "7714"
            {
            	"name"		"cph2024_signature_n1ssim_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_n1ssim_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_n1ssim_gold"
            	"sticker_material"		"cph2024/sig_n1ssim_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"101497868"
            }
            "7715"
            {
            	"name"		"cph2024_signature_nqz_4"
            	"item_name"		"#StickerKit_cph2024_signature_nqz"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nqz"
            	"sticker_material"		"cph2024/sig_nqz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"390076777"
            }
            "7716"
            {
            	"name"		"cph2024_signature_nqz_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_nqz_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nqz_glitter"
            	"sticker_material"		"cph2024/sig_nqz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"390076777"
            }
            "7717"
            {
            	"name"		"cph2024_signature_nqz_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_nqz_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nqz_holo"
            	"sticker_material"		"cph2024/sig_nqz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"390076777"
            }
            "7718"
            {
            	"name"		"cph2024_signature_nqz_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_nqz_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nqz_gold"
            	"sticker_material"		"cph2024/sig_nqz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"102"
            	"tournament_player_id"		"390076777"
            }
            "7719"
            {
            	"name"		"cph2024_signature_decenty_4"
            	"item_name"		"#StickerKit_cph2024_signature_decenty"
            	"description_string"		"#StickerKit_desc_cph2024_signature_decenty"
            	"sticker_material"		"cph2024/sig_decenty"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"346906182"
            }
            "7720"
            {
            	"name"		"cph2024_signature_decenty_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_decenty_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_decenty_glitter"
            	"sticker_material"		"cph2024/sig_decenty_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"346906182"
            }
            "7721"
            {
            	"name"		"cph2024_signature_decenty_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_decenty_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_decenty_holo"
            	"sticker_material"		"cph2024/sig_decenty_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"346906182"
            }
            "7722"
            {
            	"name"		"cph2024_signature_decenty_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_decenty_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_decenty_gold"
            	"sticker_material"		"cph2024/sig_decenty_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"346906182"
            }
            "7723"
            {
            	"name"		"cph2024_signature_felps_4"
            	"item_name"		"#StickerKit_cph2024_signature_felps"
            	"description_string"		"#StickerKit_desc_cph2024_signature_felps"
            	"sticker_material"		"cph2024/sig_felps"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"22765766"
            }
            "7724"
            {
            	"name"		"cph2024_signature_felps_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_felps_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_felps_glitter"
            	"sticker_material"		"cph2024/sig_felps_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"22765766"
            }
            "7725"
            {
            	"name"		"cph2024_signature_felps_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_felps_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_felps_holo"
            	"sticker_material"		"cph2024/sig_felps_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"22765766"
            }
            "7726"
            {
            	"name"		"cph2024_signature_felps_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_felps_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_felps_gold"
            	"sticker_material"		"cph2024/sig_felps_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"22765766"
            }
            "7727"
            {
            	"name"		"cph2024_signature_hen1_4"
            	"item_name"		"#StickerKit_cph2024_signature_hen1"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hen1"
            	"sticker_material"		"cph2024/sig_hen1"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"57761535"
            }
            "7728"
            {
            	"name"		"cph2024_signature_hen1_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_hen1_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hen1_glitter"
            	"sticker_material"		"cph2024/sig_hen1_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"57761535"
            }
            "7729"
            {
            	"name"		"cph2024_signature_hen1_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_hen1_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hen1_holo"
            	"sticker_material"		"cph2024/sig_hen1_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"57761535"
            }
            "7730"
            {
            	"name"		"cph2024_signature_hen1_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_hen1_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_hen1_gold"
            	"sticker_material"		"cph2024/sig_hen1_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"57761535"
            }
            "7731"
            {
            	"name"		"cph2024_signature_noway_4"
            	"item_name"		"#StickerKit_cph2024_signature_noway"
            	"description_string"		"#StickerKit_desc_cph2024_signature_noway"
            	"sticker_material"		"cph2024/sig_noway"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"839943839"
            }
            "7732"
            {
            	"name"		"cph2024_signature_noway_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_noway_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_noway_glitter"
            	"sticker_material"		"cph2024/sig_noway_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"839943839"
            }
            "7733"
            {
            	"name"		"cph2024_signature_noway_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_noway_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_noway_holo"
            	"sticker_material"		"cph2024/sig_noway_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"839943839"
            }
            "7734"
            {
            	"name"		"cph2024_signature_noway_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_noway_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_noway_gold"
            	"sticker_material"		"cph2024/sig_noway_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"839943839"
            }
            "7735"
            {
            	"name"		"cph2024_signature_vini_4"
            	"item_name"		"#StickerKit_cph2024_signature_vini"
            	"description_string"		"#StickerKit_desc_cph2024_signature_vini"
            	"sticker_material"		"cph2024/sig_vini"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"36104456"
            }
            "7736"
            {
            	"name"		"cph2024_signature_vini_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_vini_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_vini_glitter"
            	"sticker_material"		"cph2024/sig_vini_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"36104456"
            }
            "7737"
            {
            	"name"		"cph2024_signature_vini_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_vini_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_vini_holo"
            	"sticker_material"		"cph2024/sig_vini_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"36104456"
            }
            "7738"
            {
            	"name"		"cph2024_signature_vini_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_vini_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_vini_gold"
            	"sticker_material"		"cph2024/sig_vini_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"113"
            	"tournament_player_id"		"36104456"
            }
            "7739"
            {
            	"name"		"cph2024_signature_910_4"
            	"item_name"		"#StickerKit_cph2024_signature_910"
            	"description_string"		"#StickerKit_desc_cph2024_signature_910"
            	"sticker_material"		"cph2024/sig_910"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1243297617"
            }
            "7740"
            {
            	"name"		"cph2024_signature_910_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_910_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_910_glitter"
            	"sticker_material"		"cph2024/sig_910_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1243297617"
            }
            "7741"
            {
            	"name"		"cph2024_signature_910_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_910_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_910_holo"
            	"sticker_material"		"cph2024/sig_910_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1243297617"
            }
            "7742"
            {
            	"name"		"cph2024_signature_910_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_910_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_910_gold"
            	"sticker_material"		"cph2024/sig_910_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1243297617"
            }
            "7743"
            {
            	"name"		"cph2024_signature_blitz_4"
            	"item_name"		"#StickerKit_cph2024_signature_blitz"
            	"description_string"		"#StickerKit_desc_cph2024_signature_blitz"
            	"sticker_material"		"cph2024/sig_blitz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"999558360"
            }
            "7744"
            {
            	"name"		"cph2024_signature_blitz_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_blitz_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_blitz_glitter"
            	"sticker_material"		"cph2024/sig_blitz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"999558360"
            }
            "7745"
            {
            	"name"		"cph2024_signature_blitz_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_blitz_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_blitz_holo"
            	"sticker_material"		"cph2024/sig_blitz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"999558360"
            }
            "7746"
            {
            	"name"		"cph2024_signature_blitz_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_blitz_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_blitz_gold"
            	"sticker_material"		"cph2024/sig_blitz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"999558360"
            }
            "7747"
            {
            	"name"		"cph2024_signature_mzinho_4"
            	"item_name"		"#StickerKit_cph2024_signature_mzinho"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mzinho"
            	"sticker_material"		"cph2024/sig_mzinho"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"878556854"
            }
            "7748"
            {
            	"name"		"cph2024_signature_mzinho_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_mzinho_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mzinho_glitter"
            	"sticker_material"		"cph2024/sig_mzinho_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"878556854"
            }
            "7749"
            {
            	"name"		"cph2024_signature_mzinho_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_mzinho_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mzinho_holo"
            	"sticker_material"		"cph2024/sig_mzinho_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"878556854"
            }
            "7750"
            {
            	"name"		"cph2024_signature_mzinho_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_mzinho_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mzinho_gold"
            	"sticker_material"		"cph2024/sig_mzinho_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"878556854"
            }
            "7751"
            {
            	"name"		"cph2024_signature_senzu_4"
            	"item_name"		"#StickerKit_cph2024_signature_senzu"
            	"description_string"		"#StickerKit_desc_cph2024_signature_senzu"
            	"sticker_material"		"cph2024/sig_senzu"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"960454289"
            }
            "7752"
            {
            	"name"		"cph2024_signature_senzu_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_senzu_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_senzu_glitter"
            	"sticker_material"		"cph2024/sig_senzu_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"960454289"
            }
            "7753"
            {
            	"name"		"cph2024_signature_senzu_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_senzu_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_senzu_holo"
            	"sticker_material"		"cph2024/sig_senzu_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"960454289"
            }
            "7754"
            {
            	"name"		"cph2024_signature_senzu_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_senzu_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_senzu_gold"
            	"sticker_material"		"cph2024/sig_senzu_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"960454289"
            }
            "7755"
            {
            	"name"		"cph2024_signature_techno4k_4"
            	"item_name"		"#StickerKit_cph2024_signature_techno4k"
            	"description_string"		"#StickerKit_desc_cph2024_signature_techno4k"
            	"sticker_material"		"cph2024/sig_techno4k"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1006074432"
            }
            "7756"
            {
            	"name"		"cph2024_signature_techno4k_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_techno4k_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_techno4k_glitter"
            	"sticker_material"		"cph2024/sig_techno4k_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1006074432"
            }
            "7757"
            {
            	"name"		"cph2024_signature_techno4k_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_techno4k_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_techno4k_holo"
            	"sticker_material"		"cph2024/sig_techno4k_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1006074432"
            }
            "7758"
            {
            	"name"		"cph2024_signature_techno4k_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_techno4k_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_techno4k_gold"
            	"sticker_material"		"cph2024/sig_techno4k_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"122"
            	"tournament_player_id"		"1006074432"
            }
            "7759"
            {
            	"name"		"cph2024_signature_forester_4"
            	"item_name"		"#StickerKit_cph2024_signature_forester"
            	"description_string"		"#StickerKit_desc_cph2024_signature_forester"
            	"sticker_material"		"cph2024/sig_forester"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"67083025"
            }
            "7760"
            {
            	"name"		"cph2024_signature_forester_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_forester_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_forester_glitter"
            	"sticker_material"		"cph2024/sig_forester_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"67083025"
            }
            "7761"
            {
            	"name"		"cph2024_signature_forester_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_forester_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_forester_holo"
            	"sticker_material"		"cph2024/sig_forester_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"67083025"
            }
            "7762"
            {
            	"name"		"cph2024_signature_forester_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_forester_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_forester_gold"
            	"sticker_material"		"cph2024/sig_forester_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"67083025"
            }
            "7763"
            {
            	"name"		"cph2024_signature_icy_4"
            	"item_name"		"#StickerKit_cph2024_signature_icy"
            	"description_string"		"#StickerKit_desc_cph2024_signature_icy"
            	"sticker_material"		"cph2024/sig_icy"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"94843300"
            }
            "7764"
            {
            	"name"		"cph2024_signature_icy_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_icy_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_icy_glitter"
            	"sticker_material"		"cph2024/sig_icy_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"94843300"
            }
            "7765"
            {
            	"name"		"cph2024_signature_icy_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_icy_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_icy_holo"
            	"sticker_material"		"cph2024/sig_icy_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"94843300"
            }
            "7766"
            {
            	"name"		"cph2024_signature_icy_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_icy_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_icy_gold"
            	"sticker_material"		"cph2024/sig_icy_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"94843300"
            }
            "7767"
            {
            	"name"		"cph2024_signature_krad_4"
            	"item_name"		"#StickerKit_cph2024_signature_krad"
            	"description_string"		"#StickerKit_desc_cph2024_signature_krad"
            	"sticker_material"		"cph2024/sig_krad"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"71642904"
            }
            "7768"
            {
            	"name"		"cph2024_signature_krad_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_krad_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_krad_glitter"
            	"sticker_material"		"cph2024/sig_krad_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"71642904"
            }
            "7769"
            {
            	"name"		"cph2024_signature_krad_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_krad_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_krad_holo"
            	"sticker_material"		"cph2024/sig_krad_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"71642904"
            }
            "7770"
            {
            	"name"		"cph2024_signature_krad_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_krad_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_krad_gold"
            	"sticker_material"		"cph2024/sig_krad_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"71642904"
            }
            "7771"
            {
            	"name"		"cph2024_signature_nickelback_4"
            	"item_name"		"#StickerKit_cph2024_signature_nickelback"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nickelback"
            	"sticker_material"		"cph2024/sig_nickelback"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"1882779"
            }
            "7772"
            {
            	"name"		"cph2024_signature_nickelback_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_nickelback_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nickelback_glitter"
            	"sticker_material"		"cph2024/sig_nickelback_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"1882779"
            }
            "7773"
            {
            	"name"		"cph2024_signature_nickelback_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_nickelback_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nickelback_holo"
            	"sticker_material"		"cph2024/sig_nickelback_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"1882779"
            }
            "7774"
            {
            	"name"		"cph2024_signature_nickelback_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_nickelback_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nickelback_gold"
            	"sticker_material"		"cph2024/sig_nickelback_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"1882779"
            }
            "7775"
            {
            	"name"		"cph2024_signature_travis_4"
            	"item_name"		"#StickerKit_cph2024_signature_travis"
            	"description_string"		"#StickerKit_desc_cph2024_signature_travis"
            	"sticker_material"		"cph2024/sig_travis"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"402704995"
            }
            "7776"
            {
            	"name"		"cph2024_signature_travis_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_travis_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_travis_glitter"
            	"sticker_material"		"cph2024/sig_travis_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"402704995"
            }
            "7777"
            {
            	"name"		"cph2024_signature_travis_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_travis_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_travis_holo"
            	"sticker_material"		"cph2024/sig_travis_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"402704995"
            }
            "7778"
            {
            	"name"		"cph2024_signature_travis_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_travis_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_travis_gold"
            	"sticker_material"		"cph2024/sig_travis_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"123"
            	"tournament_player_id"		"402704995"
            }
            "7779"
            {
            	"name"		"cph2024_signature_kraghen_4"
            	"item_name"		"#StickerKit_cph2024_signature_kraghen"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kraghen"
            	"sticker_material"		"cph2024/sig_kraghen"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"86933217"
            }
            "7780"
            {
            	"name"		"cph2024_signature_kraghen_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_kraghen_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kraghen_glitter"
            	"sticker_material"		"cph2024/sig_kraghen_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"86933217"
            }
            "7781"
            {
            	"name"		"cph2024_signature_kraghen_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_kraghen_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kraghen_holo"
            	"sticker_material"		"cph2024/sig_kraghen_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"86933217"
            }
            "7782"
            {
            	"name"		"cph2024_signature_kraghen_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_kraghen_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_kraghen_gold"
            	"sticker_material"		"cph2024/sig_kraghen_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"86933217"
            }
            "7783"
            {
            	"name"		"cph2024_signature_nodios_4"
            	"item_name"		"#StickerKit_cph2024_signature_nodios"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nodios"
            	"sticker_material"		"cph2024/sig_nodios"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"110610542"
            }
            "7784"
            {
            	"name"		"cph2024_signature_nodios_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_nodios_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nodios_glitter"
            	"sticker_material"		"cph2024/sig_nodios_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"110610542"
            }
            "7785"
            {
            	"name"		"cph2024_signature_nodios_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_nodios_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nodios_holo"
            	"sticker_material"		"cph2024/sig_nodios_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"110610542"
            }
            "7786"
            {
            	"name"		"cph2024_signature_nodios_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_nodios_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nodios_gold"
            	"sticker_material"		"cph2024/sig_nodios_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"110610542"
            }
            "7787"
            {
            	"name"		"cph2024_signature_patti_4"
            	"item_name"		"#StickerKit_cph2024_signature_patti"
            	"description_string"		"#StickerKit_desc_cph2024_signature_patti"
            	"sticker_material"		"cph2024/sig_patti"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"59724778"
            }
            "7788"
            {
            	"name"		"cph2024_signature_patti_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_patti_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_patti_glitter"
            	"sticker_material"		"cph2024/sig_patti_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"59724778"
            }
            "7789"
            {
            	"name"		"cph2024_signature_patti_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_patti_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_patti_holo"
            	"sticker_material"		"cph2024/sig_patti_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"59724778"
            }
            "7790"
            {
            	"name"		"cph2024_signature_patti_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_patti_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_patti_gold"
            	"sticker_material"		"cph2024/sig_patti_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"59724778"
            }
            "7791"
            {
            	"name"		"cph2024_signature_queenix_4"
            	"item_name"		"#StickerKit_cph2024_signature_queenix"
            	"description_string"		"#StickerKit_desc_cph2024_signature_queenix"
            	"sticker_material"		"cph2024/sig_queenix"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"70280269"
            }
            "7792"
            {
            	"name"		"cph2024_signature_queenix_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_queenix_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_queenix_glitter"
            	"sticker_material"		"cph2024/sig_queenix_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"70280269"
            }
            "7793"
            {
            	"name"		"cph2024_signature_queenix_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_queenix_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_queenix_holo"
            	"sticker_material"		"cph2024/sig_queenix_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"70280269"
            }
            "7794"
            {
            	"name"		"cph2024_signature_queenix_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_queenix_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_queenix_gold"
            	"sticker_material"		"cph2024/sig_queenix_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"70280269"
            }
            "7795"
            {
            	"name"		"cph2024_signature_salazar_4"
            	"item_name"		"#StickerKit_cph2024_signature_salazar"
            	"description_string"		"#StickerKit_desc_cph2024_signature_salazar"
            	"sticker_material"		"cph2024/sig_salazar"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"141998048"
            }
            "7796"
            {
            	"name"		"cph2024_signature_salazar_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_salazar_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_salazar_glitter"
            	"sticker_material"		"cph2024/sig_salazar_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"141998048"
            }
            "7797"
            {
            	"name"		"cph2024_signature_salazar_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_salazar_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_salazar_holo"
            	"sticker_material"		"cph2024/sig_salazar_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"141998048"
            }
            "7798"
            {
            	"name"		"cph2024_signature_salazar_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_salazar_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_salazar_gold"
            	"sticker_material"		"cph2024/sig_salazar_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"124"
            	"tournament_player_id"		"141998048"
            }
            "7799"
            {
            	"name"		"cph2024_signature_adams_4"
            	"item_name"		"#StickerKit_cph2024_signature_adams"
            	"description_string"		"#StickerKit_desc_cph2024_signature_adams"
            	"sticker_material"		"cph2024/sig_adams"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"8124135"
            }
            "7800"
            {
            	"name"		"cph2024_signature_adams_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_adams_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_adams_glitter"
            	"sticker_material"		"cph2024/sig_adams_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"8124135"
            }
            "7801"
            {
            	"name"		"cph2024_signature_adams_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_adams_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_adams_holo"
            	"sticker_material"		"cph2024/sig_adams_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"8124135"
            }
            "7802"
            {
            	"name"		"cph2024_signature_adams_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_adams_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_adams_gold"
            	"sticker_material"		"cph2024/sig_adams_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"8124135"
            }
            "7803"
            {
            	"name"		"cph2024_signature_dav1g_4"
            	"item_name"		"#StickerKit_cph2024_signature_dav1g"
            	"description_string"		"#StickerKit_desc_cph2024_signature_dav1g"
            	"sticker_material"		"cph2024/sig_dav1g"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"457082328"
            }
            "7804"
            {
            	"name"		"cph2024_signature_dav1g_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_dav1g_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_dav1g_glitter"
            	"sticker_material"		"cph2024/sig_dav1g_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"457082328"
            }
            "7805"
            {
            	"name"		"cph2024_signature_dav1g_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_dav1g_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_dav1g_holo"
            	"sticker_material"		"cph2024/sig_dav1g_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"457082328"
            }
            "7806"
            {
            	"name"		"cph2024_signature_dav1g_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_dav1g_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_dav1g_gold"
            	"sticker_material"		"cph2024/sig_dav1g_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"457082328"
            }
            "7807"
            {
            	"name"		"cph2024_signature_just_4"
            	"item_name"		"#StickerKit_cph2024_signature_just"
            	"description_string"		"#StickerKit_desc_cph2024_signature_just"
            	"sticker_material"		"cph2024/sig_just"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"52722111"
            }
            "7808"
            {
            	"name"		"cph2024_signature_just_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_just_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_just_glitter"
            	"sticker_material"		"cph2024/sig_just_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"52722111"
            }
            "7809"
            {
            	"name"		"cph2024_signature_just_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_just_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_just_holo"
            	"sticker_material"		"cph2024/sig_just_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"52722111"
            }
            "7810"
            {
            	"name"		"cph2024_signature_just_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_just_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_just_gold"
            	"sticker_material"		"cph2024/sig_just_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"52722111"
            }
            "7811"
            {
            	"name"		"cph2024_signature_mopoz_4"
            	"item_name"		"#StickerKit_cph2024_signature_mopoz"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mopoz"
            	"sticker_material"		"cph2024/sig_mopoz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"37931638"
            }
            "7812"
            {
            	"name"		"cph2024_signature_mopoz_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_mopoz_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mopoz_glitter"
            	"sticker_material"		"cph2024/sig_mopoz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"37931638"
            }
            "7813"
            {
            	"name"		"cph2024_signature_mopoz_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_mopoz_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mopoz_holo"
            	"sticker_material"		"cph2024/sig_mopoz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"37931638"
            }
            "7814"
            {
            	"name"		"cph2024_signature_mopoz_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_mopoz_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_mopoz_gold"
            	"sticker_material"		"cph2024/sig_mopoz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"37931638"
            }
            "7815"
            {
            	"name"		"cph2024_signature_stadodo_4"
            	"item_name"		"#StickerKit_cph2024_signature_stadodo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_stadodo"
            	"sticker_material"		"cph2024/sig_stadodo"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"87137134"
            }
            "7816"
            {
            	"name"		"cph2024_signature_stadodo_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_stadodo_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_stadodo_glitter"
            	"sticker_material"		"cph2024/sig_stadodo_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"87137134"
            }
            "7817"
            {
            	"name"		"cph2024_signature_stadodo_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_stadodo_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_stadodo_holo"
            	"sticker_material"		"cph2024/sig_stadodo_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"87137134"
            }
            "7818"
            {
            	"name"		"cph2024_signature_stadodo_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_stadodo_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_stadodo_gold"
            	"sticker_material"		"cph2024/sig_stadodo_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"125"
            	"tournament_player_id"		"87137134"
            }
            "7819"
            {
            	"name"		"cph2024_signature_b4rtin_4"
            	"item_name"		"#StickerKit_cph2024_signature_b4rtin"
            	"description_string"		"#StickerKit_desc_cph2024_signature_b4rtin"
            	"sticker_material"		"cph2024/sig_b4rtin"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"169818854"
            }
            "7820"
            {
            	"name"		"cph2024_signature_b4rtin_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_b4rtin_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_b4rtin_glitter"
            	"sticker_material"		"cph2024/sig_b4rtin_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"169818854"
            }
            "7821"
            {
            	"name"		"cph2024_signature_b4rtin_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_b4rtin_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_b4rtin_holo"
            	"sticker_material"		"cph2024/sig_b4rtin_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"169818854"
            }
            "7822"
            {
            	"name"		"cph2024_signature_b4rtin_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_b4rtin_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_b4rtin_gold"
            	"sticker_material"		"cph2024/sig_b4rtin_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"169818854"
            }
            "7823"
            {
            	"name"		"cph2024_signature_coldzera_4"
            	"item_name"		"#StickerKit_cph2024_signature_coldzera"
            	"description_string"		"#StickerKit_desc_cph2024_signature_coldzera"
            	"sticker_material"		"cph2024/sig_coldzera"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"79720871"
            }
            "7824"
            {
            	"name"		"cph2024_signature_coldzera_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_coldzera_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_coldzera_glitter"
            	"sticker_material"		"cph2024/sig_coldzera_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"79720871"
            }
            "7825"
            {
            	"name"		"cph2024_signature_coldzera_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_coldzera_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_coldzera_holo"
            	"sticker_material"		"cph2024/sig_coldzera_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"79720871"
            }
            "7826"
            {
            	"name"		"cph2024_signature_coldzera_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_coldzera_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_coldzera_gold"
            	"sticker_material"		"cph2024/sig_coldzera_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"79720871"
            }
            "7827"
            {
            	"name"		"cph2024_signature_dumau_4"
            	"item_name"		"#StickerKit_cph2024_signature_dumau"
            	"description_string"		"#StickerKit_desc_cph2024_signature_dumau"
            	"sticker_material"		"cph2024/sig_dumau"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"234059589"
            }
            "7828"
            {
            	"name"		"cph2024_signature_dumau_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_dumau_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_dumau_glitter"
            	"sticker_material"		"cph2024/sig_dumau_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"234059589"
            }
            "7829"
            {
            	"name"		"cph2024_signature_dumau_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_dumau_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_dumau_holo"
            	"sticker_material"		"cph2024/sig_dumau_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"234059589"
            }
            "7830"
            {
            	"name"		"cph2024_signature_dumau_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_dumau_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_dumau_gold"
            	"sticker_material"		"cph2024/sig_dumau_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"234059589"
            }
            "7831"
            {
            	"name"		"cph2024_signature_latto_4"
            	"item_name"		"#StickerKit_cph2024_signature_latto"
            	"description_string"		"#StickerKit_desc_cph2024_signature_latto"
            	"sticker_material"		"cph2024/sig_latto"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"889754458"
            }
            "7832"
            {
            	"name"		"cph2024_signature_latto_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_latto_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_latto_glitter"
            	"sticker_material"		"cph2024/sig_latto_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"889754458"
            }
            "7833"
            {
            	"name"		"cph2024_signature_latto_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_latto_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_latto_holo"
            	"sticker_material"		"cph2024/sig_latto_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"889754458"
            }
            "7834"
            {
            	"name"		"cph2024_signature_latto_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_latto_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_latto_gold"
            	"sticker_material"		"cph2024/sig_latto_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"889754458"
            }
            "7835"
            {
            	"name"		"cph2024_signature_nekiz_4"
            	"item_name"		"#StickerKit_cph2024_signature_nekiz"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nekiz"
            	"sticker_material"		"cph2024/sig_nekiz"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"76618432"
            }
            "7836"
            {
            	"name"		"cph2024_signature_nekiz_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_nekiz_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nekiz_glitter"
            	"sticker_material"		"cph2024/sig_nekiz_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"76618432"
            }
            "7837"
            {
            	"name"		"cph2024_signature_nekiz_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_nekiz_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nekiz_holo"
            	"sticker_material"		"cph2024/sig_nekiz_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"76618432"
            }
            "7838"
            {
            	"name"		"cph2024_signature_nekiz_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_nekiz_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_nekiz_gold"
            	"sticker_material"		"cph2024/sig_nekiz_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"126"
            	"tournament_player_id"		"76618432"
            }
            "7839"
            {
            	"name"		"cph2024_signature_emiliaqaq_4"
            	"item_name"		"#StickerKit_cph2024_signature_emiliaqaq"
            	"description_string"		"#StickerKit_desc_cph2024_signature_emiliaqaq"
            	"sticker_material"		"cph2024/sig_emiliaqaq"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"856465673"
            }
            "7840"
            {
            	"name"		"cph2024_signature_emiliaqaq_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_emiliaqaq_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_emiliaqaq_glitter"
            	"sticker_material"		"cph2024/sig_emiliaqaq_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"856465673"
            }
            "7841"
            {
            	"name"		"cph2024_signature_emiliaqaq_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_emiliaqaq_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_emiliaqaq_holo"
            	"sticker_material"		"cph2024/sig_emiliaqaq_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"856465673"
            }
            "7842"
            {
            	"name"		"cph2024_signature_emiliaqaq_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_emiliaqaq_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_emiliaqaq_gold"
            	"sticker_material"		"cph2024/sig_emiliaqaq_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"856465673"
            }
            "7843"
            {
            	"name"		"cph2024_signature_jee_4"
            	"item_name"		"#StickerKit_cph2024_signature_jee"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jee"
            	"sticker_material"		"cph2024/sig_jee"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"400141913"
            }
            "7844"
            {
            	"name"		"cph2024_signature_jee_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_jee_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jee_glitter"
            	"sticker_material"		"cph2024/sig_jee_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"400141913"
            }
            "7845"
            {
            	"name"		"cph2024_signature_jee_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_jee_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jee_holo"
            	"sticker_material"		"cph2024/sig_jee_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"400141913"
            }
            "7846"
            {
            	"name"		"cph2024_signature_jee_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_jee_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_jee_gold"
            	"sticker_material"		"cph2024/sig_jee_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"400141913"
            }
            "7847"
            {
            	"name"		"cph2024_signature_starry_4"
            	"item_name"		"#StickerKit_cph2024_signature_starry"
            	"description_string"		"#StickerKit_desc_cph2024_signature_starry"
            	"sticker_material"		"cph2024/sig_starry"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"920033815"
            }
            "7848"
            {
            	"name"		"cph2024_signature_starry_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_starry_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_starry_glitter"
            	"sticker_material"		"cph2024/sig_starry_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"920033815"
            }
            "7849"
            {
            	"name"		"cph2024_signature_starry_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_starry_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_starry_holo"
            	"sticker_material"		"cph2024/sig_starry_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"920033815"
            }
            "7850"
            {
            	"name"		"cph2024_signature_starry_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_starry_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_starry_gold"
            	"sticker_material"		"cph2024/sig_starry_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"920033815"
            }
            "7851"
            {
            	"name"		"cph2024_signature_westmelon_4"
            	"item_name"		"#StickerKit_cph2024_signature_westmelon"
            	"description_string"		"#StickerKit_desc_cph2024_signature_westmelon"
            	"sticker_material"		"cph2024/sig_westmelon"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"146974312"
            }
            "7852"
            {
            	"name"		"cph2024_signature_westmelon_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_westmelon_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_westmelon_glitter"
            	"sticker_material"		"cph2024/sig_westmelon_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"146974312"
            }
            "7853"
            {
            	"name"		"cph2024_signature_westmelon_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_westmelon_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_westmelon_holo"
            	"sticker_material"		"cph2024/sig_westmelon_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"146974312"
            }
            "7854"
            {
            	"name"		"cph2024_signature_westmelon_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_westmelon_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_westmelon_gold"
            	"sticker_material"		"cph2024/sig_westmelon_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"146974312"
            }
            "7855"
            {
            	"name"		"cph2024_signature_z4kr_4"
            	"item_name"		"#StickerKit_cph2024_signature_z4kr"
            	"description_string"		"#StickerKit_desc_cph2024_signature_z4kr"
            	"sticker_material"		"cph2024/sig_z4kr"
            	"item_rarity"		"rare"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"177517735"
            }
            "7856"
            {
            	"name"		"cph2024_signature_z4kr_4_glitter"
            	"item_name"		"#StickerKit_cph2024_signature_z4kr_glitter"
            	"description_string"		"#StickerKit_desc_cph2024_signature_z4kr_glitter"
            	"sticker_material"		"cph2024/sig_z4kr_glitter"
            	"item_rarity"		"mythical"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"177517735"
            }
            "7857"
            {
            	"name"		"cph2024_signature_z4kr_4_holo"
            	"item_name"		"#StickerKit_cph2024_signature_z4kr_holo"
            	"description_string"		"#StickerKit_desc_cph2024_signature_z4kr_holo"
            	"sticker_material"		"cph2024/sig_z4kr_holo"
            	"item_rarity"		"legendary"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"177517735"
            }
            "7858"
            {
            	"name"		"cph2024_signature_z4kr_4_gold"
            	"item_name"		"#StickerKit_cph2024_signature_z4kr_gold"
            	"description_string"		"#StickerKit_desc_cph2024_signature_z4kr_gold"
            	"sticker_material"		"cph2024/sig_z4kr_gold"
            	"item_rarity"		"ancient"
            	"tournament_event_id"		"22"
            	"tournament_team_id"		"127"
            	"tournament_player_id"		"177517735"
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
            else if (name.Contains("(Gold)"))
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

        string json = JsonSerializer.Serialize(stickers, options);

        string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "copenhagen2024.json");

        await File.WriteAllTextAsync(filename, json);
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