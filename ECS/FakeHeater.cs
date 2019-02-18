namespace ECS
{
    public class FakeHeater : IHeater
    {
        private bool _testHeaterIsOn = false;

        public bool GetTestHeaterIsOnBool()
        {
            return _testHeaterIsOn;
        }

        public void TurnOn()
        {
            _testHeaterIsOn = true;
        }

        public void TurnOff()
        {
            _testHeaterIsOn = false;
        }

        public bool RunSelfTest()
        {

            return true;
        }

    }
}