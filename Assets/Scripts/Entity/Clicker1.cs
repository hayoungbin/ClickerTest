public class Clicker1 : Clickers
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(PlayerManager.Instance.AutoIncom());
    }
}
