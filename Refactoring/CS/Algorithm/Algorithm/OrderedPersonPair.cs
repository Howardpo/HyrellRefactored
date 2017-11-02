using System;

namespace Algorithm
{
    /// <summary>
    /// Pair of Persons and the distance between their birthdays
    /// </summary>
    public class OrderedPersonPair : IComparable<OrderedPersonPair>
    {
        private TimeSpan _DistanceBetweenBirthdays;

        public Person YoungerPerson { get; set; }
        public Person OlderPerson { get; set; }
        public TimeSpan DistanceBetweenBirthdays {
            get
            {
                if (_DistanceBetweenBirthdays == default(TimeSpan)
                    && YoungerPerson != default(Person)
                    && OlderPerson != default(Person)
                    )
                {
                    _DistanceBetweenBirthdays = OlderPerson.BirthDate - YoungerPerson.BirthDate;
                }
                return _DistanceBetweenBirthdays;
            }
        }

        public OrderedPersonPair() { }

        /// <summary>
        /// Sort people as the object is created
        /// </summary>
        /// <param name="Person1"></param>
        /// <param name="Person2"></param>
        public OrderedPersonPair(Person Person1, Person Person2)
        {
            if (Person1.BirthDate < Person2.BirthDate)
            {
                YoungerPerson = Person1;
                OlderPerson = Person2;
            } else
            {
                YoungerPerson = Person2;
                OlderPerson = Person1;
            }
        }

        /// <summary>Allow user to sort a list of OrderedPersons by distance between birthdays
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(OrderedPersonPair other)
        {
            int result = 0;

            if (other != null)
            {
                if (DistanceBetweenBirthdays < other.DistanceBetweenBirthdays)
                {
                    // this is first
                    result = -1;
                }
                else if (DistanceBetweenBirthdays == other.DistanceBetweenBirthdays)
                {
                    // equal
                    result = 0;
                }
                else
                {
                    // other is first
                    result = 1;
                }
            }

            return result;
        }
    }
}