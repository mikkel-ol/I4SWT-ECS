using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    class Application
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            TempSensor tempSensor = new TempSensor();

            var ecs = new ECS(28, tempSensor, heater);

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate();
        }
    }
}
