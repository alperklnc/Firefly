using UnityEngine;

namespace Utils
{
    public static class ScreenCalculator {
        public static float Left { get; private set; }
        public static float Right { get; private set; }
        public static float Top { get; private set; }
        public static float Bottom { get; private set; }

        public static void Init() {
            float screenZAxis = -Camera.main.transform.position.z;

            Vector3 bottomLeftScreen = new Vector3(0, 0, screenZAxis);
            Vector3 topRightScreen = new Vector3(Screen.width, Screen.height, screenZAxis);

            Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(bottomLeftScreen);
            Vector3 topRight = Camera.main.ScreenToWorldPoint(topRightScreen);

            Left = bottomLeft.x;
            Right = topRight.x;
            Top = topRight.y;
            Bottom = bottomLeft.y;
        }
    }
}
