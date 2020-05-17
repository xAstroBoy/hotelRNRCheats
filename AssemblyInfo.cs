using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: AssemblyTitle(Hotel_RNR_Cheats.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(Hotel_RNR_Cheats.BuildInfo.Company)]
[assembly: AssemblyProduct(Hotel_RNR_Cheats.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + Hotel_RNR_Cheats.BuildInfo.Author)]
[assembly: AssemblyTrademark(Hotel_RNR_Cheats.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(Hotel_RNR_Cheats.BuildInfo.Version)]
[assembly: AssemblyFileVersion(Hotel_RNR_Cheats.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonModInfo(typeof(Hotel_RNR_Cheats.HotelRnRCheats), Hotel_RNR_Cheats.BuildInfo.Name, Hotel_RNR_Cheats.BuildInfo.Version, Hotel_RNR_Cheats.BuildInfo.Author, Hotel_RNR_Cheats.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonModGame(null, null)]