namespace ECS
{
    public class FakeTempSensor : ISensor
    {
        private int _testTemp = 0;

        public int GetSensorData() => GetTemp();

        public void SetTestTemp(int temp)
        {
            _testTemp = temp;
        }

        public int GetTemp()
        {
            return _testTemp;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}