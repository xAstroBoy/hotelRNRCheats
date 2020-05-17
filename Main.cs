using System;
using System.Threading;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Threading.Tasks;
using MelonLoader;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;

namespace Hotel_RNR_Cheats
{
	public static class BuildInfo
	{
		public const string Name = "HotelRNR Cheats"; // Name of the Mod.  (MUST BE SET)
		public const string Author = "marcocorriero"; // Author of the Mod.  (Set as null if none)
		public const string Company = null; // Company that made the Mod.  (Set as null if none)
		public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
		public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
	}

	public class HotelRnRCheats : MelonMod
	{
		public bool isActive = true;
		public bool CommandsShown = false;

		private bool HeadsetColliderPatch = false;
		private bool isGodMode = false;
		private bool GenerateSafeKey = false;


		private PlayerData pdata;

		private HeadsetCollider VrCollider;
		private ArmSwinger armsw;


		private RNRPlayer player;
		private RNRHand playerhand;
		private RNRHead playerhead;
		private Safe safegen;

		public override void OnApplicationStart()
		{
			MelonModLogger.Log(": HotelRNR Cheats Started");
			MelonModLogger.Log(": Press [Numpad 1] to toggle keybinds.");
		}


		public override void OnUpdate()
		{
			if (Input.GetKeyDown(KeyCode.Keypad1))
			{
				isActive = !isActive;
				if (isActive)
				{
					CommandsShown = false;
				}
				else
				{ 
					MelonModLogger.Log(": Keybinds disabled");
				}
			}

			if ((Time.time - LastTimeCheck2 > 25))
			{
				if (safegen == null)
				{
					if (safegen == null)
					{
						if (Resources.FindObjectsOfTypeAll(Il2CppTypeOf<Safe>.Type).Length != 0)
						{
							safegen = Resources.FindObjectsOfTypeAll(Il2CppTypeOf<Safe>.Type)[0].Cast<Safe>();
							if (safegen != null)
							{
								DebugLog("Found Safe Instance!");
							}
						}
					}
				}

				if (playerhead == null)
				{
					if (Resources.FindObjectsOfTypeAll(Il2CppTypeOf<RNRHead>.Type).Length != 0)
					{
						playerhead = Resources.FindObjectsOfTypeAll(Il2CppTypeOf<RNRHead>.Type)[0].Cast<RNRHead>();
						if (playerhead != null)
						{
							DebugLog("Found RNRHead Instance!");
						}
					}
				}


				if (playerhand == null)
				{
					if (Resources.FindObjectsOfTypeAll(Il2CppTypeOf<RNRHand>.Type).Length != 0)
					{
						playerhand = Resources.FindObjectsOfTypeAll(Il2CppTypeOf<RNRHand>.Type)[0].Cast<RNRHand>();
						if (playerhand != null)
						{
							DebugLog("Found RNRHand Instance!");
						}
					}
				}

				if (VrCollider == null)
				{
					if (Resources.FindObjectsOfTypeAll(Il2CppTypeOf<HeadsetCollider>.Type).Length != 0)
					{
						VrCollider = Resources.FindObjectsOfTypeAll(Il2CppTypeOf<HeadsetCollider>.Type)[0].Cast<HeadsetCollider>();
						if (VrCollider != null)
						{
							DebugLog("Found HeadsetCollider Instance!");
						}
					}
				}


				if (armsw == null)
				{
					if (Resources.FindObjectsOfTypeAll(Il2CppTypeOf<ArmSwinger>.Type).Length != 0)
					{
						armsw = Resources.FindObjectsOfTypeAll(Il2CppTypeOf<ArmSwinger>.Type)[0].Cast<ArmSwinger>();
						if (armsw != null)
						{
							DebugLog("Found ArmSwinger Instance!");
						}
					}
				}

				if (player == null)
				{
					if (Resources.FindObjectsOfTypeAll(Il2CppTypeOf<RNRPlayer>.Type).Length != 0)
					{
						player = Resources.FindObjectsOfTypeAll(Il2CppTypeOf<RNRPlayer>.Type)[0].Cast<RNRPlayer>();
						if (player != null)
						{
							DebugLog("Found RNRPlayer Instance!");
						}
					}
				}

				if (pdata == null)
				{
					if (Resources.FindObjectsOfTypeAll(Il2CppTypeOf<PlayerData>.Type).Length != 0)
					{
						pdata = Resources.FindObjectsOfTypeAll(Il2CppTypeOf<PlayerData>.Type)[0].Cast<PlayerData>();
						if (pdata != null)
						{
							DebugLog("Found PlayerData Instance!");
						}
					}
				}
				LastTimeCheck2 = Time.time;
			}
			if (!isActive)
				return;


			if(!CommandsShown)
			{
				MelonModLogger.Log(": Keybinds enabled");
				MelonModLogger.Log("D To Show Debug stuff!");
				MelonModLogger.Log("B To Kill all Headset Bounds!");
				MelonModLogger.Log("C To Unlock Everything!");
				MelonModLogger.Log("S To generate a Safe Code!");
				MelonModLogger.Log("G To Enable GOD Mode!");

				CommandsShown = true;
			}

			if (Input.GetKeyDown(KeyCode.S))
			{
				MelonModLogger.Log(": Generating Safe Code....");
				StartSafeGenerator();
			}


			if (Input.GetKeyDown(KeyCode.G))
			{
				isGodMode = !isGodMode;
				if (isGodMode)
				{
					MelonModLogger.Log(": God Mode Enabled");
					StartGodModeThread();
				}
				else
				{
					MelonModLogger.Log(": God Mode Disabled");
				}
			}

			if (Input.GetKeyDown(KeyCode.B))
			{
				HeadsetColliderPatch = !HeadsetColliderPatch;
				if (HeadsetColliderPatch)
				{
					MelonModLogger.Log(": Headset Bounds are Disabled!");
					StartRemoveHeadsetBounds();
				}
				else
				{
					MelonModLogger.Log(": Headset Bounds are Enabled!");
				}
			}


			if (Input.GetKeyDown(KeyCode.C))
			{
				UnlockAll();
				MelonModLogger.Log(": Unlocking Everything...");
			}

			if (Input.GetKeyDown(KeyCode.D))
			{
				isDebugMode = !isDebugMode;
				if (isDebugMode)
				{
					MelonModLogger.Log(": Debug Info enabled");
				}
				else
				{
					MelonModLogger.Log(": Debug Info disabled");
				}
			}

		}


