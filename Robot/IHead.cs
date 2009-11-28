namespace Robot
{
    public interface IHead
    {
        double Yaw { get; }
        double Pitch { get; }
        MovmentComandAX12[] GetMovements();
        void SetPosition(double yaw, double pitch, double roll);
    }
}