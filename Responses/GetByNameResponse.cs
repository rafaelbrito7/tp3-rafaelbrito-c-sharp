using Model;
using System.Collections.Generic;

namespace Responses
{
    public class GetByNameResponse
    {
        public bool Status {get; set;}
        public List<Person> People {get; set;}
        public string Message {get; set;}
    }
}
