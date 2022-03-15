using UnityEngine;
using UnityEngine.Advertisements;

namespace Managers
{
    public class AdManager : MonoBehaviour
    {
        static string placementID = "rewardedVideo";

        static string gameIDPlayStore = "3984031";
        static string gameIDAppStore = "3984030";

        bool testMode = false;

        private void Start()
        {
            Advertisement.Initialize(gameIDPlayStore, testMode);
        }
        
        public static void Show()
        {
            if (Advertisement.IsReady(placementID))
                Advertisement.Show(placementID);
        }
    }
}