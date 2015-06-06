namespace DictionaryToExpandoObject.UnitTests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public class When_convert_a_simple_object_to_ExpandoObject
    {
        [Fact]
        public void It_should_match_expected_object()
        {
            var expected = new Dictionary<string, object>
            {
                ["name"] = "John Smith",
                ["age"] = 21
            };
            var actual = expected.ToExpando();

            actual.ShouldBeEquivalentTo(expected);
        }
    }

    public class When_convert_a_complex_object_to_ExpandoObject
    {
        Dictionary<string, object> expected;

        public When_convert_a_complex_object_to_ExpandoObject()
        {
            expected = new Dictionary<string, object>
            {
                ["name"] = "John Smith",
                ["age"] = 21,
                ["address"] = new Dictionary<string, object>
                {
                    ["address1"] = "End of the world",
                    ["city"] = "Nowheresvile"
                },
                ["email"] = new Dictionary<string, object>
                {
                    ["value"] = "test@test.com",
                    ["last_five_subjects"] = new List<object> { "FW: Documents you wanted", "Documents you wanted" }
                }
            };
        }

        [Fact]
        public void It_should_match_expected_object()
        {
            var actual = expected.ToExpando();

            actual.ShouldBeEquivalentTo(expected);
        }

        [Fact]
        public void It_should_have_name_accessor()
        {
            dynamic actual = expected.ToExpando();

            string name = actual.name;
            name.Should().Be("John Smith");
        }

        [Fact]
        public void It_should_have_address_accessor()
        {
            dynamic actual = expected.ToExpando();

            string address1 = actual.address.address1;
            address1.Should().Be("End of the world");
        }


        [Fact]
        public void It_should_have_email_accessor()
        {
            dynamic actual = expected.ToExpando();

            IEnumerable<object> subjects = actual.email.last_five_subjects;
            subjects.Should().Contain(new[] {"FW: Documents you wanted", "Documents you wanted"});
        }
    }
}
