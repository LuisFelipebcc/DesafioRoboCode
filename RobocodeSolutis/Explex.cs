using Robocode;
using System.Drawing;

namespace RobocodeSolutis.LuisFelipe
{
    public class Explex : AdvancedRobot
    {
        // O método principal do robô que contém as lógicas do robô 
        override public void Run()
        {
            SetColors(Color.Black, Color.Red, Color.Green);

            while (true)
            {
                SetAhead(100);
                SetTurnRight(360);
                SetBack(50);
                SetTurnGunRight(360);
                Execute();
            }
        }

        // Manipulador de eventos do robô, quando o robô vê outro robô
        override public void OnScannedRobot(ScannedRobotEvent e)
        {
            double angulo = e.Bearing;
            double distancia = e.Distance;

            if (e.Velocity == 0)
            {
                Fire(Rules.MAX_BULLET_POWER);
            }

            if (distancia < 50)
            {
                SetTurnGunRight(angulo);
                Fire(3);
                Execute();
            }

            Fire(1);
        }

        // O que fazer quando você for atingido por uma munição
        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            SetBack(30);
            SetAhead(20);
            Execute();
        }

        //O que fazer quando você atingir uma parede
        public override void OnHitWall(HitWallEvent e)
        {
            Back(30);
            Ahead(20);
        }
        //Este método é chamado quando seu robô colide com outro robô
        public override void OnHitRobot(HitRobotEvent inimigo)
        {
            SetTurnRight(inimigo.Bearing);
            Fire(3);
            Execute();
        }
    }
}
