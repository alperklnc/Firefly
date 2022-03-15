namespace Objects
{
    public class MiniLight : OncomingObject
    {
        public void DestroyMiniLight()
        {
            gameObject.SetActive(false);
        }
    }
}