		private void StartGodModeThread()
		{
			new Thread(() =>
			{
				Thread.CurrentThread.IsBackground = true;
				do
				{
					try
					{
						Thread.Sleep(1500);
						PlayerGod();
					}
					catch (Exception)
					{
					}
				} while (isGodMode);
			}).Start();
		}


		private void StartSafeGenerator()
		{
			new Thread(() =>
			{
				Thread.CurrentThread.IsBackground = true;
					try
					{
						Thread.Sleep(1500);
						GenerateSafeCode();
					}
					catch (Exception)
					{
					}
			}).Start();
		}

		private void StartRemoveHeadsetBounds()
		{
			new Thread(() =>
			{
				Thread.CurrentThread.IsBackground = true;
				do
				{
					try
					{
						Thread.Sleep(1500);
						KillAllHeadsetBounds();
					}
					catch (Exception)
					{
					}
				} while (HeadsetColliderPatch);
			}).Start();
		}

		private void GenerateSafeCode()
		{
			if (pdata != null)
			{
				pdata.GenerateNewSafeCode();
				MelonModLogger.Log("The new Safe Code is : " + pdata.currentSafeCode);
			}

		}

		private void PlayerGod()
		{

			if (player != null)
			{
				player.CancelDeath(true);
				if (player._damageState != RNRPlayer.DamageState.NONE)
				{
					player._damageState = RNRPlayer.DamageState.NONE;
					DebugLog("Setting player damageState to NONE");
				}

			}

			if (playerhand != null)
			{
				if (playerhand._damageState != RNRPlayer.DamageState.NONE)
				{
					playerhand._damageState = RNRPlayer.DamageState.NONE;
					DebugLog("Setting Player Hand damageState to NONE");
				}
				if (playerhand.Damage != 0)
				{
					playerhand.Damage = 0;
				}
			}

			if (playerhead != null)
			{
				if (playerhead._damageState != RNRPlayer.DamageState.NONE)
				{
					playerhead._damageState = RNRPlayer.DamageState.NONE;
					DebugLog("Setting Player Head damageState to NONE");
				}
			}

		}
		private void KillAllHeadsetBounds()
		{
			if(VrCollider != null)
			{
				if (VrCollider.enabled)
				{
					DebugLog("Deactivating HeadsetCollider");
					VrCollider.enabled = false;
				}
				if(VrCollider.armSwinger.headsetCollider.enabled)
				{
					DebugLog("Deactivating armSwinger Headset Collider");
					VrCollider.armSwinger.headsetCollider.enabled= false;
				}
				DebugLog("Removing HeadsetCollider");
				UnityEngine.Object.DestroyImmediate(VrCollider);

			}

			if (armsw != null)
			{
				if(armsw.pushBackOverride)
				{
					armsw.pushBackOverride = false;
					DebugLog("Deactivating armSwinger pushBackOverride");

				}
				if (armsw.preventWallClip)
				{
					armsw.preventWallClip = false;
					DebugLog("Deactivating armSwinger preventWallClip");

				}
				if (armsw.preventClimbing)
				{
					armsw.preventClimbing = false;
					DebugLog("Deactivating armSwinger preventClimbing");
				}
				if (armsw.preventWallWalking)
				{
					armsw.preventWallWalking = false;
					DebugLog("Deactivating armSwinger preventWallWalking");
				}
				if (!armsw._preventionsPaused)
				{
					armsw._preventionsPaused = true;
					DebugLog("Deactivating armSwinger Preventions");
				}
				if (!armsw.preventionsPaused)
				{
					armsw.preventionsPaused = true;
					DebugLog("Deactivating armSwinger Preventions");
				}
				armsw.PausePreventions(true);
				DebugLog("Deactivating armSwinger");

			}
		}

		private void UnlockAll()
		{
			if(pdata != null)
			{

				pdata.infamy = int.MaxValue;
				DebugLog("Infamy has been set to max!");
				pdata.cash = float.MaxValue;
				DebugLog("cash has been set to max!");

				pdata.Hotel5Unlocked = true;
				pdata.Hotel3Unlocked = true;
				pdata.Hotel2Unlocked = true;
				pdata.Hotel4Unlocked = true;
				pdata.storeUnlocked = true;
				pdata.hotel5Unlocked = true;
				pdata.hotel4Unlocked = true;
				pdata.hotel3Unlocked = true;
				pdata.hotel2Unlocked = true;
				DebugLog("All Hotels and Store should be unlocked!");

			}
		}
		

		private void FindInstances()
		{

		}

		private void DebugLog(string text)
		{
			if(isDebugMode)
			{
				MelonModLogger.Log(text);
			}
		}


		private bool isDebugMode = true;
		private float LastTimeCheck = 0;
		private float LastTimeCheck2 = 0;
	}
}