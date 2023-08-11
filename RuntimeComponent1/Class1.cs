namespace RuntimeComponent1
{
    public sealed class Class1
    {
        public int MyInt { get; set; }

        //creating a windows runtime component
        public static string GetString()
        {
            return "My String";

            //RuntimeComponent1.Class1.MyInt
        }
    }
}