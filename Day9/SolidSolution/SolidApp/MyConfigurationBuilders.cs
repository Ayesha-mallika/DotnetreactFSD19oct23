namespace SolidApp
{

    public class MyConfigurationBuilder
    {
        class MyConfiguration : MyApplicationConfiguration
        {

        }
        public MyApplicationConfiguration BuildConfiguration(int size, string name)
        {
            var obj = new MyConfiguration();
            obj.Size = size;
            obj.Label = name;
            return obj;
        }
    }
}