namespace ECS
{
    public class ECS
    {
        private int _threshold;
        private readonly ISensor _tempSensor;
        private readonly IHeater _heater;

        public ECS(int thr, ISensor sensor, IHeater heater)
        {
            SetThreshold(thr);
            _tempSensor = sensor;
            _heater = heater;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetSensorData();
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();

        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetSensorData();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
