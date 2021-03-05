
public interface IMobileUnit
{
    bool MoveForwardFlag { get; set; }

    bool MoveBackFlag { get;  set; }

    bool MoveStopFlag { get; set; }

    void MoveForward();
    void MoveBack();
    void Stop();
}
