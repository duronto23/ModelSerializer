using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelSerializer;

namespace ModelSerializerTests
{
    [TestClass()]
    public class SerializerTests
    {
        [TestMethod()]
        public void SerializedDataValidationTest()
        {
            var person_a = new Person("User", "1", "none");
            var person_b = new Person("User", "1", person_a);
            var a = new Dictionary<string, object>
            {
                {"key1", 1},
                {
                    "key2", new Dictionary<string, object>
                    {
                        {"key3", 1},
                        { "key4", new Dictionary<string, object>
                            {
                                {"key5", 4},
                                {"user", person_b }
                            }
                        }
                    }
                }
            };
            var serializer = new Serializer();
            var serializedData = serializer.GetSerializedData(a);
            Assert.IsInstanceOfType(serializedData, typeof(List<string>));
            Assert.AreEqual(12, serializedData.Count);
            Assert.AreEqual(2, serializedData.Count(s => s.Contains("father")));
        }
    }
}