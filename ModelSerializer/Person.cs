namespace ModelSerializer
{
    public class Person
    {
        public string _first_name, _last_name;
        public object _father;
        public Person(string first_name, string last_name, object father)
        {
            this._first_name = first_name;
            this._last_name = last_name;
            this._father = father;
        }
    }

}