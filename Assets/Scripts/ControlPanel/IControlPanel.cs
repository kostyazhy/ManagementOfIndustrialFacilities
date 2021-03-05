public interface IControlPanel
{
    void MoveTower(bool active, TypeSwitch.Type type);
    void MoveWindlass(bool active, TypeSwitch.Type type);
    void ActiveMagnet(bool active, TypeSwitch.Type type);
}
