using System.Drawing;

namespace Game_SyrovatskijIS
{
    /// <summary>Определяет столкновения двух объектов</summary>
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }

    }
}
