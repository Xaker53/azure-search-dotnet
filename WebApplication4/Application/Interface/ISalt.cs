namespace Application.Interface
{
    public interface ISalt: IStrategyMarker
    {
        public string Generate();
    }
}