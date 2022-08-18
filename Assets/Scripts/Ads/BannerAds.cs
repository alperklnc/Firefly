using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class BannerAds : MonoBehaviour {

        string placementID = "banner";

        string gameIDPlayStore = "3984031";
        string gameIDAppStore = "3984030";

        bool testMode = false;

        /*
        IEnumerator Start() {
            Advertisement.Initialize(gameIDPlayStore, testMode);

            while(!Advertisement.IsReady(placementID))
                yield return null;

            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            Advertisement.Banner.Show(placementID);
        }
        */
    }
}
