public class Clicker2 : Clickers
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(PlayerManager.Instance.AutoIncom2());
    }
}