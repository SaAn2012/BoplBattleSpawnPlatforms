using BepInEx;
using UnityEngine;
using UnityEngine.InputSystem;
using PlatformApi;
using BoplFixedMath;

namespace MyFirstBoplPlugin
{
    [BepInPlugin("com.SashaAnt.SpawnPlatforms", "SpawnPlatforms", "1.0.0")]

    public class Plugin : BaseUnityPlugin
        
    {

        private void Awake() => Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!"); GameObject uiTextObject = new GameObject("MyText");

        private void Update()
        {
            if (Keyboard.current[Key.E].wasPressedThisFrame)
            {
                Vector2 mousePos = Mouse.current.position.ReadValue();
                if (mousePos.x >= 0 && mousePos.x <= Screen.width && mousePos.y >= 0 && mousePos.y <= Screen.height)
                    SpawnPlatform(mousePos);
            }
            if (Keyboard.current[Key.Q].wasPressedThisFrame)
            {
                Vector2 mousePos = Mouse.current.position.ReadValue();
                if (mousePos.x >= 0 && mousePos.x <= Screen.width && mousePos.y >= 0 && mousePos.y <= Screen.height)
                    SpawnBoulder(mousePos);
            }
        }

        private void SpawnPlatform(Vector2 mousePos)
        {
            try
            {
                Vector3 worldPos = Camera.current.ScreenToWorldPoint(mousePos);
                worldPos.z = 0;
                Vector3 localPos = GameObject.Find("PlayerList").transform.InverseTransformPoint(worldPos);
                Debug.Log("Spawned a platform");
                PlatformApi.PlatformApi.SpawnPlatform((Fix)localPos.x, (Fix)localPos.y, (Fix)2, (Fix)2, (Fix)2, (Fix)1.5708f, 0.05);
                
            }
            catch
            {
                
            }
        }
        private void SpawnBoulder(Vector2 mousePos)
        {
            try
            {
                Vector3 worldPos = Camera.current.ScreenToWorldPoint(mousePos);
                worldPos.z = 0;
                Vector3 localPos = GameObject.Find("PlayerList").transform.InverseTransformPoint(worldPos);
                Vec2 vec2;
                vec2.y = (Fix)localPos.y;
                vec2.x = (Fix)localPos.x;

                Debug.Log("Spawned a boulder");
                PlatformApi.PlatformApi.SpawnBoulder(vec2, (Fix)1, PlatformType.slime, Color.cyan);
            }
            catch
            {

            }
        }
        public static class PluginInfo
        {
            public const string PLUGIN_GUID = "SpawnPlatforms";

            public const string PLUGIN_NAME = "SpawnPlatforms";

            public const string PLUGIN_VERSION = "1.0.0";
        }
    }
}
